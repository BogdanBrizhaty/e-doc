using eDoc.Model.Services;
using eDoc.Web.Controllers.Base;
using eDoc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDoc.Web.Controllers
{
    public class RegistrationController : Base.ControllerBase
    {
        [HttpGet]
        public ActionResult Patient()
        {
            ViewBag.ShowTopBar = false;
            var model = new RegisterViewModel()
            {
                IsDoctor = false
            };
            return View("~/Views/Account/Register.cshtml", model);
        }

        [HttpGet]
        public ActionResult Doctor()
        {
            ViewBag.ShowTopBar = false;
            var model = new RegisterViewModel()
            {
                IsDoctor = true
            };
            return View("~/Views/Account/Register.cshtml", model);
        }
    }
}