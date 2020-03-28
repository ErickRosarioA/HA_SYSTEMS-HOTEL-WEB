using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ha_Systems_Proyect.Controllers
{
    public class HospeController : Controller
    {
        // GET: Hospe
        public ActionResult Hospedaje()
        {

            @ViewBag.Page = "Hospedaje";
            return View();
        }
    }
}