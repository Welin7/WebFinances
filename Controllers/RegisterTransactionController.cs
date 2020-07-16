using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebFinancas.Controllers
{
    public class RegisterTransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Extract()
        {
            return View();
        }

        public IActionResult FinanceReport()
        {
            return View();
        }
    }
}
