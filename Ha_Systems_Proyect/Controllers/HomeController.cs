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
            @ViewBag.Page = "Inicio";
            return View();
        }
    }


}