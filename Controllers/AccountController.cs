using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFinancas.Models;

namespace WebFinancas.Controllers
{
    public class AccountController : Controller
    {
        IHttpContextAccessor __httpContextAccessor;
        //Receives the context for access to session variables
        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            __httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            AccountModel objectAccount = new AccountModel(__httpContextAccessor);
            ViewBag.ListAccount = objectAccount.ListAccount();
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel account)
        {
            if(ModelState.IsValid)
            {
                account.__httpContextAccessor = __httpContextAccessor;
                account.RegisterAccount();
                return RedirectToAction("Index");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteAccount(int Id)
        {
            AccountModel objectAccount = new AccountModel(__httpContextAccessor);
            objectAccount.DeleteAccount(Id);
            return RedirectToAction("Index");
        }
    }
}
