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
            txtID.Text = "3112410012";
        }

        private void btgetLH_Click(object sender, EventArgs e)
        {

        }

        private void btgetLT_Click(object sender, EventArgs e)
        {
            BLichThi.LoadDataFromSV(txtID.Text.Trim());
            grid1.DataSource = null;
            grid1.DataSource = BLichThi.getAll();
        }

        private void btgetDT_Click(object sender, EventArgs e)
        {
            BDiemThi.LoadDataFromSV(txtID.Text.Trim());
            grid1.DataSource = null;

            grid1.DataSource = BDiemThi.getAll();

        }
    }
}
