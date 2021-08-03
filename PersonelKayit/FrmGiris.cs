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

namespace PersonelKayit
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        // sql i bağlama işlemini gerçekleştirdik
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-M4Q4SMD\\SQLEXPRESS;Initial Catalog=PersonelTablosu;Integrated Security=True");

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.Add("@p2", txtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) // doğru okuma işlemi yapabilirse
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }


            baglanti.Close();
        }
    }
}
