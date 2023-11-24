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
    public partial class stat : Form
    {
        db conn = new db();
        public stat()
        {
            InitializeComponent();
            load();
        }

        void load() {

            string cmnd = "select * from v_thongke ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                double tong = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    int tt = Convert.ToInt32(row.Cells[3].Value);
                    tong += tt;
                }

                // Hiển thị tổng số lượng

                label4.Text = tong.ToString();

            }
            dataGridView1.ClearSelection();
        }

        // tìm kiếm 
        private void button2_Click(object sender, EventArgs e)
        {
            string dt1 = dateTimePicker1.Value.ToString("yyyy'/'MM'/'dd");
            string dt2 = dateTimePicker2.Value.ToString("yyyy'/'MM'/'dd");
            string cmnd = "select * from v_thongke where ngayban >= '" + dt1 + "' AND ngayban <= '" + dt2 + "' ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                double tong = 0.00;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    int tt = Convert.ToInt32(row.Cells[3].Value);
                    tong += tt;
                }

                // Hiển thị tổng số lượng
              
                label4.Text = tong.ToString();

            }
            dataGridView1.ClearSelection();

        }
    }
}
