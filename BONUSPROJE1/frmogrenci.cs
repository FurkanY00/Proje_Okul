using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BONUSPROJE1
{
    public partial class frmogrenci : Form
    {
        public frmogrenci()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmogretmen fr =new frmogretmen();
            fr.Show();
            this.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.ogrencisil(int.Parse(txtıd.Text));
            MessageBox.Show("Öğrenci silindi");
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds =new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KPC6PV7\SQLEXPRESS;Initial Catalog=bonusokul;Integrated Security=True");
        private void frmogrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencılistesi();
         
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from tbldersler",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt =new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "dersad";
            comboBox1.ValueMember= "dersıd";
            comboBox1.DataSource= dt;
            baglanti.Close();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.ogrenciguncelle(txtad.Text, txtsoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c, int.Parse(txtıd.Text));
            MessageBox.Show("Öğrenci Bilgileri Güncellendi");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencılistesi();

        }
        string c = "";
        private void btnekle_Click(object sender, EventArgs e)
        {
         
            ds.OGRENCIEKLE(txtad.Text, txtsoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Ekleme Yapıldı!!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";

            }
         
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
        }
        
        private void btnara_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ds.ogrencigetir(TXTARAMA.Text);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
