﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    class LichThi
    {
        MonHoc monHoc;

        internal MonHoc MonHoc
        {
            get { return monHoc; }
            set { monHoc = value; }
        }
        string ghepThi;

        public string GhepThi
        {
            get { return ghepThi; }
            set { ghepThi = value; }
        }
        string toThi;

        public string ToThi
        {
            get { return toThi; }
            set { toThi = value; }
        }
        int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        string ngayThi;

        public string NgayThi
        {
            get { return ngayThi; }
            set { ngayThi = value; }
        }
        string gioBD;

        public string GioBD
        {
            get { return gioBD; }
            set { gioBD = value; }
        }
        int soPhut;

        public int SoPhut
        {
            get { return soPhut; }
            set { soPhut = value; }
        }
        string phongThi;

        public string PhongThi
        {
            get { return phongThi; }
            set { phongThi = value; }
        }
    }
}
