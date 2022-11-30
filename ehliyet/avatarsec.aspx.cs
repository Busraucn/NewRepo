using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Configuration;

namespace WMSDATA
{
    public partial class avatarsec : System.Web.UI.Page
    {
        public static string kullanisim;
        public static string kullansoyisim;
        public static string firma;
        public static string emaili;
        public static string sirketidi;
        public static string kullantc;
        public static string kullansifre;
        public static string sirketadi;

        public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;
        //   String veritabani_baglanti = kullanici_giris.veritabani_baglanti;
        SqlConnection conn = new SqlConnection(veritabani_baglanti);
        SqlConnection con = new SqlConnection(veritabani_baglanti);
        public static int avatar_id;
        protected void Page_Load(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand yeni = new SqlCommand("SELECT * FROM firmatanimlar_kullanici_view WHERE tc='" + Session["user"].ToString() + "'", conn);
            SqlDataReader bak = yeni.ExecuteReader();
            if (bak.Read())
            {
                kullanisim = bak["ad"].ToString();
                kullansoyisim = bak["soyad"].ToString();
                firma = bak["firmaadi"].ToString();
                emaili = bak["email"].ToString();
                sirketadi = bak["firmaadi"].ToString();
                sirketidi = bak["kurum_id"].ToString();
                kullantc = bak["Tc"].ToString();
                kullansifre = bak["sifre"].ToString();
            }


            if (!Page.IsPostBack)
            {
                ViewState["key"] = kullanici_giris.kullaniciId;
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            avatar_id = 1;
            //  MessageBox.Show(avatar_id.ToString());


            con.Open();


            SqlCommand avatar = new SqlCommand("UPDATE kullanici1 SET avatar='1' WHERE tc='" + kullantc + "' ", con);
            SqlDataReader kk = avatar.ExecuteReader();
          
            con.Close();
            Response.Redirect("ansayfa.aspx");
        }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            avatar_id = 2;
            // MessageBox.Show(avatar_id.ToString());

            con.Open();


            SqlCommand avatar = new SqlCommand("UPDATE kullanici1 SET avatar='2' WHERE tc='" + kullantc + "' ", con);
            SqlDataReader kk = avatar.ExecuteReader();

            con.Close();
            Response.Redirect("ansayfa.aspx");
        }
    }
}