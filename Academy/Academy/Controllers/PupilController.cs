using Academy.Entities;
using Academy.Models;
using Academy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Controllers
{
    public class PupilController : Controller
    {
        public PupilRepository PupilRepository { get; set; }

        public ClassroomRepository ClassroomRepository { get; set; }

        public LevelRepository LevelRepository { get; set; }

        public TutorRepository TutorRepository { get; set; }

        public PupilController()
        {
            var entities = new Entities.Entities();
            PupilRepository = new PupilRepository(entities);
            ClassroomRepository = new ClassroomRepository(entities);
            LevelRepository = new LevelRepository(entities);
            TutorRepository = new TutorRepository(entities);
        }

        public ActionResult GetAll()
        {
            var models = PupilRepository.All().Select(c => PupilModel.ToModel(c));
            return View(models);
        }

        public ActionResult Get(Guid id)
        {
            var model = PupilModel.ToModel(PupilRepository.GetById(id));
            return View(model);
        }

        public ActionResult AddOrUpdate(Guid? id)
        {
            var model = new PupilModel();
            if (id.HasValue)
            {
                model = PupilModel.ToModel(PupilRepository.GetById(id.Value));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(PupilModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isCreated = model.Id == Guid.Empty;
            var pupil = new Pupils();
            if (!isCreated)
            {
                pupil = PupilRepository.GetById(model.Id);
            }

            pupil.BirthdayDate = model.BirthdayDate;
            pupil.Classrooms = ClassroomRepository.GetById(pupil.Classroom_Id);
            pupil.Classroom_Id = model.ClassroomId;    
            pupil.FirstName = model.FirstName;
            pupil.LastName = model.LastName;
            pupil.Level_Id = model.LevelId;
            pupil.Levels = LevelRepository.GetById(pupil.Level_Id);
            pupil.Sex = (short)model.Sex;
            pupil.State = model.State;
            pupil.Tutor_Id = model.TutorId;
            pupil.Tutors = TutorRepository.GetById(pupil.Tutor_Id);

            if (isCreated)
            {
                PupilRepository.Add(pupil);
            }
            PupilRepository.Save();

            return Redirect(Url.Action("Get", "Pupil", new { id = pupil.Id }));
        }
    }
}
