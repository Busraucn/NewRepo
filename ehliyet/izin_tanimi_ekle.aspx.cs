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
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;



namespace WMSDATA
{
    public partial class izin_tanimi_ekle : System.Web.UI.Page
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
        public static int id_count =0;
        public static string ilktarihimgenel = "";
        public static string sontarihimgenel = "";
        public static string[] secimigerial_id;
        public static string secim_karsilastir = "";
        public static string bosluk = " ";
        public static string id_karsilastir="";
        public static string idAL_karsilastir = "";
        public static string odeme_sekli = "";
        public static string aciklama = "";
        public static byte[] bytes;
        public static string id_sil = "";

        public static string view_ad = "";
        public static string view_tc = "";
        public static string view_belget = "";

        public static string basvuru_durumu_tut = "";
        public static string odeme_durumu_tut = "";
        public static string dogumtarihial;
        public static string dogumtarihiduzelt;
        public static string basvurutarihial;
        public static string basvurutarihiduzelt;
        public static string belgetarihial;
        public static string belgetarihiduzelt;
        public static string belgeverilmetarihial;
        public static string belgeverilmetarihiduzelt;
        public static string belgeiptaltarihial;
        public static string belgeiptaltarihiduzelt;
        public static string odemetarihial;
        public static string odemetarihiduzelt;
        public static string faturatarihial;
        public static string faturatarihiduzelt;
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
        public static DateTime dogumtarihin = Convert.ToDateTime(DateTime.Now);
        public static DateTime isebaslamatarihin = Convert.ToDateTime(DateTime.Now);
        public static DateTime istenayrilmatarihin = Convert.ToDateTime(DateTime.Now);
        public static int verisay=0;
        public static int[] id;
        public static string[] IzinId;
        public static string[] IzinTipi;
        public static string[] Aciklama;
        public static string[] YillikIzinKaontrol;
        public static string[] Kurum_id;

        public static string[] odemedurmu_id;
        public static string[] odemesekli_id;
        public static string[] faturadurumu_id;
        public static string[] belgedurumu_id;
        public static string[] belgetarihi_id;
        public static string[] aciklama_id;
        public static string[] belgeverilmetarihi_id;
        public static string[] belgeiptaltarihi_id;
        public static string[] basvuruyualankisi_isim;        
        public static string[] tc_id;
        public static string[] ad_id;
        public static string[] soyad_id;
        public static string[] dogumtarihi_id;
        public static string[] telefon_id;
        public static string[] basvurutarihi_id;
        public static string[] ad_soyad_id;
        public static string[] meslekdali_id;
        public static string[] belgeverenfirma_id;
        public static string[] anafirma_id;
        public static string[] altfirma_id;
        public static string[] odemetutari_id;
        public static string[] odemetarihi_id;
        public static string[] faturano_id;
        public static string[] kangrubu_id;        
        public static string[] dogumyeri_id;
        public static string[] mailadresi_id;
        public static string[] calismadurumu_id;
        public static string[] isebaslamatarihi_id;
        public static string[] istenayrilmatarihi_id;
        public static string[] faturatarihi_id;
        public static DateTime ilktarihim = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static DateTime sontarihim = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static int move ;
        public static string dogumtarihim = "";
        public static string isebaslamatarihim = "";
        public static string istenayrilmatarihim = "";
        public static string bugununtarihim="";
        public static string bugununtarihim2 = "";
        public static string tc_tut;
        public static int onyazi_acilsin_mi = 0;
        public static string calismadurum = "";

        public static string aranacak_kelime = "";
        public static int aranacakmi = 0;

