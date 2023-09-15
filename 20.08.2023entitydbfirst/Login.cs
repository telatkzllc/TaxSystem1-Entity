using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20._08._2023entitydbfirst
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        vergiyonetimEntities con = new vergiyonetimEntities();

        public bool login(string username, string password)
        {
            var query = from user in con.Users
                        where user.Nickname==username && user.Password==password
                        select user;
            if (query.Any())
            {
                return true;
            }
            else { return false; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(login(textBox1.Text,textBox2.Text))
            {
                Form1 go =new Form1();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Tekrar Deneyin.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Register go = new Register();
            go.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          if (radioButton1.Checked)
            {
                textBox2.PasswordChar= '\0';
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
