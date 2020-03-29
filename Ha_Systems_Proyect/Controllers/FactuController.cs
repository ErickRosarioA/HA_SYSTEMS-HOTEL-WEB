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
            var userCredential = Session["Data_User"];
            ViewBag.Credential = userCredential;
            if (userCredential == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}