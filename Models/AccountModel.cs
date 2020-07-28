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
    public class AccountModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter your account name.")]
        public string NameAccount { get; set; }
        
        [Required(ErrorMessage = "Enter your account balance.")]
        public double Balance { get; set; }

        public int User_Id { get; set; }
        
        public IHttpContextAccessor __httpContextAccessor { get; set; }

        public AccountModel()
        {

        }

        private string id_User_Logged()
        {
            return __httpContextAccessor.HttpContext.Session.GetString("IdUserLogged");
        }
        //Receives the context for access to session variables
        public AccountModel(IHttpContextAccessor httpContextAccessor)
        {
            __httpContextAccessor = httpContextAccessor;
        }

        public List<AccountModel> ListAccount()
        {
            List<AccountModel> List = new List<AccountModel>();
            AccountModel item;
            string sql = $"SELECT ID, NAMEACCOUNT, BALANCE, USER_ID FROM ACCOUNT WHERE USER_ID = {id_User_Logged()}";
            DAL objectDAL = new DAL();
            DataTable datatable = objectDAL.ReturnDataTable(sql);

            for(int i = 0; i < datatable.Rows.Count; i++)
            {
                item = new AccountModel();
                item.Id = int.Parse(datatable.Rows[i]["ID"].ToString());
                item.NameAccount = datatable.Rows[i]["NameAccount"].ToString();
                item.Balance = double.Parse(datatable.Rows[i]["Balance"].ToString());
                item.User_Id = int.Parse(datatable.Rows[i]["User_Id"].ToString());
                List.Add(item);
            }

            return List;
        }

        public void RegisterAccount()
        {
            string sql = $"INSERT INTO ACCOUNT(NAMEACCOUNT, BALANCE, USER_ID) VALUES('{NameAccount}','{Balance}','{id_User_Logged()}')";
            DAL objectDAL = new DAL();
            objectDAL.ExecuteCommandSql(sql);
        }

        public void DeleteAccount(int Id_Account)
        {
            new DAL().ExecuteCommandSql("DELETE FROM ACCOUNT WHERE ID = " + Id_Account);
        }
    }
}
