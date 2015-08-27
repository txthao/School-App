using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SchoolApp
{
    class BUser
    {
        public static User getUser(string id, string password)
        {
            string query = "select * from User where Id='" + id+"' and Password='"+password+"'";
            DataTable db = DataProvider.LoadData(query);
            User user = new User();
            user.Id = id;
            user.Password = password;
            if (db.Rows.Count == 0)
            {
                user.Hoten = getNameFromSV(id);
                AddUser(user);
            }
            else
            {
                for (int i = 0; i < db.Rows.Count; i++)
                {

                    user.Hoten = db.Rows[i]["HoTen"].ToString();
                }
            }

            return user;
        }

        public static User getUser(string id)
        {
            string query = "select * from User where Id='" + id + "'";
            DataTable db = DataProvider.LoadData(query);
            User user = new User();
              user.Id = id;
            if (db.Rows.Count == 0)
            {
                user.Hoten = getNameFromSV(id);
                AddUser(user);
            }
            else
            {
                for (int i = 0; i < db.Rows.Count; i++)
                {
                   
                    
                    user.Hoten = db.Rows[i]["HoTen"].ToString();
                }
            }
            return user;
        }

        static void AddUser(User user)
        {
            string query = "select * from User where Id='" + user.Id+"'";
            if (DataProvider.LoadData(query).Rows.Count==0)
            {
                string sql = string.Format("Insert into User values('{0}','{1}','{2}')", user.Id, user.Hoten, user.Password);
                DataProvider.Insert(sql);
            }
        }

        public static string getNameFromSV(string id)
        {
            
        
            XmlDocument doc = new XmlDocument();
            doc.Load("http://localhost:56715/api/user/" + id);
            XmlNode node = doc.DocumentElement.FirstChild;
            return node.ChildNodes[1].InnerText;
            
        }

    }
}
