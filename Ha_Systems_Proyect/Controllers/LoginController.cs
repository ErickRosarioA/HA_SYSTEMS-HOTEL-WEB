using Ha_Systems_Proyect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel loginDataModel)
        {
            if (ModelState.IsValid )
            {
      
                return RedirectToAction("Home","Home");
            }
            else
            {
                return View(loginDataModel);
            }
        }


    }
}