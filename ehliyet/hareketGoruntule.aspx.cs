using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Mail;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html;

namespace WMSDATA
{
    public partial class hareketGoruntule : System.Web.UI.Page
    {
        public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;
        //   String veritabani_baglanti = kullanici_giris.veritabani_baglanti;


        public static string aradigimkelime = "";
        public static string uyari_dogru = "";
        public static string uyari_yanlis = "";
        public static int sayfayayenigiris = 0;
        public static int guncellenecek_id = -1;
        public static int idli_uye_guncelle = -1;
        public static int guncellenecek_mi = 0;
        public static int anasayfadan_gelen_belge = 0;
        public static string aranandegisken = "";
        public static string id_tut = "";
        public static int id_count = 0;
        public static string ilktarihimgenel = "";
        public static string sontarihimgenel = "";
        public static string[] secimigerial_id;
        public static string secim_karsilastir = "";
        public static string bosluk = " ";
        public static string id_karsilastir = "";
        public static string idAL_karsilastir = "";
        public static string odeme_sekli = "";
        public static string aciklama = "";

        public static string id_sil = "";
        public static string id_duzenle = "";

        public static string[] ElleDuzeltildi;
        public static string[] HareketSonuc;

        public static string view_ad = "";
        public static string view_tc = "";
        public static string view_belget = "";

        public static string basvuru_durumu_tut = "";
        public static string odeme_durumu_tut = "";

        public static int guncellenecek = 0;
        public static int verilertemizlensin = 0;

        public static string odemedurumu_yaz = "";
        public static string odemebosolmaz = "";
        public static string odendi_yaz = "";
        public static string odemedurumu_tut = "";
        public static DateTime odemetarihi_tut = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static string odemetutari_tut = "";

        public static string faturadurumu_yaz = "";
        public static string faturabosolamaz = "";
        public static string faturakesilmedi_yaz = "";
        public static string faturadurumu_tut = "";
        public static DateTime faturatarihi_tut = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static string faturano_tut = "";
        public static string belgeT_tut = "";
        public static int belget_yonet = 0;
        public static DateTime bugununtarihi = Convert.ToDateTime(DateTime.Now);
        public static DateTime bugununtarihi2 = Convert.ToDateTime(DateTime.Now);
        public static int verisay = 0;
        public static string[] id;
        public static string[] odemedurmu_id;
        public static string[] faturadurumu_id;
        public static string[] belgedurumu_id;
        public static string[] belgetarihi_id;
        public static string[] belgeverilmetarihi_id;
        public static string[] belgeiptaltarihi_id;
        public static string[] basvuruyualankisi_isim;
        public static string[] KartNo;
        public static string[] TcNo;
        public static string[] Adi;
        public static int[] idS;
        public static string[] Soyad;
        public static string[] Tarih;
        public static string[] HareketTipi;
        public static string[] KayitKaynak;
        public static string[] Durum;
        public static string[] KayitKullanici;
        public static string[] anafirma_id;
        public static string[] altfirma_id;
        public static string[] odemetutari_id;
        public static string[] odemetarihi_id;
        public static DateTime ilktarihim = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static DateTime sontarihim = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static int move;
        public static string bugununtarihim = "";
        public static string bugununtarihim2 = "";
        public static string tc_tut;
        public static int onyazi_acilsin_mi = 0;

        public static string aranacak_kelime = "";
        public static int aranacakmi = 0;

        SqlConnection con = new SqlConnection(veritabani_baglanti);
        SqlConnection conn = new SqlConnection(veritabani_baglanti);



        protected void Page_Load(object sender, EventArgs e)
        {
            // ilktariharama.Value = DateTime.Today.ToString("dd-MM-yyyy");

            //  sontariharama.Value = DateTime.Today.ToString("dd-MM-yyyy");
            if (!Page.IsPostBack)
            {
                ViewState["key"] = kullanici_giris.kullaniciId;
            }

            if (Session["user"] == null)
            {
                Response.Redirect("kullanici_giris.aspx");
            }
            String idA = "";
            if (verilertemizlensin == 0)
            {
                idA = Request.QueryString["idd"];
            }
            else
            {
                idA = "";
                verilertemizlensin = 0;

            }
            id_tut = Request.QueryString["id_tut"];
            if (id_tut != null & id_tut != "")
            {

                kullanici_giris.secilen_id[id_count] = id_tut;
                id_count++;
                secim_karsilastir = id_tut;
                id_tut = "";
                sayfayayenigiris = 0;
            }
            id_sil = Request.QueryString["id_sil"];
            if (id_sil != null & id_sil != "")
            {
                if (kullanici_giris.secilen_id.Contains(id_sil) == true)
                {
                    int indeks = Array.IndexOf(kullanici_giris.secilen_id, id_sil);

                    if (indeks > 0)
                    {
                        Array.Clear(kullanici_giris.secilen_id, indeks, 1);
                    }
                    sayfayayenigiris = 0;
                }

            }

            if (idA != null & idA != "")
            {
                if (id_karsilastir.ToString() != idA.ToString())
                {
                    anasayfadan_gelen_belge = 0;
                    //  MessageBox.Show(anasayfadan_gelen_belge.ToString() +"   "+ id_karsilastir.ToString() +"  "+ idA.ToString()+ " anasayfadan_gelen_belge 0 Mİ");
                    sayfayayenigiris = 0;
                    onyazi_acilsin_mi = 1;
                }
                else
                {
                    anasayfadan_gelen_belge = 1;
                    //  MessageBox.Show(anasayfadan_gelen_belge.ToString() + " 0 dan anasayfadan_gelen_belge 1 Mİ");                   

                }
            }



            String idAl = "";

            if (verilertemizlensin == 0)
            {
                idAl = Request.QueryString["id"];
            }
            else
            {
                idAl = "";
                verilertemizlensin = 0;

            }
            if (idAl != null & idAl != "")
            {
                if (idAL_karsilastir.ToString() != idAl.ToString())
                {
                    anasayfadan_gelen_belge = 0;
                    //  MessageBox.Show(anasayfadan_gelen_belge.ToString() + "   " + idAL_karsilastir.ToString() + "  " + idAl.ToString() + " idAl anasayfadan_gelen_belge 0 Mİ");
                    sayfayayenigiris = 0;
                    onyazi_acilsin_mi = 1;
                }
                else
                {

                    anasayfadan_gelen_belge = 1;
                    //  MessageBox.Show(anasayfadan_gelen_belge.ToString() + " 0 dan anasayfadan_gelen_belge 1 Mİ");


                }
            }
             id_duzenle = Request["id_duzenle"];
        

            dogru_uyari.Visible = false;
            yanlis_uyari.Visible = false;
            bugununtarihim = bugununtarihi.ToString();
            bugununtarihim2 = bugununtarihi.AddMonths(-1).ToString();

            if (kullanici_giris.kullaniciSİrket_id == "-2")
            {
                arama_genel_GENEL();
            }
            else
            {
                arama_genel_GENEL();
            }
  
             con.Close();
        }

