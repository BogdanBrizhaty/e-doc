using AutoMapper;
using eDoc.Model.Managers.ContextState;
using eDoc.Web.Base;
using eDoc.Web.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDoc.Web.Controllers
{
    public class HomeController : Controller
    {
        IContextStateManager _contextState;
        public HomeController(IMapper mapper)
        {
            var mp = mapper;
            _contextState = new CookieManager(new HttpContextWrapper(System.Web.HttpContext.Current));
        }

        public ActionResult Index(bool force = false)
        {
            //var cookie = _contextState.GetItem("test-key");
            //if (cookie != null && cookie.Equals("lol kek"))
            //    return RedirectToAction("About");
            //_contextState.AddOrUpdateItem("test-key", "lol kek");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}