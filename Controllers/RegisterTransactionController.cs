﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFinancas.Models;

namespace WebFinancas.Controllers
{
    public class RegisterTransactionController : Controller
    {
        IHttpContextAccessor __httpContextAccessor;
        //Receives the context for access to session variables
        public RegisterTransactionController(IHttpContextAccessor httpContextAccessor)
        {
            __httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            TransactionModel objectTransaction = new TransactionModel(__httpContextAccessor);
            ViewBag.ListTransaction = objectTransaction.ListTransaction();
            return View();
        }

        [HttpPost]
        public IActionResult RegisterTransaction(TransactionModel Transaction)
        {
            if (ModelState.IsValid)
            {
                Transaction.__httpContextAccessor = __httpContextAccessor;
                //Transaction.RegisterTransaction();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult RegisterTransaction(int? Id)
        {
            if (Id != null)
            {
                TransactionModel objectTransaction = new TransactionModel(__httpContextAccessor);
                //ViewBag.RecordsTransaction = objectTransaction.LoadRecordsTransaction(Id);

            }

            ViewBag.ListAccount = new AccountModel(__httpContextAccessor).ListAccount();
            ViewBag.ListPlaneAccount = new PlaneAccountModel(__httpContextAccessor).ListPlaneAccount();
            
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