        protected void arama_genel_GENEL()
        {
            if (ilktariharama.Value != null && ilktariharama.Value != "")
            {
                ilktarihim = Convert.ToDateTime(ilktariharama.Value);
            }
            else
            {
                ilktarihim = DateTime.Today.Date;
            }

            if (sontariharama.Value != null && sontariharama.Value != "")
            {
                sontarihim = Convert.ToDateTime(sontariharama.Value);
            }
            else
            {
                sontarihim = DateTime.Today.Date;
            }

            ilktarihimgenel = ilktarihim.ToString("dd.MM.yyyy");
           
            sontarihimgenel = sontarihim.ToString("dd.MM.yyyy");

            aranandegisken = "odemetarihi";
            con.Open();
            SqlCommand C = new SqlCommand("SELECT count(VIEW_HAREKETLER.Id) FROM VIEW_HAREKETLER", con);


            verisay = (int)C.ExecuteScalar();

            id = new string[verisay + 1];
            TcNo = new string[verisay + 1];
            KartNo = new string[verisay + 1];
            Adi = new string[verisay + 1];
            Soyad = new string[verisay + 1];
            Tarih = new string[verisay + 1];
            HareketTipi = new string[verisay + 1];
            KayitKaynak = new string[verisay + 1];
            Durum = new string[verisay + 1];
            KayitKullanici = new string[verisay + 1];
            ElleDuzeltildi = new string[verisay + 1];
            HareketSonuc = new string[verisay + 1];

            //   SqlCommand S = new SqlCommand("SELECT belge_takip.tc , belge_takip.Id , uye_kayit.ad,uye_kayit.soyad,uye_kayit.dogumT,meslekDallari.meslekAdi,belgeVerenFirma.firmaAdı,sirketBilgi.sirketAdı,belge_takip.odemedurumu,belge_takip.faturadurumu.belge_takip.belgeDurumu FROM belge_takip,uye_kayit,belgeVerenFirma,meslekDallari,sirketBilgi WHERE   belge_takip.tc=uye_kayit.Tc AND belge_takip.meslekdali_id=meslekDallari.Id AND belge_takip.belgeverenfirma_id=belgeVerenFirma.Id AND belge_takip.kurum_id=sirketBilgi.Id", con);
            SqlCommand control = new SqlCommand("SELECT VIEW_HAREKETLER.* FROM VIEW_HAREKETLER", con);
            SqlDataReader dr = control.ExecuteReader();
            int i = verisay;
            while (dr.Read())
            {
                id[i - 1] = dr["hareketId"].ToString();
                TcNo[i - 1] = dr["TcNo"].ToString();
                KartNo[i - 1] = dr["KartNo"].ToString();
                Adi[i - 1] = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                Tarih[i - 1] = dr["Tarih"].ToString();
                HareketTipi[i - 1] = dr["HareketTipi"].ToString();
                KayitKaynak[i - 1] = dr["KayitKaynak"].ToString();
                Durum[i - 1] = dr["Durum"].ToString();
                KayitKullanici[i - 1] = dr["KayitKullanici"].ToString();
                ElleDuzeltildi[i - 1] = dr["ElleDuzeltildi"].ToString();
                HareketSonuc[i - 1] = dr["HareketSonuc"].ToString();
                //  MessageBox.Show(" noluyo " + belgedurumu_id[i - 1]);
                i--;
            }
            dr.Close();
            con.Close();
        }

      
        protected void arama_button_ServerClick(object sender, EventArgs e)
        {
            if (kullanici_giris.kullaniciSİrket_id == "-2")
            {
                arama_genel_GENEL();
            }
            else
            {
                arama_genel_GENEL();
            }
        }
 

        private void MessageBox(string v)
        {
            throw new NotImplementedException();
        }

        protected void personelCalismaKaydet_ServerClick(object sender, EventArgs e)
        {

          
            con.Open();
            if (Request.QueryString["id_duzenle"] != null)
            {
                SqlCommand ww = new SqlCommand("UPDATE Hareket set ElleDuzeltildi=1 , HareketSonuc='" + calismaDurum.Value + "' where Id ='" + int.Parse( hareketId.Value) + "'", con);
                ww.ExecuteNonQuery();
                SqlDataReader dw = ww.ExecuteReader();
                dw.Close();
            }
           
            con.Close();
        }
    }
   
}