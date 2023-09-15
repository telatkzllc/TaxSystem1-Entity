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
    public partial class Vergi : Form
    { //null'u sor ,
        public Vergi()
        {
            InitializeComponent();
        }
        vergiyonetimEntities con = new vergiyonetimEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.verlist().ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vergiler vrg = new Vergiler();
            vrg.VergiId = Convert.ToInt32(textBox1.Tag);
            con.verdel(vrg.VergiId);
            con.SaveChanges();
            dataGridView1.DataSource = con.verlist().ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["VergiId"].Value.ToString();
            textBox1.Text = column.Cells["VergiAdi"].Value.ToString();
            textBox2.Text = column.Cells["VergiTipi"].Value.ToString();
            textBox3.Text = column.Cells["Tutar"].Value.ToString();
            textBox4.Text = column.Cells["Faiz"].Value.ToString();
            textBox5.Text = column.Cells["KisiNo"].Value.ToString();
            textBox6.Text = column.Cells["BakanlikId"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vergiler bkn = new Vergiler();
            bkn.VergiId = Convert.ToInt32(textBox1.Tag);
            bkn.VergiAdi = textBox1.Text;
            bkn.VergiTipi = (textBox2.Text);
            bkn.Tutar = Convert.ToDecimal(textBox3.Text);
            bkn.Faiz = Convert.ToDecimal(textBox4.Text);
            bkn.KisiNo = Convert.ToInt32(textBox5.Text);
            bkn.BakanlikId = Convert.ToInt32(textBox6.Text);
            //CON.EMPLOYEES.ADD(employee);
            con.veradd(bkn.VergiAdi,
                bkn.VergiTipi, bkn.Tutar, bkn.Faiz, bkn.KisiNo, bkn.BakanlikId);
            con.SaveChanges();
            dataGridView1.DataSource = con.verlist().ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vergiler vrg = new Vergiler();
            vrg.VergiId = Convert.ToInt32(textBox1.Tag);
            vrg.VergiAdi = textBox1.Text;
            vrg.VergiTipi = (textBox2.Text);
            vrg.Tutar = Convert.ToDecimal(textBox3.Text);
            vrg.Faiz =Convert.ToDecimal(textBox4.Text);
            vrg.KisiNo = Convert.ToInt32(textBox5.Text);
            vrg.BakanlikId = Convert.ToInt32(textBox6.Text);
            //CON.EMPLOYEES.ADD(employee);
            con.verupdate(vrg.VergiId,vrg.VergiAdi,
                vrg.VergiTipi, vrg.Tutar, vrg.Faiz,vrg.KisiNo,vrg.BakanlikId);
            con.SaveChanges();
            dataGridView1.DataSource = con.verlist().ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.verinner().ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = con.berke().ToList();

            var query = from vrg in con.Vergilers
                        orderby vrg.Tutar descending
                        select new { vrg.VergiAdi, vrg.Tutar };
            dataGridView1.DataSource = query.ToList();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }
    }
}
