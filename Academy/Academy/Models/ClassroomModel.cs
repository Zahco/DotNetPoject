using Academy.Entities;
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

        [Required]
        [StringLength(50)]
        [DisplayName("Titre de la salle")]
        public string Title { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetEstablishments")]
        public Guid Establishment_Id { get; set; }

        [DisplayName("Etablissement")]
        public string Establishments { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetUsers")]
        public Guid UserId { get; set; }

        [DisplayName("Utilisateur")]
        public string User { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetYears")]
        public Guid YearId { get; set; }

        [DisplayName("Année")]
        public int Year { get; set; }

        public IEnumerable<ModelWithNameAndId> Students { get; set; }

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
                })
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var classroomRepository = new ClassroomRepository(new Entities.Entities());
            var classroom = classroomRepository.GetByTitle(Title);
            if (classroom!= null && classroom.Id != Id)
            {
                yield return new ValidationResult("Ce titre est déjà utilisé", new[] { "Title" });
            }
        }
    }
}