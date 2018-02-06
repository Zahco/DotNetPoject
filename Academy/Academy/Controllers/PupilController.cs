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

        public PupilController()
        {
            var entities = new Entities.Entities();
            PupilRepository = new PupilRepository(entities);
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

        public ActionResult Delete(Guid id)
        {
            PupilRepository.Delete(id);
            PupilRepository.Save();
            return Redirect(Url.Action("GetAll", "Pupil"));
        }
    }
}
