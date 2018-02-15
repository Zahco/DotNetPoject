using Academy.Attributes;
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
    public class EvaluationController : Controller
    {

        public EvaluationRepository EvaluationRepository { get; set; }
        public ClassroomRepository ClassroomRepository { get; set; }
        public UserRepository UserRepository { get; set; }
        public PeriodRepository PeriodRepository { get; set; }

        public EvaluationController()
        {
            var entities = new Entities.Entities();
            EvaluationRepository = new EvaluationRepository(entities);
            ClassroomRepository = new ClassroomRepository(entities);
            UserRepository = new UserRepository(entities);
            PeriodRepository = new PeriodRepository(entities);
        }

        public ActionResult GetAll()
        {
            var models = EvaluationRepository.All().Select(a => EvaluationModel.ToModel(a));
            return View(models);
        }

        public ActionResult Get(Guid id)
        {
            var model = EvaluationModel.ToModel(EvaluationRepository.GetById(id));
            return View(model);
        }

        public ActionResult AddOrUpdate(Guid? Id, Guid? ClassroomId)
        {
            var model = new EvaluationModel();
            model.Date = DateTime.Now;
            if (Id.HasValue)
            {
                model = EvaluationModel.ToModel(EvaluationRepository.GetById(Id.Value));
            }
            if (ClassroomId.HasValue)
            {
                model.ClassroomId = ClassroomId.Value;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(EvaluationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isCreated = model.Id == Guid.Empty;
            var evaluation = new Evaluations();

            if (!isCreated)
            {
                evaluation = EvaluationRepository.GetById(model.Id);
            }

            evaluation.Date = model.Date;
            evaluation.Classroom_Id = model.ClassroomId;
            evaluation.Classrooms = ClassroomRepository.GetById(model.ClassroomId);
            evaluation.User_Id = model.UserId;
            evaluation.Users = UserRepository.GetById(model.UserId);
            evaluation.TotalPoint = model.TotalPoint;
            evaluation.Periods = PeriodRepository.GetById(model.PeriodId);

            if (isCreated)
            {
                EvaluationRepository.Add(evaluation);
            }
            EvaluationRepository.Save();

            return Redirect(Url.Action("Get", "Evaluation", new { id = evaluation.Id }));
        }

        public ActionResult Delete(Guid Id)
        {
            EvaluationRepository.Delete(Id);
            EvaluationRepository.Save();
            return Redirect(Url.Action("GetAll", "Evaluation"));
        }

        public ActionResult GetByFilter(string filter)
        {
            return Json(EvaluationRepository.All()
                .Where(e => 
                (e.Classrooms.Title.ToLower() 
                + e.Date.ToString() 
                + e.TotalPoint.ToString() 
                + e.Users.LastName.ToLower()
                + e.Users.FirstName.ToLower()).Contains(filter.ToLower()))
                .Select(e => e.Id), JsonRequestBehavior.AllowGet);
        }
    }
}