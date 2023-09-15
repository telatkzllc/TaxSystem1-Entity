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
    public partial class Vatandas : Form
    {
        public Vatandas()
        {
            InitializeComponent();
        }
        vergiyonetimEntities con = new vergiyonetimEntities();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vatanda vatandas = new Vatanda();
            vatandas.Tc= textBox1.Text;
            vatandas.Meslek =(textBox2.Text);
            vatandas.Adres = textBox3.Text;
            vatandas.Telefon = textBox4.Text;
            vatandas.Mail = textBox5.Text;

            //CON.EMPLOYEES.ADD(employee);
            con.vatadd(vatandas.Tc,
                vatandas.Meslek, vatandas.Adres, vatandas.Telefon,vatandas.Mail);
            con.SaveChanges();
            dataGridView1.DataSource = con.vatlist().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.vatlist().ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vatanda vatandas = new Vatanda();
            vatandas.KisiNo = Convert.ToInt32(textBox1.Tag);
            con.vatdel(vatandas.KisiNo);
            con.SaveChanges();
            dataGridView1.DataSource = con.vatlist().ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["KisiNo"].Value.ToString();
            textBox1.Text = column.Cells["Tc"].Value.ToString();
            textBox2.Text = column.Cells["Meslek"].Value.ToString();
            textBox3.Text = column.Cells["Adres"].Value.ToString();
            textBox4.Text = column.Cells["Telefon"].Value.ToString();
            textBox5.Text = column.Cells["Mail"].Value.ToString();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Vatanda vatandas = new Vatanda();
            vatandas.KisiNo = Convert.ToInt32(textBox1.Tag);
            vatandas.Tc = textBox1.Text;
            vatandas.Meslek = (textBox2.Text);
            vatandas.Adres = textBox3.Text;
            vatandas.Telefon = textBox4.Text;
            vatandas.Mail = textBox5.Text;

            //CON.EMPLOYEES.ADD(employee);
            con.vatupdate(vatandas.KisiNo,vatandas.Tc,
                vatandas.Meslek, vatandas.Adres, vatandas.Telefon, vatandas.Mail);
            con.SaveChanges();
            dataGridView1.DataSource = con.vatlist().ToList();
        }

        private void Vatandas_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = con.versırala().ToList();

            var query = from vtn in con.Vatandas
                        orderby vtn.Tc descending
                        select new { vtn.Tc, vtn.Meslek};
            dataGridView1.DataSource = query.ToList();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.telo().ToList(); // sıralaması degisti joinden dolayı.
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = con.adresegore();  
            var query = from vtn in con.Vatandas
                        orderby vtn.Adres
                        select vtn;
            dataGridView1.DataSource = query.ToList();
        }
    }
}
