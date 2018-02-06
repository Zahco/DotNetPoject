using Academy.Models;
using Academy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Academy.Controllers
{
    public class SessionController : Controller
    {
        public UserRepository UserRepository { get; set; }

        public SessionController()
        {
            var entities = new Entities.Entities();
            UserRepository = new UserRepository(entities);
        }
        // GET: LogOn
        public ActionResult LogOn(string ReturnUrl)
        {
            if (GlobalVariables.IsAuthenticated)
                return Redirect(Url.Action("Index", "Home"));
            return View(new LogOnModel
            {
                UserName = "USER4",
                Password = "utilisateur4",
                ReturnUrl = ReturnUrl
            });
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = UserRepository.GetByUserNameAndPassword(model.UserName, model.Password);
            GlobalVariables.UserId = user.Id;

            if (model.ReturnUrl == "" || model.ReturnUrl == null)
                return Redirect(Url.Action("Index", "Home"));
            else
                return Redirect(model.ReturnUrl);
        }

        public ActionResult LogOff()
        {
            GlobalVariables.Session.Abandon();
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}