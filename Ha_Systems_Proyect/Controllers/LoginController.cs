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
        private HA_SYSTEMSEntities1 Modelo_Generate = new HA_SYSTEMSEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(USUARIO loginDataModel)
        {

            if (loginDataModel.Passwords!="" && loginDataModel.Usuario1!="" )
            {
                foreach (var item in Modelo_Generate.USUARIOs.ToList())
                {
                    if (loginDataModel.Usuario1 == item.Usuario1 && loginDataModel.Passwords == item.Passwords)
                    {
                        return RedirectToAction("Home", "Home");
                    }
                }

                ViewBag.LoginAcces = "Usuario No En contrado";
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult Register()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult Register(USUARIO registerData)
        {
            if (ModelState.IsValid)
            {
                if (registerData.Passwords == registerData.Password_V)
                {

                    Modelo_Generate.USUARIOs.Add(registerData);
                    Modelo_Generate.SaveChanges();
                    return RedirectToAction("Index", "Login");

                }
                else
                {

                    ViewBag.LoginAcces = "Contraseñas no Coinciden";
                    return View();
                }

            }
            else
            {
                return View();
            }
        }


    }
}