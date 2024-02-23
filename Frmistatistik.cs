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

namespace DataProje1
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Dante\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;Encrypt=False;");
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand ("Select Count(*) From Tbl_Personel" , baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //Evli Personel Sayısı

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand ("Select Count(*) From Tbl_Personel where PerDurum = 1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvliPersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();
        }
    }
}
