using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Mail;

namespace WMSDATA
{
    public partial class kullanici_giris : System.Web.UI.Page
    {
        public static string veritabani_dosya_yolu;
        public static string kullaniciEmail;
        public static string kullaniciId;
        public static string kullaniciSifre;
        public static string kullaniciTc;
        public static string kullaniciİsim;
        public static string kullaniciSoyisim;
        public static string kullaniciSİrket;
        public static string kullaniciKURUM;
        public static string kullaniciSİrket_id;
        public static string kullansirketidi;
        public static string uyaritext = "";
        public static int verisay = 0;
        public static string[] secilen_id;
        public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;

        public static int belgeSayfasiCheck = 0;
        public static int yapilacak_say;
        public static string[] firmaidmail;
        public static string[] mailadresimail;
        public static string[] mailgondericimail;
        public static string[] mailkullanicimail;
        public static string[] mailsifremail;
        public static string[] smtpadresmail;
        public static string[] smtpportmail;
        public string dosya_oku()
        {

            string sonuc = "";
            FileStream fs = new FileStream(veritabani_dosya_yolu, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            sonuc = sr.ReadToEnd();
            fs.Close();
            return sonuc;
            // MessageBox.Show(sonuc);
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                ViewState["key"] = kullanici_giris.kullaniciId;
            }

            uyari.Visible = false;
            con.Open();
            SqlCommand C = new SqlCommand("SELECT count(personel.Id) FROM personel", con);

            verisay = (int)C.ExecuteScalar();
            secilen_id = new string[verisay];

            con.Close();
        }
        //SQL BAĞLANTIM BURADA
        SqlConnection con = new SqlConnection(veritabani_baglanti);
        SqlConnection conn = new SqlConnection(veritabani_baglanti);


        protected void giris_ServerClick(object sender, EventArgs e)
        {
                 if (sifre.Value != "" && email.Value != "")
                 {
                     uyari.Visible = false;
                     con.Open();
                     SqlCommand sql = new SqlCommand("SELECT Tcno,ad,soyad,email,Id, HASHBYTES('MD5', sifre) AS KULLANICI_SIFRE ,Kurum_id, firmaadi  FROM firmatanimlar_PERSONEL_view where email ='" + email.Value + "' AND sifre= HASHBYTES('MD5', '" + sifre.Value + "')", con);
                     SqlDataReader oku = sql.ExecuteReader();
                     if (oku.Read())
                     {
                         /*kullaniciId = oku["Id"].ToString();*/
                      kullaniciTc = oku["TcNO"].ToString();
                        Session["user"] = kullaniciTc.ToString();
                        kullansirketidi = oku["Id"].ToString();
                        kullaniciSİrket_id = oku["kurum_id"].ToString();
                        kullaniciEmail = oku["email"].ToString();
                        //kullaniciİsim = oku["ad"].ToString();
                        // kullaniciSoyisim = oku["soyad"].ToString();
                        uyari.Visible = false;
                        uyaritext = "";
                        conn.Open();
                        SqlCommand yeni = new SqlCommand("SELECT ilkgiris FROM kullanici1 WHERE tc='" + oku["TcNO"].ToString() + "'", conn);
                        SqlDataReader bak = yeni.ExecuteReader();
                        if (bak.Read())
                        {

                            if ((int)bak["ilkgiris"] == 0)
                            {

                                Response.Redirect("ilkGiris.aspx");
                            }
                            else
                            {
                                if (Session["user"] == null)
                                {
                                    // MessageBox.Show(Session["user"].ToString());
                                    Response.Redirect("kullanici_giris.aspx");
                                }
                                else
                                {
                                    email.Value = "";
                                    sifre.Value = "";
                                    Response.Redirect("ansayfa.aspx");
                                }
                            }
                        }

                        conn.Close();
                        //   

                    }
                    else
                    {
                        uyari.Visible = true;
                        uyaritext = "Girdiğiniz Bilgilere Ait Bir Kullanıcı Bulunamadı.";
                    }
                    con.Close();
                }
                else
                {
                    uyari.Visible = true;
                    uyaritext = "Email ve Şifre Doldurulmalıdır.";
                }
            /*     }
                     catch
                       {

                       }
                   }
                   else
                   {
                       uyaritext = "Doğrulama kodunu kontrol ediniz!";            
                   }
       */
        }
        protected void Unnamed_ServerClick2(object sender, EventArgs e)
        {  
            tckimlikno.Visible = true;
            sifreyenile.Visible = true;
            
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

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            string yenisifre = RastgeleUret();

            if (email.Value != "" && email.Value != null && tckimlikno.Value != "" && tckimlikno.Value != null)
            {
                    con.Open();
                    SqlCommand ww = new SqlCommand("UPDATE personel SET sifre= HASHBYTES('MD5','" + yenisifre + "') WHERE tcno='" + tckimlikno.Value + "' and mailadresi='" + email.Value + "'", con);
                    ww.ExecuteNonQuery();
                    SqlDataReader dw = ww.ExecuteReader();
                    dw.Close();
                    con.Close();



                string ad = "";
                string soyad = "";
                string sifre = "";
                string mailadresimails = "";
                string mailgondericimails = "";
                string mailkullanicimails = "";
                string mailsifremails = "";
                string smtpadresmails = "";
                string smtpportmails = "";
                
                con.Open();
                SqlCommand sql = new SqlCommand("SELECT  HASHBYTES('MD5', sifre) AS KULLANICI_SIFRE , ad, soyad  FROM firmatanimlar_PERSONEL_view where email ='" + email.Value + "'  ", con);
                SqlDataReader oku = sql.ExecuteReader();
                if (oku.Read())
                {
                    ad = oku["ad"].ToString();
                    soyad = oku["soyad"].ToString();
                    sifre = oku["KULLANICI_SIFRE"].ToString();
                }
                oku.Close();
           
                SqlCommand r = new SqlCommand("SELECT * FROM mail_kullanici_view WHERE email='" + email.Value + "' and tc='" + tckimlikno.Value + "'", con);
                SqlDataReader okus = r.ExecuteReader();
                if (okus.Read())
                {
                    
                    mailadresimails = okus["mailadresi"].ToString();
                    mailgondericimails = okus["mailgonderici"].ToString();
                    mailkullanicimails= okus["mailkullanici"].ToString();
                    mailsifremails= okus["mailsifre"].ToString();
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
                    msg.Subject = " ŞİFREMİ UNUTTUM ";
                    msg.Body = @"<html>
                      <body > <a >
                        <div >      
                           <i><font color=black  ><h1><strong> WMSDATA</strong></h1></font> </i>
                          </div>
                 <i >  <h3> HOŞGELDİN  " + ad.ToUpper() + "  " + soyad.ToUpper() + " ; </h3></i >  <p><i ><a href='http://WMSDATA.com/kullanici_giris.aspx'  > WMSDATA </a> şifreniz...:  " + yenisifre + "  Email ve şifre ile giriş yapabilirsin. </i> </p>    <hr width=50000 size=2 color=teal align=left />  <address>  <strong> WMSDATA </strong><br>  Aydıntepe Mah. Sahilbulvarı Cad. Alize İş Merkezi<br>No: 191 / 12, İçmeler - Tuzla / İstanbul<br> <abbr  > Telefon: </abbr> +90 (216) 565 55 55 </address> </div> </a>  </div></body> </html>  ";
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
                    uyari.Visible = true;
                    uyaritext = "Mail Atılamadı.";
                }
            }
            else
            {
                uyari.Visible = true;
                uyaritext = "EMAİLİNİZİ GİRİNİZ.";

            }
        }
    }
}