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
    public partial class proje_olay_kayit : System.Web.UI.Page
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
        public static string[] idm;
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
        public static int degisenid;
        public static string[] departmankodus;
        public static string[] departmanadis;
        public static string[] ustdepartmankodus;
        public static string[] departmanyoneticis;
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
        public static String idAl = "";
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
            con.Open();
            if (!Page.IsPostBack)
            {
                ViewState["key"] = kullanici_giris.kullaniciId;
            }
            arama_genel_IDLI();
            departmantanimlari();
            personelgetir();
            sayfayukleme();
        }
        public void departmantanimlari()
        {
            if (ustdepartmankodw.Text == "")
            {
                projebolum.Items.Clear();
                projenom.Items.Clear();
                projebolum.Items.Clear();
                projekonum.Items.Clear();
                ustdepartmankodw.Items.Clear();
                ustdepartmankodw.Items.Add (" ");
                SqlCommand s3 = new SqlCommand("SELECT * FROM ProjeTipiKayit where sirket_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            SqlDataReader oku3 = s3.ExecuteReader();
            while (oku3.Read())
            {
                ustdepartmankodw.Items.Add(oku3["ProjeTipi"].ToString());
            }
            oku3.Close();

            }
           
        }

        public void projetanimlari(object sender, EventArgs e)
        {

            projenom.Items.Clear();
            projebolum.Items.Clear();
            projekonum.Items.Clear();
            projenom.Items.Add(" ");
            SqlCommand s3 = new SqlCommand("SELECT * FROM ProjeKayit where ProjeTipiId='" + ustdepartmankodw.Text + "' AND sirket_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
                SqlDataReader oku3 = s3.ExecuteReader();
                while (oku3.Read())
                {
                    projenom.Items.Add(oku3["PErojeNo"].ToString());
                }
                oku3.Close();


        }

        public void projenolar(object sender, EventArgs e)
        {
            projebolum.Items.Clear();
            projekonum.Items.Clear();
            projebolum.Items.Add(" ");
            SqlCommand s3 = new SqlCommand("SELECT * FROM ProjeBolumKayit where ProjeTipi='" + ustdepartmankodw.Text + "' AND Projeno='" + projenom.Text + "' AND sirket_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            SqlDataReader oku3 = s3.ExecuteReader();
            while (oku3.Read())
            {
                projebolum.Items.Add(oku3["ProjeBolumu"].ToString());
            }
            oku3.Close();


        }

        public void projebolumler(object sender, EventArgs e)
        {
            projekonum.Items.Clear();
            projekonum.Items.Add(" ");
            SqlCommand s3 = new SqlCommand("SELECT * FROM ProjeKonuKayit where ProjeTipi='" + ustdepartmankodw.Text + "' AND Projeno='" + projenom.Text + "' AND projebolumu='" + projebolum.Text + "' AND sirketid='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            SqlDataReader oku3 = s3.ExecuteReader();
            while (oku3.Read())
            {
                projekonum.Items.Add(oku3["Projekonusu"].ToString());
            }
            oku3.Close();


        }



        protected void temizleyici()
        {

            projeOlayno.Value = "";
            acikalama.Value = "";
            ustdepartmankodw.Text = "";
            ProjeOlayId.Text = "";
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

            if (idAl != null && idAl != "" )
            {
                
                guncellenecek = 1;
                degisenid = int.Parse(idAl);

                id_karsilastir = degisenid.ToString();
                SqlCommand control = new SqlCommand("SELECT * FROM Projeolaykayit where Id='" + degisenid + "'", con);
                SqlDataReader dr = control.ExecuteReader();
                while (dr.Read())
                {
                    ProjeOlayId.Text= dr["Id"].ToString();
                    projenom.Text= dr["projeno"].ToString();
                    projeOlayno.Value = dr["ProjeOlayi"].ToString();
                    acikalama.Value = dr["Aciklama"].ToString();
                    ustdepartmankodw.Text = dr["ProjeTipiId"].ToString(); 
                }
                dr.Close();

            }


            dogru_uyari.Visible = false;
            yanlis_uyari.Visible = false;
            tc_tut = ProjeOlayId.Text;
            bugununtarihim = bugununtarihi.ToString();
            bugununtarihim2 = bugununtarihi.ToString();
            if (sayfayayenigiris == 0 || kullanici_giris.belgeSayfasiCheck == 0)
            {
                sayfayayenigiris = 1;
                con.Close();
                con.Open();
            }
          //  arama_genel_IDLI();
         }

        protected void Gorev_Kaydet(object sender, EventArgs e)
        {       // con.Open();        
            string ustdepartman = ustdepartmankodw.Text;

            SqlCommand cmd = new SqlCommand("ProjeOlayKaydetGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PGorevID", ProjeOlayId.Text);
            cmd.Parameters.AddWithValue("@ProjeNo", projenom.Text);
            cmd.Parameters.AddWithValue("@ProjeBolumu", projebolum.Text);
            cmd.Parameters.AddWithValue("@ProjeKonusu", projekonum.Text);
            cmd.Parameters.AddWithValue("@ProjeOlayi", projeOlayno.Value);
            cmd.Parameters.AddWithValue("@Aciklama", acikalama.Value);
            cmd.Parameters.AddWithValue("@ProjeTipiId", ustdepartman);

            cmd.Parameters.AddWithValue("PKurum_Id", kullanici_giris.kullaniciSİrket_id);
            //con.Open();
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                uyari_dogru = "Kayıt Başarı ile tamamlandı";                
            }
            con.Close();       
    }
        public void personelgetir()
        {
            //con.Open();
            if (ustdepartmankodw.Text == "")
            {
                ustdepartmankodw.Items.Clear();
                ustdepartmankodw.Items.Add(" ");
                SqlCommand s3 = new SqlCommand("SELECT * FROM Proje_OLAY_Konu_Bolum_Tipi_Proje_View WHERE sirket_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
                SqlDataReader oku3 = s3.ExecuteReader();
                while (oku3.Read())
                {
                    ustdepartmankodw.Items.Add(oku3["projekonusu"].ToString() + " " + oku3["projekonuaciklama"].ToString() );
                   // departmanyoneticim.te = oku3["departman"].ToString();
                }
                oku3.Close();

            }
           // con.Close();
            
        }
        protected void arama_genel_IDLI()
        {
            
            SqlCommand C = new SqlCommand("SELECT count(Proje_OLAY_Konu_Bolum_Tipi_Proje_View.Id) FROM Proje_OLAY_Konu_Bolum_Tipi_Proje_View  WHERE  Proje_OLAY_Konu_Bolum_Tipi_Proje_View.sirket_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
            verisay = (int)C.ExecuteScalar();
            idm = new string[verisay + 1];
            departmankodus = new string[verisay + 1];
            departmanadis = new string[verisay + 1];
            ustdepartmankodus = new string[verisay + 1];
            departmanyoneticis = new string[verisay + 1];

            //   SqlCommand S = new SqlCommand("SELECT belge_takip.tc , belge_takip.Id , uye_kayit.ad,uye_kayit.soyad,uye_kayit.dogumT,meslekDallari.meslekAdi,belgeVerenFirma.firmaAdı,sirketBilgi.sirketAdı,belge_takip.odemedurumu,belge_takip.faturadurumu.belge_takip.belgeDurumu FROM belge_takip,uye_kayit,belgeVerenFirma,meslekDallari,sirketBilgi WHERE   belge_takip.tc=uye_kayit.Tc AND belge_takip.meslekdali_id=meslekDallari.Id AND belge_takip.belgeverenfirma_id=belgeVerenFirma.Id AND belge_takip.kurum_id=sirketBilgi.Id", con);
            SqlCommand control = new SqlCommand("SELECT Proje_OLAY_Konu_Bolum_Tipi_Proje_View.* FROM Proje_OLAY_Konu_Bolum_Tipi_Proje_View WHERE Proje_OLAY_Konu_Bolum_Tipi_Proje_View.sirket_id='" + kullanici_giris.kullaniciSİrket_id + "'", con);
                SqlDataReader dr = control.ExecuteReader();
            int i = verisay;
            while (dr.Read())
            {
                idm[i - 1] = dr["Id"].ToString();
                departmankodus[i - 1] = dr["ProjeOlayi"].ToString();
                departmanadis[i - 1] = dr["olayaciklama"].ToString();
                ustdepartmankodus[i - 1] = dr["projeolayid"].ToString();
                

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