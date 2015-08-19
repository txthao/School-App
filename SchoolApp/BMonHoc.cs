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
        List<MonHoc> list;
        public void AddMon(MonHoc mh)
        {
            string sql;
            sql=string.Format("Insert into MonHoc values('{0}'.'{1}',{2},{3}",mh.MaMH,mh.TenMH,mh.SoTC,mh.TileThi);
            DataProvider.Insert(sql);
        }

        public List<MonHoc> GetAll()
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
    }
}
