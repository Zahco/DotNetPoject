using Academy.Models;
using Academy.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academy.WebModels
{
    public class AcademyModel : IValidatableObject
    {
        public Guid Id { get; set; }
        [DisplayName("Nom de l'académie")]
        [Required]
        public string Name { get; set; }


        public static AcademyModel ToModel(Academies academies)
        {
            return new AcademyModel
            {
                Id = academies.Id,
                Name = academies.Name
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var academyRepository = new AcademyRepository(new Entities());
            var academy = academyRepository.GetByName(Name);
            if (academy != null && academy.Id != Id)
            {
                yield return new ValidationResult("Ce nom est déjà utilisé", new[] { "Name" });
            }
        }
    }
}