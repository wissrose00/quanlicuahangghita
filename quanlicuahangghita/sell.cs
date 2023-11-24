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
    public partial class sell : Form
    {
        db conn = new db();
        public sell()
        {
            InitializeComponent();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selling sl = new selling(this);
            sl.ShowDialog();
        }

     public void load() {

            string cmnd = "select * from v_hoadon ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
             
            }
            dataGridView1.ClearSelection();
            label5.Text = string.Format("Tổng cộng: {0} hóa đơn.", dataGridView1.Rows.Count);
        
        
        }


        // nút tìm kiếm 
        private void button2_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_hoadon where [SDT]  like N'%" + textBox2.Text + "%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
            dataGridView1.ClearSelection();
            label5.Text = string.Format("Tổng cộng: {0} hóa đơn.", dataGridView1.Rows.Count);
        }


        // chọn đơn hàng
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string c1 = selectedRow.Cells[0].Value.ToString();
                string c2 = selectedRow.Cells[1].Value.ToString();
                string c3 = selectedRow.Cells[3].Value.ToString();
                string c4 = selectedRow.Cells[4].Value.ToString();
                string c5 = selectedRow.Cells[5].Value.ToString();


                label2.Text = c3;
                label4.Text = c4;
                label8.Text = c5;
                label10.Text = c2;


                string cmnd = "select * from v_cthd where HD =" +c1;
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView2.DataSource = dt;

                }
                dataGridView2.ClearSelection();



            }
        }

      


    }
}
