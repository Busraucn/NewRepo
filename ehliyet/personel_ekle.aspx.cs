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
    public partial class personel_ekle : System.Web.UI.Page
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
            if (fluPicture.PostedFile != null && fluPicture.PostedFile.ContentLength > 0)
                UpLoadAndDisplay();
            sehir();
        }
        public void qruertici()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode kod = koduret.CreateQrCode(kullanici_giris.kullaniciSİrket_id + "-" + "wmsdata.net" + "-" + tcnumarasi.ToString(), QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bmp = kod.GetGraphic(5))
                {
                    bmp.Save(ms, ImageFormat.Png);
                    qrimage.ImageUrl = "data:imge/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

        }
        public void sehir()
        { 
                    anafirma.Items.Add("");
            //   altfirma.Items.Add("");
            SqlCommand s2 = new SqlCommand("SELECT * FROM sehir  ", con);
            SqlDataReader oku2 = s2.ExecuteReader();
            while (oku2.Read())
            {
                anafirma.Items.Add(oku2["adi"].ToString());
                // altfirma.Items.Add(oku2["sirketAdı"].ToString());
            }
            oku2.Close();
        }

        public void fTextChanged(object sender, EventArgs e)
        {
            ilce();
        }
        public void ilce()

        {
            ilcesec.Items.Clear();
            ilcesec.Items.Add("");
            SqlCommand s3 = new SqlCommand("SELECT * FROM VIEW_IL_ILCE where SEHIRADI='" + anafirma.Text + "'", con);
            SqlDataReader oku3 = s3.ExecuteReader();
            while (oku3.Read())
            {
                ilcesec.Items.Add(oku3["adi"].ToString());
            }
            oku3.Close();
        }
        public void ilce2()

        {
            ilcesec.Items.Clear();
            ilcesec.Items.Add("");
            SqlCommand s3 = new SqlCommand("SELECT * FROM VIEW_IL_ILCE", con);
            SqlDataReader oku3 = s3.ExecuteReader();
            while (oku3.Read())
            {
                ilcesec.Items.Add(oku3["adi"].ToString());
            }
            oku3.Close();
        }
        public void gorevtanimlari()
        {
            if (gorevlist.Text == "")
            {
                gorevlist.Items.Clear();
            gorevlist.Items.Add("");
            SqlCommand s3 = new SqlCommand("SELECT * FROM PersonelGorevTanim WHERE kurum_id='"+kullanici_giris.kullaniciSİrket_id+"'", con);
            SqlDataReader oku3 = s3.ExecuteReader();
            while (oku3.Read())
            {
                gorevlist.Items.Add(oku3["PersonelGorevi"].ToString());
            }
            oku3.Close();
            }
        }
        public void departmantanimlari()
        {
            if (departmanlist.Text == "")
            {
                departmanlist.Items.Clear();
            departmanlist.Items.Add("");
            SqlCommand s3 = new SqlCommand("SELECT * FROM personeldepartman WHERE kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            SqlDataReader oku3 = s3.ExecuteReader();
            while (oku3.Read())
            {
                departmanlist.Items.Add(oku3["DepartmanAdi"].ToString());
            }
            oku3.Close();
            }
        }
        private void UpLoadAndDisplay()
        {
            resimguncellenecek = 1;
            bytes = null;
            imgName = fluPicture.FileName;
            imgPath = "images/" + imgName;
            imgSize = fluPicture.PostedFile.ContentLength;
            if (fluPicture.PostedFile != null && fluPicture.PostedFile.FileName != "")
            {
                fluPicture.SaveAs(Server.MapPath(imgPath));
                imgPicture.ImageUrl = "~/" + imgPath;
            }

            using (BinaryReader br = new BinaryReader(fluPicture.PostedFile.InputStream))
            {
                bytes = br.ReadBytes(fluPicture.PostedFile.ContentLength);
            }


        }
        protected void temizleyici()
        {
            guncellenecekpersonel = 0;
            isim.Value = "";
            imgPicture.ImageUrl = "";
            soyisim.Value = "";
            DateTime tarih1=Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
            DOGUMTARIHI.Value = tarih1.ToString();
            dogumyeri.Value = "";
            cinsiyet1.Value = "";
            kizliksoyadi.Value = "";
            anneadi.Value = "";
            babaadi.Value = "";
            medenidurum1.Value = "";
            cocuksayisi.Value = "0";
            kangrubu1.Value = "";
            telefon1.Value = "";
            telefon2.Value = "";
            mailadresi.Value = "";
            ulke.Value = "";
            anafirma.Text = "";
            ilcesec.Text = "";
            mahalle.Value = "";
            adres.Value = "";
            no.Value = "";
            postakodu.Value = "";
            engeldurumu1.Value = "";
            engelorani.Value = "0";
            not.Value = "";
            checkbox1.Checked = false;
            checkbox2.Checked = false;
            checkbox3.Checked = false;
            checkbox4.Checked = false;
            checkbox5.Checked = false;
            checkbox6.Checked = false;
            checkbox7.Checked = false;
            departmanlist.Text = "";
            gorevlist.Text = "";
            emeklidurumu1.Value = "";
            calismadurumu1.Value = "";
            DateTime tarih2 = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
            isebaslamatarihi.Value = tarih2.ToString();
            DateTime tarih3 = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
            istenayrilmatarihi.Value=tarih3.ToString();
            kartkodu.Value = "";

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
            gorevtanimlari();
            departmantanimlari();
            arama_genel_GENELTUMU();
        }

        protected void tckimlikdogrula(object sender, EventArgs e)
        {
            if (tckimlik.Text != "" & tckimlik.Text != null & isim.Value != "" & isim.Value != null & soyisim.Value != "" & soyisim.Value != null)
            {
                if (DOGUMTARIHI.Value=="") { DOGUMTARIHI.Value = DateTime.Today.ToString("yyyy-MM-dd"); }
            long tcno = Convert.ToInt64(tckimlik.Text);
            String ad_ = isim.Value;
            String soyad_ = soyisim.Value;
            String dogumyili = DOGUMTARIHI.Value.Substring(0, 4).ToString();
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
        protected void Personel_Getir(object sender, EventArgs e)
        {
            try
            {
                temizleyici();
                ilce2();                
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
                    cinsiyet1.Value = dr["cinsiyet"].ToString();
                    kizliksoyadi.Value = dr["kızlıksoyadı"].ToString();
                    anneadi.Value = dr["anneadı"].ToString();
                    babaadi.Value = dr["babaadı"].ToString();
                    dogumtarihim2 = Convert.ToDateTime(dr["doğumtarihi"]);
                    DOGUMTARIHI.Value = dogumtarihim2.ToString("yyyy-MM-dd");


                    dogumyeri.Value = dr["doğumyeri"].ToString();
                    medenidurum1.Value = dr["medenidurumu"].ToString();
                    cocuksayisi.Value = dr["cocuksayisi"].ToString();
                    kangrubu1.Value = dr["kangrubu"].ToString();
                    telefon1.Value = dr["TelefonEv"].ToString();
                    telefon2.Value = dr["TelefonCep"].ToString();
                    ulke.Value = dr["adresulke"].ToString();
                    mahalle.Value = dr["adresmahalle"].ToString();
                    adres.Value = dr["adrescaddesokak"].ToString();
                    postakodu.Value = dr["adrespostakodu"].ToString();
                    no.Value = dr["adreskapıno"].ToString();
                    calismadurumu1.Value = dr["durumu"].ToString();
                    isegiristarihim2 = Convert.ToDateTime(dr["IşeBaşlamaTarihi"]);
                    isebaslamatarihi.Value = isegiristarihim2.ToString("yyyy-MM-dd");
                    istenayrilmatarihim2 = Convert.ToDateTime(dr["IştenAyrılmaTarihi"]);
                    istenayrilmatarihi.Value = istenayrilmatarihim2.ToString("yyyy-MM-dd");
                    emeklidurumu1.Value = dr["emeklilikdurumu"].ToString();
                    not.Value = dr["pnot"].ToString();
                    mailadresi.Value = dr["mailadresi"].ToString();
                    engeldurumu1.Value = dr["engeldurumu"].ToString();
                    engelorani.Value = dr["engelorani"].ToString();
                    anafirma.Text = dr["AdresIl"].ToString();
                   // ilce();
                    ilcesec.Text = dr["AdresIlçe"].ToString();
                    gorevlist.Text = dr["tipi"].ToString();
                    kartkodu.Value = dr["kartno"].ToString();
                    departmanlist.Text= dr["departman"].ToString();
                     if (dr["1"].ToString() == "1") { checkbox1.Checked = true; } else { checkbox1.Checked = false; }
                     if (dr["2"].ToString() == "1") { checkbox2.Checked = true; } else { checkbox2.Checked = false; }
                     if (dr["3"].ToString() == "1") { checkbox3.Checked = true; } else { checkbox3.Checked = false; }
                     if (dr["4"].ToString() == "1") { checkbox4.Checked = true; } else { checkbox4.Checked = false; }
                     if (dr["5"].ToString() == "1") { checkbox5.Checked = true; } else { checkbox5.Checked = false; }
                     if (dr["6"].ToString() == "1") { checkbox6.Checked = true; } else { checkbox6.Checked = false; }
                     if (dr["7"].ToString() == "1") { checkbox7.Checked = true; } else { checkbox7.Checked = false; }
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

        protected void Personel_Kaydet(object sender, EventArgs e)
        {       // con.Open();
            yenisifre = RastgeleUret();
            conn.Open();    
            connn.Open();
            if (tckimlik.Text != "" & tckimlik.Text != null & isim.Value != "" & isim.Value != null & soyisim.Value != "" & soyisim.Value != null & mailadresi.Value != "" & mailadresi.Value != null)

            {
                SqlCommand cmd = new SqlCommand("PersonelKaydetGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("tcNo", tckimlik.Text);
            cmd.Parameters.AddWithValue("ad", isim.Value);
            cmd.Parameters.AddWithValue("soyad", soyisim.Value);
            cmd.Parameters.AddWithValue("cinsiyet", cinsiyet1.Value);
            cmd.Parameters.AddWithValue("kızlıkSoyadı", kizliksoyadi.Value);
            cmd.Parameters.AddWithValue("anneadi", anneadi.Value);
            cmd.Parameters.AddWithValue("babaadi", babaadi.Value);
            cmd.Parameters.AddWithValue("dogumtarihi", DOGUMTARIHI.Value);
            cmd.Parameters.AddWithValue("dogumyeri", dogumyeri.Value);
            cmd.Parameters.AddWithValue("medenidurumu", medenidurum1.Value);
            cmd.Parameters.AddWithValue("cocuksayisi", cocuksayisi.Value);
            cmd.Parameters.AddWithValue("kangrubu", kangrubu1.Value);
            cmd.Parameters.AddWithValue("telefonev", telefon1.Value);
            cmd.Parameters.AddWithValue("telefoncep", telefon2.Value);
            cmd.Parameters.AddWithValue("adresulke", ulke.Value);
            cmd.Parameters.AddWithValue("adresil", anafirma.Text);
            cmd.Parameters.AddWithValue("adresilçe", ilcesec.Text);
            cmd.Parameters.AddWithValue("adresmahalle", mahalle.Value);
            cmd.Parameters.AddWithValue("adrescaddesokak", adres.Value);
            cmd.Parameters.AddWithValue("AdresPostaKodu", postakodu.Value);
            cmd.Parameters.AddWithValue("adreskapıno", no.Value);
            cmd.Parameters.AddWithValue("durumu", calismadurumu1.Value);
            cmd.Parameters.AddWithValue("isebaslamatarihi", isebaslamatarihi.Value);
            cmd.Parameters.AddWithValue("istenayrilmatarihi", istenayrilmatarihi.Value);
            cmd.Parameters.AddWithValue("tipi", gorevlist.Text);
            cmd.Parameters.AddWithValue("emeklilikdurumu", emeklidurumu1.Value);
            cmd.Parameters.AddWithValue("pnot", not.Value);
            cmd.Parameters.AddWithValue("mailadresi", mailadresi.Value);
            cmd.Parameters.AddWithValue("engeldurumu", engeldurumu1.Value);
            cmd.Parameters.AddWithValue("engelorani", engelorani.Value);
            cmd.Parameters.AddWithValue("KartNo", kartkodu.Value);
            cmd.Parameters.AddWithValue("kurum_id", kullanici_giris.kullaniciSİrket_id);
            cmd.Parameters.AddWithValue("departman", departmanlist.Text);
            int k = cmd.ExecuteNonQuery();
                if (k != 0 && guncellenecekpersonel==0)
                {
                    
                    uyari_dogru = "Kayıt Başarı ile tamamlandı";
                    SqlCommand ww = new SqlCommand("UPDATE personel SET sifre= HASHBYTES('MD5','" + yenisifre + "') WHERE tcno='" + tckimlik.Text + "' and mailadresi='" + mailadresi.Value + "'", con);
                    ww.ExecuteNonQuery();
                    SqlDataReader dw = ww.ExecuteReader();
                    dw.Close();
                mailgonder();

                }

            SqlCommand cmd2 = new SqlCommand("PersonelCalismaGunTakipKaydetGuncelle", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("PPersonelId", tckimlik.Text);
            cmd2.Parameters.AddWithValue("p1", checkbox1.Checked);
            cmd2.Parameters.AddWithValue("p2", checkbox2.Checked);
            cmd2.Parameters.AddWithValue("p3", checkbox3.Checked);
            cmd2.Parameters.AddWithValue("p4", checkbox4.Checked);
            cmd2.Parameters.AddWithValue("p5", checkbox5.Checked);
            cmd2.Parameters.AddWithValue("p6", checkbox6.Checked);
            cmd2.Parameters.AddWithValue("p7", checkbox7.Checked);
            cmd2.Parameters.AddWithValue("Pvardiya", "vardiya1");
            cmd2.Parameters.AddWithValue("PSirketId", kullanici_giris.kullaniciSİrket_id);
            int l = cmd2.ExecuteNonQuery();
                if (l != 0)
                {
                    uyari_dogru = "Kayıt Başarı ile tamamlandı";

                }
                if (resimguncellenecek == 1)
                    {
                    SqlCommand cmd3 = new SqlCommand("PersonelResimKaydetGuncelle", connn);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("TcNo", tckimlik.Text);
                        cmd3.Parameters.AddWithValue("resim", bytes);
                        cmd3.Parameters.AddWithValue("SirketId", kullanici_giris.kullaniciSİrket_id);
                   
                    int m = cmd3.ExecuteNonQuery();

                    if (m != 0)
                    {
                        resimguncellenecek = 0;
                    }
                   }
            }
            con.Close();
            conn.Close();  
            connn.Close();
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
        protected void mailgonder()
        {
            
            if (guncellenecekpersonel == 0) { 
            string mailadresimails = "";
            string mailgondericimails = "";
            string mailkullanicimails = "";
            string mailsifremails = "";
            string smtpadresmails = "";
            string smtpportmails = "";

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
            
            try
            {
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new MailAddress(mailadresimails, mailgondericimails); ;
                msg.To.Add(new MailAddress(mailadresi.Value));
                msg.IsBodyHtml = true;
                msg.Subject = " WMSDATA HOŞGELDİNİZ";
                msg.Body = @"<html>
                      <body > <a >
                        <div >      
                           <i><font color=black  ><h1><strong> WMSDATA</strong></h1></font> </i>
                          </div>
                 <i >  <h3> Merhaba ; </h3></i >  <p><i ><a href='http://www.wmsdata.net/'  > WMSDATA  Sistemine kaydınız başarı ile gerçekleşmiştir </a> şifreniz:" + yenisifre + "  Email ve şifre ile giriş yapabilirsiniz. Not: İlk girişte şifrenizi değiştirmeyi unutmayınız. </i> </p>    <hr width=50000 size=2 color=teal align=left />  <address>  <strong> WMSDATA '"+DateTime.Now.ToString()+ "'</strong><br>  </address> </div> </a>  </div></body> </html>  ";
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
        }
    }
}