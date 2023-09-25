using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace BONUSPROJE1
{
    public partial class frmogrencinotlar : Form
    {
        public frmogrencinotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KPC6PV7\SQLEXPRESS;Initial Catalog=bonusokul;Integrated Security=True");
        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();


        public string numara;

        private void frmogrencinotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select *from tbldersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "dersad";
            comboBox1.ValueMember = "dersıd";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }
        

        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.notlistesi(int.Parse(txtıd.Text));
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmogretmen frmo = new frmogretmen();
            frmo.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtıd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtortalama.Text= dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sınav1, sınav2, sınav3, proje;
        double ortalam;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnhesapla_Click(object sender, EventArgs e)
        {
            
            
            sınav1 = Convert.ToInt16(txtsınav1.Text);
            sınav2 = Convert.ToInt16(txtsınav2.Text);
            sınav3 = Convert.ToInt16(txtsınav3.Text);
            proje = Convert.ToInt16(txtsınav1.Text);
            ortalam=(sınav1+sınav2+sınav3+proje)/4;
            txtortalama.Text = ortalam.ToString();
            if (ortalam >= 50)
            {
                txtdurum.Text = "true";
            }
            else
            {
                txtdurum.Text="false";
            }
        }
        int notid;
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.notguncelle(byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txtıd.Text), byte.Parse(txtsınav1.Text), byte.Parse(txtsınav2.Text), byte.Parse(txtsınav3.Text), byte.Parse(txtproje.Text), decimal.Parse(txtortalama.Text), bool.Parse(txtdurum.Text), notid);

        }
    }
}
