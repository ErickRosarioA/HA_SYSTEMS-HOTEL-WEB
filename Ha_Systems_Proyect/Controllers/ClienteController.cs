using Ha_Systems_Proyect.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Data.Entity.Infrastructure;
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


        public ActionResult EditCliente(int? idC)
        {
            if (idC == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cliente = Modelo_Generate.CLIENTE.Find(idC);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            var userCredential = Session["Data_User"];
            ViewBag.Credential = userCredential;
            if (userCredential == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCliente(CLIENTE clienteEdit)
        {
            var userCredential = Session["Data_User"];
            if (ModelState.IsValid)
            {
                try
                {
            
                    ViewBag.Credential = userCredential;
                    if (userCredential == null)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    Modelo_Generate.Entry(clienteEdit).State = EntityState.Modified;
                    Modelo_Generate.SaveChanges();
                        
                  return RedirectToAction("Cliente");
                }
                catch (Exception err)
                {

                    var c = err;

                    ViewBag.x = c;
                }
            }

            ViewBag.Credential = userCredential;
            if (userCredential == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(clienteEdit);
        }

        public ActionResult DeleteCliente(int? idC)
        {
            if (idC == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE clienteData = Modelo_Generate.CLIENTE.Find(idC);
            if (clienteData == null)
            {
                return HttpNotFound();
            }
            else
            {
                var userCredential = Session["Data_User"];
                try
                {
                    Modelo_Generate.CLIENTE.Remove(clienteData);
                    Modelo_Generate.SaveChanges();

                }
                catch (Exception)
                {

                }
                ViewBag.Credential = userCredential;
                if (userCredential == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                return RedirectToAction("Cliente");
            }
        
        }

    }
}