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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //3 tane tablolu entitydbfirstli proclu proje yapacaksınız.
            //raporlama olacak(join,order by,groupby,top)

            //vergi yönetim sistemi

            //bakanlık            //vergiler             vatandas
            //bakanlıkkid         //vergiid              kisino
            //bakanlıkadi         //vergitipi            tc
            //dairebaskanlik      //vergiadi             meslek
            //ciro                //tutar                adres
            //merkez              //faiz                 telefon
                                                         //mail
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vatandas go = new Vatandas();
            go.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vergi go = new Vergi();
            go.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bakan go = new Bakan();
            go.Show();
            this.Hide();
        }
    }
}
