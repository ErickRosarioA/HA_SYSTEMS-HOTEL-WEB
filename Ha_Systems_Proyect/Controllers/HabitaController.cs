using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class HabitaController : Controller
    {
        // GET: Habita
        public ActionResult Habitacion()
        {
            @ViewBag.Page = "Habitaciones";
            return View();
        }
    }
}