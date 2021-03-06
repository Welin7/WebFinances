﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebFinancas.DataLayer;

namespace WebFinancas.Models
{
    public class FinanceReport
    {
        public double TotalValue { get; set; }

        public string PlaneAccountName { get; set; }

        public IHttpContextAccessor __httpContextAccessor { get; set; }

        public FinanceReport()
        {

        }

        //Receives the context for access to session variables
        public FinanceReport(IHttpContextAccessor httpContextAccessor)
        {
            __httpContextAccessor = httpContextAccessor;
        }

        private string id_User_Logged()
        {
            return __httpContextAccessor.HttpContext.Session.GetString("IdUserLogged");
        }
        
        public List<FinanceReport> ReturnDataGraphicPie()
        {
            string sql = " Select SUM(T.Value) As TotalValue, PA.Description As PlaneAccountName From Transaction T " +
                         " INNER JOIN PlaneAccount As PA on T.PlaneAccount_Id = PA.Id " +
                         $" WHERE T.Type = 'E' AND T.User_Id = {id_User_Logged()} GROUP BY PA.Description";

            DAL objectDAL = new DAL();
            DataTable datatable = objectDAL.ReturnDataTable(sql);

            List<FinanceReport> List = new List<FinanceReport>();
            FinanceReport item;

            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                item = new FinanceReport();
                item.TotalValue = double.Parse(datatable.Rows[i]["TotalValue"].ToString());
                item.PlaneAccountName = datatable.Rows[i]["PlaneAccountName"].ToString();
                List.Add(item);
            }

            return List;
        }
    }
}
