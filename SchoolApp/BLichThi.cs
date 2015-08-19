using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    class BLichThi
    {
        List<LichThi> list;
        List<LichThi> getAll()
        {
            list = new List<LichThi>();
            string query = "select * from LichThi";
            DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                LichThi lt = new LichThi();
                lt.MaMH = db.Rows[i]["MaMH"].ToString();
                lt.GhepThi = db.Rows[i]["GhepThi"].ToString();
                lt.ToThi = db.Rows[i]["ToThi"].ToString();
                lt.SoLuong = int.Parse(db.Rows[i]["SoLuong"].ToString());
                lt.NgayThi = db.Rows[i]["MaMH"].ToString();
                lt.GioBD = db.Rows[i]["GioBD"].ToString();
                lt.SoPhut = int.Parse(db.Rows[i]["SoPhut"].ToString());
                lt.PhongThi = db.Rows[i]["PhongThi"].ToString();
                list.Add(lt);
            }
            return list;
        }
        void AddLT(LichThi lt)
        {
            string query = "select * from LichThi where MaMH="+lt.MaMH+",NgayThi="+lt.NgayThi;
            if (DataProvider.LoadData(query) == null)
            {
                string sql = string.Format("Insert into LichThi values('{0}','{1}','{2}',{3},'{4}','{5}',{6},'{7}')", lt.MaMH, lt.GhepThi, lt.ToThi, lt.SoLuong, lt.NgayThi, lt.GioBD, lt.SoPhut, lt.PhongThi);
                DataProvider.Insert(sql);
            
            }

        }
    }
}
