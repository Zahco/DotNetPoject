using Academy.Models;
using Academy.Repositories;
using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace Academy.Controllers
{
    // All methods return IEnumerable<ModelWithNameAndId>
    public class ApiController : Controller
    {
        public AcademyRepository AcademyRepository { get; }

        public ClassroomRepository ClassroomRepository{ get; }

        public EstablishmentRepository EstablishmentRepository { get; }

        public LevelRepository LevelRepository { get; }

        public PeriodRepository PeriodRepository { get; }

        public UserRepository UserRepository { get; }

        public TutorRepository TutorRepository { get; }

        public YearRepository YearRepository { get; }

        public ApiController()
        {
            var entities = new Entities.Entities();
            AcademyRepository = new AcademyRepository(entities);
            ClassroomRepository = new ClassroomRepository(entities);
            EstablishmentRepository = new EstablishmentRepository(entities);
            LevelRepository = new LevelRepository(entities);
            PeriodRepository new PeriodRepository(entities);
            UserRepository = new UserRepository(entities);
            TutorRepository = new TutorRepository(entities);
            YearRepository = new YearRepository(entities);
        }
        
        public ActionResult GetAcademies()
        {
            var academies = AcademyRepository.All().Select(a => new ModelWithNameAndId
            { 
                Id = a.Id,
                Name = a.Name
            });
            return Json(academies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEstablishments()
        {
            var establishments = EstablishmentRepository.All().Select(e => new ModelWithNameAndId
            {
                Id = e.Id,
                Name = e.Name
            });
            return Json(establishments, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsers()
        {
            var users = UserRepository.All().Select(u => new ModelWithNameAndId
            {
                Id = u.Id,
                Name = u.FirstName + " " + u.LastName
            });
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetYears()
        {
            var years = YearRepository.All().OrderByDescending(y => y.Year).Select(y => new ModelWithNameAndId
            {
                Id = y.Id,
                Name = y.Year.ToString()
            });
            return Json(years, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetClassrooms()
        {
            var classrooms = ClassroomRepository.All().Select(c => new ModelWithNameAndId
            {
                Id = c.Id,
                Name = c.Title
            });
            return Json(classrooms, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTutors()
        {
            var tutors = TutorRepository.All().Select(t => new ModelWithNameAndId
            {
                Id = t.Id,
                Name = t.FirstName + " " + t.LastName
            });
            return Json(tutors, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLevels()
        {
            var levels = LevelRepository.All().OrderBy(l => l.Cycles.Title).ThenBy(l => l.Title).Select(l => new ModelWithNameAndId
            {
                Id = l.Id,
                Name = l.Title
            });
            return Json(levels, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPeriods()
        {
            var periods = PeriodRepository.All().Select(p => new ModelWithNameAndId
            {
                Id = p.Id,
                Name = p.Begin.Date + "-" + p.End.Date,
            });
            return Json(periods, JsonRequestBehavior.AllowGet);
    }
}
