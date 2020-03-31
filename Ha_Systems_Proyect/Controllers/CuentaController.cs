using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Cuenta()
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