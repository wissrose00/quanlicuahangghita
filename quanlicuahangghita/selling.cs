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
    public partial class selling : Form
    {
        db conn = new db();
        private bool cochon = false;
        private bool cochon1 = false;
        sell sel;
        public selling(sell sel)
        {
            InitializeComponent();
            this.sel = sel;
        }

        private void selling_Load(object sender, EventArgs e)
        {
            label9.Text = alogin.Name_USER;

            string cmnd = "select * from v_ban ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
            dataGridView1.ClearSelection();

        }

        // xóa sản phẩm 
        private void button2_Click(object sender, EventArgs e)
        {

            if (cochon1)
            {
                int selectedRowIndex = dataGridView2.CurrentCell.RowIndex;

                dataGridView2.Rows.RemoveAt(selectedRowIndex);
                dataGridView2.ClearSelection();
                total();
                cochon1 = false;
              
            }
        }


        // thêm sản phẩm 
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(selectedDataGridView1Row.Cells[0].Value,
                           selectedDataGridView1Row.Cells[1].Value, textBox3.Text, selectedDataGridView1Row.Cells[2].Value, (int.Parse(selectedDataGridView1Row.Cells[2].Value.ToString()) * int.Parse(textBox3.Text))
                           );
            dataGridView2.ClearSelection();
            dataGridView1.ClearSelection();
            total();
            cochon = false;
        }

        public DataGridViewRow selectedDataGridView1Row { get; set; }

        // chọn sp 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];

            // Lưu lại để sử dụng ở nút Thêm
            selectedDataGridView1Row = selectedRow; 
        }

        // chọn sp trong đon hàng 
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cochon1 = true;
        }

        // thanh toán
        private void button3_Click(object sender, EventArgs e)
        {
            thanhtoan(alogin.Name_USER, textBox1.Text, textBox2.Text, label4.Text);
            sel.load();
        }

        private void thanhtoan(string nhanvien, string khach, string sdt, string tongtien)
        {
            string cmnd = "sp_ThemHoaDon '" + nhanvien + "',N'" + khach + "','" + sdt + "','" + tongtien + "'";
            DataTable dt = conn.readdata(cmnd);
            string a = "";
            if (dt != null)
            {
                a = dt.Rows[0][0].ToString();
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    string cm = "sp_ThemHoaDonCT '" + a + "','" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "',"+dataGridView2.Rows[i].Cells[2].Value.ToString()+",'" + dataGridView2.Rows[i].Cells[4].Value.ToString() + "'";
                    bool y = conn.exedata(cm);
                }
                dataGridView2.Rows.Clear();
                MessageBox.Show("Thanh toán thành công số tiền " + label4.Text);
                textBox2.Text = textBox1.Text = label4.Text = label6.Text = "";
                dataGridView2.Rows.Clear();
            }
        }


        void total()
        {

            int slt = 0;
            double tong = 0.00;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView2.Rows[i];
                int tt = Convert.ToInt32(row.Cells[4].Value);
                int sl = Convert.ToInt32(row.Cells[2].Value);
                tong += tt;
                slt += sl;
            }

            // Hiển thị tổng số lượng
            label6.Text = slt.ToString();
            label4.Text = tong.ToString();

          
        }
    }
}
