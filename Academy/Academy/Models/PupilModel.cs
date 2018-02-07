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
    public class PupilModel
    {
        public Guid Id { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [UIHint("Date")]
        [DisplayName("Date de naissance")]
        public DateTime BirthdayDate { get; set; }

        [DisplayName("Sexe")]
        public Gender Sex { get; set; }

        [DisplayName("State")]
        public short State { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetTutors")]
        public Guid TutorId { get; set; }

        [DisplayName("Tuteur")]
        public string Tutor { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetClassrooms")]
        public Guid ClassroomId { get; set; }

        [DisplayName("Nom de la classe")]
        public string Classrooms { get; set; }

        [UIHint("SelectFor")]
        [AdditionalMetadata("method", "GetLevels")]
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
                Sex = (Gender) pupil.Sex
            };
        }
    }

    public enum Gender
    {
        MALE,
        FEMALE
    }
}