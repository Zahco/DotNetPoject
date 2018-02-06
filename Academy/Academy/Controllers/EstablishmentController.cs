using Academy.Entities;
using Academy.Repositories;
using Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Controllers
{
    public class EstablishmentController : Controller
    {
        public EstablishmentRepository EstablishmentRepository { get; set; }
        public AcademyRepository AcademyRepository { get; set; }
        public UserRepository UserRepository { get; set; }

        public EstablishmentController()
        {
            var entities = new Entities.Entities();
            EstablishmentRepository = new EstablishmentRepository(entities);
            AcademyRepository = new AcademyRepository(entities);
            UserRepository = new UserRepository(entities);
        }

        public ActionResult GetAll()
        {
            var models = EstablishmentRepository.All().Select(e => EstablishmentModel.ToModel(e));
            return View(models);
        }

        public ActionResult Get(Guid id)
        {
            var model = EstablishmentModel.ToModel(EstablishmentRepository.GetById(id));
            return View(model);
        }

        public ActionResult AddOrUpdate(Guid? id)
        {
            var model = new EstablishmentModel();
            if (id.HasValue)
            {
                model = EstablishmentModel.ToModel(EstablishmentRepository.GetById(id.Value));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(EstablishmentModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isCreated = model.Id == Guid.Empty;
            var esta = new Establishments();
            if (!isCreated)
            {
                esta = EstablishmentRepository.GetById(model.Id);
            }

            esta.Name = model.Name;
            esta.Academie_Id = model.AcademyId;
            esta.Academies = AcademyRepository.GetByName(model.Academy);
            esta.Address = model.Address;
            esta.PostCode = model.PostCode;
            esta.Town = model.Town;
            //TODO : choose a user
            if (esta.Users == null)
                esta.Users = UserRepository.All().First();

            if (isCreated)
            {
                EstablishmentRepository.Add(esta);
            }
            EstablishmentRepository.Save();

            return Redirect(Url.Action("Get", "Establishment", new { id = esta.Id }));
        }

        public ActionResult Delete(Guid Id)
        {
            EstablishmentRepository.Delete(Id);
            EstablishmentRepository.Save();
            return Redirect(Url.Action("GetAll", "Establishment"));
        }
    }
}