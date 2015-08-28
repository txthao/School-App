﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SchoolApp
{
    class BLichThi
    {
       public static List<LichThi> list;
       public static List<LichThi> getAll()
        {
            list = new List<LichThi>();
            string query = "select * from LichThi";
            DataTable db = DataProvider.LoadData(query);
            for (int i = 0; i < db.Rows.Count; i++)
            {
                LichThi lt = new LichThi();
                lt.MonHoc = new MonHoc();
                lt.MonHoc.MaMH = db.Rows[i]["MaMH"].ToString();
                lt.GhepThi = db.Rows[i]["GhepThi"].ToString();
                lt.ToThi = db.Rows[i]["ToThi"].ToString();
                lt.SoLuong = int.Parse(db.Rows[i]["SoLuong"].ToString());
                lt.NgayThi = db.Rows[i]["NgayThi"].ToString();
                lt.GioBD = db.Rows[i]["GioBD"].ToString();
                lt.SoPhut = int.Parse(db.Rows[i]["SoPhut"].ToString());
                lt.PhongThi = db.Rows[i]["PhongThi"].ToString();
                list.Add(lt);
            }
            foreach (LichThi lt in list)
            {
                lt.MonHoc = BMonHoc.getByMaMH(lt.MonHoc.MaMH);
            }
            return list;
        }
        static void AddLT(LichThi lt)
        {
            
            string query = string.Format("select * from LichThi where MaMH='{0}' and NgayThi='{1}'",lt.MonHoc.MaMH,lt.NgayThi);
            
            if (DataProvider.LoadData(query).Rows.Count==0)
            {
                string sql = string.Format("Insert into LichThi values('{0}','{1}','{2}',{3},'{4}','{5}',{6},'{7}')", lt.MonHoc.MaMH, lt.GhepThi, lt.ToThi, lt.SoLuong, lt.NgayThi, lt.GioBD, lt.SoPhut, lt.PhongThi);
                DataProvider.Insert(sql);
            
            }

        }

        public  static List<LichThi> LoadDataFromSV(string id)
        {
            list = new List<LichThi>();
            XmlDocument doc = new XmlDocument();
           
            doc.Load("http://localhost:56715/api/lichthi/"+id);
            XmlElement root = doc.DocumentElement;

           
            

            foreach (XmlNode node in root.ChildNodes)
            {
                LichThi lt = new LichThi();
                lt.GhepThi = node.ChildNodes[0].InnerText.Trim();
                lt.GioBD = node.ChildNodes[1].InnerText.Trim();
                lt.MonHoc = new MonHoc();
                lt.MonHoc.MaMH = node.ChildNodes[3].InnerText.Trim();
                lt.MonHoc.TenMH=node.ChildNodes[8].InnerText.Trim();
                lt.NgayThi = node.ChildNodes[4].InnerText.Trim();
                lt.PhongThi = node.ChildNodes[5].InnerText.Trim();
                lt.SoLuong = int.Parse(node.ChildNodes[6].InnerText.Trim());
                lt.SoPhut = int.Parse(node.ChildNodes[7].InnerText.Trim());
                lt.ToThi = node.ChildNodes[9].InnerText.Trim();
                list.Add(lt);
                BMonHoc.AddMon(lt.MonHoc);
                AddLT(lt);
            }
           
            return list;
        }

    }
}