        SqlConnection con = new SqlConnection(veritabani_baglanti);
        SqlConnection conn = new SqlConnection(veritabani_baglanti);


     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["key"] = kullanici_giris.kullaniciId;
            }
            sayfayukleme();
            YURURLUKBASLANGICTARIHI.Value = DateTime.Today.ToString("yyyy-MM-dd");
            YURURLUKBITISTARIHI.Value = DateTime.Today.ToString("yyyy-MM-dd");
        }


        protected void temizleyici()
        {
            izinim.Value = "";
            
            aciklamam.Value = "";
        }
        protected void sayfayukleme()
        {
            //  ilktariharama.Value = DateTime.Today.ToString("yyyy-MM-dd");
            //  sontariharama.Value = DateTime.Today.ToString("yyyy-MM-dd");

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
            dogru_uyari.Visible = false;
            yanlis_uyari.Visible = false;
            tc_tut = gorevidm.Text;
            bugununtarihim = bugununtarihi.ToString();
            bugununtarihim2 = bugununtarihi.ToString();
            if (sayfayayenigiris == 0 || kullanici_giris.belgeSayfasiCheck == 0)
            {
                sayfayayenigiris = 1;
                con.Close();
                con.Open();
            }
            arama_genel_IDLI();
         }
       protected void izin_Getir(object sender, EventArgs e)
        {
            try
            {
                temizleyici();
                //con.Open();
                SqlCommand control = new SqlCommand("SELECT * FROM PersonelIzınTanim where Id='" + gorevidm.Text + "'", con);
                SqlDataReader dr = control.ExecuteReader();
                while (dr.Read())
                {
                    izinim.Value = dr["PERSONELGOREVi"].ToString();
                    aciklamam.Value = dr["aciklama"].ToString();

                }
                dr.Close();
            }
            catch
            {
                dogru_uyari.Visible = false;
                yanlis_uyari.Visible = true;
                uyari_yanlis = "Bilgiler tam alınamadı ";
            }
        }
        protected void Personel_Kaydet(object sender, EventArgs e)
        {       // con.Open();        
          // if (YURURLUKBASLANGICTARIHI.Value(DateTime) < YURURLUKBITISTARIHI.Value(DateTime)) { 
            SqlCommand cmd = new SqlCommand("IzinTipKaydetGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("PIzinID", gorevidm.Text);
            cmd.Parameters.AddWithValue("PIzin", izinim.Value);
            cmd.Parameters.AddWithValue("PIzinAciklama", aciklamam.Value);
            cmd.Parameters.AddWithValue("PYillikIzinKaontrol", izindurum.Value);
            cmd.Parameters.AddWithValue("Pyururlukbaslangictarihi", YURURLUKBASLANGICTARIHI.Value);
            cmd.Parameters.AddWithValue("Pyururlukbitistarihi", YURURLUKBITISTARIHI.Value);
            cmd.Parameters.AddWithValue("PKurumid", kullanici_giris.kullaniciSİrket_id);
            //con.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                uyari_dogru = "Kayıt Başarı ile tamamlandı";                
            }
            con.Close();
           
        }

        protected void arama_genel_IDLI()
        {
            //con.Open();
            SqlCommand C = new SqlCommand("SELECT count(PersonelIzınTanim.Id) FROM PersonelIzınTanim  WHERE  PersonelIzınTanim.kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            verisay = (int)C.ExecuteScalar();
            IzinId = new string[verisay + 1];
            IzinTipi = new string[verisay + 1];
            Aciklama = new string[verisay + 1];
            YillikIzinKaontrol = new string[verisay + 1];
            //   SqlCommand S = new SqlCommand("SELECT belge_takip.tc , belge_takip.Id , uye_kayit.ad,uye_kayit.soyad,uye_kayit.dogumT,meslekDallari.meslekAdi,belgeVerenFirma.firmaAdı,sirketBilgi.sirketAdı,belge_takip.odemedurumu,belge_takip.faturadurumu.belge_takip.belgeDurumu FROM belge_takip,uye_kayit,belgeVerenFirma,meslekDallari,sirketBilgi WHERE   belge_takip.tc=uye_kayit.Tc AND belge_takip.meslekdali_id=meslekDallari.Id AND belge_takip.belgeverenfirma_id=belgeVerenFirma.Id AND belge_takip.kurum_id=sirketBilgi.Id", con);
            SqlCommand control = new SqlCommand("SELECT PersonelIzınTanim.* FROM PersonelIzınTanim WHERE PersonelIzınTanim.kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
                SqlDataReader dr = control.ExecuteReader();
            int i = verisay;
            while (dr.Read())
            {
                IzinId[i - 1] = dr["Id"].ToString();
                IzinTipi[i - 1] = dr["IzinTipi"].ToString();
                Aciklama[i - 1] = dr["Aciklama"].ToString();
                YillikIzinKaontrol[i - 1] = dr["YillikIzinKaontrol"].ToString();
               

                //  MessageBox.Show(" noluyo " + belgedurumu_id[i - 1]);
                i--;
            }
            dr.Close();
          
        }


        protected void temizle_ServerClick(object sender, EventArgs e)
        {
            temizleyici();
            sayfayukleme();
        }

        private void MessageBox(string v)
        {
            throw new NotImplementedException();
        }      

    }
}