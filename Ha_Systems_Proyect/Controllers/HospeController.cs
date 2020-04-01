using Ha_Systems_Proyect.Models;
using System.Linq;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class HospeController : Controller
    {
        private HA_SYSTEMSEntities3 Modelo_Generate = new HA_SYSTEMSEntities3();
        // GET: Hospe
        public ActionResult Hospedaje()
        {
            var listado = new SelectList(Modelo_Generate.CLIENTE.ToList(),"Id_Cliente", "Cedula");
            ViewData["Data"]= listado;
            
            return View(Modelo_Generate.CLIENTE.ToList());
        }

        [HttpPost]
        public ActionResult ClienteData(int? Id_Cliente)
        {
            var query = from c in Modelo_Generate.CLIENTE where c.Id_cliente == Id_Cliente select new { Id_Cliente = c.Id_cliente, name = c.Nombre + " " + c.Apellido, celular = c.Celular , direccion=c.Direccion };

            return Json(query, JsonRequestBehavior.AllowGet);

        }
    }
}