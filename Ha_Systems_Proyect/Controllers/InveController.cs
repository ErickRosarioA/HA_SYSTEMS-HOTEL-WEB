using Ha_Systems_Proyect.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class InveController : Controller
    {
        private HA_SYSTEMSEntities6 Modelo_Generate = new HA_SYSTEMSEntities6();
        // GET: Inve
        public ActionResult Inventario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inventario(INVENTARIO invetaData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Modelo_Generate.INVENTARIO.Add(invetaData);
                    Modelo_Generate.SaveChanges();
                    return RedirectToAction("Inventario", "Inve");
                }
                catch (Exception)
                {

                }

            }
            else
            {
                ViewBag.error = "Existen Campos invalidos, revisar";
            }
            return View();
        }

        public ActionResult ListInventario()
        {
            if (Session["Data_User"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(Modelo_Generate.INVENTARIO.ToList());
        }

        public ActionResult EditInventario(int? idI)
        {

            if (idI == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO inventaData = Modelo_Generate.INVENTARIO.Find(idI);
            if (inventaData == null)
            {
                return HttpNotFound();
            }

            return View(inventaData);
        }

        public ActionResult ImpresionInventario(int? idI)
        {

            if (idI == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO inventaData = Modelo_Generate.INVENTARIO.Find(idI);
            if (inventaData == null)
            {
                return HttpNotFound();
            }

            return View(inventaData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInventario(INVENTARIO inventaData)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Modelo_Generate.Entry(inventaData).State = EntityState.Modified;
                    Modelo_Generate.SaveChanges();

                    return RedirectToAction("Inventario");
                }
                catch (Exception err)
                {
                    var c = err;
                    ViewBag.x = c;
                }
            }
            return View(inventaData);
        }


        public ActionResult DeleteInventario(int? idI)
        {
            if (idI == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO inventaData = Modelo_Generate.INVENTARIO.Find(idI);
            if (inventaData == null)
            {
                return HttpNotFound();
            }
            else
            {
                try
                {
                    Modelo_Generate.INVENTARIO.Remove(inventaData);
                    Modelo_Generate.SaveChanges();

                }
                catch (Exception)
                {

                }
                return RedirectToAction("Inventario");
            }

        }

    }
}