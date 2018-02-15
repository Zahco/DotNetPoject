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

        public ActionResult Update(Guid id)
        {
            return View(ResultModel.ToModel(ResultRepository.GetById(id)));
        }

        [HttpPost]
        public ActionResult Update(ResultModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isCreated = model.Id == Guid.Empty;
            var result = new Results();
            if (!isCreated)
            {
                result = ResultRepository.GetById(model.Id);
            }
            
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

        public ActionResult AddAllByEval(Guid EvalId)
        {
            var eval = EvaluationRepository.GetById(EvalId);
            var model = new AddAllByEvalModel
            {
                EvalId = eval.Id,
                Results = eval.Classrooms.Pupils.Select(p => new OneResult
                {
                    Pupil = new ModelWithNameAndId { Id = p.Id, Name = p.FirstName + " " + p.LastName },
                    Note = p.Results.SingleOrDefault(r => r.Evaluations.Id == EvalId)?.Note ?? 0
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult AddAllByEval(AddAllByEvalModel model)
        {
            var eval = EvaluationRepository.GetById(model.EvalId);

            foreach(var result in model.Results)
            {
                var resutlEntity = ResultRepository.GetByEvalAndPupil(eval.Id, result.Pupil.Id);
                var isNew = resutlEntity == null;

                if (isNew)
                {
                    resutlEntity = new Results();
                }

                resutlEntity.Evaluations = eval;
                resutlEntity.Note = result.Note;
                resutlEntity.Pupils = PupilRepository.GetById(result.Pupil.Id);

                if (isNew)
                {
                    ResultRepository.Add(resutlEntity);
                }
            }

            ResultRepository.Save();

            return Redirect(Url.Action("Get", "Evaluation", new { Id = eval.Id }));
        }
        public ActionResult GetByFilter(string filter)
        {
            return Json(ResultRepository.All()
                .Where(r =>
                (r.Note.ToString()
                + r.Pupils.LastName.ToLower()
                + r.Pupils.FirstName.ToLower()).Contains(filter.ToLower()))
                .Select(r => r.Id), JsonRequestBehavior.AllowGet);
        }
    }
}