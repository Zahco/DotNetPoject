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
    public class ResultModel : IValidatableObject
    {
        public Guid Id { get; set; }
        [DisplayName("Evaluation")]
        public ModelWithNameAndId Evaluation { get; set; }  

        [DisplayName("Elève")]
        public ModelWithNameAndId Pupil { get; set; }

        [DisplayName("Note")]
        public double Note { get; set; }

        public static ResultModel ToModel(Results model)
        {
            return new ResultModel
            {
                Id = model.Id,
                Evaluation = new ModelWithNameAndId { Id = model.Evaluations.Id, Name = model.Evaluations.Classrooms.Title + " - " + model.Evaluations.Date },
                Note = model.Note,
                Pupil = new ModelWithNameAndId { Id = model.Pupils.Id, Name = model.Pupils.FirstName + " " + model.Pupils.LastName },
            };
        }
   
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (0 > Note || Note > 20)
            {
                yield return new ValidationResult("La note doit être comprise entre 0 et 20", new string[] { "Note" } );
            }
        }
    }
}