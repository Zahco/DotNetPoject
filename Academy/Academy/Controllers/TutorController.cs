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
    public class TutorController : Controller
    {
        public PupilRepository PupilRepository { get; set; }

        public TutorRepository TutorRepository { get; set; }

        public TutorController()
        {
            var entities = new Entities.Entities();
            PupilRepository = new PupilRepository(entities);
            TutorRepository = new TutorRepository(entities);
        }

        public ActionResult GetAll()
        {
            var models = TutorRepository.All().Select(c => TutorModel.ToModel(c));
            return View(models);
        }

        public ActionResult Get(Guid id)
        {
            var model = TutorModel.ToModel(TutorRepository.GetById(id));
            return View(model);
        }

        public ActionResult AddOrUpdate(Guid? id)
        {
            var model = new TutorModel();
            if (id.HasValue)
            {
                model = TutorModel.ToModel(TutorRepository.GetById(id.Value));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(TutorModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isCreated = model.Id == Guid.Empty;
            var tutor = new Tutors();
            if (!isCreated)
            {
                tutor = TutorRepository.GetById(model.Id);
            }

            tutor.Address = model.Address;
            tutor.Comment = model.Comment;
            tutor.FirstName = model.FirstName;
            tutor.LastName = model.LastName;
            tutor.Mail = model.Mail;
            tutor.PostCode = model.PostCode;
            tutor.Tel = model.Tel;
            tutor.Town = model.Town;
            tutor.Pupils = PupilRepository.All().ToList();
            
            if (isCreated)
            {
                TutorRepository.Add(tutor);
            }
            TutorRepository.Save();

            return Redirect(Url.Action("Get", "Tutor", new { id = tutor.Id }));
        }

        public ActionResult Delete(Guid id)
        {
            TutorRepository.Delete(id);
            TutorRepository.Save();
            return Redirect(Url.Action("GetAll", "Tutor"));
        }
    }
}