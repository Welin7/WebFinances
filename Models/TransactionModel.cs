using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebFinancas.DataLayer;

namespace WebFinancas.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the Date of Transaction.")]
        public string DateTransaction { get; set; }

        public string Type { get; set; }

        [Required(ErrorMessage = "Enter the Value.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Enter the Description.")]
        public string Description { get; set; }

        public int Account_Id { get; set; }

        public string NameAccount { get; set; }

        public int PlaneAccount_Id { get; set; }

        public string NamePlaneAccount { get; set; }

        public int User_Id { get; set; }

        public IHttpContextAccessor __httpContextAccessor { get; set; }

        public TransactionModel()
        {

        }

        //Receives the context for access to session variables
        public TransactionModel(IHttpContextAccessor httpContextAccessor)
        {
            __httpContextAccessor = httpContextAccessor;
        }

        public List<TransactionModel> ListTransaction()
        {
            List<TransactionModel> List = new List<TransactionModel>();
            TransactionModel item;
            string id_User_Logged = __httpContextAccessor.HttpContext.Session.GetString("IdUserLogged");
            string sql = " SELECT T.Id, T.DateTransaction, T.Type, T.Value, T.Description, " +
                         " T.Account_Id, A.NameAccount, PlaneAccount_Id, PA.Description As NamePlaneAccount FROM Transaction T " +
                         " INNER JOIN Account A on A.Id = T.Account_Id " +
                         " INNER JOIN PlaneAccount PA on PA.Id = T.PlaneAccount_Id " +
                         $" WHERE T.User_Id = {id_User_Logged} ORDER BY T.DateTransaction DESC LIMIT 10";

            DAL objectDAL = new DAL();
            DataTable datatable = objectDAL.ReturnDataTable(sql);

            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                item = new TransactionModel();
                item.Id = int.Parse(datatable.Rows[i]["ID"].ToString());
                item.DateTransaction = DateTime.Parse(datatable.Rows[i]["DateTransaction"].ToString()).ToString("dd/MM/yyyy");               
                item.Type = datatable.Rows[i]["Type"].ToString();
                item.Value = double.Parse(datatable.Rows[i]["Value"].ToString());
                item.Description = datatable.Rows[i]["Description"].ToString();
                item.Account_Id = int.Parse(datatable.Rows[i]["Account_Id"].ToString());
                item.NameAccount = datatable.Rows[i]["NameAccount"].ToString();
                item.PlaneAccount_Id = int.Parse(datatable.Rows[i]["PlaneAccount_Id"].ToString());
                item.NamePlaneAccount = datatable.Rows[i]["NamePlaneAccount"].ToString();
                List.Add(item);
            }

            return List;
        }
    }
}
