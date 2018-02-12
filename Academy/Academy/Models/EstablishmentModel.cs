using Academy.Entities;
using Academy.Helpers;
using Academy.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Academy.Models
{
    public class EstablishmentModel : IValidatableObject
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Nom")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Ville")]
        public string Town { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetAcademies")]
        public Guid AcademyId { get; set; }

        [DisplayName("Académie")]
        public string Academy { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Adresse")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Code postal")]
        [DataType(DataType.PostalCode)]
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var establishmentRepository = new EstablishmentRepository(new Entities.Entities());
            var establishment = establishmentRepository.GetByName(Name);
            if (establishment != null && establishment.Id != Id && establishment.Academies.Name != Academy)
            {
                yield return new ValidationResult("Cette établissement est déjà présent dans cette académie.", new[] { "Name" });
            }

            var isPostCode = ValidationHelper.IsValidPostCode(PostCode);
            if (!isPostCode)
            {
                yield return new ValidationResult("Le code postal ne possède pas le bon format", new[] { "PostCode" });
            }
        }
    }
}