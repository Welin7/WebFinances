using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebFinancas.DataLayer;

namespace WebFinancas.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public string NameAccount { get; set; }

        public double Balance { get; set; }

        public int User_Id { get; set; }

        public List<AccountModel> ListAccount()
        {
            List<AccountModel> List = new List<AccountModel>();
            AccountModel item;
            string id_User_Logged = "1";
            string sql = $"SELECT ID, NAMEACCOUNT, BALANCE, USER_ID FROM ACCOUNT WHERE USER_ID = {id_User_Logged}";
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
    }
}
