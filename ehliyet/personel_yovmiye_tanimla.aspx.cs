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
    public partial class personel_yovmiye_tanimla : System.Web.UI.Page
    {
         public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;
        //   String veritabani_baglanti = kullanici_giris.veritabani_baglanti;

        public static string ayarid = "";
        public static string BESYIL = "";
        public static string ONBESYIL = "";
        public static string ONBESYILDANFAZLA = "";
        public static string ONSEKIZYASINDANAZ = "";
        public static string ELLIYASINDANFAZLA = "";
        public static string IDARIIZINSAYISI = "";
        public static string HAFTATATILGUNSAYISI = "";
        public static string ayardepartmanlist = "";

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
        public static int izingun = 0;
        public static int calyil = 0;
        public static int calyil1 = 0;
        public static int calyil2 = 0;
        public static int calyil3 = 0;
        public static int calyil4 = 0;
        public static int calyil5 = 0;
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
        public static string izintipial;
        public static string izintipial2;
        public static string faturatarihiduzelt;
        public static string calismasuresi;
        public static string kullanilanizinsuresi;
        public static string yasi;
        public static string idarisure;
        public static int guncellenecek = 0;
        public static int verilertemizlensin = 0;
        public static string secilentext = "";

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
        public static DateTime isegiristarihim ;
        public static DateTime dogumtarihimm;

        public static String idAl = "";
        public static int verisay=0;
        public static int[] id;
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
        public static string[] idm;
        public static string[] soyad_id;
        public static string[] dogumtarihi_id;
        public static string[] telefon_id;
        public static string[] basvurutarihi_id;
        public static string[] ad_soyad_id;
        public static string[] meslekdali_id;
        public static string[] belgeverenfirma_id;
        public static string[] BelgeAdiM;
        public static string[] BelgeSüresiM;
        public static string[] AciklamaM;
        public static string[] BelgeDosyaAdiM;
        public static string[] Aciklama;
        public static string[] BelgeBitisTarihiM;
        public static string[] BelgeBaslangicTarihiM;        
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
        public static int degisenid;
        public static int sayfadangelen = 0;
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
            personelgetir();

            if (tckimlik1.Text != "") { arama_genel_IDLI(); }
            if (tckimlik1.Text == " ") { arama_genel(); }

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


            if (idAl != null && idAl != "" & guncellenecek == 0)
            {
                con.Open();
                guncellenecek = 1;
                degisenid = int.Parse(idAl);
                
                id_karsilastir = degisenid.ToString();
                SqlCommand control = new SqlCommand("SELECT personel_izin_liste_view.* FROM personel_izin_liste_view WHERE Id='" + degisenid + "'", con);
                SqlDataReader dr = control.ExecuteReader();
                int i = verisay;
                while (dr.Read())
                {

                    yovmiye.Value = dr["IzinTipi"].ToString();
                    yururlulukbaslangictarihi.Value = dr["IzincikisTarihi"].ToString();
                    Bitis_Tarihi.Value = dr["aIzincikisTarihi"].ToString();
                    aciklamam1.Value = dr["aciklama"].ToString();
                    i--;
                }
                dr.Close();
                sayfadangelen = -2;
                con.Close();
                if (secilentext !="") { tckimlik1.Text = secilentext; izin_algetir(); }
            }
        }


        protected void temizleyici()
        {
            yovmiye.Value = "";
                     
        }
        protected void sayfayukleme()
        {
            //  ilktariharama.Value = DateTime.Today.ToString("yyyy-MM-dd");
            //  sontariharama.Value = DateTime.Today.ToString("yyyy-MM-dd");

            if (Session["user"] == null)
            {
                Response.Redirect("kullanici_giris.aspx");
            }
            dogru_uyari.Visible = false;
            yanlis_uyari.Visible = false;
        }

        protected void izin_algetir()
        {
            try
            {
                con.Open();
                temizleyici();
                string secilen1 = tckimlik1.Text;
                string sonsecilen2 = secilen1.Split(' ').First();

                //con.Open();
                SqlCommand control = new SqlCommand("SELECT *,  (DATEDIFF(DAY,DoğumTarihi,GETDATE()))/365  as 'Yas' , (DATEDIFF(DAY,IşeBaşlamaTarihi,GETDATE())) /365  as 'calismasuresi' , (select sum(DATEDIFF(DD, Izincikistarihi, IzinDonusTarihi)) as kullanilansure from personel_izin_view where IzinTipi <> '' and tcno='" + sonsecilen2 + "' ) AS KULLANILANSURE,(select sum(DATEDIFF(DD, Izincikistarihi, IzinDonusTarihi)) as kullanilansure from personel_izin_view where IzinTipi = '' and tcno='" + sonsecilen2 + "') AS IDARISURE FROM Personel_izin_view where tcno='" + sonsecilen2 + "'", con);
                SqlDataReader dr = control.ExecuteReader();
                while (dr.Read())
                {

                    calismasuresi = dr["calismasuresi"].ToString();
                    yasi = dr["Yas"].ToString();
                    idarisure = dr["IDARISURE"].ToString();
                    kullanilanizinsuresi = dr["KULLANILANSURE"].ToString();
                   // izinn1.Value = dr["PGorevID"].ToString();
                }
                


            }
            catch
            {
                dogru_uyari.Visible = false;
                yanlis_uyari.Visible = true;
                uyari_yanlis = "Bilgiler tam alınamadı ";
            }
            con.Close();

        }
        protected void izin_Getir(object sender, EventArgs e)
        {
            secilentext = tckimlik1.SelectedValue;
            izin_algetir();
           
        }
        public void izinayargetir()
        {
            con.Open();

            SqlCommand control = new SqlCommand("SELECT personel_izin_ayarlar_departman_view.* FROM personel_izin_ayarlar_departman_view WHERE departman='" + yovmiye.Value + "' and kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            SqlDataReader dr = control.ExecuteReader();
            int i = verisay;
            while (dr.Read())
            {
                ayarid = dr["Id"].ToString();
                BESYIL = dr["BESYIL"].ToString();
                ONBESYIL = dr["ONBESYIL"].ToString();
                ONBESYILDANFAZLA = dr["ONBESYILDANFAZLA"].ToString();
                ONSEKIZYASINDANAZ = dr["ONSEKIZYASINDANAZ"].ToString();
                ELLIYASINDANFAZLA = dr["ELLIYASINDANFAZLA"].ToString();
                IDARIIZINSAYISI = dr["IDARIIZINSAYISI"].ToString();
                HAFTATATILGUNSAYISI = dr["HAFTATATILGUNSAYISI"].ToString();
                ayardepartmanlist = dr["Departman"].ToString();
                i--;
            }
            dr.Close();
            con.Close();
        }



        public void personelgetir()
        {
            con.Open();    
            if (tckimlik1.Text == "")
            {
                tckimlik1.Items.Clear();
            tckimlik1.Items.Add(" ");
            SqlCommand s3 = new SqlCommand("SELECT * FROM personel_departman_view WHERE DepartmanYonetici='"+kullanici_giris.kullaniciTc + "' and tcno<>'"+ kullanici_giris.kullaniciTc + "'", con);
            SqlDataReader oku3 = s3.ExecuteReader();
            while (oku3.Read())
            {
                tckimlik1.Items.Add(oku3["tcno"].ToString() + " " + oku3["ad"].ToString() + " " + oku3["soyad"].ToString() );
                    
            }
            oku3.Close();
            
            }
            con.Close();
            izinayargetir();
         }

        protected void izin_Kaydet(object sender, EventArgs e)
        {
            con.Open();
            //  
            string secilen1 = tckimlik1.Text;
            string sonsecilen2 = secilen1.Split(' ').First();
            
             SqlCommand cmd = new SqlCommand("PersonelIzinDurumGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("PPersonelId", Convert.ToInt64(sonsecilen2));
            cmd.Parameters.AddWithValue("PSirketId", kullanici_giris.kullaniciSİrket_id);
            
            cmd.Parameters.AddWithValue("onaylayanyonetici", kullanici_giris.kullaniciTc);
             //con.Open();
                int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                uyari_dogru = "Kayıt Başarı ile tamamlandı";
                    if (tckimlik1.Text != "") { arama_genel_IDLI(); }
                    if (tckimlik1.Text == " ") { arama_genel(); }
                }
           
            


            con.Close();
        }
        protected void arama_genel()
        {
            //ListBox1.Items.Add( kullanici_giris.kullaniciSİrket_id);
            con.Open();
            SqlCommand C = new SqlCommand("SELECT count(personel_izin_liste_view.sirketid) FROM personel_izin_liste_view  WHERE  DepartmanYonetici='" + kullanici_giris.kullaniciTc + "'", con);
            verisay = (int)C.ExecuteScalar();
            idm = new string[verisay + 1];
            tc_id = new string[verisay + 1];
            ad_id = new string[verisay + 1];
            soyad_id = new string[verisay + 1];
            BelgeAdiM = new string[verisay + 1];
            BelgeSüresiM = new string[verisay + 1];
            BelgeBaslangicTarihiM = new string[verisay + 1];
            BelgeBitisTarihiM = new string[verisay + 1];
            AciklamaM = new string[verisay + 1];
            BelgeDosyaAdiM = new string[verisay + 1];

            //   SqlCommand S = new SqlCommand("SELECT belge_takip.tc , belge_takip.Id , uye_kayit.ad,uye_kayit.soyad,uye_kayit.dogumT,meslekDallari.meslekAdi,belgeVerenFirma.firmaAdı,sirketBilgi.sirketAdı,belge_takip.odemedurumu,belge_takip.faturadurumu.belge_takip.belgeDurumu FROM belge_takip,uye_kayit,belgeVerenFirma,meslekDallari,sirketBilgi WHERE   belge_takip.tc=uye_kayit.Tc AND belge_takip.meslekdali_id=meslekDallari.Id AND belge_takip.belgeverenfirma_id=belgeVerenFirma.Id AND belge_takip.kurum_id=sirketBilgi.Id", con);
            SqlCommand control = new SqlCommand("SELECT personel_izin_liste_view.* FROM personel_izin_liste_view WHERE DepartmanYonetici='" + kullanici_giris.kullaniciTc + "'", con);
            SqlDataReader dr = control.ExecuteReader();
            int i = verisay;
            while (dr.Read())
            {
                idm[i - 1] = dr["Id"].ToString();
                tc_id[i - 1] = dr["tcno"].ToString();
                ad_id[i - 1] = dr["AD"].ToString();
                soyad_id[i - 1] = dr["soyad"].ToString();
                BelgeAdiM[i - 1] = dr["IzinTipi"].ToString();
                BelgeSüresiM[i - 1] = dr["rapordurumu"].ToString();
                BelgeBaslangicTarihiM[i - 1] = dr["IzincikisTarihi"].ToString();
                BelgeBitisTarihiM[i - 1] = dr["IzinDonusTarihi"].ToString();
                AciklamaM[i - 1] = dr["YONETICIISIM"].ToString() + " " + dr["YONETICISOYISIM"].ToString();
                BelgeDosyaAdiM[i - 1] = dr["onaydurumu"].ToString();
                i--;
            }
            dr.Close();
            con.Close();
        }
        protected void arama_genel_IDLI()
        {
           
            string secilen = tckimlik1.Text;
            string sonsecilen= secilen.Split(' ').First(); 
            con.Close();
            //ListBox1.Items.Add( kullanici_giris.kullaniciSİrket_id);
            con.Open();
            SqlCommand C = new SqlCommand("SELECT count(personel_izin_liste_view.sirketid) FROM personel_izin_liste_view  WHERE  DepartmanYonetici='" + kullanici_giris.kullaniciTc + "' and personelId='" + sonsecilen + "'", con);
            verisay = (int)C.ExecuteScalar();
            idm = new string[verisay + 1];
            tc_id = new string[verisay + 1];
            ad_id = new string[verisay + 1];
            soyad_id = new string[verisay + 1];
            BelgeAdiM = new string[verisay + 1];
            BelgeSüresiM = new string[verisay + 1];
            BelgeBaslangicTarihiM = new string[verisay + 1];
            BelgeBitisTarihiM = new string[verisay + 1];
            AciklamaM = new string[verisay + 1];
            BelgeDosyaAdiM = new string[verisay + 1];
            //   SqlCommand S = new SqlCommand("SELECT belge_takip.tc , belge_takip.Id , uye_kayit.ad,uye_kayit.soyad,uye_kayit.dogumT,meslekDallari.meslekAdi,belgeVerenFirma.firmaAdı,sirketBilgi.sirketAdı,belge_takip.odemedurumu,belge_takip.faturadurumu.belge_takip.belgeDurumu FROM belge_takip,uye_kayit,belgeVerenFirma,meslekDallari,sirketBilgi WHERE   belge_takip.tc=uye_kayit.Tc AND belge_takip.meslekdali_id=meslekDallari.Id AND belge_takip.belgeverenfirma_id=belgeVerenFirma.Id AND belge_takip.kurum_id=sirketBilgi.Id", con);
            SqlCommand control = new SqlCommand("SELECT personel_izin_liste_view.* FROM personel_izin_liste_view WHERE DepartmanYonetici='" + kullanici_giris.kullaniciTc + "' and personelId='" + sonsecilen + "'", con);
                SqlDataReader dr = control.ExecuteReader();
            int i = verisay;
            while (dr.Read())
            {
                idm[i-1] = dr["Id"].ToString();
                tc_id[i - 1] = dr["tcno"].ToString();
                ad_id[i - 1] = dr["AD"].ToString();
                soyad_id[i - 1] = dr["soyad"].ToString();
                BelgeAdiM[i - 1] = dr["IzinTipi"].ToString();
                BelgeSüresiM[i - 1] = dr["rapordurumu"].ToString();
                BelgeBaslangicTarihiM[i - 1] = dr["IzincikisTarihi"].ToString();
                BelgeBitisTarihiM[i - 1] = dr["IzinDonusTarihi"].ToString();
                AciklamaM[i - 1] = dr["YONETICIISIM"].ToString() + " " + dr["YONETICISOYISIM"].ToString();
                BelgeDosyaAdiM[i - 1] = dr["onaydurumu"].ToString();
                i--;
            }
            dr.Close();
          con.Close();
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