using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Mail;
using System.Data;


namespace WMSDATA
{
    public partial class kullanici_sayfasi : System.Web.UI.Page
    {
         public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;
        //   String veritabani_baglanti = kullanici_giris.veritabani_baglanti;

        public static string uyari_dogru = "";
        public static string uyari_yanlis = "";
      
        public static int degisen_id;
       
        public static int verisay;
        public static int[] id;
        public static string[] kullanici_tc;
        public static string[] kullanici_ad;
        public static string[] kullanici_soyad;
        public static string[] kullanici_email;
        public static string[] kullanici_sifre;
        public static string[] kullanici_sirket;

        public static String idAl = "";
        public static int verilertemizlensin = 0;
        public static string id_karsilastir = "";
        public static int guncellenecek = 0;
        public static int degisenid;
        public static int sayfadangelen=0;

        SqlConnection con = new SqlConnection(veritabani_baglanti);
        SqlConnection conn = new SqlConnection(veritabani_baglanti);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                //MessageBox.Show(Session["user"].ToString());
                Response.Redirect("kullanici_giris.aspx");
            }
            kullanici_giris.belgeSayfasiCheck = 0;
            //  idAl = Request.QueryString["uyeid"];
            idAl = "";

            if (verilertemizlensin == 0)
            {
                idAl = Request.QueryString["uyeid"];
            }
            else
            {
                idAl = "";
                verilertemizlensin = 0;
            }
            if (idAl != null & idAl != "")
            {
                if (id_karsilastir.ToString() != idAl.ToString())
                {
                    guncellenecek = 0;
                }
                else
                {
                    guncellenecek = 1;
                }
            }

