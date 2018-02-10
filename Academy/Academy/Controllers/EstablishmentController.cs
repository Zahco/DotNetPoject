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
            var establishment = new Establishments();
            if (!isCreated)
            {
                establishment = EstablishmentRepository.GetById(model.Id);
            }

            establishment.Name = model.Name;
            establishment.Academie_Id = model.AcademyId;
            establishment.Academies = AcademyRepository.GetByName(model.Academy);
            establishment.Address = model.Address;
            establishment.PostCode = model.PostCode;
            establishment.Town = model.Town;
            establishment.User_Id = model.UserId;
            establishment.Users = UserRepository.GetById(model.UserId);

            if (isCreated)
            {
                EstablishmentRepository.Add(establishment);
            }
            EstablishmentRepository.Save();

            return Redirect(Url.Action("Get", "Establishment", new { id = establishment.Id }));
        }

        public ActionResult Delete(Guid Id)
        {
            EstablishmentRepository.Delete(Id);
            EstablishmentRepository.Save();
            return Redirect(Url.Action("GetAll", "Establishment"));
        }

        public ActionResult GetByFilter(string filter)
        {
            filter = filter.ToUpper();
            return Json(EstablishmentRepository.All()
                .Where(e => 
                    e.Name.ToUpper().Contains(filter) || 
                    e.Town.ToUpper().Contains(filter) || 
                    e.Academies.Name.ToUpper().Contains(filter) ||
                    e.Address.ToUpper().Contains(filter) ||
                    e.PostCode.Contains(filter) || 
                    e.Town.ToUpper().Contains(filter))
                .Select(e => e.Id), JsonRequestBehavior.AllowGet);
        }
    }
}