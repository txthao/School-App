using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SchoolApp
{
    class BDiemThi
    {
        static List<DiemThi> list;
        static void AddDiemMon(DiemMon dm)
        {
            string query = string.Format("select * from DiemMon where MaMH='{0}' and NamHoc={1} and HocKy={2}", dm.MonHoc.MaMH, dm.NamHoc, dm.Hocky);
            if (DataProvider.LoadData(query).Rows.Count==0)
            {
                string sql = string.Format("Insert into DiemMon values('{0}','{1}','{2}','{3}','{4}',{5},{6})", dm.MonHoc.MaMH, dm.DiemKT,dm.DiemThi,dm.DiemTK10,dm.DiemChu, dm.Hocky, dm.NamHoc);
                DataProvider.Insert(sql);
            }
        }
        public static List<DiemMon> getDiemMon(int namhoc, int hocky)
        {
            List<DiemMon> listct = new List<DiemMon>();
            string query = "select * from DiemMon where NamHoc=" + namhoc + " and HocKy=" + hocky;
            DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                DiemMon dm = new DiemMon();
                dm.Hocky = hocky;
                dm.NamHoc = namhoc;
                
                dm.DiemKT=db.Rows[i]["DiemKT"].ToString();
                dm.DiemThi = db.Rows[i]["DiemThi"].ToString();
                dm.DiemTK10 = db.Rows[i]["DiemTK10"].ToString();
                dm.DiemChu = db.Rows[i]["DiemChu"].ToString();
                dm.MonHoc.MaMH = db.Rows[i]["MaMH"].ToString();

                listct.Add(dm);
            }
            foreach (DiemMon dm in listct)
            {
                dm.MonHoc = BMonHoc.getByMaMH(dm.MonHoc.MaMH);
            }
            return listct;
        }

        public static List<DiemThi> getAll()
        {
            string query = "select * from DiemThi";
            list = new List<DiemThi>();
             DataTable db = DataProvider.LoadData(query);
             for (int i = 0; i < db.Rows.Count; i++)
             {
                 DiemThi dt = new DiemThi();
                 dt.Hocky=int.Parse(db.Rows[i]["HocKy"].ToString());
                 dt.NamHoc = int.Parse(db.Rows[i]["NamHoc"].ToString());
                 dt.DiemTB10 =db.Rows[i]["DiemTB10"].ToString();
                 dt.DiemTB4 = db.Rows[i]["DiemTB4"].ToString();
                 dt.DiemTBTL10 = db.Rows[i]["DiemTBTL10"].ToString();
                 dt.DiemTBTL4 = db.Rows[i]["DiemTBTL4"].ToString();
                 dt.SoTCDat = db.Rows[i]["SoTCDat"].ToString();
                 dt.SoTCTL = db.Rows[i]["SoTCTL"].ToString();
                 dt.DiemRL =db.Rows[i]["DiemRL"].ToString();
                 dt.LoaiRL = db.Rows[i]["LoaiRL"].ToString();
                
                 list.Add(dt);
             }
             foreach (DiemThi dt in list)
             {
                 dt.DiemMons = getDiemMon(dt.NamHoc, dt.Hocky);
             }
             return list;
        }

        public static void AddDiemThi(DiemThi dt)
        {
             string query = string.Format("select * from DiemThi where NamHoc={0} and HocKy={1}",dt.NamHoc,dt.Hocky);
             if (DataProvider.LoadData(query).Rows.Count==0)
             {
                 string sql = string.Format("Insert into DiemThi values({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", dt.Hocky, dt.NamHoc,dt.DiemTB10,dt.DiemTB4,dt.DiemTBTL10,dt.DiemTBTL4,dt.SoTCDat,dt.SoTCTL,dt.DiemRL,dt.LoaiRL);
                 DataProvider.Insert(sql);
             }
        }

        public static List<DiemThi> LoadDataFromSV(string id)
        {
            list = new List<DiemThi>();
            XmlDocument doc = new XmlDocument();

            doc.Load("http://localhost:56715/api/diemthi/"+id);
            XmlElement root = doc.DocumentElement;


            

            foreach (XmlNode node in root.ChildNodes)
            {
                DiemThi lt = new DiemThi();
                lt.DiemRL = node.ChildNodes[0].InnerText.Trim();
                lt.DiemMons = new List<DiemMon>();
                foreach (XmlNode nod in node.ChildNodes[5].ChildNodes)
                {
                    DiemMon dm = new DiemMon();
                    MonHoc mh = new MonHoc();
                    dm.Hocky = int.Parse(node.ChildNodes[9].InnerText.Trim()[7].ToString());
                    dm.NamHoc = int.Parse(node.ChildNodes[9].InnerText.Trim().Substring(17));
                    dm.DiemKT = nod.ChildNodes[0].InnerText;
                    dm.MonHoc = new MonHoc();
                    dm.MonHoc.MaMH = nod.ChildNodes[1].InnerText;
                    mh.MaMH = dm.MonHoc.MaMH;
                    mh.TenMH = nod.ChildNodes[5].InnerText;
                    mh.SoTC = int.Parse(nod.ChildNodes[4].InnerText);
                    mh.TileThi = int.Parse( nod.ChildNodes[3].InnerText.ToString());
                    dm.DiemThi = nod.ChildNodes[6].InnerText;
                    dm.DiemTK10 = nod.ChildNodes[7].InnerText;
                    dm.DiemChu = nod.ChildNodes[8].InnerText;
                    lt.DiemMons.Add(dm);
                    AddDiemMon(dm);
                    BMonHoc.AddMon(mh);
                    BMonHoc.UpdateMH(mh);
                }
                lt.DiemTB4 = node.ChildNodes[1].InnerText.Trim();
                lt.DiemTB10 = node.ChildNodes[2].InnerText.Trim();
                lt.DiemTBTL4 = node.ChildNodes[3].InnerText.Trim();
                lt.DiemTBTL10 = node.ChildNodes[4].InnerText.Trim();
                lt.LoaiRL = node.ChildNodes[6].InnerText.Trim();
                lt.SoTCDat = node.ChildNodes[7].InnerText.Trim();
                lt.SoTCTL = node.ChildNodes[8].InnerText.Trim();  
                lt.NamHoc = int.Parse(node.ChildNodes[9].InnerText.Trim().Substring(17));
                lt.Hocky = int.Parse(node.ChildNodes[9].InnerText.Trim()[7].ToString());

                AddDiemThi(lt);
                list.Add(lt);
            }

            return list;
        }

    }
}
