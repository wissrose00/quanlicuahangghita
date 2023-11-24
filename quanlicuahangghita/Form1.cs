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
    public partial class Form1 : Form
    {
        db conn = new db();
        public bool isExit = true;
        public event EventHandler logout;
        Color originalBackground1;
        Color originalBackground2;
        Color originalBackground3;
        Color originalBackground4;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button7.Text = alogin.Name_USER;
          
            originalBackground1 = button5.BackColor;
            originalBackground2 = button4.BackColor;
            originalBackground3 = button2.BackColor;
            originalBackground4 = button3.BackColor;

            button5.PerformClick();

        }

        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logout(this, new EventArgs());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình ?", "Thông báo ", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    e.Cancel = true;
                }

            }
        }
       

        private void button5_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new home());
            button5.BackColor = Color.LightGray;
            button4.BackColor = originalBackground2;
            button2.BackColor = originalBackground3;
            button3.BackColor = originalBackground4;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new guitar());
            button4.BackColor = Color.LightGray;
            button5.BackColor = originalBackground1;
            button2.BackColor = originalBackground3;
            button3.BackColor = originalBackground4;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new sell());
            button2.BackColor = Color.LightGray;
            button4.BackColor = originalBackground2;
            button5.BackColor = originalBackground1;
            button3.BackColor = originalBackground4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new stat());
            button3.BackColor = Color.LightGray;
            button4.BackColor = originalBackground2;
            button2.BackColor = originalBackground3;
            button5.BackColor = originalBackground1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            changepass cp = new changepass();
            cp.ShowDialog();
        }



    }
}
