using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFinancas.Models;

namespace WebFinancas.Controllers
{
    public class PlaneAccountController : Controller
    {
        IHttpContextAccessor __httpContextAccessor;
        //Receives the context for access to session variables
        public PlaneAccountController(IHttpContextAccessor httpContextAccessor)
        {
            __httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            PlaneAccountModel objectPlaneAccount = new PlaneAccountModel(__httpContextAccessor);
            ViewBag.ListPlaneAccount = objectPlaneAccount.ListPlaneAccount();
            return View();
        }

        [HttpPost]
        public IActionResult CreatePlaneAccount(PlaneAccountModel PlaneAccount)
        {
            if (ModelState.IsValid)
            {
                PlaneAccount.__httpContextAccessor = __httpContextAccessor;
                PlaneAccount.RegisterPlaneAccount();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreatePlaneAccountEdition(int? Id)
        {
            if(Id != null)
            {
                PlaneAccountModel objectPlaneAccount = new PlaneAccountModel(__httpContextAccessor);
                ViewBag.Records = objectPlaneAccount.LoadRecords(Id);

            }
            return View();
        }

        [HttpGet]
        public IActionResult CreatePlaneAccount()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeletePlaneAccount(int Id)
        {
            PlaneAccountModel objectPlaneAccount = new PlaneAccountModel(__httpContextAccessor);
            objectPlaneAccount.DeletePlaneAccount(Id);
            return RedirectToAction("Index");
        }
    }
}
