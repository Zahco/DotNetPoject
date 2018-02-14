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
    public class EvaluationModel
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
        public Guid PeriodId { get; set; }

        [Required]
        [UIHint("Date")]
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
            };
        }
    }
}