            dogru_uyari.Visible = false;
            yanlis_uyari.Visible = false;
            arama();
            sirketlistesi();
            if (idAl != null && idAl != "" & guncellenecek == 0)
            {
                guncellenecek = 1;
                degisenid = int.Parse(idAl);
                id_karsilastir = degisenid.ToString();
                SqlCommand d = new SqlCommand("SELECT * FROM firmatanimlar_kullanici_view WHERE Id='" + degisenid + "' ", con);
                SqlDataReader bak = d.ExecuteReader();
                if (bak.Read())
                {
                    tc.Value = bak["Tc"].ToString();
                    ad.Value = bak["ad"].ToString();
                    soyad.Value = bak["soyad"].ToString();
                    email.Value = bak["email"].ToString();
                    sirket.Value = bak["firmaadi"].ToString();
                    dt.Visible = false;
                    gizle.Visible = false;
                    tc.Disabled = true;
                }
                bak.Close();
                sayfadangelen = -2;
            }
            con.Close();
        }
        string RastgeleUret()
        {
            Random rnd = new System.Random(unchecked((int)DateTime.Now.Ticks));
            string ret = "";
            for (int i = 0; i < 6; i++)
        {
                ret += randLetter(rnd);
            }
            return ret;
        }
        const string letters = "123456789abcdefghijkmnpqrstuvwxwz&#+%=*!";
        char randLetter(Random rnd)
        {
            return letters[rnd.Next(letters.Length)];
        }

        protected void sirketlistesi()
        {  
            con.Open();
            sirket.Items.Clear();
            SqlCommand s2 = new SqlCommand("SELECT * FROM Firmatanimlar  ", con);
            SqlDataReader oku2 = s2.ExecuteReader();
            while (oku2.Read())
            {
                sirket.Items.Add(oku2["firmaadi"].ToString());
            }
            oku2.Close();
            con.Close();
        }
        protected void tckimlikdogrula(object sender, EventArgs e)
        {
            if (tc.Value != "" & tc.Value != null & ad.Value != "" & ad.Value != null & soyad.Value != "" & soyad.Value != null )
            {
                if (dt.Value == "") { dt.Value = DateTime.Today.ToString("yyyy-MM-dd"); }
            long tcno = Convert.ToInt64(tc.Value);
            String ad_ = ad.Value;
            String soyad_ = soyad.Value;
            String dogumyili = dt.Value.Substring(0, 4).ToString();
            int dogumt = Convert.ToInt32(dogumyili);
            tcNoDogrula.KPSPublic tcdogrula = new tcNoDogrula.KPSPublic();
            try
            {
                bool kontrol = tcdogrula.TCKimlikNoDogrula(tcno, ad_, soyad_, dogumt);
                if (kontrol == true)
                {
                    dogru_uyari.Visible = true;
                    yanlis_uyari.Visible = false;
                    uyari_dogru = "Girilen Kimlik Bilgileri Doğrulandı";

                }
                else
                {
                    dogru_uyari.Visible = false;
                    yanlis_uyari.Visible = true;
                    uyari_yanlis = "Girilen Kimlik Bilgileri Doğrulanamadı.";
                }
            }
            catch (Exception er)
            {

            }
            }
        }
        protected void mailgonder()
        {
            string mailadresimails = "";
            string mailgondericimails = "";
            string mailkullanicimails = "";
            string mailsifremails = "";
            string smtpadresmails = "";
            string smtpportmails = "";
            SqlCommand r = new SqlCommand("SELECT * FROM mail_kullanici_view WHERE tc='" + tc.Value + "'", con);
            SqlDataReader okus = r.ExecuteReader();
            if (okus.Read())
            {
                mailadresimails = okus["mailadresi"].ToString();
                mailgondericimails = okus["mailgonderici"].ToString();
                mailkullanicimails = okus["mailkullanici"].ToString();
                mailsifremails = okus["mailsifre"].ToString();
                smtpadresmails = okus["smtpadres"].ToString();
                smtpportmails = okus["smtpport"].ToString();
            }
            okus.Close();
            con.Close();
            try
            {
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new MailAddress(mailadresimails, mailgondericimails); ;
                msg.To.Add(new MailAddress(email.Value));
                msg.IsBodyHtml = true;
                msg.Subject = " WMSDATA HOŞGELDİNİZ";
                msg.Body = @"<html>
                      <body > <a >
                        <div >      
                           <i><font color=black  ><h1><strong> WMSDATA</strong></h1></font> </i>
                          </div>
                 <i >  <h3> Merhaba ; </h3></i >  <p><i ><a href='http://www.wmsdata.net/'  > WMSDATA  Sistemine kaydınız başarı ile gerçekleşmiştir </a> şifreniz...: wmsdata  Email ve şifre ile giriş yapabilirsiniz. Not: İlk girişte şifrenizi değiştirmeyi unutmayınız. </i> </p>    <hr width=50000 size=2 color=teal align=left />  <address>  <strong> WMSDATA '" + DateTime.Now.ToString() + "'</strong><br>  </address> </div> </a>  </div></body> </html>  ";
                SmtpClient mySmtpClient = new SmtpClient();
                System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential(mailkullanicimails, mailsifremails);
                mySmtpClient.Host = smtpadresmails;
                mySmtpClient.Port = Convert.ToInt32(smtpportmails);
                mySmtpClient.EnableSsl = false;
                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.Credentials = myCredential;
                mySmtpClient.Send(msg);
                msg.Dispose();
            }
            catch (Exception exp)
            {

            }
        }
        protected void temizler()
        {
            ad.Value = "";
            soyad.Value = "";
            tc.Value = "";
            email.Value = "";
            sifre.Value = "";
            sirket.Value = "";
            idAl = "";
            dt.Visible = true;
            gizle.Visible = true;
            tc.Disabled = false;
            sayfadangelen = 0;
        }
        protected void arama()
        {
            conn.Open();
            SqlCommand Cw = new SqlCommand("SELECT COUNT(Id) FROM kullanici", conn);
            verisay = (int)Cw.ExecuteScalar();
            id = new int[verisay + 1];
            kullanici_tc = new string[verisay + 1];
            kullanici_ad = new string[verisay + 1];
            kullanici_soyad = new string[verisay + 1];
            kullanici_email = new string[verisay + 1];
            kullanici_sifre = new string[verisay + 1];
            kullanici_sirket = new string[verisay + 1];
            SqlCommand controlw = new SqlCommand("SELECT * FROM kullanici", conn);
            SqlDataReader drw = controlw.ExecuteReader();
            int ik = verisay;
            while (drw.Read())
            {
                kullanici_tc[ik - 1] = drw["Tc"].ToString();
                kullanici_ad[ik - 1] = drw["ad"].ToString();
                kullanici_soyad[ik - 1] = drw["soyad"].ToString();
                kullanici_email[ik - 1] = drw["email"].ToString();
                kullanici_sifre[ik - 1] = drw["sifre"].ToString();
                kullanici_sirket[ik - 1] = drw["sirket"].ToString();

                ik--;
            }
            drw.Close();
            conn.Close();
        }
        protected void kaydet_ServerClick(object sender, EventArgs e)
        {
            conn.Open();
            string kurum_id = "";
            SqlCommand s_i = new SqlCommand(" SELECT * FROM firmatanimlar WHERE firmaadi='" + sirket.Value + "'  ", conn);
            SqlDataReader dr_s = s_i.ExecuteReader();
            if (dr_s.Read())
            {
                kurum_id = dr_s["Kurum_id"].ToString();
            }
            conn.Close();
            con.Open();
            if (tc.Value != "" & tc.Value != null & ad.Value != "" & ad.Value != null & soyad.Value != "" & soyad.Value != null & email.Value != "" & email.Value != null & sirket.Value != "" & sirket.Value != null)
            {
                string yenisifrem = "wmsdata";
                SqlCommand cmd = new SqlCommand("PersonelKullaniciKaydetGuncelleson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ad", ad.Value);
                cmd.Parameters.AddWithValue("soyad", soyad.Value);
                cmd.Parameters.AddWithValue("tc", tc.Value);
                cmd.Parameters.AddWithValue("email", email.Value);
                cmd.Parameters.AddWithValue("sifre", yenisifrem);
                cmd.Parameters.AddWithValue("sirket", sirket.Value);
                cmd.Parameters.AddWithValue("sirket_id", kurum_id);
                cmd.Parameters.AddWithValue("dogumT", dt.Value);
               //con.Open();
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    uyari_dogru = "Kayıt Başarı ile tamamlandı";
                    mailgonder();
                    temizler();
                    arama();
                }
                con.Close();
            }
            else
            {
                dogru_uyari.Visible = false;
                yanlis_uyari.Visible = true;
                uyari_yanlis = "Tüm Alanlar Doldurulmalıdır.";

            }
        }        



  



    }
}