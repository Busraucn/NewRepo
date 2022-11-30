using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Configuration;
using System.Net.Mail;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;


namespace WMSDATA
{
    public partial class CalismaZamaniTanim : System.Web.UI.Page
    {
        public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;
        SqlConnection con = new SqlConnection(veritabani_baglanti);
        public static DateTime bugununtarihi = Convert.ToDateTime(DateTime.Now);
        public static string uyari_dogru = "";
        public static string uyari_yanlis = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["key"] = kullanici_giris.kullaniciId;
            }
        }

        protected void tanimKaydet_ServerClick(object sender, EventArgs e)
        {
            con.Open();
            string date = daterangemodal1.Value;
            string d_start = (date.Split('-'))[0];
            string d_end = (date.Split('-'))[1];

            DateTime end = DateTime.Parse(d_end, System.Globalization.CultureInfo.InvariantCulture);
            DateTime start = DateTime.Parse(d_start, System.Globalization.CultureInfo.InvariantCulture);

            SqlCommand cmd = new SqlCommand("CalismaZamanıTanimlamaKaydetGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PId", 0);
            cmd.Parameters.AddWithValue("@Aciklama", description.Value);
            cmd.Parameters.AddWithValue("@PCalismaBaslangicSaat", baslamaS.Value);
            cmd.Parameters.AddWithValue("@PCalismaBitisSaat", bitisS.Value);
            cmd.Parameters.AddWithValue("@Yevmiye", yevmiye.Value);
            cmd.Parameters.AddWithValue("@PLateness", lateness.Value);
            cmd.Parameters.AddWithValue("@PGecerlilikBaslangicT", start);
            cmd.Parameters.AddWithValue("@PGecerlilikBitisT", end);
            cmd.Parameters.AddWithValue("@PSirketId", kullanici_giris.kullaniciSİrket_id);
            cmd.Parameters.AddWithValue("@PEtkinMi", true);
            //con.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                uyari_dogru = "Kayıt Başarı ile tamamlandı";
            }
            con.Close();
        }
    }
}