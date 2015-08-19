using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    class BUser
    {
        User getUser(string id,string password)
        {
            string query = "select * from User where Id=" + id+",Password="+password;
            DataTable db = DataProvider.LoadData(query);
            User user = new User();
            for (int i = 0; i < db.Rows.Count; i++)
            {
                user.Id = id;
                user.Password = password;
                user.Hoten = db.Rows[i]["HoTen"].ToString();
            }
            return user;
        }
        void AddUser(User user)
        {
            string query = "select * from User where id=" + user.Id;
            if (DataProvider.LoadData(query) == null)
            {
                string sql = string.Format("Insert into User values('{0}','{1}','{2}')", user.Id, user.Hoten, user.Password);
                DataProvider.Insert(sql);
            }
        }
    }
}
