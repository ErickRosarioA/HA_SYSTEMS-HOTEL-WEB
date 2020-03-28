using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            @ViewBag.Page = "Inicio";
            return View();
        }
    }


}