using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class FactuController : Controller
    {
        // GET: Factu
        public ActionResult Facturacion()
        {
            @ViewBag.Page = "Facturacion";
            return View();
        }
    }
}