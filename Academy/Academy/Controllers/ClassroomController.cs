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
    public class ClassroomController : Controller
    {
        public ClassroomRepository ClassroomRepository { get; set; }
        public EstablishmentRepository EstablishmentRepository { get; set; }
        public UserRepository UserRepository { get; set; }

        public ClassroomController()
        {
            var entities = new Entities.Entities();
            ClassroomRepository = new ClassroomRepository(entities);
            EstablishmentRepository = new EstablishmentRepository(entities);
            UserRepository = new UserRepository(entities);
        }

        public ActionResult GetAll()
        {
            var models = ClassroomRepository.All().Select(c => ClassroomModel.ToModel(c));
            return View(models);
        }

        public ActionResult Get(Guid id)
        {
            var model = ClassroomModel.ToModel(ClassroomRepository.GetById(id));
            return View(model);
        }

        public ActionResult AddOrUpdate(Guid? id)
        {
            var model = new ClassroomModel();
            if (id.HasValue)
            {
                model = ClassroomModel.ToModel(ClassroomRepository.GetById(id.Value));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(ClassroomModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isCreated = model.Id == Guid.Empty;
            var classroom = new Classrooms();
            if (!isCreated)
            {
                classroom = ClassroomRepository.GetById(model.Id);
            }

            classroom.Title = model.Title;
            classroom.Establishment_Id = model.Establishment_Id;
            classroom.Establishments = EstablishmentRepository.GetById(model.Establishment_Id);
            
            //TODO : choose a user
            if (classroom.Users == null)
            {
                classroom.Users = UserRepository.All().First();
            }

            if (isCreated)
            {
                ClassroomRepository.Add(classroom);
            }
            EstablishmentRepository.Save();

            return Redirect(Url.Action("Get", "Classroom", new { id = classroom.Id }));
        }
    }
}