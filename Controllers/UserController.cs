using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFinancas.Models;

namespace WebFinancas.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login(int? Id)
        {
            if(Id != null)
            {
                if(Id == 0)
                {
                    HttpContext.Session.SetString("IdUserLogged", string.Empty);
                    HttpContext.Session.SetString("NameUserLogged", string.Empty);
                }
            }
            return View();  
        }

        [HttpPost]
        public IActionResult ValidateLogin(UserModel user)
        {
            bool checkLogin = user.ValidateLogin();
            if(checkLogin)
            {
                HttpContext.Session.SetString("NameUserLogged", user.name);
                HttpContext.Session.SetString("IdUserLogged", user.Id.ToString());
                return RedirectToAction("Menu", "Home");
            }
            else
            {
                TempData["MensageLoginInvalid"] = "Invalid Login Data!";
                return RedirectToAction("Login");
            }     
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                //Register user on system.
                user.RegisterUser();
                return RedirectToAction("Success");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}