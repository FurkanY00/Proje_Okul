using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BONUSPROJE1
{
    public partial class frmogretmen : Form
    {
        public frmogretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmkulup fr =new frmkulup();
            fr.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmdersler frm = new frmdersler();
            frm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmogrenci fr =new frmogrenci();
            fr.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmogrencinotlar fr=new frmogrencinotlar();
            fr.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmogretmenler frm=new frmogretmenler();
            frm.Show();
            this.Close();
        }
    }
}
