using Ha_Systems_Proyect.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class HospeController : Controller
    {
        private HA_SYSTEMSEntities6 Modelo_Generate = new HA_SYSTEMSEntities6();
        // GET: Hospe
        public ActionResult Hospedaje()
        {
            var listadoClientes = new SelectList(Modelo_Generate.CLIENTE.ToList(),"Id_Cliente", "Cedula");
            var modeloH = (from p in Modelo_Generate.HABITACION
                               where p.Disponibilidad == true
                               select p).ToList();
            var listadoHabi = new SelectList(modeloH, "Id_habitacion", "Descripcion");
            ViewData["Data_Clientes"]= listadoClientes;
            ViewData["Data_Habi"] = listadoHabi;

            return View();
        }

        [HttpPost]
        public ActionResult Hospedaje(HOSPEDAJE hospedaje)
        {
            if (ModelState.IsValid)
            {
              
                try
                {
                    HABITACION HabitacionSelect= Modelo_Generate.HABITACION.Find(hospedaje.Habitacion_id);
                    HabitacionSelect.Disponibilidad = false;
                    Modelo_Generate.Entry(HabitacionSelect).State = EntityState.Modified;
                    Modelo_Generate.HOSPEDAJE.Add(hospedaje);
                    Modelo_Generate.SaveChanges();
                    return RedirectToAction("ListadoHospedaje", "Hospe");
                }
                catch (Exception)
                {

                }

            }
            else
            {
                ViewBag.error = "Existen Campos invalidos, revisar";
            }
            return RedirectToAction("Hospedaje");
        }

        public ActionResult ListadoHospedaje()
        {

            return View(Modelo_Generate.HOSPEDAJE.ToList());
        }

        public ActionResult DeleteHospedaje(int? idH)
        {
            if (idH == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOSPEDAJE hospedajeDta = Modelo_Generate.HOSPEDAJE.Find(idH);
            if (hospedajeDta == null)
            {
                return HttpNotFound();
            }
            else
            {
                try
                {
                    HABITACION HabitacionSelect = Modelo_Generate.HABITACION.Find(hospedajeDta.Habitacion_id);
                    HabitacionSelect.Disponibilidad = true;
                    Modelo_Generate.Entry(HabitacionSelect).State = EntityState.Modified;
                    Modelo_Generate.HOSPEDAJE.Remove(hospedajeDta);
                    Modelo_Generate.SaveChanges();

                }
                catch (Exception)
                {

                }
                return RedirectToAction("ListadoHospedaje", "Hospe");
            }

        }

        [HttpPost]
        public ActionResult ClienteData(int? Id_Cliente)
        {
            var query = from c in Modelo_Generate.CLIENTE where c.Id_cliente == Id_Cliente select new { Id_Cliente = c.Id_cliente, name = c.Nombre + " " + c.Apellido, celular = c.Celular , direccion=c.Direccion };

            return Json(query, JsonRequestBehavior.AllowGet);

        }
    }
}