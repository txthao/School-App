﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    class DiemMon
    {
        MonHoc mh;

        internal MonHoc MonHoc
        {
            get { return mh; }
            set { mh = value; }
        }

        
        string diemKT;

        public string DiemKT
        {
            get { return diemKT; }
            set { diemKT = value; }
        }
        string diemThi;

        public string DiemThi
        {
            get { return diemThi; }
            set { diemThi = value; }
        }
        string diemTK10;

        public string DiemTK10
        {
            get { return diemTK10; }
            set { diemTK10 = value; }
        }
        string diemChu;

        public string DiemChu
        {
            get { return diemChu; }
            set { diemChu = value; }
        }
        int hocky;
        public int Hocky
        {
            get { return hocky; }
            set { hocky = value; }
        }

        int namhoc;

        public int NamHoc
        {
            get { return namhoc; }
            set { namhoc = value; }
        }
    }
}
