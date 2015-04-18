using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QQWebAPI.Test.Infrastructure;

namespace QQWebAPI.Test.Controllers
{
    public class HomeController : Controller
    {
        private IUrlHelper urlHelper;

        public HomeController(IUrlHelper helper)
        {
            urlHelper = helper;
        }
        // GET: Home
        public ActionResult Index()
        {
            string url = urlHelper.GetOauthUrl("", "1231");
            ViewBag.Url = url;
            return View();

        }

        public ActionResult CallBack()
        {
            var ss = Request;
            return View();
        }
    }
}