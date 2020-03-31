using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
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