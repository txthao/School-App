using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             BLichThi.LoadDataFromSV("1");
             BDiemThi.LoadDataFromSV("1");
             grid1.DataSource = BDiemThi.getAll();
        }
    }
}
