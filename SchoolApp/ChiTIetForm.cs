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
    public partial class ChiTIetForm : Form
    {
        public ChiTIetForm(Object t)
        {
            InitializeComponent();
            LichHoc lh = (LichHoc)t;
            dataGridView1.DataSource = lh.Chitiet;

          //  DiemThi dt = (DiemThi)t;
           // dataGridView1.DataSource = dt.DiemMons;


        }

        private void ChiTIetForm_Load(object sender, EventArgs e)
        {

        }
    }
}
