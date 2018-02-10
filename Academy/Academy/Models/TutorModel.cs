using Academy.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class TutorModel
    {
        public Guid Id { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Adresse")]
        public string Address { get; set; }

        [DisplayName("Code Postal")]
        public string PostCode { get; set; }

        [DisplayName("Ville")]
        public string Town { get; set; }

        [DisplayName("Téléphone")]
        public string Tel { get; set; }

        [DisplayName("Email")]
        public string Mail { get; set; }

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