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
    public partial class HourlyWage : System.Web.UI.Page
    {
        public static string veritabani_baglanti = ConfigurationManager.ConnectionStrings["OSGBAPPCONNECTION"].ConnectionString;
        SqlConnection con = new SqlConnection(veritabani_baglanti);
        public static DateTime bugununtarihi = Convert.ToDateTime(DateTime.Now);
        public static string uyari_dogru = "";
        public static string uyari_yanlis = "";
        public static int verisay = 0;
        public static string[] Id                    ;
        public static string[] Tc                    ;
        public static string[] CalismaZamaniTanimId  ;
        public static string[] OdemeBilgisi          ;
        public static string[] CalismaGunu           ;
        public static string[] SirketId; 



        public static int Gverisay = 0;
        public static string[] GId;
        public static string[] GTc;
        public static string[] GCalismaZamaniTanimId;
        public static string[] GOdemeBilgisi;
        public static string[] GCalismaGunu;
        public static string[] GKartNo;
        public static string[] GAd;
        public static string[] GSoyad;
        public static string[] GHareketTipi;
        public static string[] GSirketId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["key"] = kullanici_giris.kullaniciId;
                fillThePersonelList();
                fillcalismaSaatiTanim();
                arama_genel_IDLI();
                gerceklesen_IDLI();
            }
            
        }
        public void fillThePersonelList()
        {
            con.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("PersonelListGoruntule", con);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            personel.DataSource = dtbl;
            personel.DataTextField = "TcNo";
            personel.DataValueField = "Id";
            personel.DataBind();
            personelmodal.DataSource = dtbl;
            personelmodal.DataTextField = "TcNo";
            personelmodal.DataValueField = "Id";
            personelmodal.DataBind();
            yevmiyePersonel.DataSource = dtbl;
            yevmiyePersonel.DataTextField = "TcNo";
            yevmiyePersonel.DataValueField = "TcNo";
            yevmiyePersonel.DataBind();
            con.Close();
        }
        public void fillcalismaSaatiTanim()
        {
            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM CalismaZamanıTanimlama", con);
            DataTable tbl = new DataTable();
            adptr.Fill(tbl);
            calismaSaatiTanim.DataSource = tbl;
            calismaSaatiTanim.DataTextField = "Aciklama";
            calismaSaatiTanim.DataValueField = "Id";
            calismaSaatiTanim.DataBind();

            con.Close();
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

        protected void personelCalismaKaydet_ServerClick(object sender, EventArgs e)
        {
            con.Open();
            string date = daterange.Value;
            string d_start = (date.Split('-'))[0];
            string d_end = (date.Split('-'))[1];
            //string start = d_start ;
            // string end = d_end ;
            DateTime end = DateTime.Parse(d_end, System.Globalization.CultureInfo.InvariantCulture);
            DateTime start = DateTime.Parse(d_start, System.Globalization.CultureInfo.InvariantCulture);

            SqlCommand cmd = new SqlCommand("PersonelCalismaGunleriKaydetGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PId", 0);
            cmd.Parameters.AddWithValue("@PpId", personel.SelectedValue);
            cmd.Parameters.AddWithValue("@PCalismaZamaniTanimId", calismaSaatiTanim.SelectedValue);
            cmd.Parameters.AddWithValue("@POdemeBilgisi", onay.Value);
            cmd.Parameters.AddWithValue("@PCalismaGunu", bugununtarihi);
            cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(start));
            cmd.Parameters.AddWithValue("@PSirketId", kullanici_giris.kullaniciSİrket_id);
            cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(end));

            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                uyari_dogru = "Kayıt Başarı ile tamamlandı";
            }
            con.Close();
        }

        protected void Button1_ServerClick(object sender, EventArgs e)
        {
          
            string date = daterangemodal2.Value;
            string d_start = (date.Split('-'))[0];
            string d_end = (date.Split('-'))[1];
            //string start = d_start ;
            // string end = d_end ;
            DateTime end = DateTime.Parse(d_end, System.Globalization.CultureInfo.InvariantCulture);
            DateTime start = DateTime.Parse(d_start, System.Globalization.CultureInfo.InvariantCulture);

            con.Open();
            SqlCommand control = new SqlCommand("sELECT  sum(CalismaZamanıTanimlama.yevmiye) * (select top 1 yevmiyeBedeli from YevmiyeBedeli Order  by Id desc) as bedel FROM  Personel " +
                "join PersonelCalismaGunleri on  Personel.Id = PersonelCalismaGunleri.Personel_Id " +
                "join CalismaZamanıTanimlama on  CalismaZamanıTanimlama.Id = PersonelCalismaGunleri.CalismaZamaniTanimId " +
                "left join YevmiyeBedeli on YevmiyeBedeli.GecerlilikBitisTarihi = null where PersonelCalismaGunleri.CalismaGunu" +
                " between CONVERT(Date, '"+ start + "', 104) and CONVERT(Date, '" + end + "', 104) and '" + personelmodal.SelectedValue+"' = Personel.Id", con);
                SqlDataReader dr = control.ExecuteReader();
                if (dr.Read())
                {
                Toplam.Value = dr["bedel"].ToString();
            }
            dr.Close();
       
            con.Close();
        }

        protected void payall_ServerClick(object sender, EventArgs e)
        {
            string date = daterangemodal2.Value;
            string d_start = (date.Split('-'))[0];
            string d_end = (date.Split('-'))[1];

            DateTime end = DateTime.Parse(d_end, System.Globalization.CultureInfo.InvariantCulture);
            DateTime start = DateTime.Parse(d_start, System.Globalization.CultureInfo.InvariantCulture);
            con.Open();
            SqlCommand ww = new SqlCommand("UPDATE PersonelCalismaGunleri SET PersonelCalismaGunleri.OdemeBilgisi=1 where " +
                "PersonelCalismaGunleri.Personel_Id ='" + personelmodal.SelectedValue + "'  and PersonelCalismaGunleri.CalismaGunu " +
                "between '" + Convert.ToDateTime(start) + "' and '" + Convert.ToDateTime(end) + "'", con);
            ww.ExecuteNonQuery();
            SqlDataReader dw = ww.ExecuteReader();
            dw.Close();
            Toplam.Value = "";
            con.Close();
        }
        protected void arama_genel_IDLI()
        {
            //ListBox1.Items.Add( kullanici_giris.kullaniciSİrket_id);
            con.Open();
            SqlCommand C = new SqlCommand("SELECT count(PersonelCalismaGunleri.Id)  FROM PersonelCalismaGunleri,CalismaZamanıTanimlama,personel WHERE PersonelCalismaGunleri.sirketId='" + kullanici_giris.kullaniciSİrket_id + "' and CalismaZamanıTanimlama.Id = PersonelCalismaGunleri.CalismaZamaniTanimId and personel.Id = PersonelCalismaGunleri.Personel_Id", con);
            verisay = (int)C.ExecuteScalar();
            Id                   = new string[verisay + 1];
            Tc                   = new string[verisay + 1];
            CalismaZamaniTanimId = new string[verisay + 1];
            OdemeBilgisi         = new string[verisay + 1];
            CalismaGunu          = new string[verisay + 1];
            SirketId             = new string[verisay + 1];
           
            //   SqlCommand S = new SqlCommand("SELECT belge_takip.tc , belge_takip.Id , uye_kayit.ad,uye_kayit.soyad,uye_kayit.dogumT,meslekDallari.meslekAdi,belgeVerenFirma.firmaAdı,sirketBilgi.sirketAdı,belge_takip.odemedurumu,belge_takip.faturadurumu.belge_takip.belgeDurumu FROM belge_takip,uye_kayit,belgeVerenFirma,meslekDallari,sirketBilgi WHERE   belge_takip.tc=uye_kayit.Tc AND belge_takip.meslekdali_id=meslekDallari.Id AND belge_takip.belgeverenfirma_id=belgeVerenFirma.Id AND belge_takip.kurum_id=sirketBilgi.Id", con);
            SqlCommand control = new SqlCommand("SELECT PersonelCalismaGunleri.Id as id,personel.TcNo,CalismaZamaniTanimId,OdemeBilgisi,CalismaGunu, PersonelCalismaGunleri.sirketId as sId, CalismaZamanıTanimlama.Aciklama as aciklama FROM PersonelCalismaGunleri,CalismaZamanıTanimlama,personel WHERE PersonelCalismaGunleri.sirketId='" + kullanici_giris.kullaniciSİrket_id + "' and CalismaZamanıTanimlama.Id = PersonelCalismaGunleri.CalismaZamaniTanimId and personel.Id = PersonelCalismaGunleri.Personel_Id", con);
            SqlDataReader dr = control.ExecuteReader();
            int i = verisay;
            while (dr.Read())
            {
                Id                  [i - 1] = dr["id"].ToString();
                Tc                  [i - 1] = dr["TcNo"].ToString();
                CalismaZamaniTanimId[i - 1] = dr["aciklama"].ToString();
                OdemeBilgisi        [i - 1] = dr["OdemeBilgisi"].ToString();
                CalismaGunu         [i - 1] = dr["CalismaGunu"].ToString();
                SirketId            [i - 1] = dr["sId"].ToString();
                i--;
            }
            dr.Close();
            con.Close();
        }
        protected void gerceklesen_IDLI()
        {
            //ListBox1.Items.Add( kullanici_giris.kullaniciSİrket_id);
            con.Open();
            SqlCommand C = new SqlCommand("SELECT count(PersonelCalismaGunleri.Id) FROM PersonelCalismaGunleri, CalismaZamanıTanimlama, VIEW_HAREKETLER,personel WHERE  CalismaZamanıTanimlama.Id = PersonelCalismaGunleri.CalismaZamaniTanimId and VIEW_HAREKETLER.TcNo = personel.TcNo and PersonelCalismaGunleri.CalismaGunu = CONVERT(date, VIEW_HAREKETLER.Tarih) and personel.Id = PersonelCalismaGunleri.Personel_Id", con);
            Gverisay = (int)C.ExecuteScalar();
            GId = new string[Gverisay + 1];
            GTc = new string[Gverisay + 1];
            GCalismaZamaniTanimId = new string[Gverisay + 1];
            GOdemeBilgisi = new string[Gverisay + 1];
            GCalismaGunu = new string[Gverisay + 1];
            GSirketId = new string[Gverisay + 1];

            GKartNo      = new string[Gverisay + 1];
            GAd          = new string[Gverisay + 1];
            GSoyad       = new string[Gverisay + 1];
            GHareketTipi = new string[Gverisay + 1];
          
        //   SqlCommand S = new SqlCommand("SELECT belge_takip.tc , belge_takip.Id , uye_kayit.ad,uye_kayit.soyad,uye_kayit.dogumT,meslekDallari.meslekAdi,belgeVerenFirma.firmaAdı,sirketBilgi.sirketAdı,belge_takip.odemedurumu,belge_takip.faturadurumu.belge_takip.belgeDurumu FROM belge_takip,uye_kayit,belgeVerenFirma,meslekDallari,sirketBilgi WHERE   belge_takip.tc=uye_kayit.Tc AND belge_takip.meslekdali_id=meslekDallari.Id AND belge_takip.belgeverenfirma_id=belgeVerenFirma.Id AND belge_takip.kurum_id=sirketBilgi.Id", con);
        SqlCommand control = new SqlCommand("SELECT PersonelCalismaGunleri.Id as id, VIEW_HAREKETLER.Ad, VIEW_HAREKETLER.Soyad, VIEW_HAREKETLER.KartNo, VIEW_HAREKETLER.HareketTipi, personel.TcNo, CalismaZamaniTanimId, OdemeBilgisi, CalismaGunu, PersonelCalismaGunleri.sirketId as sId, CalismaZamanıTanimlama.Aciklama as aciklama  FROM PersonelCalismaGunleri, CalismaZamanıTanimlama, VIEW_HAREKETLER,personel WHERE  CalismaZamanıTanimlama.Id = PersonelCalismaGunleri.CalismaZamaniTanimId and VIEW_HAREKETLER.TcNo = personel.TcNo and PersonelCalismaGunleri.CalismaGunu = CONVERT(date, VIEW_HAREKETLER.Tarih) and personel.Id = PersonelCalismaGunleri.Personel_Id", con);
            SqlDataReader dr = control.ExecuteReader();
            int i = Gverisay;
            while (dr.Read())
            {
                GId                  [i - 1] = dr["id"].ToString();
                GTc                  [i - 1] = dr["TcNo"].ToString();
                GCalismaZamaniTanimId[i - 1] = dr["aciklama"].ToString();
                GOdemeBilgisi        [i - 1] = dr["OdemeBilgisi"].ToString();
                GCalismaGunu         [i - 1] = dr["CalismaGunu"].ToString();
                GSirketId            [i - 1] = dr["sId"].ToString();
                GKartNo[i - 1] = dr["KartNo"].ToString();
                GAd[i - 1] = dr["Ad"].ToString();
                GSoyad[i - 1] = dr["Soyad"].ToString();
                GHareketTipi[i - 1] = dr["HareketTipi"].ToString();
                i--;
            }
            dr.Close();
            con.Close();
        }

        protected void yevmiyekaydet_ServerClick(object sender, EventArgs e)
        {

            con.Open();
           
            SqlCommand cmd = new SqlCommand("YevmiyeKaydetGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PId", 0);
            cmd.Parameters.AddWithValue("@PTc", yevmiyePersonel.SelectedValue);
            cmd.Parameters.AddWithValue("@PyevmiyeBedeli", price.Value);
            cmd.Parameters.AddWithValue("@PbaslamaT", Convert.ToDateTime(bdate.Value));

            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                uyari_dogru = "Kayıt Başarı ile tamamlandı";
            }
            con.Close();

        }
    }
    }
