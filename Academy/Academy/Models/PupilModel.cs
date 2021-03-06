﻿using Academy.Entities;
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

        [Required]
        [StringLength(50)]
        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nom")]
        public string LastName { get; set; }

        [UIHint("DateTime")]
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

        public IEnumerable<ResultListByPupil> Results { get; set; }

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
                Sex = (Gender)pupil.Sex,
                Results = pupil.Results.Select(r => new ResultListByPupil
                {
                    Evaluation = new ModelWithNameAndId { Id = r.Evaluations.Id, Name = r.Evaluations.Classrooms.Title + " - " + r.Evaluations.Date.ToShortDateString() },
                    Result = new ModelWithNameAndId { Id = r.Id, Name = r.Note.ToString() }
                })
            };
        }

        public class ResultListByPupil
        {
            public ModelWithNameAndId Result { get; set; }
            public ModelWithNameAndId Evaluation { get; set; }
        }
    }

    public enum Gender
    {
        MALE,
        FEMALE
    }
}