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

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetEvaluations")]
        public Guid EvaluationId { get; set; } 
        
        [DisplayName("Evaluation")]
        public EvaluationModel Evaluation { get; set; }        

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetPupils")]
        public Guid PupilId { get; set; }

        [DisplayName("Elève")]
        public string Pupil { get; set; }

        [DisplayName("Note")]
        public double Note { get; set; }

        public static ResultModel ToModel(Results model)
        {
            return new ResultModel
            {
                Id = model.Id,
                EvaluationId = model.Evaluation_Id,
                Evaluation = EvaluationModel.ToModel(model.Evaluations),
                Note = model.Note,
                PupilId = model.Pupil_Id,
                Pupil = model.Pupils.FirstName + " " + model.Pupils.LastName,
            };
        }
   
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (0 < Note && Note <= 20)
            {
                yield return new ValidationResult("La note doit être comprise entre 0 et 20", new string[] { "Note" } );
            }
        }
    }
}