using Academy.Attributes;
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

        public EvaluationController()
        {
            EvaluationRepository = new EvaluationRepository(new Entities.Entities());
        }

        public ActionResult GetAll()
        {
            var models = EvaluationRepository.All().Select(a => EvaluationModel.ToModel(a));
            return View(models);
        }
    }
}