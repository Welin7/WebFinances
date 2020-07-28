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
        [Required(ErrorMessage = "Enter your description.")]
        public string Description { get; set; }
        public string Type { get; set; }
        public int User_Id { get; set; }

        public IHttpContextAccessor __httpContextAccessor { get; set; }

        public PlaneAccountModel()
        {

        }
        private string id_User_Logged()
        {
            return __httpContextAccessor.HttpContext.Session.GetString("IdUserLogged");
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
            string sql = $"SELECT ID, DESCRIPTION, TYPE, USER_ID FROM PLANEACCOUNT WHERE USER_ID = {id_User_Logged()}";
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

        //metod load record to edition pass id
        public PlaneAccountModel LoadRecords(int? Id)
        {
            PlaneAccountModel item = new PlaneAccountModel();
            string sql = $"SELECT ID, DESCRIPTION, TYPE, USER_ID FROM PLANEACCOUNT WHERE USER_ID = {id_User_Logged()} AND ID = {Id}";
            DAL objectDAL = new DAL();
            DataTable datatable = objectDAL.ReturnDataTable(sql);

            item.Id = int.Parse(datatable.Rows[0]["ID"].ToString());
            item.Description = datatable.Rows[0]["Description"].ToString();
            item.Type = datatable.Rows[0]["Type"].ToString();
            item.User_Id = int.Parse(datatable.Rows[0]["User_Id"].ToString());

            return item;
        }

        public void RegisterPlaneAccount()
        {
            string sql = "";
            
            if(Id == 0)
            {
                sql = $"INSERT INTO PLANEACCOUNT(DESCRIPTION, TYPE, USER_ID) VALUES('{Description}','{Type}','{id_User_Logged()}')";
            }
            else
            {
                sql = $"UPDATE PLANEACCOUNT SET DESCRIPTION = '{Description}', Type = '{Type}' WHERE USER_ID = '{id_User_Logged()}' AND ID = '{Id}'";
            }
            
            DAL objectDAL = new DAL();
            objectDAL.ExecuteCommandSql(sql);
        }

        public void DeletePlaneAccount(int Id_Account)
        {
            new DAL().ExecuteCommandSql("DELETE FROM PLANEACCOUNT WHERE ID = " + Id_Account);
        }
    }
}
