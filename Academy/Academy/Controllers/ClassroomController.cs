﻿using Academy.Attributes;
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
    [RequiredConnectedUser]
    public class ClassroomController : Controller
    {
        public ClassroomRepository ClassroomRepository { get; set; }

        public EstablishmentRepository EstablishmentRepository { get; set; }

        public UserRepository UserRepository { get; set; }

        public YearRepository YearRepository { get; set; }

        public ClassroomController()
        {
            var entities = new Entities.Entities();
            ClassroomRepository = new ClassroomRepository(entities);
            EstablishmentRepository = new EstablishmentRepository(entities);
            UserRepository = new UserRepository(entities);
            YearRepository = new YearRepository(entities);
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

        public ActionResult AddOrUpdate(Guid? id, Guid? establishmentId)
        {
            var model = new ClassroomModel();
            if (id.HasValue)
            {
                model = ClassroomModel.ToModel(ClassroomRepository.GetById(id.Value));
            }
            if (establishmentId.HasValue)
            {
                model.Establishment_Id = establishmentId.Value;
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
            classroom.User_Id = model.UserId;
            classroom.Users = UserRepository.GetById(model.UserId);
            classroom.Year_Id = model.YearId;
            classroom.Years = YearRepository.GetById(model.YearId);

            if (isCreated)
            {
                ClassroomRepository.Add(classroom);
            }
            ClassroomRepository.Save();

            return Redirect(Url.Action("Get", "Classroom", new { id = classroom.Id }));
        }

        public ActionResult Delete(Guid id)
        {
            var classroom = ClassroomRepository.GetById(id);
            if (classroom.Pupils.Count() > 0)
            {
                return Redirect(Url.Action("GetAll", "Classroom"));
            }
            ClassroomRepository.Delete(id);
            ClassroomRepository.Save();
            return Redirect(Url.Action("GetAll", "Classroom"));
        }

        public ActionResult GetByFilter(string filter)
        {
            filter = filter.ToUpper();
            return Json(ClassroomRepository.All()
                .Where(c => 
                    c.Title.ToUpper().Contains(filter) || 
                    c.Years.Year.ToString().Contains(filter) || 
                    c.Establishments.Name.ToUpper().Contains(filter) ||
                    c.Users.FirstName.ToUpper().Contains(filter) ||
                    c.Users.LastName.ToUpper().Contains(filter))
                .Select(c => c.Id), JsonRequestBehavior.AllowGet);
        }
    }
}