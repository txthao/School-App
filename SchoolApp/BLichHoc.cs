﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SchoolApp
{
    class BLichHoc
    {
        

        public static List<LichHoc> list;

        public static List<LichHoc> getAll()
        {
            string query = "select * from LichHoc";
            list = new List<LichHoc>();
            DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                LichHoc mh = new LichHoc();
                mh.Id = db.Rows[i]["Id"].ToString();
                
                mh.MaLop = db.Rows[i]["MaLop"].ToString();
                mh.ThoigianBD = db.Rows[i]["ThoigianBD"].ToString();
                mh.ThoigianKT = db.Rows[i]["ThoigianKT"].ToString();
                mh.NhomMH = db.Rows[i]["NhomMH"].ToString();
                mh.MonHoc = new MonHoc();
                mh.MonHoc.MaMH = db.Rows[i]["MaMH"].ToString();
               
                list.Add(mh);
            }
            foreach (LichHoc lh in list)
            {
                lh.Chitiet = getChiTiets(lh.Id);
                lh.MonHoc = BMonHoc.getByMaMH(lh.MonHoc.MaMH);
            }
            return list;
        }

        public static int getID()
        {

            string query = "select  * from LichHoc ORDER BY Id DESC LIMIT 1";

            DataTable db = DataProvider.LoadData(query);
            if (db.Rows.Count == 0)
                return 1;
            int k = int.Parse(db.Rows[0][0].ToString());
            return k+1;
        }


        static void AddLH(LichHoc lh)
        {
            string query = "select * from LichHoc where MaMH='" + lh.MonHoc.MaMH+"'";
            if (DataProvider.LoadData(query).Rows.Count==0)
            {
                string sql = string.Format("Insert into LichHoc values('{0}','{1}','{2}','{3}','{4}','{5}')", lh.Id, lh.MonHoc.MaMH, lh.NhomMH, lh.MaLop, lh.ThoigianBD, lh.ThoigianKT);
                DataProvider.Insert(sql);
                insertCT(lh.Chitiet);
            }
        }
        static void insertCT(List<chiTietLH> listCT)
        {
            string query;
            foreach (chiTietLH ct in listCT)
            {
                query = string.Format("insert into CHITIETLH values('{0}','{1}','{2}','{3}','{4}','{5}')", ct.Id, ct.Thu, ct.TietBatDau, ct.SoTiet, ct.Phong, ct.CBGD);
                DataProvider.Insert(query);
            }
        }
        static List<chiTietLH> getChiTiets(string id)
        {
            List<chiTietLH> listct = new List<chiTietLH>();
            string query = "select * from CHITIETLH where Id='" + id+"'";
            DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                chiTietLH ct = new chiTietLH();
                ct.Id = id;
                ct.Thu = db.Rows[i]["Thu"].ToString();
                ct.TietBatDau = db.Rows[i]["TietBD"].ToString();
                ct.SoTiet = db.Rows[i]["SoTiet"].ToString();
                ct.Phong = db.Rows[i]["Phong"].ToString();
                ct.CBGD = db.Rows[i]["CBGD"].ToString();
                listct.Add(ct);
            }
            return listct;
        }
        public static List<LichHoc> LoadDataFromSV(string id)
        {
            list = new List<LichHoc>();
            XmlDocument doc = new XmlDocument();

            doc.Load("http://localhost:56715/api/thoikhoabieu/"+id);
            XmlElement root = doc.DocumentElement;



            int k = getID();
            foreach (XmlNode node in root.ChildNodes)
            {
                LichHoc lh = new LichHoc();
                MonHoc mh = new MonHoc();
                lh.Id = k.ToString() ;
                lh.MonHoc = new MonHoc();
                lh.MonHoc.MaMH = node.ChildNodes[2].InnerText.Trim();
                lh.MaLop = node.ChildNodes[1].InnerText.Trim();
                lh.NhomMH = node.ChildNodes[3].InnerText.Trim();
                mh.MaMH = lh.MonHoc.MaMH;
                mh.TenMH = node.ChildNodes[7].InnerText.Trim();
                mh.SoTC=int.Parse(node.ChildNodes[5].InnerText.Trim());
                mh.TileThi = 0;
                lh.ThoigianBD = node.ChildNodes[10].InnerText.Trim().Substring(0, 10);
                lh.ThoigianKT = node.ChildNodes[10].InnerText.Trim().Substring(12);
                List<chiTietLH> listct = new List<chiTietLH>();
                // constant
                int one = 1;
                int five = 5;
                for (int i = 0; i < node.ChildNodes[8].InnerText.Trim().Length; i++)
                {
                    chiTietLH ct = new chiTietLH();
                    ct.Id = k.ToString();
                    string magv = node.ChildNodes[0].InnerText.Trim().Substring(i * five, five);
                    ct.CBGD = BUser.getUser(magv).Hoten;
                    ct.Phong = node.ChildNodes[4].InnerText.Trim().Substring(i * 6, 6);
                    ct.Thu = node.ChildNodes[8].InnerText.Trim().Substring(i * one, one);
                    ct.TietBatDau = node.ChildNodes[9].InnerText.Trim().Substring(i * one, one);//tiet bat dau = 10

                    ct.SoTiet = node.ChildNodes[6].InnerText.Trim()[i].ToString();
                    listct.Add(ct);
                }
                lh.Chitiet = listct;
                list.Add(lh);
                AddLH(lh);
                BMonHoc.AddMon(mh);
                k++;
            }

            return list;
        }



    }
}
