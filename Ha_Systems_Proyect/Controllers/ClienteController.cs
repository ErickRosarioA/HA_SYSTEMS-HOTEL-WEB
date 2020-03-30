using Ha_Systems_Proyect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class ClienteController : Controller
    {
        private HA_SYSTEMSEntities1 Modelo_Generate = new HA_SYSTEMSEntities1();
        // GET: Cliente
        public ActionResult Cliente()
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