using Academy.Entities;
using Academy.Repositories;
using Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy.Attributes;

namespace Academy.Controllers
{

    [RequiredConnectedUser]
    public class AcademyController : Controller
    {
        public AcademyRepository AcademyRepository { get; set; }

        public AcademyController()
        {
            AcademyRepository = new AcademyRepository(new Entities.Entities());
        }

        public ActionResult GetAll()
        {
            var models = AcademyRepository.All().Select(a => AcademyModel.ToModel(a));
            return View(models);
        }
        
        public ActionResult Get(Guid id)
        {
            var academy = AcademyModel.ToModel(AcademyRepository.GetById(id));
            return View(academy);
        }

        public ActionResult AddOrUpdate(Guid? id)
        {
            var model = new AcademyModel();
            if (id.HasValue)
            {
                model = AcademyModel.ToModel(AcademyRepository.GetById(id.Value));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(AcademyModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isCreated = model.Id == Guid.Empty;
            var academy = new Academies();
            if (!isCreated)
            {
                academy = AcademyRepository.GetById(model.Id);
            }

            academy.Name = model.Name;

            if (isCreated)
            {
                AcademyRepository.Add(academy);
            }
            AcademyRepository.Save();

            return Redirect(Url.Action("Get", "Academy", new { id = academy.Id }));
        }
    }
}