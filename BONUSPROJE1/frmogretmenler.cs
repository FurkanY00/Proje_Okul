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

namespace BONUSPROJE1
{
    public partial class frmogretmenler : Form
    {
        public frmogretmenler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KPC6PV7\SQLEXPRESS;Initial Catalog=bonusokul;Integrated Security=True");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            frmogretmen frm =new frmogretmen();
            frm.Show();
            this.Close();
        }

        private void frmogretmenler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from  tblogretmenler",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
