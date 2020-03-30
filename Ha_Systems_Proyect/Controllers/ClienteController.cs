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
        private HA_SYSTEMSEntities3 Modelo_Generate = new HA_SYSTEMSEntities3();
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

        [HttpPost]
        public ActionResult Cliente(CLIENTE dataCliente)
        {
            var userCredential = Session["Data_User"];
            if (ModelState.IsValid)
            {
                try
                {
                    Modelo_Generate.CLIENTE.Add(dataCliente);
                    Modelo_Generate.SaveChanges();
                    return RedirectToAction("Cliente", "Cliente");
                }
                catch (Exception)
                {
               
                }

            }
            else
            {
                ViewBag.error = "Existen Campos invalidos, revisar";
            }
            ViewBag.Credential = userCredential;
            if (userCredential == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        public ActionResult ListCliente()
        {
            var userCredential = Session["Data_User"];
            ViewBag.Credential = userCredential;
            if (userCredential == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(Modelo_Generate.CLIENTE.ToList());
        }
    }
}