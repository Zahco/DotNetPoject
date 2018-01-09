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
        public AcademyRepository AcademyRepository { get; set; }

        public APIController()
        {
            AcademyRepository = new AcademyRepository(new Entities());
        }

        public ActionResult GetAcademies()
        {
            var academies = AcademyRepository.All().Select(a => AcademyModel.ToModel(a));
            return Json(academies, JsonRequestBehavior.AllowGet);
        }
    }
}
