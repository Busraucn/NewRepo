using System;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Net.Mail;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;
using System.IO;

namespace WMSDATA
{
    public partial class ansayfa : System.Web.UI.Page
    {
        public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;
        //   String veritabani_baglanti = kullanici_giris.veritabani_baglanti;
        public static int veri_toplam_personel;
        public static int veri_devameden;
        public static int veri_tamamlanan;
        public static int veri_toplam_proje;
        public static int veri_toplambasvuru;
        public static int veri_devamedensayisi;
        public static int veri_tamamlanansayisi;
        public static int veri_odenen;
        public static int veri_odenmeyen;
        public static int veri_toplamuye;
        public static int veri_toplamkullanici;
        public static int sirket_toplambasvuru;
        public static int sirket_toplamkullanici;
        public static int veri_toplam_olay;
        public static int uye_toplamkisi;
        public static int avatarid;

        public static string uyari_dogru;
        public static string uyari_yanlis;

        public static string tut;
        public static int veri_devameden_yuzde;
        public static int veri_tamamlanan_yuzde;
        public static int veri_odenen_yuzde;
        public static int veri_odenmeyen_yuzde;
        public static int veri_toplamuye_yuzde;

        public static int g1;
        public static int g2;
        public static int g3;
        public static int g4;
        public static int g5;
        public static int g6;
        public static int g1_2;
        public static int g2_2;
        public static int g3_2;
        public static int g4_2;
        public static int g5_2;
        public static int g6_2;
        public static string kullanisim;
        public static string kullansoyisim;
        public static string firma;
        public static string emaili;
        public static string sirketidi;
        public static string kullantc;
        public static string kullansifre;
        public static string sirketadi;
        public static string kullansirketidi;
        public static int yapilacak_say;
        public static int verisay;
        public static int verisay_tamamlanan;
        public static int verisaysayisi;
        public static string tcnumarasi = "";
        public static int verisay_tamamlanansayisi;
        public static int verisay_odenmedi;
        public static int verisay_odenmedisayisi;
        public static int verisay_odendi;
        public static int verisay_odendisayisi;
        public static string[] id;
        public static string[] tc;
        public static string[] ad_soyad;
        public static string[] meslekdali;
        public static string[] belgeverenfirma;
        public static string[] anafirma;

        public static string[] id_tamamlanan;
        public static string[] tc_tamamlanan;
        public static string[] ad_soyad_tamamlanan;
        public static string[] meslekdali_tamamlanan;
        public static string[] belgeverenfirma_tamamlanan;
        public static string[] anafirma_tamamlanan;

        public static string[] id_odenmedi;
        public static string[] tc_odenmedi;
        public static string[] ad_soyad_odenmedi;
        public static string[] meslekdali_odenmedi;
        public static string[] belgeverenfirma_odenmedi;
        public static string[] anafirma_odenmedi;

        public static string[] id_odendi;
        public static string[] tc_odendi;
        public static string[] ad_soyad_odendi;
        public static string[] meslekdali_odendi;
        public static string[] belgeverenfirma_odendi;
        public static string[] anafirma_odendi;

        public static string[] id_yapilacak;
        public static string[] neyapilacak;
        public static string[] yapilacak_durum;

        public static string[] firmaidmail;
        public static string[] mailadresimail;
        public static string[] mailgondericimail;
        public static string[] mailkullanicimail;
        public static string[] mailsifremail;
        public static string[] smtpadresmail;
        public static string[] smtpportmail;




