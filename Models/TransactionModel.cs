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

        public string FinalDate { get; set; } //include to filter in Extract

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

            //Used to filter transactions in the extract view
            string filter = "";

            if(DateTransaction != null && (FinalDate != null))
            {
                filter += $" AND T.DateTransaction >= '{DateTime.Parse(DateTransaction).ToString("yyyy/MM/dd")}' AND T.DateTransaction <= '{DateTime.Parse(FinalDate).ToString("yyyy/MM/dd")}'";
            }

            if(Type != null)
            {
                if(Type != "A")
                {
                    filter += $" AND T.Type = '{Type}' ";
                }
            }

            if(Account_Id != 0)
            {
                filter += $" AND T.Account_Id = '{Account_Id}' ";

            }

            string id_User_Logged = __httpContextAccessor.HttpContext.Session.GetString("IdUserLogged");
            string sql = " SELECT T.Id, T.DateTransaction, T.Type, T.Value, T.Description, " +
                         " T.Account_Id, A.NameAccount, PlaneAccount_Id, PA.Description As NamePlaneAccount FROM Transaction T " +
                         " INNER JOIN Account A on A.Id = T.Account_Id " +
                         " INNER JOIN PlaneAccount PA on PA.Id = T.PlaneAccount_Id " +
                         $" WHERE T.User_Id = {id_User_Logged} {filter} ORDER BY T.DateTransaction DESC LIMIT 15";

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

        public TransactionModel LoadTransaction(int? Id)
        {
            TransactionModel item;
            string id_User_Logged = __httpContextAccessor.HttpContext.Session.GetString("IdUserLogged");
            string sql = " SELECT T.Id, T.DateTransaction, T.Type, T.Value, T.Description, " +
                         " T.Account_Id, A.NameAccount, PlaneAccount_Id, PA.Description As NamePlaneAccount FROM Transaction T " +
                         " INNER JOIN Account A on A.Id = T.Account_Id " +
                         " INNER JOIN PlaneAccount PA on PA.Id = T.PlaneAccount_Id " +
                         $" WHERE T.User_Id = {id_User_Logged} AND T.Id = '{Id}'";

            DAL objectDAL = new DAL();
            DataTable datatable = objectDAL.ReturnDataTable(sql);

            item = new TransactionModel();
            item.Id = int.Parse(datatable.Rows[0]["ID"].ToString());
            item.DateTransaction = DateTime.Parse(datatable.Rows[0]["DateTransaction"].ToString()).ToString("dd/MM/yyyy");
            item.Type = datatable.Rows[0]["Type"].ToString();
            item.Value = double.Parse(datatable.Rows[0]["Value"].ToString());
            item.Description = datatable.Rows[0]["Description"].ToString();
            item.Account_Id = int.Parse(datatable.Rows[0]["Account_Id"].ToString());
            item.NameAccount = datatable.Rows[0]["NameAccount"].ToString();
            item.PlaneAccount_Id = int.Parse(datatable.Rows[0]["PlaneAccount_Id"].ToString());
            item.NamePlaneAccount = datatable.Rows[0]["NamePlaneAccount"].ToString();
            
            return item;
        }

        public void RegisterTransaction()
        {
            string id_User_Logged = __httpContextAccessor.HttpContext.Session.GetString("IdUserLogged");
            string sql = "";

            if (Id == 0)
            {
                sql = "INSERT INTO TRANSACTION(DATETRANSACTION, TYPE, VALUE, DESCRIPTION, ACCOUNT_ID, PLANEACCOUNT_ID, USER_ID) " +
                      $" VALUES('{DateTime.Parse(DateTransaction).ToString("yyyy/MM/dd")}','{Type}','{Value}','{Description}','{Account_Id}','{PlaneAccount_Id}','{id_User_Logged}')";
            }
            else
            {
                sql = $"UPDATE TRANSACTION SET DATETRANSACTION = '{DateTime.Parse(DateTransaction).ToString("yyyy/MM/dd")}', " +
                      $" TYPE = '{Type}', " +
                      $" VALUE = '{Value}', " +
                      $" DESCRIPTION = '{Description}', " +
                      $" ACCOUNT_ID = '{Account_Id}', " +
                      $" PLANEACCOUNT_ID = '{PlaneAccount_Id}' " +
                      $"WHERE USER_ID = '{id_User_Logged}' AND ID = '{Id}'";
            }

            DAL objectDAL = new DAL();
            objectDAL.ExecuteCommandSql(sql);
        }

        public void Delete(int Id_Transaction)
        {
            new DAL().ExecuteCommandSql("DELETE FROM TRANSACTION WHERE ID = " + Id_Transaction);
        }
    }
}
