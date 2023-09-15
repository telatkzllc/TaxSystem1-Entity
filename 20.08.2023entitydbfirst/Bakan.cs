using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _20._08._2023entitydbfirst
{
    public partial class Bakan : Form
    {
        public Bakan()
        {
            InitializeComponent();
        }
        vergiyonetimEntities con = new vergiyonetimEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = con.baklist().ToList();

            var query = from bkn in con.Bakanlık
                        orderby bkn.BakanlikAdi
                        select bkn;
            dataGridView1.DataSource = query.ToList();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["BakanlikId"].Value.ToString();
            textBox1.Text = column.Cells["BakanlikAdi"].Value.ToString();
            textBox2.Text = column.Cells["BakanlıkBaskan"].Value.ToString();
            textBox3.Text = column.Cells["Ciro"].Value.ToString();
            textBox4.Text = column.Cells["Merkez"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bakanlık bkn = new Bakanlık();
            bkn.BakanlikId = Convert.ToInt32(textBox1.Tag);
            con.bakdel(bkn.BakanlikId);
            con.SaveChanges();
            dataGridView1.DataSource = con.baklist().ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bakanlık bkn = new Bakanlık();
            bkn.BakanlikAdi = textBox1.Text;
            bkn.BakanlıkBaskan = (textBox2.Text);
            bkn.Ciro =Convert.ToDecimal(textBox3.Text);
            bkn.Merkez = textBox4.Text;

            //CON.EMPLOYEES.ADD(employee);
            con.bakadd(bkn.BakanlikAdi,
                bkn.BakanlıkBaskan, bkn.Ciro, bkn.Merkez);
            con.SaveChanges();
            dataGridView1.DataSource = con.baklist().ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bakanlık bkn = new Bakanlık();
            bkn.BakanlikId = Convert.ToInt32(textBox1.Tag);
            bkn.BakanlikAdi = textBox1.Text;
            bkn.BakanlıkBaskan = (textBox2.Text);
            bkn.Ciro = Convert.ToDecimal(textBox3.Text);
            bkn.Merkez = textBox4.Text;

            //CON.EMPLOYEES.ADD(employee);
            con.bakupdate(bkn.BakanlikId,bkn.BakanlikAdi,
                bkn.BakanlıkBaskan, bkn.Ciro, bkn.Merkez);
            con.SaveChanges();
            dataGridView1.DataSource = con.baklist().ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = con.MerkezeGore().ToList(); //BU KOMUT SIKINTI.

            var query = from cir in con.Bakanlık
                        group cir by cir.Merkez into gruplandir
                        select new
                        {
                            urunAdi = gruplandir.Key,
                            ortlama = gruplandir.Count()
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.innervatandas().ToList();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1();
            go.Show();
            this.Hide();
        }
        private void button8_Click(object sender, EventArgs e)
        {   
        }
        private void button8_Click_1(object sender, EventArgs e)
        {  
        }
        private void button8_Click_2(object sender, EventArgs e)
        {
            dataGridView1.DataSource = con.ankortalama().ToList(); ///devam

            //var query = con.Bakanlık.Where(x => x.Merkez == "Ankara").Average(fiyat => fiyat.Ciro);
            //textBox1.Text = query.ToString();
            //dataGridView1.DataSource = textBox1.Text;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*dataGridView1.DataSource = con.bknmrkzortalama().ToList();*/ //entity ile group by sıkıntı

            var query = from cir in con.Bakanlık
                        group cir by cir.Merkez into gruplandir
                        select new
                        {
                            urunAdi = gruplandir.Key,
                            ortlama = gruplandir.Average(x => x.Ciro)
                        };
            dataGridView1.DataSource = query.ToList();
        }
    }
}
