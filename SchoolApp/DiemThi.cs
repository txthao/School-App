using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp
{
    class DiemThi
    {
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

        float diemTB10;

        public float DiemTB10
        {
            get { return diemTB10; }
            set { diemTB10 = value; }
        }
        float diemTB4;

        public float DiemTB4
        {
            get { return diemTB4; }
            set { diemTB4 = value; }
        }
        float diemTBTL10;

        public float DiemTBTL10
        {
            get { return diemTBTL10; }
            set { diemTBTL10 = value; }
        }
        float diemTBTL4;

        public float DiemTBTL4
        {
            get { return diemTBTL4; }
            set { diemTBTL4 = value; }
        }
        int soTCDat;

        public int SoTCDat
        {
            get { return soTCDat; }
            set { soTCDat = value; }
        }
        int soTCTL;

        public int SoTCTL
        {
            get { return soTCTL; }
            set { soTCTL = value; }
        }
        int diemRL;

        public int DiemRL
        {
            get { return diemRL; }
            set { diemRL = value; }
        }

        List<DiemMon> diemmons;

        internal List<DiemMon> DiemMons
        {
            get { return diemmons; }
            set { diemmons = value; }
        }

    }
}
