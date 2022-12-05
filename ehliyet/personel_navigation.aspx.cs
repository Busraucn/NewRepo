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
    public partial class personel_navigation : System.Web.UI.Page
    {
        public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;
        //   String veritabani_baglanti = kullanici_giris.veritabani_baglanti;

        public static string tcsecilen = "";
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
        public static int guncellenecekpersonel = 0;
        public static string ilktarihimgenel = "";
        public static string sontarihimgenel = "";
        public static string[] secimigerial_id;
        public static string secim_karsilastir = "";
        public static string bosluk = " ";
        public static string id_karsilastir = "";
        public static string idAL_karsilastir = "";
        public static string odeme_sekli = "";
        public static string aciklama = "";
        public static byte[] bytes;
        public static string id_sil = "";
        public static DateTime isegiristarihim2;
        public static DateTime dogumtarihim2;
        public static DateTime istenayrilmatarihim2;
        public static string view_ad = "";
        public static string view_tc = "";
        public static string view_belget = "";
        public static string imgName;
        public static string imgPath;
        public static int imgSize;
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
        public static int resimguncellenecek=0;
        public static string odemedurumu_yaz = "";
        public static string odemebosolmaz = "";
        public static string odendi_yaz = "";
        public static string odemedurumu_tut = "";
        public static DateTime odemetarihi_tut = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static string odemetutari_tut = "";
        public static string yenisifre = "";
        public static string tcnumarasi = "";
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
        public static int verisay = 0;
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
        public static int move;
        public static string dogumtarihim = "";
        public static string isebaslamatarihim = "";
        public static string istenayrilmatarihim = "";
        public static string bugununtarihim = "";
        public static string bugununtarihim2 = "";
        public static string tc_tut;
        public static int onyazi_acilsin_mi = 0;
        public static string calismadurum = "";

        public static string aranacak_kelime = "";
        public static int aranacakmi = 0;

        SqlConnection con = new SqlConnection(veritabani_baglanti);
        SqlConnection conn = new SqlConnection(veritabani_baglanti);
        SqlConnection connn = new SqlConnection(veritabani_baglanti);


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["key"] = kullanici_giris.kullaniciId;
            }
            tcsecilen = "";
            
            sayfayukleme();
            personelgetir();
          
            
        }
        public void qruertici()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeData kod = koduret.CreateQrCode(kullanici_giris.kullaniciSİrket_id + "-" + "wmsdata.net" + "-" + tcnumarasi.ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode QrCode = new QRCode(kod);

                using (Bitmap bmp = QrCode.GetGraphic(5))
                {
                   bmp.Save(ms, ImageFormat.Png);
                    qrimage.ImageUrl = "data:imge/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
        }
      

       
      
     
     

        protected void temizleyici()
        {
            guncellenecekpersonel = 0;
            isim.Value = "";
            imgPicture.ImageUrl = "";
            soyisim.Value = "";


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
            tc_tut = tckimlik.Text;
            bugununtarihim = bugununtarihi.ToString();
            bugununtarihim2 = bugununtarihi.ToString();
            if (sayfayayenigiris == 0 || kullanici_giris.belgeSayfasiCheck == 0)
            {
                sayfayayenigiris = 1;
                //DOGUMTARIHI.Value = DateTime.Today.ToString("yyyy-MM-dd");
               // isebaslamatarihi.Value = DateTime.Today.ToString("yyyy-MM-dd");
               // istenayrilmatarihi.Value = DateTime.Today.ToString("yyyy-MM-dd");
                con.Close();
                con.Open();
            }

            arama_genel_GENELTUMU();
        }

 
        protected void Personel_Getir(object sender, EventArgs e)
        {
            try
            {
                temizleyici();
               
                string secilen1 = tckimlik1.Text;
                string sonsecilen2 = secilen1.Split(' ').First();
                tckimlik.Text = sonsecilen2;
                tcsecilen = tckimlik.Text;
                //con.Open();
                SqlCommand control = new SqlCommand("SELECT * FROM personel_calismagun_view where tcno='" + sonsecilen2 + "' and kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
                SqlDataReader dr = control.ExecuteReader();
                while (dr.Read())
                {
                    guncellenecekpersonel = 1;

                    isim.Value = dr["ad"].ToString();
                    if (dr["resim"].ToString() != "")
                    {
                        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["resim"]);
                        imgPicture.ImageUrl = imageUrl;
                    }
                    tcnumarasi= dr["tcno"].ToString();
                    soyisim.Value = dr["soyad"].ToString();
                     qruertici();
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

        protected void Personel_Getir2(object sender, EventArgs e)
        {
            temizleyici();
            tckimlik1.Text = " ";
                //con.Open();
                SqlCommand control = new SqlCommand("SELECT * FROM personel_calismagun_view where tcno='" + tckimlik.Text + "' and kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
                SqlDataReader dr = control.ExecuteReader();
                while (dr.Read())
                {
                    guncellenecekpersonel = 1;
                    dogru_uyari.Visible = false;
                    yanlis_uyari.Visible = true;
                    uyari_yanlis = "Daha önce kaydedilmiş personel, lütfen kontrol ediniz";
                }
                dr.Close();
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


        protected void personeladinaizinsayfasiac(object sender, EventArgs e)
        {
            tcsecilen = tckimlik.Text;
                }


        public void personelgetir()
        {
            
            if (tckimlik1.Text == "")
            {
                tckimlik1.Items.Clear();
                tckimlik1.Items.Add(" ");
                SqlCommand s3 = new SqlCommand("SELECT * FROM PERSONEL WHERE Kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
                SqlDataReader oku3 = s3.ExecuteReader();
                while (oku3.Read())
                {
                    tckimlik1.Items.Add(oku3["tcno"].ToString() + " " + oku3["ad"].ToString() + " " + oku3["soyad"].ToString());
                    
                }
                oku3.Close();

            }
            
            
        }


        protected void arama_genel_IDLI()
        {
            //con.Open();
            SqlCommand C = new SqlCommand("SELECT count(PERSONEL.Id) FROM PERSONEL  WHERE  PERSONEL.kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            verisay = (int)C.ExecuteScalar();
            tc_id = new string[verisay + 1];
            ad_id = new string[verisay + 1];
            soyad_id = new string[verisay + 1];
            dogumtarihi_id = new string[verisay + 1];
            dogumyeri_id = new string[verisay + 1];
            kangrubu_id = new string[verisay + 1];
            telefon_id = new string[verisay + 1];
            mailadresi_id = new string[verisay + 1];
            calismadurumu_id = new string[verisay + 1];
            isebaslamatarihi_id = new string[verisay + 1];
            istenayrilmatarihi_id = new string[verisay + 1];
            //   SqlCommand S = new SqlCommand("SELECT belge_takip.tc , belge_takip.Id , uye_kayit.ad,uye_kayit.soyad,uye_kayit.dogumT,meslekDallari.meslekAdi,belgeVerenFirma.firmaAdı,sirketBilgi.sirketAdı,belge_takip.odemedurumu,belge_takip.faturadurumu.belge_takip.belgeDurumu FROM belge_takip,uye_kayit,belgeVerenFirma,meslekDallari,sirketBilgi WHERE   belge_takip.tc=uye_kayit.Tc AND belge_takip.meslekdali_id=meslekDallari.Id AND belge_takip.belgeverenfirma_id=belgeVerenFirma.Id AND belge_takip.kurum_id=sirketBilgi.Id", con);
            SqlCommand control = new SqlCommand("SELECT PERSONEL.* FROM PERSONEL WHERE PERSONEL.kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            SqlDataReader dr = control.ExecuteReader();
            int i = verisay;
            while (dr.Read())
            {
                tc_id[i - 1] = dr["tcno"].ToString();
                ad_soyad_id[i - 1] = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                ad_id[i - 1] = dr["ad"].ToString();
                soyad_id[i - 1] = dr["soyad"].ToString();
                dogumtarihial = dr["DoğumTarihi"].ToString();
                dogumtarihiduzelt = dogumtarihial.Split(' ').First();
                dogumtarihi_id[i - 1] = dogumtarihiduzelt.ToString();
                dogumyeri_id[i - 1] = dr["doğumyeri"].ToString();
                kangrubu_id[i - 1] = dr["kangrubu"].ToString();
                telefon_id[i - 1] = dr["telefonev"].ToString();
                mailadresi_id[i - 1] = dr["mailadresi"].ToString();
                calismadurumu_id[i - 1] = dr["durumu"].ToString();
                basvurutarihial = dr["IşeBaşlamaTarihi"].ToString();
                basvurutarihiduzelt = basvurutarihial.Split(' ').First();
                isebaslamatarihi_id[i - 1] = basvurutarihiduzelt.ToString();
                belgetarihial = dr["IştenAyrılmaTarihi"].ToString();
                belgetarihiduzelt = belgetarihial.Split(' ').First();
                istenayrilmatarihi_id[i - 1] = belgetarihiduzelt.ToString();

                //  MessageBox.Show(" noluyo " + belgedurumu_id[i - 1]);
                i--;
            }
            dr.Close();

        }

        protected void arama_genel_GENELTUMU()
        {
            //con.Open();
            SqlCommand C = new SqlCommand("SELECT count(PERSONEL.Id) FROM PERSONEL", con);
            verisay = (int)C.ExecuteScalar();
            tc_id = new string[verisay + 1];
            ad_id = new string[verisay + 1];
            soyad_id = new string[verisay + 1];
            dogumtarihi_id = new string[verisay + 1];
            dogumyeri_id = new string[verisay + 1];
            kangrubu_id = new string[verisay + 1];
            telefon_id = new string[verisay + 1];
            mailadresi_id = new string[verisay + 1];
            calismadurumu_id = new string[verisay + 1];
            isebaslamatarihi_id = new string[verisay + 1];
            istenayrilmatarihi_id = new string[verisay + 1];
            //   SqlCommand S = new SqlCommand("SELECT belge_takip.tc , belge_takip.Id , uye_kayit.ad,uye_kayit.soyad,uye_kayit.dogumT,meslekDallari.meslekAdi,belgeVerenFirma.firmaAdı,sirketBilgi.sirketAdı,belge_takip.odemedurumu,belge_takip.faturadurumu.belge_takip.belgeDurumu FROM belge_takip,uye_kayit,belgeVerenFirma,meslekDallari,sirketBilgi WHERE   belge_takip.tc=uye_kayit.Tc AND belge_takip.meslekdali_id=meslekDallari.Id AND belge_takip.belgeverenfirma_id=belgeVerenFirma.Id AND belge_takip.kurum_id=sirketBilgi.Id", con);
            SqlCommand control = new SqlCommand("SELECT * FROM PERSONEL", con);
            SqlDataReader dr = control.ExecuteReader();
            int i = verisay;
            while (dr.Read())
            {
                tc_id[i - 1] = dr["tcno"].ToString();
                ad_id[i - 1] = dr["ad"].ToString();
                soyad_id[i - 1] = dr["soyad"].ToString();
                dogumtarihial = dr["DoğumTarihi"].ToString();
                dogumtarihiduzelt = dogumtarihial.Split(' ').First();
                dogumtarihi_id[i - 1] = dogumtarihiduzelt.ToString();
                dogumyeri_id[i - 1] = dr["doğumyeri"].ToString();
                kangrubu_id[i - 1] = dr["kangrubu"].ToString();
                telefon_id[i - 1] = dr["telefonev"].ToString();
                mailadresi_id[i - 1] = dr["mailadresi"].ToString();
                calismadurumu_id[i - 1] = dr["durumu"].ToString();
                basvurutarihial = dr["IşeBaşlamaTarihi"].ToString();
                basvurutarihiduzelt = basvurutarihial.Split(' ').First();
                isebaslamatarihi_id[i - 1] = basvurutarihiduzelt.ToString();
                belgetarihial = dr["IştenAyrılmaTarihi"].ToString();
                belgetarihiduzelt = belgetarihial.Split(' ').First();
                istenayrilmatarihi_id[i - 1] = belgetarihiduzelt.ToString();

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