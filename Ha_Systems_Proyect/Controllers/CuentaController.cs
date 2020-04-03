using Ha_Systems_Proyect.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class CuentaController : Controller
    {

        private HA_SYSTEMSEntities6 Modelo_Generate = new HA_SYSTEMSEntities6();
        // GET: Cuenta
        public ActionResult Cuenta()
        {
            var listaCliente = new SelectList(Modelo_Generate.CLIENTE.ToList(), "Id_Cliente", "Cedula");
            ViewData["Data_Clientes"] = listaCliente;
            if (ViewData["Data_factura"] == null)
            {
                ViewData["Data_factura"] = new SelectList(Modelo_Generate.FACTURA.ToList(), "Codigo", "Code_Factura");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Cuenta(CUENTA_POR_COBRAR cuentaData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Modelo_Generate.CUENTA_POR_COBRAR.Add(cuentaData);
                    Modelo_Generate.SaveChanges();
                    return RedirectToAction("Cuenta", "Cuenta");
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

        public ActionResult ListCuenta()
        {
            if (Session["Data_User"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(Modelo_Generate.CUENTA_POR_COBRAR.ToList());
        }


        public ActionResult DeleteCuenta(int? idCu)
        {
            if (idCu == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA_POR_COBRAR cuentaData = Modelo_Generate.CUENTA_POR_COBRAR.Find(idCu);
            if (cuentaData == null)
            {
                return HttpNotFound();
            }
            else
            {
                try
                {
                    Modelo_Generate.CUENTA_POR_COBRAR.Remove(cuentaData);
                    Modelo_Generate.SaveChanges();
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Cuenta");
            }
        }
        [HttpPost]
        public ActionResult LoadData(int? Id_Cliente)
        {
            var query = from c in Modelo_Generate.CLIENTE where c.Id_cliente == Id_Cliente select new { name = c.Nombre + " " + c.Apellido };
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DataPrice(int? Codigo)
        {
            var query = from f in Modelo_Generate.FACTURA where f.Codigo == Codigo select new { total = f.Total, fecha = f.Fecha_Creacion.ToString() };
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ImpreCuenta(int? idCu)
        {
            if (idCu == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA_POR_COBRAR cuentaData = Modelo_Generate.CUENTA_POR_COBRAR.Find(idCu);
            if (cuentaData == null)
            {
                return HttpNotFound();
            }
            return View(cuentaData);
        }

        [HttpGet]
        public ActionResult GetCode(int? Id_Cliente)
        {
            var listFactura = (from f in Modelo_Generate.FACTURA join c in Modelo_Generate.CLIENTE on f.HOSPEDAJE.CLIENTE equals c where c.Id_cliente == Id_Cliente where f.Cedula_Cliente == c.Cedula select new { id_fact = f.Codigo, code = f.Code_Factura }).ToList();
            ViewData["Data_factura"] = new SelectList(listFactura, "Codigo", "Code_Factura");

            return Json(listFactura, JsonRequestBehavior.AllowGet);
        }
    }
}