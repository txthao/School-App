using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    class BHocPhi
    {
        public static List<HocPhi> list;

        public static List<HocPhi> getAll()
        {
            string query = "select * from HocPhi";
            list = new List<HocPhi>();
            DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                HocPhi hp = new HocPhi();
                hp.MaMH = db.Rows[i]["MaMH"].ToString();
               
                hp.HocPhi1 = db.Rows[i]["HocPhi"].ToString();
                hp.MienGiam = db.Rows[i]["MienGiam"].ToString();
                hp.NamHoc = int.Parse(db.Rows[i]["NamHoc"].ToString());
                hp.HocKy = int.Parse(db.Rows[i]["HocKy"].ToString());


                list.Add(hp);
            }
           
            return list;
        }
        public static void AddHP(HocPhi hp)
        {
            string query = string.Format("select * from HocPhi where MaMH='{0}' and NamHoc={1} and HocKy={2}",hp.MaMH,hp.NamHoc,hp.HocKy);
            if (DataProvider.LoadData(query).Rows.Count == 0)
            {
                try
                {
                    string sql = string.Format("Insert into HocPhi values('{0}','{1}','{2}',{3},{4})", hp.MaMH, hp.HocPhi1, hp.MienGiam, hp.NamHoc, hp.HocKy);
                    DataProvider.Insert(sql);
                }
                catch
                {

                }
            }
        }

    }
}
