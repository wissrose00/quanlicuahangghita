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
    public partial class changepass : Form
    {
        db conn = new db();
        public string uid = "";
        public changepass()
        {
            InitializeComponent();
        }
            
        private void button1_Click(object sender, EventArgs e)
        {   



            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp!");
            }
            else
            {
                if (textBox1.Text != alogin.Pass_USER) {
                    MessageBox.Show("Mật khẩu không đúng!");
                }
                else
                {
                    doimk(uid, textBox2.Text);
                }
            }  
        }

        private void doimk(string id, string pass)
        {
            String cmd = ("update taikhoan set matkhau= '" + pass + "' WHERE maso ='" + id + "'");
            if (conn.exedata(cmd))
            {
                MessageBox.Show("Đổi mật khẩu thành công !");
                this.Close();
            }
            else MessageBox.Show("Đổi mật khẩu không thành công !");
        }

   

        private void changepass_Load(object sender, EventArgs e)
        {
            uid = alogin.ID_USER;
        }


    }
}
