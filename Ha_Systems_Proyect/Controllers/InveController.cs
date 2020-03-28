using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class InveController : Controller
    {
        // GET: Inve
        public ActionResult Inventario()
        {
            @ViewBag.Page = "Inventario";
            return View();
        }
    }
}