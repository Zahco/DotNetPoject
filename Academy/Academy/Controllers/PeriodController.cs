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
    public class PeriodController : Controller
    {
        public PeriodRepository PeriodRepository { get; set; }

        public YearRepository YearRepository { get; set; }

        public PeriodController()
        {
            var entities = new Entities.Entities();
            PeriodRepository = new PeriodRepository(entities);
            YearRepository = new YearRepository(entities);
        }

        public ActionResult GetAll()
        {
            return View(PeriodRepository.All().Select(p => PeriodModel.ToModel(p)));
        }

        public ActionResult Get(Guid id)
        {
            return View(PeriodModel.ToModel(PeriodRepository.GetById(id)));
        }

        public ActionResult AddOrUpdate(Guid? id)
        {
            var model = new PeriodModel();
            if (id.HasValue)
            {
                model = PeriodModel.ToModel(PeriodRepository.GetById(id.Value));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(PeriodModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isCreated = model.Id == Guid.Empty;
            var period = new Periods();
            if (!isCreated)
            {
                period = PeriodRepository.GetById(model.Id);
            }

            period.Begin = model.Begin;
            period.End = model.End;
            period.Years = YearRepository.GetById(model.YearId);

            if (isCreated)
            {
                PeriodRepository.Add(period);
            }
            PeriodRepository.Save();

            return Redirect(Url.Action("Get", "Period", new { id = period.Id }));
        }

        public ActionResult Delete(Guid id)
        {
            PeriodRepository.Delete(id);
            PeriodRepository.Save();
            return Redirect(Url.Action("GetAll", "Period"));
        }

        public ActionResult GetByFilter(string filter)
        {
            return Json(PeriodRepository.All()
                .Where(p => p.Years.Year.ToString().ToUpper().Contains(filter.ToUpper()))
                .Select(p => p.Id), JsonRequestBehavior.AllowGet);
        }
    }
}