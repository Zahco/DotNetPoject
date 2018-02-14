using Academy.Entities;
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
    public class PeriodModel : IValidatableObject
    {

        public Guid Id { get; set; }
        [Required]
        [DisplayName("Date de début")]
        public DateTime Begin { get; set; }
        [Required]
        [DisplayName("Date de fin")]
        public DateTime End { get; set; }
        [DisplayName("Année")]
        public ModelWithNameAndId Year { get; set; }
        [UIHint("SelectFor")]
        [Required]
        [DisplayName("Année")]
        [AdditionalMetadata("method", "GetYears")]
        public Guid YearId { get; set; }

        public static PeriodModel ToModel(Periods period)
        {
            return new PeriodModel
            {
                Id = period.Id,
                Begin = period.Begin,
                End = period.End,
                Year = new ModelWithNameAndId { Id = period.Years.Id, Name = period.Years.Year.ToString() },
                YearId = period.Years.Id
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Begin >= End)
            {
                yield return new ValidationResult("Date fin supérieur à date de début", new string[] { "Begin", "End" });
            }

            var YearRepository = new YearRepository(new Entities.Entities());
            var year = YearRepository.GetById(YearId).Year;

            if (Begin.Year > year + 1 || Begin.Year < year || End.Year > year + 1 || End.Year < year)
            {
                yield return new ValidationResult("L'année selectionnée ne correspond pas aux dates précédements selectionnées", new string[] { "YearId" });
            }
        }
    }
}