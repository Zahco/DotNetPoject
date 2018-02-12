using Academy.Entities;
using Academy.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class AcademyModel : IValidatableObject
    {
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(50)]
        [DisplayName("Nom de l'académie")]
        public string Name { get; set; }

        [DisplayName("Nom de l'établissement")]
        public IEnumerable<ModelWithNameAndId> Establishments { get; set; }


        public static AcademyModel ToModel(Academies academies)
        {
            return new AcademyModel
            {
                Id = academies.Id,
                Name = academies.Name,
                Establishments = academies.Establishments.Select(e => new ModelWithNameAndId { Id = e.Id, Name = e.Name })
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var academyRepository = new AcademyRepository(new Entities.Entities());
            var academy = academyRepository.GetByName(Name);
            if (academy != null && academy.Id != Id)
            {
                yield return new ValidationResult("Ce nom est déjà utilisé", new[] { "Name" });
            }
        }
    }
}