        SqlConnection conn = new SqlConnection(veritabani_baglanti);
        SqlConnection con = new SqlConnection(veritabani_baglanti);
        protected void Page_Load(object sender, EventArgs e)
        {


            //BELGESİ TAMAMLANAN VE DEVAM EDENLERİ BUL

            if (Session["user"] == null)
            {
                // MessageBox.Show(Session["user"].ToString());
                Response.Redirect("kullanici_giris.aspx");
            }
            //Response.Write(Session["user"]);

            con.Open();
            kullanici_giris.belgeSayfasiCheck = 0;
            SqlCommand k3 = new SqlCommand("SELECT COUNT(Id) FROM Personel WHERE PERSONEL.kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            veri_toplam_personel = (int)k3.ExecuteScalar();
            SqlCommand k4 = new SqlCommand("SELECT COUNT(Id) FROM Projekayit WHERE Projekayit.sirket_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            sirket_toplambasvuru = (int)k4.ExecuteScalar();
            SqlCommand k5 = new SqlCommand("SELECT COUNT(Id) FROM ProjeOlaykayit WHERE ProjeOlaykayit.sirket_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            uye_toplamkisi = (int)k5.ExecuteScalar();
            conn.Open();
            SqlCommand yeni = new SqlCommand("SELECT * FROM firmatanimlar_personel_view WHERE tcno='" + Session["user"].ToString() + "'", conn);
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
                kullansifre = bak["sifre"].ToString();
                kullansirketidi = bak["Id"].ToString();
            }

            //GRAFİK DUZENLE

            int i = 0;

            // YAPILACAKLAR LİSTESİ
            SqlCommand w = new SqlCommand("SELECT count(id) FROM yapilacak_list  WHERE tc='" + kullantc + "' AND durumu='0'", con);
            yapilacak_say = (int)w.ExecuteScalar();
            if (yapilacak_say > 200)
            {
                yapilacak_say = 200;
            }


            id_yapilacak = new string[yapilacak_say + 1];
            neyapilacak = new string[yapilacak_say + 1];
            yapilacak_durum = new string[yapilacak_say + 1];



            SqlCommand ww = new SqlCommand("SELECT TOP 200  * FROM yapilacak_list WHERE tc='" + kullantc + "' AND durumu='0'", con);
            ww.ExecuteNonQuery();
            SqlDataReader dw = ww.ExecuteReader();
            i = yapilacak_say;
            while (dw.Read())

            {
                id_yapilacak[i - 1] = dw["id"].ToString();
                neyapilacak[i - 1] = dw["yapilacak"].ToString();
                yapilacak_durum[i - 1] = dw["durumu"].ToString();


                i--;
            }

            dw.Close();
            con.Close();

            veri_devameden = verisaysayisi;
            veri_tamamlanan = verisay_tamamlanansayisi;
            veri_odenen = verisay_odendisayisi;
            veri_odenmeyen = verisay_odenmedisayisi;
            veri_toplambasvuru = veri_devameden + veri_tamamlanan;

            //   MessageBox.Show(veri_odenen.ToString() + " " + veri_toplambasvuru.ToString ()+ " " + veri_odenen_yuzde.ToString ());
            if (veri_toplambasvuru != 0)
            {
                veri_devameden_yuzde = 100 * veri_devameden / veri_toplambasvuru;
                veri_odenmeyen_yuzde = 100 * veri_odenmeyen / veri_toplambasvuru;
                veri_odenen_yuzde = 100 * veri_odenen / veri_toplambasvuru;
                veri_tamamlanan_yuzde = 100 * veri_tamamlanan / veri_toplambasvuru;
            }
            else
            {

                veri_devameden_yuzde = 0;
                veri_odenmeyen_yuzde = 0;
                veri_odenen_yuzde = 0;
                veri_tamamlanan_yuzde = 0;

            }



            qruertici();

        }

        public void qruertici()
        {
            tcnumarasi = kullanici_giris.kullaniciTc.ToString();
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
           //     QRCodeGenerator.QRCode kod = koduret.CreateQrCode(kullanici_giris.kullaniciSİrket_id + "-" + "wmsdata.net" + "-" + tcnumarasi.ToString(), QRCodeGenerator.ECCLevel.Q);
         //       using (Bitmap bmp = kod.GetGraphic(5))
                {
           //         bmp.Save(ms, ImageFormat.Png);
                    qrimage.ImageUrl = "data:imge/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

        }
        protected void yapilacak_ServerClick(object sender, EventArgs e)
        {


            con.Open();
            SqlCommand ww = new SqlCommand("INSERT INTO yapilacak_list VALUES(upper('" + kullanici_giris.kullaniciTc + "'),upper('" + metin.Value + "'),'0')", con);
            ww.ExecuteNonQuery();




            con.Close();
            con.Open();
            metin.Value = "";

            SqlCommand w = new SqlCommand("SELECT count(id) FROM yapilacak_list WHERE tc='" + kullantc + "' AND durumu='0'", con);
            yapilacak_say = (int)w.ExecuteScalar();
            id_yapilacak = new string[yapilacak_say + 1];
            neyapilacak = new string[yapilacak_say + 1];
            yapilacak_durum = new string[yapilacak_say + 1];



            SqlCommand r = new SqlCommand("SELECT * FROM yapilacak_list WHERE tc='" + kullantc + "' AND durumu='0'", con);
            r.ExecuteNonQuery();
            SqlDataReader dw = r.ExecuteReader();
            int i = yapilacak_say;
            while (dw.Read())

            {
                id_yapilacak[i - 1] = dw["id"].ToString();
                neyapilacak[i - 1] = dw["yapilacak"].ToString();
                yapilacak_durum[i - 1] = dw["durumu"].ToString();


                i--;
            }

            dw.Close();
            con.Close();

        }

        protected void degis1_ServerClick(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand ww = new SqlCommand("UPDATE yapilacak_list SET durumu='1' WHERE id='" + id_yapilacak[0] + "' ", con);
            ww.ExecuteNonQuery();

            SqlCommand r = new SqlCommand("SELECT * FROM yapilacak_list WHERE tc='" + kullantc + "' AND durumu='0'", con);
            r.ExecuteNonQuery();
            SqlDataReader dw = r.ExecuteReader();
            int i = yapilacak_say;
            while (dw.Read())

            {
                id_yapilacak[i - 1] = dw["id"].ToString();
                neyapilacak[i - 1] = dw["yapilacak"].ToString();
                yapilacak_durum[i - 1] = dw["durumu"].ToString();


                i--;
            }

            dw.Close();
            con.Close();

        }

        protected void degis2_ServerClick(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand ww = new SqlCommand("UPDATE yapilacak_list SET durumu='1' WHERE id='" + id_yapilacak[1] + "' ", con);
            ww.ExecuteNonQuery();

            SqlCommand r = new SqlCommand("SELECT * FROM yapilacak_list WHERE tc='" + kullantc + "' AND durumu='0'", con);
            r.ExecuteNonQuery();
            SqlDataReader dw = r.ExecuteReader();
            int i = yapilacak_say;
            while (dw.Read())

            {
                id_yapilacak[i - 1] = dw["id"].ToString();
                neyapilacak[i - 1] = dw["yapilacak"].ToString();
                yapilacak_durum[i - 1] = dw["durumu"].ToString();


                i--;
            }

            dw.Close();
            con.Close();
        }

        protected void degis3_ServerClick(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand ww = new SqlCommand("UPDATE yapilacak_list SET durumu='1' WHERE id='" + id_yapilacak[2] + "' ", con);
            ww.ExecuteNonQuery();

            SqlCommand r = new SqlCommand("SELECT * FROM yapilacak_list WHERE tc='" + kullantc + "' AND durumu='0'", con);
            r.ExecuteNonQuery();
            SqlDataReader dw = r.ExecuteReader();
            int i = yapilacak_say;
            while (dw.Read())

            {
                id_yapilacak[i - 1] = dw["id"].ToString();
                neyapilacak[i - 1] = dw["yapilacak"].ToString();
                yapilacak_durum[i - 1] = dw["durumu"].ToString();


                i--;
            }

            dw.Close();
            con.Close();

        }

        protected void degis4_ServerClick(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand ww = new SqlCommand("UPDATE yapilacak_list SET durumu='1' WHERE id='" + id_yapilacak[3] + "' ", con);
            ww.ExecuteNonQuery();

            SqlCommand r = new SqlCommand("SELECT * FROM yapilacak_list WHERE tc='" + kullantc + "' AND durumu='0'", con);
            r.ExecuteNonQuery();
            SqlDataReader dw = r.ExecuteReader();
            int i = yapilacak_say;
            while (dw.Read())

            {
                id_yapilacak[i - 1] = dw["id"].ToString();
                neyapilacak[i - 1] = dw["yapilacak"].ToString();
                yapilacak_durum[i - 1] = dw["durumu"].ToString();


                i--;
            }

            dw.Close();
            con.Close();


        }

        protected void degis5_ServerClick(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand ww = new SqlCommand("UPDATE yapilacak_list SET durumu='1' WHERE id='" + id_yapilacak[4] + "' ", con);
            ww.ExecuteNonQuery();

            SqlCommand r = new SqlCommand("SELECT * FROM yapilacak_list WHERE tc='" + kullantc + "' AND durumu='0'", con);
            r.ExecuteNonQuery();
            SqlDataReader dw = r.ExecuteReader();
            int i = yapilacak_say;
            while (dw.Read())

            {
                id_yapilacak[i - 1] = dw["id"].ToString();
                neyapilacak[i - 1] = dw["yapilacak"].ToString();
                yapilacak_durum[i - 1] = dw["durumu"].ToString();


                i--;
            }

            dw.Close();
            con.Close();

        }

        protected void degis6_ServerClick(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand ww = new SqlCommand("UPDATE yapilacak_list SET durumu='1' WHERE id='" + id_yapilacak[5] + "' ", con);
            ww.ExecuteNonQuery();

            SqlCommand r = new SqlCommand("SELECT * FROM yapilacak_list WHERE tc='" + kullantc + "' AND durumu='0'", con);
            r.ExecuteNonQuery();
            SqlDataReader dw = r.ExecuteReader();
            int i = yapilacak_say;
            while (dw.Read())

            {
                id_yapilacak[i - 1] = dw["id"].ToString();
                neyapilacak[i - 1] = dw["yapilacak"].ToString();
                yapilacak_durum[i - 1] = dw["durumu"].ToString();


                i--;
            }

            dw.Close();
            con.Close();

        }

        protected void degis7_ServerClick(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand ww = new SqlCommand("UPDATE yapilacak_list SET durumu='1' WHERE id='" + id_yapilacak[6] + "' ", con);
            ww.ExecuteNonQuery();

            SqlCommand r = new SqlCommand("SELECT * FROM yapilacak_list WHERE tc='" + kullantc + "' AND durumu='0'", con);
            r.ExecuteNonQuery();
            SqlDataReader dw = r.ExecuteReader();
            int i = yapilacak_say;
            while (dw.Read())

            {
                id_yapilacak[i - 1] = dw["id"].ToString();
                neyapilacak[i - 1] = dw["yapilacak"].ToString();
                yapilacak_durum[i - 1] = dw["durumu"].ToString();


                i--;
            }

            dw.Close();
            con.Close();
        }

        protected void emaildegis_ServerClick(object sender, EventArgs e)
        {
            if (yeniemail.Value != null & yeniemail.Value != "")
            {
                con.Open();
                SqlCommand ww = new SqlCommand("UPDATE kullanici SET email=upper('" + yeniemail.Value + "') WHERE tc='" + kullantc + "'", con);
                ww.ExecuteNonQuery();
                SqlDataReader dw = ww.ExecuteReader();
                dw.Close();
                con.Close();
                yeniemail.Value = "";
            }
        }

        protected void sifredegis_ServerClick(object sender, EventArgs e)
        {
            string firmaadimails = "";
            string mailadresimails = "";
            string mailgondericimails = "";
            string mailkullanicimails = "";
            string mailsifremails = "";
            string smtpadresmails = "";
            string smtpportmails = "";

            con.Open();
                SqlCommand ww = new SqlCommand("UPDATE personel SET sifre= HASHBYTES('MD5','" + yenisifre.Value + "') WHERE tcno='" + kullantc + "' and sifre= HASHBYTES('MD5','" + eskisifre.Value + "')", con);
                ww.ExecuteNonQuery();
                SqlDataReader dw = ww.ExecuteReader();
                dw.Close();


            SqlCommand r = new SqlCommand("SELECT * FROM mail_kullanici_view WHERE tc='" + kullanici_giris.kullaniciTc + "'", con);
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
                msg.From = new MailAddress(mailadresimails.ToString(), mailgondericimails.ToString()); ;   
                msg.To.Add(new MailAddress(kullanici_giris.kullaniciEmail.ToString()));
                msg.IsBodyHtml = true;
                msg.Subject = " ŞİFRENİZ YENİLENDİ ";
                msg.Body = @"<html>
                      <body > <a >
                        <div >      
                           <i><font color=black  ><h1><strong> WMSDATA</strong></h1></font> </i>
                          </div>
                 <i >  <h3>MERHABA ŞİFRENİZ DEĞİŞTİRİLDİ, BU İŞLEMİ SİZ YAPMADIYSANIZ LÜTFEN YÖNETİCİNİZE BİLGİ VERİNİZ. ; </h3></i >  <p><i ><a href='http://WMSDATA.com/kullanici_giris.aspx'  > WMSDATA Email Adresin ve Yeni şifre ile giriş yapabilirsin. </i> </p>    <hr width=50000 size=2 color=teal align=left />  <address>  <strong> WMSDATA </strong><br>  Aydıntepe Mah. Sahilbulvarı Cad. Alize İş Merkezi<br>No: 191 / 12, İçmeler - Tuzla / İstanbul<br> <abbr  > Telefon: </abbr> +90 (216) 565 55 55 </address> </div> </a>  </div></body> </html>  ";
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
        private void MessageBox(string v)
        {
            throw new NotImplementedException();
        }
    }
}