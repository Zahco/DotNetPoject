using Academy.Models;
using Academy.Repositories;
using Academy.WebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace Academy.Controllers
{
    public class APIController : Controller
    {
        public AcademyRepository AcademyRepository { get; }

        public EstablishmentRepository EstablishmentRepository { get; }

        public APIController()
        {
            var entities = new Entities();
            AcademyRepository = new AcademyRepository(entities);
            EstablishmentRepository = new EstablishmentRepository(entities);
        }

        public ActionResult GetAcademies()
        {
            var academies = AcademyRepository.All().Select(a => AcademyModel.ToModel(a));
            return Json(academies, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEstablishments()
        {
            var establishments = EstablishmentRepository.All().Select(e => EstablishmentModel.ToModel(e));
            return Json(establishments, JsonRequestBehavior.AllowGet);
        }

    }
}
