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

    public partial class frmkulup : Form
    {
        public frmkulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KPC6PV7\SQLEXPRESS;Initial Catalog=bonusokul;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void liste()
        {

            SqlDataAdapter da = new SqlDataAdapter("select *from tblkulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void frmkulup_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da=new SqlDataAdapter("select *from tblkulupler",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 =new SqlCommand("insert into tblkulupler (kulupad) values (@p1)",baglanti);
            komut1.Parameters.AddWithValue("@p1",txtkulupad.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kulüp eklendi","bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            liste();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" update tblkulupler set kulupad=@p1 where kulupıd=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",txtkulupad.Text);
            komut.Parameters.AddWithValue("@p2",txtkulupıd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Güncelleme İşlemi Gerçekleşti");
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightBlue;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from tblkulupler where kulupıd=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkulupıd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Silme İşlemi Gercekleşti");
            liste();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmogretmen FRM =new frmogretmen();
            FRM.Show();
            this.Hide();
        }
    }
}
