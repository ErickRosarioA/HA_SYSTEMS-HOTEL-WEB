using Ha_Systems_Proyect.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class FactuController : Controller
    {
        private HA_SYSTEMSEntities5 Modelo_Generate = new HA_SYSTEMSEntities5();
        // GET: Factu
        public ActionResult Facturacion()
        {

            var listadoHospe = new SelectList(Modelo_Generate.HOSPEDAJE.ToList(), "Id_hospedaje", "Id_hospedaje");
            ViewData["Data_Hospe"] = listadoHospe;
            return View();
        }

        [HttpPost]
        public ActionResult Facturacion(FACTURA facturaData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Modelo_Generate.FACTURA.Add(facturaData);
                    Modelo_Generate.SaveChanges();
                    return RedirectToAction("Facturacion", "Factu");
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

        public ActionResult EditFactura(int? idF)
        {

            if (idF == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA facturaData = Modelo_Generate.FACTURA.Find(idF);
            if (facturaData == null)
            {
                return HttpNotFound();
            }
            return View(facturaData);

        }
        [HttpPost]
        public ActionResult EditFactura(FACTURA facturaData)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    Modelo_Generate.Entry(facturaData).State = EntityState.Modified;
                    Modelo_Generate.SaveChanges();

                    return RedirectToAction("Facturacion");
                }
                catch (Exception err)
                {
                    var c = err;
                    ViewBag.x = c;
                }
            }

            return View(facturaData);
        }

        public ActionResult ListFactura()
        {
            if (Session["Data_User"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(Modelo_Generate.FACTURA.ToList());
        }


        public ActionResult DeleteFactura(int? idF)
        {
            if (idF == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA facturaData = Modelo_Generate.FACTURA.Find(idF);
            if (facturaData == null)
            {
                return HttpNotFound();
            }
            else
            {
                try
                {
                    Modelo_Generate.FACTURA.Remove(facturaData);
                    Modelo_Generate.SaveChanges();

                }
                catch (Exception)
                {

                }
                return RedirectToAction("Facturacion");
            }



        }

    }
}