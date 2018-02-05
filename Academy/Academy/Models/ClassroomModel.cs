using Academy.Entities;
using Academy.Models;
using Academy.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class ClassroomModel : IValidatableObject
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Titre de la salle")]
        public string Title { get; set; }

        public Guid Establishment_Id { get; set; }

        [DisplayName("Etablissement")]
        public virtual EstablishmentModel Establishments { get; set; }

        public static ClassroomModel ToModel(Classrooms classrooms)
        {
            return new ClassroomModel
            {
                Id = classrooms.Id,
                Title = classrooms.Title,
                Establishment_Id = classrooms.Establishment_Id
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