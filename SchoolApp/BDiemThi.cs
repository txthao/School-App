using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    class BDiemThi
    {
        List<DiemThi> list;
        void AddDiemMon(DiemMon dm)
        {
            string query = "select * from DiemMon where MaMH='" + dm.MaMH + "',NamHoc=" + dm.NamHoc+",HocKy="+dm.Hocky;
            if (DataProvider.LoadData(query) == null)
            {
                string sql = string.Format("Insert into DiemMon values('{0}',{1},{2},{3},'{4}',{5},{6})", dm.MaMH, dm.DiemKT,dm.DiemThi,dm.DiemTK10,dm.DiemChu, dm.Hocky, dm.NamHoc);
                DataProvider.Insert(sql);
            }
        }
        List<DiemMon> getDiemMon(int namhoc, int hocky)
        {
            List<DiemMon> listct = new List<DiemMon>();
            string query = "select * from DiemMon where NamHoc=" + namhoc + ",HocKy=" + hocky;
            DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                DiemMon dm = new DiemMon();
                dm.Hocky = hocky;
                dm.NamHoc = namhoc;
                dm.MaMH = db.Rows[i]["MaMH"].ToString();
                dm.DiemKT=float.Parse(db.Rows[i]["DiemKT"].ToString());
                dm.DiemThi = float.Parse(db.Rows[i]["DiemThi"].ToString());
                dm.DiemTK10 = float.Parse(db.Rows[i]["DiemTK10"].ToString());
                dm.DiemChu = db.Rows[i]["DiemChu"].ToString();

                listct.Add(dm);
            }

            return listct;
        }

        List<DiemThi> getAll()
        {
            string query = "select * from DiemThi";
            list = new List<DiemThi>();
             DataTable db = DataProvider.LoadData(query);
             for (int i = 0; i < db.Rows.Count; i++)
             {
                 DiemThi dt = new DiemThi();
                 dt.Hocky=int.Parse(db.Rows[i]["HocKy"].ToString());
                 dt.NamHoc = int.Parse(db.Rows[i]["NamHoc"].ToString());
                 dt.DiemTB10 = float.Parse(db.Rows[i]["DiemTB10"].ToString());
                 dt.DiemTB4 = float.Parse(db.Rows[i]["DiemTB4"].ToString());
                 dt.DiemTBTL10 = float.Parse(db.Rows[i]["DiemTBTL10"].ToString());
                 dt.DiemTBTL4 = float.Parse(db.Rows[i]["DiemTBTL4"].ToString());
                 dt.SoTCDat = int.Parse(db.Rows[i]["SoTCDat"].ToString());
                 dt.SoTCTL = int.Parse(db.Rows[i]["SoTCTL"].ToString());
                 dt.DiemRL = int.Parse(db.Rows[i]["DiemRL"].ToString());
                 dt.DiemMons = getDiemMon(dt.NamHoc, dt.Hocky);
                 list.Add(dt);
             }
             return list;
        }

        public void AddDiemThi(DiemThi dt)
        {
             string query = "select * from DiemThi where NamHoc=" + dt.NamHoc + ",HocKy=" + dt.Hocky;
             if (DataProvider.LoadData(query) == null)
             {
                 string sql = string.Format("Insert into DiemThi values({0},{1},{2},{3},{4},{5},{6},{7},{8})", dt.Hocky, dt.NamHoc,dt.DiemTB10,dt.DiemTB4,dt.DiemTBTL10,dt.DiemTBTL4,dt.SoTCDat,dt.SoTCTL,dt.DiemRL);
                 DataProvider.Insert(sql);
             }
        }


    }
}
