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
    public partial class guitar : Form
    {
        db conn = new db();
        public guitar()
        {
            InitializeComponent();
           
        }

        private void guitar_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox2.SelectedIndex = comboBox3.SelectedIndex = 0;
            load();
           
        }
        // load đàn 
        void load() {

            string cmnd = "select * from v_dan ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
            }
            dataGridView1.ClearSelection();
            label22.Text = string.Format("Tổng cộng: {0} sản phầm.", dataGridView1.Rows.Count);
        }


        // nút thêm 
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string cmd = "SP_them_sanpham N'" + textBox2.Text + "',N'" + comboBox4.SelectedItem.ToString() + "',N'" + comboBox5.SelectedItem.ToString() + "','"
                                                  + textBox5.Text + "','" + textBox6.Text + "','" + textBox10.Text + "','"
                                                  + textBox9.Text + "','" + textBox11.Text + "','" + textBox8.Text + "','"
                                                  + textBox7.Text + "','" + textBox3.Text + "','" + textBox12.Text + "','"
                                                  + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','"
                                                  + textBox16.Text + "','" + textBox17.Text + "','" + textBox4.Text + "'";
                if (conn.exedata(cmd) == true)
                {
                    MessageBox.Show("Đã thêm");
                    load();
                    cleardata();
                }
                else
                {
                    MessageBox.Show("Không thể thêm");
                }
            }
        }


        void cleardata() {

         textBox1.Text =  textBox2.Text = textBox5.Text = textBox6.Text = textBox10.Text = textBox9.Text =
            textBox11.Text = textBox8.Text = textBox7.Text = textBox3.Text = textBox12.Text =
            textBox13.Text = textBox14.Text = textBox15.Text = textBox16.Text = textBox17.Text = textBox4.Text = "";

            comboBox4.SelectedIndex = comboBox5.SelectedIndex  = -1;
            dataGridView1.ClearSelection();
        
        }
        // nút sửa 
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string cmd = "SP_sua_sanpham '" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + comboBox4.SelectedItem.ToString() + "',N'" + comboBox5.SelectedItem.ToString() + "','"
                                                  + textBox5.Text + "','" + textBox6.Text + "','" + textBox10.Text + "','"
                                                  + textBox9.Text + "','" + textBox11.Text + "','" + textBox8.Text + "','"
                                                  + textBox7.Text + "','" + textBox3.Text + "','" + textBox12.Text + "','"
                                                  + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','"
                                                  + textBox16.Text + "','" + textBox17.Text + "','" + textBox4.Text + "'";
                if (conn.exedata(cmd) == true)
                {
                    MessageBox.Show("Đã sửa");
                    load();
                    cleardata();
                }
                else
                {
                    MessageBox.Show("Không thể sửa");
                }
            }
        }




        // nút xóa 
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string cmd = "delete guitar where maso = " + textBox1.Text;
                DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xóa không ? ", " Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    if (conn.exedata(cmd) == true)
                    {
                        MessageBox.Show("Đã xóa dữ liệu");
                        load();
                        cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa dữ liệu");
                    }
                }
            }
        }
        // nút hủy 
        private void button5_Click(object sender, EventArgs e)
        {
            cleardata();
        }

        // loại 
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != 0)
            {
                string cmnd = "select * from v_dan where [LOẠI] = N'" + comboBox3.SelectedItem.ToString() + "'";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 50;
                    dataGridView1.Columns[1].Width = 285;
                    dataGridView1.Columns[2].Width = 100;
                    dataGridView1.Columns[3].Width = 100;
                    dataGridView1.Columns[4].Width = 100;
                    dataGridView1.Columns[5].Width = 100;
                }
                dataGridView1.ClearSelection();
                label22.Text = string.Format("Tổng cộng: {0} sản phầm.", dataGridView1.Rows.Count);
            }
            else {
                load();
            }


        }

        // tính năng 
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != 0)
            {
                string cmnd = "select * from v_dan where [TÍNH NĂNG] = N'" + comboBox2.SelectedItem.ToString() + "'";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 50;
                    dataGridView1.Columns[1].Width = 285;
                    dataGridView1.Columns[2].Width = 100;
                    dataGridView1.Columns[3].Width = 100;
                    dataGridView1.Columns[4].Width = 100;
                    dataGridView1.Columns[5].Width = 100;
                }
                dataGridView1.ClearSelection();
                label22.Text = string.Format("Tổng cộng: {0} sản phầm.", dataGridView1.Rows.Count);
            }
            else
            {
                load();
            }

        }

        // giá
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmnd = "";

            if (comboBox1.SelectedIndex == 0) {
               cmnd = "select * from v_dan ";
            }

            if (comboBox1.SelectedIndex == 1)
            {
                cmnd = "select * from v_dan where [GIÁ]  < 3000000 ";
            }

            if (comboBox1.SelectedIndex == 2)
            {
               cmnd = "select * from v_dan where [GIÁ]  >= 5000000  AND [GIÁ]  <= 10000000 ";  
            }

            if (comboBox1.SelectedIndex == 3)
            {
                cmnd = "select * from v_dan where [GIÁ]  > 10000000  AND [GIÁ]  <= 20000000 ";  
            }

            if (comboBox1.SelectedIndex == 4)
            {
                cmnd = "select * from v_dan where [GIÁ]  > 20000000  AND [GIÁ]  <= 40000000 ";  
            }

            if (comboBox1.SelectedIndex == 5)
            {
                cmnd = "select * from v_dan where [GIÁ]  > 40000000  AND [GIÁ]  <= 100000000 ";  
            }

            if (comboBox1.SelectedIndex == 6)
            {
                cmnd = "select * from v_dan where [GIÁ]  > 100000000  AND [GIÁ]  <= 300000000 ";  
            }


            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
            }
            dataGridView1.ClearSelection();
            label22.Text = string.Format("Tổng cộng: {0} sản phầm.", dataGridView1.Rows.Count);


        }


        // chọn 1 dòng 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                // Lấy giá trị từ các cột tương ứng trong DataGridView
                string c1 = selectedRow.Cells[0].Value.ToString();
                string c2 = selectedRow.Cells[1].Value.ToString();
                string c3 = selectedRow.Cells[2].Value.ToString();
                string c4 = selectedRow.Cells[3].Value.ToString();
                string c19 = selectedRow.Cells[4].Value.ToString();
                string c5 = selectedRow.Cells[5].Value.ToString();
                string c6 = selectedRow.Cells[6].Value.ToString();
                string c7 = selectedRow.Cells[7].Value.ToString();
                string c8 = selectedRow.Cells[8].Value.ToString();
                string c9 = selectedRow.Cells[9].Value.ToString();
                string c10= selectedRow.Cells[10].Value.ToString();
                string c11 = selectedRow.Cells[11].Value.ToString();
                string c12 = selectedRow.Cells[12].Value.ToString();
                string c13 = selectedRow.Cells[13].Value.ToString();
                string c14 = selectedRow.Cells[14].Value.ToString();
                string c15= selectedRow.Cells[15].Value.ToString();
                string c16 = selectedRow.Cells[16].Value.ToString();
                string c17= selectedRow.Cells[17].Value.ToString();
                string c18 = selectedRow.Cells[18].Value.ToString();
               

                

                // Đổ dữ liệu vào các TextBox
                textBox1.Text = c1;
                textBox2.Text = c2;

                comboBox4.SelectedItem = c3;
                comboBox5.SelectedItem = c4;

                textBox5.Text = c5;
                textBox6.Text = c6;
                textBox10.Text = c7;
                textBox9.Text = c8;
                textBox11.Text = c9;
                textBox8.Text = c10;
                textBox7.Text = c11;
                textBox3.Text = c12;
                textBox12.Text = c13;
                textBox13.Text = c14;
                textBox14.Text = c15;
                textBox15.Text = c16;
                textBox16.Text = c17;
                textBox17.Text = c18;
                textBox4.Text = c19;
               


            }
        }
    }
}
