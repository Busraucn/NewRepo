using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows.Forms;

namespace WMSDATA
{
    public partial class Anasablon : System.Web.UI.MasterPage
    {
        public static string kullanisim;
        public static string kullansoyisim ;
        public static string firma ;
        public static string emaili;
        public static string sirketidi;
        public static string kullansirketidi;

        public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;
        //   String veritabani_baglanti = kullanici_giris.veritabani_baglanti;
        public static int avatarid;
        SqlConnection con = new SqlConnection(veritabani_baglanti);
        SqlConnection conn = new SqlConnection(veritabani_baglanti);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                //MessageBox.Show(Session["user"].ToString());
                Response.Redirect("kullanici_giris.aspx");
            }
            con.Open();


            SqlCommand avatar = new SqlCommand("SELECT avatar FROM kullanici1 WHERE  tc='" + Session["user"].ToString() + "'  ", con);
            SqlDataReader kk = avatar.ExecuteReader();
            if (kk.Read()) avatarid = (int)kk["avatar"];
            kk.Close();
            con.Close();

            conn.Open();
            SqlCommand yeni = new SqlCommand("SELECT * FROM firmatanimlar_personel_view WHERE tcno='" + Session["user"].ToString() + "'", conn);
            SqlDataReader bak = yeni.ExecuteReader();
            if (bak.Read())
            {
                 kullanisim = bak["ad"].ToString();
                 kullansoyisim = bak["soyad"].ToString();
                 firma = bak["firmaadi"].ToString();
                 emaili = bak["email"].ToString();
                sirketidi = bak["kurum_id"].ToString();
                kullansirketidi = bak["Id"].ToString();
                if (bak["resim"].ToString() != "")
                {
                    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])bak["resim"]);
                    imgPicture.ImageUrl = imageUrl;
                }
            }
            }

        protected void cikis_ServerClick(object sender, EventArgs e)
        {
         

            kullanici_giris.kullaniciTc = "";
            kullanici_giris.kullaniciİsim = "";
            kullanici_giris.kullaniciSoyisim = "";
            kullanici_giris.kullaniciSİrket_id = "";
            kullanici_giris.kullaniciSifre = "";
            kullanici_giris.kullaniciEmail = "";
            kullanici_giris.kullaniciKURUM = "";
           
            Session.Abandon();
            Response.Redirect("kullanici_giris.aspx");
        }
    }
}