using Academy.Entities;
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
        //[Required]
        public string Academy { get; set; }

        [DisplayName("Adresse")]
        [Required]
        public string Address { get; set; }

        [DisplayName("Code postal")]
        [Required]
        public string PostCode { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetDirectors")]
        public Guid UserId { get; set; }

        //[Required]
        [DisplayName("Responsable")]
        public string Director { get; set; }

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
                Director = esta.Users.FirstName + " " + esta.Users.LastName
            };
        }
    }
}