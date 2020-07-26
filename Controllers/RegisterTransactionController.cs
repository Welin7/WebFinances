using System;
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
                Transaction.RegisterTransaction();
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
                ViewBag.RecordsTransaction = objectTransaction.LoadTransaction(Id);
            }

            ViewBag.ListAccount = new AccountModel(__httpContextAccessor).ListAccount();
            ViewBag.ListPlaneAccount = new PlaneAccountModel(__httpContextAccessor).ListPlaneAccount();           
            return View();
        }

        public IActionResult DeleteTransaction(int Id)
        {
            TransactionModel objectTransaction = new TransactionModel(__httpContextAccessor);
            ViewBag.RecordsTransaction = objectTransaction.LoadTransaction(Id);           
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            TransactionModel objectTransaction= new TransactionModel(__httpContextAccessor);
            objectTransaction.Delete(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [HttpGet]
        public IActionResult Extract(TransactionModel Transaction)
        {
            Transaction.__httpContextAccessor = __httpContextAccessor;
            ViewBag.ListTransaction = Transaction.ListTransaction();
            ViewBag.ListAccount = new AccountModel(__httpContextAccessor).ListAccount();
            return View();
        }

        public IActionResult FinanceReport()
        {
            List<FinanceReport> list = new FinanceReport().ReturnDataGraphicPie();
            string values = "";
            string labels = "";
            string colors = "";
            
            //Used the function to generate random colors
            var random = new Random();

            for (int i = 0; i < list.Count; i++)
            {
                values += list[i].TotalValue.ToString() + ",";
                labels += "'" + list[i].PlaneAccountName.ToString() + "',";
                colors += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Colors = colors;
            ViewBag.Values = values;
            ViewBag.Labels = labels;

            return View();
        }
    }
}
