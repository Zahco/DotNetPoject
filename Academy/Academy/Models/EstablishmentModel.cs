﻿using Academy.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Models
{
    public class EstablishmentModel
    {
        public Guid Id { get; set; }

        [DisplayName("Nom")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Ville")]
        [Required]
        public string Town { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetAcademies")]
        public Guid AcademyId { get; set; }

        [DisplayName("Académie")]
        public string Academy { get; set; }

        [DisplayName("Adresse")]
        [Required]
        public string Address { get; set; }

        [DisplayName("Code postal")]
        [Required]
        public string PostCode { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetUsers")]
        public Guid UserId { get; set; }
        
        [DisplayName("Directeur")]
        public string User { get; set; }

        public IEnumerable<ModelWithNameAndId> Classrooms { get; set; }

        [DisplayName("Adresse")]
        public string FullAddress
        {
            get
            {
                return Address + ", " + PostCode + " " + Town;
            }
        }

        public static EstablishmentModel ToModel(Establishments esta)
        {
            return new EstablishmentModel
            {
                Id = esta.Id,
                Name = esta.Name,
                AcademyId = esta.Academies.Id,
                Academy = esta.Academies.Name,
                Address = esta.Address,
                PostCode = esta.PostCode,
                Town = esta.Town,
                UserId = esta.Users.Id,
                User = esta.Users.FirstName + " " + esta.Users.LastName,
                Classrooms = esta.Classrooms.Select(c => new ModelWithNameAndId
                {
                    Id = c.Id,
                    Name = c.Title
                })
            };
        }
    }
}