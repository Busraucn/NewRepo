using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WMSDATA
{
    public partial class ilkGiris : System.Web.UI.Page
    {
        public static string kullanisim;
        public static string kullansoyisim;
        public static string firma;
        public static string emaili;
        public static string sirketidi;
        public static string kullantc;
        public static string kullansifre;
        public static string sirketadi;
        public static string sifrem;
        public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;
        //   String veritabani_baglanti = kullanici_giris.veritabani_baglanti;
        public static int avatar_id;
        public static string uyari_yanlis = "";
        SqlConnection con = new SqlConnection(veritabani_baglanti);
        SqlConnection conn = new SqlConnection(veritabani_baglanti);
        SqlConnection conns = new SqlConnection(veritabani_baglanti);
        protected void Page_Load(object sender, EventArgs e)
        {

            yanlis_uyari.Visible = false;
            conns.Open();
            SqlCommand yeni = new SqlCommand("SELECT * FROM firmatanimlar_personel_view WHERE tcno='" + Session["user"].ToString() + "'", conns);
            SqlDataReader bak = yeni.ExecuteReader();
            if (bak.Read())
            {
                kullanisim = bak["ad"].ToString();
                kullansoyisim = bak["soyad"].ToString();
                firma = bak["firmaadi"].ToString();
                emaili = bak["email"].ToString();
                sirketadi = bak["firmaadi"].ToString();
                sirketidi = bak["kurum_id"].ToString();
                kullantc = bak["Tcno"].ToString();
            }
        }

        protected void sifrekaydet_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (ilksifre.Value == ilksifre2.Value)
                {
                    con.Open();
                    SqlCommand s = new SqlCommand("UPDATE personel SET sifre=HASHBYTES('MD5','" + ilksifre.Value + "') WHERE Tcno='" + kullantc + "' ", con);
                    SqlDataReader oku = s.ExecuteReader();

                    oku.Close();
                    con.Close();

                    con.Open();
                    SqlCommand w = new SqlCommand("UPDATE kullanici1 SET ilkgiris='1' WHERE tc='" + kullantc + "' ", con);
                    SqlDataReader sw = w.ExecuteReader();

                    sw.Close();
                    con.Close();


                    avatar_id = 1;
                    //  MessageBox.Show(avatar_id.ToString());


                    con.Open();


                    SqlCommand avatar = new SqlCommand("UPDATE kullanici1 SET avatar='1' WHERE tc='" + kullanici_giris.kullaniciTc + "' ", con);
                    SqlDataReader kk = avatar.ExecuteReader();

                    con.Close();
                    Response.Redirect("ansayfa.aspx");
                }
                else
                {
                    yanlis_uyari.Visible = true;
                    uyari_yanlis = "ŞİFRELER EŞLEŞMEDİ";
                }
            }
            catch(Exception er)
            {
                yanlis_uyari.Visible = true;
                uyari_yanlis = "ŞİFRE DEĞİŞTİRİLEMİYOR.";

            }
        }
    }
}