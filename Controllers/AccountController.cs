using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebFinancas.Models;

namespace WebFinancas.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            AccountModel objectAccount = new AccountModel();
            ViewBag.ListAccount = objectAccount.ListAccount();
            return View();
        }
    }
}
