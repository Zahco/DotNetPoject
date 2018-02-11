using Academy.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class TutorModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nom")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Adresse")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Code Postal")]
        public string PostCode { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Ville")]
        public string Town { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Téléphone")]
        public string Tel { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Mail { get; set; }

        [StringLength(1000)]
        [DisplayName("Commentaire")]
        public string Comment { get; set; }

        [DisplayName("Elèves")]
        public IEnumerable<ModelWithNameAndId> Pupils { get; set; }

        [DisplayName("Identité")]
        public string FullName {  get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        [DisplayName("Adresse")]
        public string FullAddress
        {
            get
            {
                return Address + ", " + PostCode + " " + Town;
            }
        }

        public static TutorModel ToModel(Tutors tutors)
        {
            return new TutorModel
            {
                Id = tutors.Id,
                FirstName = tutors.FirstName,
                LastName = tutors.LastName,
                Address = tutors.Address,
                Comment = tutors.Comment,
                Mail = tutors.Mail,
                PostCode = tutors.PostCode,
                Tel = tutors.Tel,
                Town = tutors.Town,
                Pupils = tutors.Pupils.Select(p => new ModelWithNameAndId
                {
                    Id = p.Id,
                    Name = p.FirstName + " " + p.LastName
                })
            };
        }
    }
}