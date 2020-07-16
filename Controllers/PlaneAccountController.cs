using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebFinancas.Controllers
{
    public class PlaneAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
