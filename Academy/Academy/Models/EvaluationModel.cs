using Academy.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Repositories;

namespace Academy.Models
{
    public class EvaluationModel : IValidatableObject
    {
        public Guid Id { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetClassrooms")]
        public Guid ClassroomId { get; set; }

        [DisplayName("Classe")]
        public string Classroom { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetUsers")]
        public Guid UserId { get; set; }

        [DisplayName("Utilisateur")]
        public string User { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetPeriods")]
        [DisplayName("Période")]
        public Guid PeriodId { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Total des points")]
        public int TotalPoint { get; set; }

        [DisplayName("Classe")]
        public ModelWithNameAndId ClassroomWithNameAndId { get; set; }

        [DisplayName("Professeur")]
        public ModelWithNameAndId UserWithNameAndId { get; set; }

        public static EvaluationModel ToModel(Evaluations evaluations)
        {
            return new EvaluationModel
            {
                Id = evaluations.Id,
                ClassroomId = evaluations.Classroom_Id,
                Classroom = evaluations.Classrooms.Title,
                Date = evaluations.Date,
                UserId = evaluations.User_Id,
                User = evaluations.Users.FirstName + " " + evaluations.Users.LastName,
                TotalPoint = evaluations.TotalPoint,
                ClassroomWithNameAndId = new ModelWithNameAndId
                {
                    Id = evaluations.Classrooms.Id,
                    Name = evaluations.Classrooms.Title
                },
                UserWithNameAndId = new ModelWithNameAndId
                {
                    Id = evaluations.Users.Id,
                    Name = evaluations.Users.FirstName + " " + evaluations.Users.LastName
                },
                PeriodId = evaluations.Period_Id
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var PeriodRepository = new PeriodRepository(new Entities.Entities());
            var period = PeriodRepository.GetById(PeriodId);
            if (Date < period.Begin || Date > period.End)
            {
                yield return new ValidationResult("La date doit être comprise dans la période", new string[] { "Date" });
            }
        }
    }
}