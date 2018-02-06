using Academy.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Academy.Models
{
    public class PupilModel
    {
        public Guid Id { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Date de naissance")]
        public DateTime BirthdayDate { get; set; }

        [DisplayName("Sexe")]
        public short Sex { get; set; }

        [DisplayName("State")]
        public short State { get; set; }

        public Guid TutorId { get; set; }

        [DisplayName("Tuteur")]
        public string Tutor { get; set; }

        public Guid ClassroomId { get; set; }

        [DisplayName("Nom de la classe")]
        public string Classrooms { get; set; }

        public Guid LevelId { get; set; }

        [DisplayName("Niveau de scolarité")]
        public string Levels { get; set; }
        
        [DisplayName("Identité")]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public static PupilModel ToModel(Pupils pupil)
        {
            return new PupilModel
            {
                Id = pupil.Id,
                FirstName = pupil.FirstName,
                LastName = pupil.LastName,
                BirthdayDate = pupil.BirthdayDate,
                ClassroomId = pupil.Classroom_Id,
                Classrooms = pupil.Classrooms.Title,
                Levels = pupil.Levels.Title,
                LevelId = pupil.Level_Id,
                State = pupil.State,
                Tutor = pupil.Tutors.FirstName + " " + pupil.Tutors.LastName,
                TutorId = pupil.Tutor_Id,
                Sex = pupil.Sex
            };
        }
    }
}