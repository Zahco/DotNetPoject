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
    public class ResultController : Controller
    {
        public ResultRepository ResultRepository;

        public EvaluationRepository EvaluationRepository;

        public PupilRepository PupilRepository;

        public ResultController()
        {
            var entities = new Entities.Entities();
            ResultRepository = new ResultRepository(entities);
            EvaluationRepository = new EvaluationRepository(entities);
            PupilRepository = new PupilRepository(entities);
        }

        public ActionResult GetAll()
        {
            var models = ResultRepository.All().Select(r => ResultModel.ToModel(r));
            return View(models);
        }

        public ActionResult Get(Guid id)
        {
            var model = ResultModel.ToModel(ResultRepository.GetById(id));
            return View(model);
        }

        public ActionResult AddOrUpdate(Guid? id)
        {
            var model = new ResultModel();
            if (id.HasValue)
            {
                model = ResultModel.ToModel(ResultRepository.GetById(id.Value));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(ResultModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isCreated = model.Id == Guid.Empty;
            var result = new Results();
            if (!isCreated)
            {
                result = ResultRepository.GetById(model.Id);
            }

            result.Evaluation_Id = model.EvaluationId;
            result.Evaluations = EvaluationRepository.GetById(model.EvaluationId);
            result.Pupil_Id = model.PupilId;
            result.Pupils = PupilRepository.GetById(model.PupilId);
            result.Note = model.Note;           

            if (isCreated)
            {
                ResultRepository.Add(result);
            }
            ResultRepository.Save();

            return Redirect(Url.Action("Get", "Result", new { id = result.Id }));
        }

        public ActionResult Delete(Guid id)
        {
            ResultRepository.Delete(id);
            ResultRepository.Save();
            return Redirect(Url.Action("GetAll", "Result"));
        }
    }
}