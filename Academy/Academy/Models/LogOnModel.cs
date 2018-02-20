using Academy.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class LogOnModel : IValidatableObject
    {
        [Required]
        [DisplayName("Nom d'utilisateur")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Mot de passe")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var userRepository = new UserRepository(new Entities.Entities());
            var user = userRepository.GetByUserNameAndPassword(UserName, Password);
            if (user == null)
            {
                yield return new ValidationResult("Votre username ou mot de passe est invalide", new[] { "Password" });
            }
        }
    }
}