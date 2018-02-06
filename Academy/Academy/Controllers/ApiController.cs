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

        public EstablishmentRepository EstablishmentRepository { get; }

        public UserRepository UserRepository { get; }

        public YearRepository YearRepository { get; }

        public ApiController()
        {
            var entities = new Entities.Entities();
            AcademyRepository = new AcademyRepository(entities);
            EstablishmentRepository = new EstablishmentRepository(entities);
            UserRepository = new UserRepository(entities);
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
            var years = YearRepository.All().Select(y => new ModelWithNameAndId
            {
                Id = y.Id,
                Name = y.Year.ToString()
            });
            return Json(years, JsonRequestBehavior.AllowGet);
        }
    }
}
