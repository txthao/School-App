using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    class BMonHoc
    {
        static List<MonHoc> list;
        public static void AddMon(MonHoc mh)
        {
            string sql;
            string query = string.Format("select * from MonHoc Where MaMH='{0}'", mh.MaMH);
            if (DataProvider.LoadData(query).Rows.Count == 0)
            {
                sql = string.Format(@"Insert into MonHoc values('{0}','{1}',{2},{3})", mh.MaMH, mh.TenMH, mh.SoTC, mh.TileThi);
                DataProvider.Insert(sql);
            }
           
        }
        public static MonHoc getByMaMH(string maMH)
        {
            MonHoc mh = new MonHoc();
            string query = string.Format("select * from MonHoc Where MaMH='{0}'", maMH);
            DataTable db = DataProvider.LoadData(query);
            if (db.Rows.Count >0)
            {
                mh.MaMH = db.Rows[0]["MaMH"].ToString();
                mh.TenMH = db.Rows[0]["TenMH"].ToString();
                mh.SoTC = int.Parse(db.Rows[0]["SoTC"].ToString());
                mh.TileThi = int.Parse(db.Rows[0]["TileThi"].ToString());
            }
            return mh;
        }
        public static List<MonHoc> GetAll()
        {
            string sql="Select * from MonHoc";
            list = new List<MonHoc>();
            DataTable db=DataProvider.LoadData(sql);
            for (int i=0;i<db.Rows.Count;i++)
            {
                MonHoc mh = new MonHoc();
                mh.MaMH = db.Rows[i]["MaMH"].ToString();
                mh.TenMH = db.Rows[i]["TenMH"].ToString();
                mh.SoTC = int.Parse(db.Rows[i]["SoTC"].ToString());
                mh.TileThi = int.Parse(db.Rows[i]["TileThi"].ToString());
                list.Add(mh);
            }
            return list;
            
        }

        public static void UpdateMH(MonHoc mh)
        {
            try
            {
                string query = string.Format("update MonHoc set TileThi={0} where MaMH='{1}'", mh.TileThi, mh.MaMH);
                DataProvider.ExecuteQuery(query);

            }
            catch
            {
            }
            
        }

    }
}
