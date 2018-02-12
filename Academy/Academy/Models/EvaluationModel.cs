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

        [Required]
        [DisplayName("Classe")]
        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetClassrooms")]
        public ModelWithNameAndId Classroom { get; set; }
        [Required]
        [DisplayName("Utilisateur")]
        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetUsers")]
        public ModelWithNameAndId User { get; set; }
        [Required]
        [DisplayName("Date")]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Total des points")]
        public int TotalPoint { get; set; }

        public static EvaluationModel ToModel(Evaluations evaluations)
        {
            return new EvaluationModel
            {
                Id = evaluations.Id,
                Classroom = new ModelWithNameAndId { Id = evaluations.Classrooms.Id, Name = evaluations.Classrooms.Title },
                Date = evaluations.Date,
                TotalPoint = evaluations.TotalPoint,
                User = new ModelWithNameAndId { Id = evaluations.Users.Id, Name = evaluations.Users.UserName }
            };
        }
    }
}