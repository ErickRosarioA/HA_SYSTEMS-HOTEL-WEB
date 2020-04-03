using Ha_Systems_Proyect.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class HabitaController : Controller
    {
        private HA_SYSTEMSEntities6 Modelo_Generate = new HA_SYSTEMSEntities6();
        // GET: Habita
        public ActionResult Habitacion()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Habitacion(HABITACION habitData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Modelo_Generate.HABITACION.Add(habitData);
                    Modelo_Generate.SaveChanges();
                    return RedirectToAction("Habitacion", "Habita");
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

        public ActionResult EditHabitacion(int? idH)
        {
            if (idH == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION habitData = Modelo_Generate.HABITACION.Find(idH);
            if (habitData == null)
            {
                return HttpNotFound();
            }
            return View(habitData);
        }

        [HttpPost]
        public ActionResult EditHabitacion(HABITACION habitaData)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    Modelo_Generate.Entry(habitaData).State = EntityState.Modified;
                    Modelo_Generate.SaveChanges();

                    return RedirectToAction("Habitacion");
                }
                catch (Exception err)
                {

                    var c = err;
                    ViewBag.x = c;
                }
            }

            return View(habitaData);
        }

        public ActionResult ListHabitacion()
        {

            if (Session["Data_User"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(Modelo_Generate.HABITACION.ToList());
        }



        public ActionResult DeleteHabitacion(int? idH)
        {
            if (idH == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION habitData = Modelo_Generate.HABITACION.Find(idH);
            if (habitData == null)
            {
                return HttpNotFound();
            }
            else
            {
                try
                {
                    Modelo_Generate.HABITACION.Remove(habitData);
                    Modelo_Generate.SaveChanges();

                }
                catch (Exception)
                {

                }
                return RedirectToAction("Habitacion");
            }



        }
    }
}