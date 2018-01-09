using Academy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academy.WebModels
{
    public class AcademyModel
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
    }
}