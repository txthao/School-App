using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SchoolApp
{
    class BHocPhi
    {
        public static List<HocPhi> list;

        public static List<CTHocPhi> getCTHP(int NamHoc, int HocKy)
        {
            string query =string.Format("select * from CTHocPhi where NamHoc={0} and HocKy={1}",NamHoc,HocKy);
            List<CTHocPhi> listct = new List<CTHocPhi>();
            DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                CTHocPhi ct = new CTHocPhi();
                ct.monHoc=BMonHoc.getByMaMH(db.Rows[i]["MaMH"].ToString());
               
                ct.HocPhi = db.Rows[i]["HocPhi"].ToString();
                ct.MienGiam = db.Rows[i]["MienGiam"].ToString();
                ct.MaNhom = db.Rows[i]["MaNhom"].ToString();
                ct.PhaiDong = db.Rows[i]["PhaiDong"].ToString();
                ct.NamHoc = int.Parse(db.Rows[i]["NamHoc"].ToString());
                ct.HocKy = int.Parse(db.Rows[i]["HocKy"].ToString());

                listct.Add(ct);
            }
            return listct;
        }


        public static void AddCTHP(CTHocPhi ct)
        {
            string query = string.Format("select * from CTHocPhi where MaMH='{0}' and NamHoc={1} and HocKy={2}", ct.monHoc.MaMH, ct.NamHoc, ct.HocKy);
            if (DataProvider.LoadData(query).Rows.Count == 0)
            {
                try
                {
                    string sql = string.Format("Insert into CTHocPhi values('{0}','{1}','{2}','{3}','{4}',{5},{6})", ct.monHoc.MaMH,ct.MaNhom, ct.HocPhi, ct.MienGiam,ct.PhaiDong, ct.NamHoc, ct.HocKy);
                    DataProvider.Insert(sql);
                }
                catch
                {

                }
            }
        }


        public static List<HocPhi> getAll()
        {
            string query = "select * from HocPhi";
            list = new List<HocPhi>();
             DataTable db = DataProvider.LoadData(query);
             for (int i = 0; i < db.Rows.Count; i++)
             {
                 HocPhi hp = new HocPhi();
                 hp.TongSoTC = db.Rows[i]["TongSoTC"].ToString();
                 hp.TongSoTien = db.Rows[i]["TongSoTien"].ToString();
                 hp.TienDongTTLD = db.Rows[i]["TienDongTTLD"].ToString();
                 hp.TienDaDong = db.Rows[i]["TienDaDong"].ToString();
                 hp.TienConNo = db.Rows[i]["TienConNo"].ToString();
                 hp.HocKy = int.Parse(db.Rows[i]["NamHoc"].ToString());
                 hp.NamHoc = int.Parse(db.Rows[i]["HocKy"].ToString());
                 list.Add(hp);
             }
             foreach (HocPhi hp in list)
             {
                 hp.ListCTHP = getCTHP(hp.NamHoc, hp.HocKy);
             }
             return list;
        }

        public static void AddHP(HocPhi hp)
        {
            string query = string.Format("select * from HocPhi where NamHoc={0} and HocKy={1}", hp.NamHoc, hp.HocKy);
                        if (DataProvider.LoadData(query).Rows.Count == 0)
            {
                try
                {
                    string sql = string.Format("insert into HocPhi values('{0}','{1}','{2}','{3}','{4}',{5},{6})",hp.TongSoTC,hp.TongSoTien,hp.TienDongTTLD,hp.TienDaDong,hp.TienConNo,hp.NamHoc,hp.HocKy);
                    DataProvider.Insert(sql);
                    foreach (CTHocPhi ct in hp.ListCTHP)
                    {
                        AddCTHP(ct);
                    }
                }
                catch
                {

                }
            }
        }


        public static HocPhi LoadDataFromSV(string id, string password)
        {
            
            XmlDocument doc = new XmlDocument();

            doc.Load("http://localhost:56715/api/hocphi");
            XmlElement root = doc.DocumentElement;

            XmlNode node = root;
            HocPhi hp = new HocPhi();
            hp.HocKy = int.Parse(node.ChildNodes[1].InnerText[7].ToString());
            hp.NamHoc = int.Parse(node.ChildNodes[1].InnerText.Substring(19, 4));
            hp.TienConNo = node.ChildNodes[2].InnerText;
            hp.TienDaDong = node.ChildNodes[3].InnerText;
            hp.TienDongTTLD = node.ChildNodes[4].InnerText;
            hp.TongSoTC = node.ChildNodes[5].InnerText;
            hp.TongSoTien = node.ChildNodes[6].InnerText;
            hp.ListCTHP = new List<CTHocPhi>();
            foreach (XmlNode node1 in node.ChildNodes[0].ChildNodes)
            {
                CTHocPhi ct = new CTHocPhi();
                ct.HocPhi = node1.ChildNodes[0].InnerText;
                ct.MaNhom = node1.ChildNodes[1].InnerText;
                ct.MienGiam = node1.ChildNodes[2].InnerText;
                ct.PhaiDong = node1.ChildNodes[3].InnerText;
                ct.HocKy = hp.HocKy;
                ct.NamHoc = hp.NamHoc;
                ct.monHoc = new MonHoc();
                ct.monHoc.MaMH = node1.ChildNodes[4].ChildNodes[1].InnerText;
                hp.ListCTHP.Add(ct);
            }
            AddHP(hp);
            
            return hp;
        }

    }
}
