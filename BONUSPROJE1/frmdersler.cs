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
    public partial class frmdersler : Form
    {
        public frmdersler()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmogretmen frm= new frmogretmen();
            frm.Show();
            this.Close();
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();
        private void frmdersler_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds.derslistesi();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.dersekle(txtdersad.Text);
            MessageBox.Show("Ders Ekleme İşlemi Gerçekleşti");
            dataGridView1.DataSource=ds.derslistesi();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.derslistesi();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.derssil(byte.Parse(txtdersıd.Text));
            dataGridView1.DataSource = ds.derslistesi();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.dersguncelle(txtdersad.Text, byte.Parse(txtdersıd.Text));
            dataGridView1.DataSource = ds.derslistesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdersıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
