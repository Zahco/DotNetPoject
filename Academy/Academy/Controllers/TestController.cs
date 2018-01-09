using Academy.Models;
using Academy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Controllers
{
    public class TestController : Controller
    {
        public AcademyRepository AcademyRepository { get; set; }

        public TestController()
        {
            AcademyRepository = new AcademyRepository(new Entities());
        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrintAllAcademies()
        {
            return View(AcademyRepository.All());
        }
    }
}