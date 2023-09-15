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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        vergiyonetimEntities con = new vergiyonetimEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User usr = new User();  //User Tablo ismidir.
                usr.Nickname = textBox1.Text;
                usr.Password = textBox2.Text;
                con.Users.Add(usr);
                con.SaveChanges();
                Login go = new Login();
                go.Show();
                this.Hide();
            }
            catch
            {
                Console.WriteLine("Tekrar Deneyiniz.");
            }
        }
    }
}
