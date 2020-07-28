using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebFinancas.DataLayer;

namespace WebFinancas.Models
{
    public class UserModel
    {
        public int Id { get; set;}

        [Required(ErrorMessage = "Enter your name.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Enter your email.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Informed email is not valid.")]
        public string Email_Adress { get; set; }

        [Required(ErrorMessage = "Enter your password.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter your date birth.")]
        public string Date_Birth { get; set; }

        public bool ValidateLogin()
        {
            string sql = $"SELECT ID, NAME, DATE_BIRTH FROM USERS WHERE EMAIL_ADRESS = '{Email_Adress}' AND PASSWORD = '{Password}'";
            DAL objectDAL = new DAL();
            DataTable datatable = objectDAL.ReturnDataTable(sql);

            if(datatable != null)
            {
                if(datatable.Rows.Count == 1)
                {
                    Id = int.Parse(datatable.Rows[0]["Id"].ToString());
                    name = datatable.Rows[0]["Name"].ToString();
                    Date_Birth = datatable.Rows[0]["Date_Birth"].ToString();
                    return true;
                }
            }

            return false;
        }

        public void RegisterUser()
        {
            string Date_Rebirth_Format = DateTime.Parse(Date_Birth).ToString("yyyy/MM/dd");
            string sql = $"INSERT INTO USERS(NAME, EMAIL_ADRESS, PASSWORD, DATE_BIRTH) VALUES('{name}','{Email_Adress}','{Password}','{Date_Rebirth_Format}')";
            DAL objectDAL = new DAL();
            objectDAL.ExecuteCommandSql(sql);
        }
    }
}
