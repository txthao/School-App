using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    class BLichHoc
    {
        List<LichHoc> list;

        public List<LichHoc> getAll()
        {
            string query="select * from LichHoc";
            list = new List<LichHoc>();
            DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                LichHoc mh = new LichHoc();
                mh.Id = db.Rows[i]["Id"].ToString();
                mh.MaMH = db.Rows[i]["MaMH"].ToString();
                mh.MaLop = db.Rows[i]["MaLop"].ToString();
                mh.ThoigianBD = DateTime.Parse(db.Rows[i]["ThoigianBD"].ToString());
                mh.ThoigianKT = DateTime.Parse(db.Rows[i]["ThoigianKT"].ToString());
                mh.Chitiet = getChiTiets(mh.Id);
                list.Add(mh);
            }
            return list;
        }
        void AddLH(LichHoc lh)
        {
            string query = "select * from LichHoc where id='" + lh.Id+"'";
            if (DataProvider.LoadData(query) == null)
            {
                string sql = string.Format("Insert into LichHoc values('{0}','{1}','{2}','{3}',{4},{5})", lh.Id, lh.MaMH, lh.NhomMH, lh.MaLop, lh.ThoigianBD, lh.ThoigianKT);
                insertCT(lh.Chitiet);
                DataProvider.Insert(sql);
            }
        }
        void insertCT(List<chiTietLH> listCT)
        {
            string query;
            foreach (chiTietLH ct in listCT)
            {
                query = string.Format("inser into CHITIETLH values('{0}','{1}',{2},{3},'{4}','{5}'", ct.Id, ct.Thu, ct.TietBatDau, ct.SoTiet, ct.Phong, ct.CBGD);
                DataProvider.Insert(query);
            }
        }
        List<chiTietLH> getChiTiets(string id)
        {
            List<chiTietLH> listct=new List<chiTietLH>();
            string query = "select * from CHITIETLH where id=" + id;
             DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                chiTietLH ct=new chiTietLH();
                ct.Id=id;
                ct.Thu=db.Rows[i]["Thu"].ToString();
                ct.TietBatDau=int.Parse(db.Rows[i]["TietBatDau"].ToString());
                 ct.SoTiet=int.Parse(db.Rows[i]["SoTiet"].ToString());
                ct.Phong=db.Rows[i]["Phong"].ToString();
                ct.CBGD=db.Rows[i]["CBGD"].ToString();
                listct.Add(ct);
            }
            return listct;
        }
       
    }
}
