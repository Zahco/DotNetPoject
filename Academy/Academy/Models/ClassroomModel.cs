﻿using Academy.Entities;
using Academy.Models;
using Academy.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Models
{
    public class ClassroomModel : IValidatableObject
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Le champ Titre est requis")]
        [StringLength(50, ErrorMessage = "Le nom de la classe doit être compris entre 1 et 50 charactères")]
        [DisplayName("Nom de la classe")]
        public string Title { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetEstablishments")]
        public Guid Establishment_Id { get; set; }

        [DisplayName("Etablissement")]
        public string Establishments { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetUsers")]
        public Guid UserId { get; set; }

        [DisplayName("Professeur")]
        public string User { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetYears")]
        public Guid YearId { get; set; }

        [DisplayName("Année")]
        public int Year { get; set; }

        [DisplayName("Etudiants")]
        public IEnumerable<ModelWithNameAndId> Students { get; set; }

        [DisplayName("Evaluations")]
        public IEnumerable<ModelWithNameAndId> Evaluations { get; set; }

        public static ClassroomModel ToModel(Classrooms classroom)
        {
            return new ClassroomModel
            {
                Id = classroom.Id,
                Title = classroom.Title,
                Establishment_Id = classroom.Establishment_Id,
                Establishments = classroom.Establishments.Name,
                UserId = classroom.User_Id,
                User = classroom.Users.FirstName + " " + classroom.Users.LastName,
                YearId = classroom.Year_Id,
                Year = classroom.Years.Year,
                Students = classroom.Pupils.Select(p => new ModelWithNameAndId
                {
                    Id = p.Id,
                    Name = p.FirstName + " " + p.LastName
                }),
                Evaluations = classroom.Evaluations.Select(e => new ModelWithNameAndId
                {
                    Id = e.Id,
                    Name = classroom.Title + " " + e.Date.ToShortDateString()
                }),
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var classroomRepository = new ClassroomRepository(new Entities.Entities());
            var classroom = classroomRepository.GetByTitle(Title);
            if (classroom.Any(c => c.Establishment_Id == Establishment_Id && c.Id != Id))
            {
                yield return new ValidationResult("Cette classe est déjà présente dans l'établissement", new[] { "Title", "Establishments" });
            }
        }
    }
}