using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Cuenta()
        {
            @ViewBag.Page = "Cuentas";
            return View();
        }
    }
}