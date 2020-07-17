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
    public class PlaneAccountModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your Description.")]
        public string Description { get; set; }
        public string Type { get; set; }
        public int User_Id { get; set; }

        public IHttpContextAccessor __httpContextAccessor { get; set; }

        public PlaneAccountModel()
        {

        }

        //Receives the context for access to session variables
        public PlaneAccountModel(IHttpContextAccessor httpContextAccessor)
        {
            __httpContextAccessor = httpContextAccessor;
        }

        public List<PlaneAccountModel> ListPlaneAccount()
        {
            List<PlaneAccountModel> List = new List<PlaneAccountModel>();
            PlaneAccountModel item;
            string id_User_Logged = __httpContextAccessor.HttpContext.Session.GetString("IdUserLogged");
            string sql = $"SELECT ID, DESCRIPTION, TYPE, USER_ID FROM PLANEACCOUNT WHERE USER_ID = {id_User_Logged}";
            DAL objectDAL = new DAL();
            DataTable datatable = objectDAL.ReturnDataTable(sql);

            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                item = new PlaneAccountModel();
                item.Id = int.Parse(datatable.Rows[i]["ID"].ToString());
                item.Description = datatable.Rows[i]["Description"].ToString();
                item.Type = datatable.Rows[i]["Type"].ToString();
                item.User_Id = int.Parse(datatable.Rows[i]["User_Id"].ToString());
                List.Add(item);
            }

            return List;
        }

        public void RegisterPlaneAccount()
        {
            string id_User_Logged = __httpContextAccessor.HttpContext.Session.GetString("IdUserLogged");
            string sql = $"INSERT INTO PLANEACCOUNT(DESCRIPTION, TYPE, USER_ID) VALUES('{Description}','{Type}','{id_User_Logged}')";
            DAL objectDAL = new DAL();
            objectDAL.ExecuteCommandSql(sql);
        }

        public void DeletePlaneAccount(int Id_Account)
        {
            new DAL().ExecuteCommandSql("DELETE FROM PLANEACCOUNT WHERE ID = " + Id_Account);
        }
    }
}
