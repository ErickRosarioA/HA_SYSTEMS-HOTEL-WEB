using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class HabitaController : Controller
    {
        // GET: Habita
        public ActionResult Habitacion()
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