using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace quanlicuahangghita
{
    public partial class home : Form
    {
        db conn = new db();
        public home()
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
        {
            load1();
           
        }


        // sản phẩm bán chạy
        void load1() {

            string cmnd = "select * from v_banchay  where YEAR([ngayban]) = YEAR(GETDATE()) AND MONTH([ngayban]) = MONTH(GETDATE()) ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
              

            }
        
        }

    }
}
