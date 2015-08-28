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
            lbName.Text = BUser.getUser(txtID.Text.Trim()).Hoten;

            BLichHoc.LoadDataFromSV(txtID.Text.Trim());
            grid1.DataSource = null;
            grid1.DataSource = BLichHoc.getAll();
        }

        private void btgetLT_Click(object sender, EventArgs e)
        {
            lbName.Text = BUser.getUser(txtID.Text.Trim()).Hoten;
            BLichThi.LoadDataFromSV(txtID.Text.Trim());
            grid1.DataSource = null;
            grid1.DataSource = BLichThi.getAll();
        }

        private void btgetDT_Click(object sender, EventArgs e)
        {
            lbName.Text = BUser.getUser(txtID.Text.Trim()).Hoten;
            BDiemThi.LoadDataFromSV(txtID.Text.Trim());
            grid1.DataSource = null;

            grid1.DataSource = BDiemThi.getAll();

        }

        private void btChiTiet_Click(object sender, EventArgs e)
        {
            /* int k = grid1.CurrentCell.RowIndex;
           MessageBox.Show(k.ToString());
           List<LichHoc> list ;
           list = BLichHoc.getAll();
            */
            
            int k = grid1.CurrentCell.RowIndex;
            MessageBox.Show(k.ToString());
            List<DiemThi> list;
            list = BDiemThi.getAll();

          
            ChiTIetForm f = new ChiTIetForm(list[k]);
            f.Show();
        }

        private void btHocPhi_Click(object sender, EventArgs e)
        {
            grid1.DataSource = null;
            List<HocPhi> l = new List<HocPhi>();
            l.Add(BHocPhi.LoadDataFromSV("1","2"));
            grid1.DataSource = l;
        }
    }
}
