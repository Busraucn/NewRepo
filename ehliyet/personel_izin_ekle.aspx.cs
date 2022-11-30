using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Net.Mail;



namespace WMSDATA
{
    public partial class personel_izin_ekle : System.Web.UI.Page
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
        public static int id_count = 0;
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
        public static string id_karsilastir = "";
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
        public static string kullandigimizinsuresi;
        public static string kullanilanizinsuresi;
        public static string yasi;
        public static string h1;
        public static string h2;
        public static string h3;
        public static string h4;
        public static string h5;
        public static string h6;
        public static string h7;
        public static string idarisure;
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
        public static DateTime isegiristarihim;
        public static DateTime dogumtarihimm;

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
        public static string[] idm;
        public static string[] soyad_id;
        public static string[] izintarihleri;
        public static string[] resmiizintarihleri;
        public static string[] hesaplananizintarihleri;
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
        public static DateTime isebaslamatarihims = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static DateTime dogumtarihims = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static int move;
        public static int hesaplanangun = 0;
        public static string dogumtarihim = "";
        public static string isebaslamatarihim = "";
        public static string istenayrilmatarihim = "";
        public static string bugununtarihim = "";
        public static string bugununtarihim2 = "";
        public static string tc_tut;
        public static string raporkontrol = "";
        public static string yillikizinkontrol = "";
        public static DateTime ilktarih = Convert.ToDateTime(DateTime.Now);
        public static DateTime sontarih = Convert.ToDateTime(DateTime.Now);
        public static DateTime resmiizin = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static DateTime resmiizin1 = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static DateTime resmiizin2 = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static DateTime resmiizin3 = Convert.ToDateTime("1900 - 01 - 01 00:00:00.000");
        public static int onyazi_acilsin_mi = 0;
        public static string calismadurum = "";
        public static String idAl = "";
        public static String departmanyonetici = "";
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
            fTextChangeds();
            tckimlik.Value = kullanici_giris.kullaniciTc;
            personelgetir();
            izinayargetir();
            izin_Getir();
            arama_genel_IDLI();
        }
        protected void temizleyici()
        {
            gunsayisi.Value = "0";
            izintanimlarimiz.Enabled = true;
            rapordurum2.Enabled = true;
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
            tc_tut = tckimlik.Value;
            bugununtarihim = bugununtarihi.ToString();
            bugununtarihim2 = bugununtarihi.ToString();
            if (sayfayayenigiris == 0)
            {
                sayfayayenigiris = 1;

                con.Open();

                if (ilktarihim == Convert.ToDateTime("1900 - 01 - 01 00:00:00.000"))
                {
                    izinbaslangictarihi.Value = DateTime.Today.ToString("yyyy-MM-dd");
                }
                if (sontarihim == Convert.ToDateTime("1900 - 01 - 01 00:00:00.000"))
                {
                    izinbitistarihi.Value = DateTime.Today.ToString("yyyy-MM-dd");
                }
                gunsayisi.Value = "0";
                ilktarihim = Convert.ToDateTime(izinbaslangictarihi.Value);
                sontarihim = Convert.ToDateTime(izinbitistarihi.Value);
                con.Close();
            }
        }
        public void fTextChangeds()
        {  
            con.Open();
            if (izintanimlarimiz.Text == "")
            { 
                izintanimlarimiz.Items.Clear();
                izintanimlarimiz.Items.Add("");
                SqlCommand s3 = new SqlCommand("SELECT * FROM PersonelIzınTanim", con);
                SqlDataReader oku3 = s3.ExecuteReader();
                while (oku3.Read())
            {
                izintanimlarimiz.Items.Add(oku3["IzinTipi"].ToString());
            }
                oku3.Close();
            }
                con.Close();
            if (rapordurum2.Text == "")
            {
                rapordurum2.Items.Clear();
                rapordurum2.Items.Add(" ");
                rapordurum2.Items.Add("RAPORSUZ");
                rapordurum2.Items.Add("RAPORLU");
            }
        }
        public void personelgetir()
        {
                conn.Open();
                SqlCommand s5 = new SqlCommand("SELECT * FROM personel_departman_view WHERE tcno='" + kullanici_giris.kullaniciTc + "'", conn);
                SqlDataReader oku4 = s5.ExecuteReader();
                while (oku4.Read())
                {

                    departmani.Value = oku4["departmanadi"].ToString();
                    departmanyonetici= oku4["departmanyonetici"].ToString();
                }
                    oku4.Close();
                    conn.Close();       
        }
        protected void listedenemem(object sender, EventArgs e)
        {
            Boolean hesaplansin = false;
             raporkontrol = "";
             yillikizinkontrol = "";
            if (izintanimlarimiz.SelectedValue !="")
            {
                con.Open();
                SqlCommand s3 = new SqlCommand("SELECT * FROM PersonelIzınTanim where IzinTipi='"+ izintanimlarimiz.SelectedValue+"' and kurum_id='"+kullanici_giris.kullaniciSİrket_id+"'", con);
                SqlDataReader oku3 = s3.ExecuteReader();
                while (oku3.Read())
                {
                    raporkontrol= oku3["raporkontrol"].ToString();
                    yillikizinkontrol = oku3["YillikIzinKaontrol"].ToString();
                    hesaplansin = true;
                    izintanimlarimiz.Enabled = false;
                    rapordurum2.Enabled = false;
                }
                oku3.Close();
                con.Close();
            }
            if (hesaplansin==true)
                {
                int haftaninizinsayisi=0;
                con.Open();
                ilktarihim = Convert.ToDateTime(izinbaslangictarihi.Value);
                sontarihim = Convert.ToDateTime(izinbitistarihi.Value);
                if (sontarihim > ilktarihim)
                {
                    //  isimlers.Items.Clear();
                    //  isimlers2.Items.Clear();
                    isimlers3.Items.Clear();
                    conn.Open();
                    SqlCommand s6 = new SqlCommand("SELECT count(personeltatilgunleri.sirketid) FROM personeltatilgunleri WHERE sirketid='" + kullanici_giris.kullaniciSİrket_id + "'", conn);
                    int izinsayisi = (int)s6.ExecuteScalar();
                    resmiizintarihleri = new string[izinsayisi + 1];
                    SqlCommand s5 = new SqlCommand("SELECT * FROM personeltatilgunleri WHERE sirketid='" + kullanici_giris.kullaniciSİrket_id + "'", conn);
                    SqlDataReader oku4 = s5.ExecuteReader();
                    while (oku4.Read())
                    {
                        resmiizin = Convert.ToDateTime(oku4["tarih"]);
                        resmiizintarihleri[izinsayisi] = resmiizin.ToString("dd-MM-yyyy");
                        //  isimlers.Items.Add(resmiizin.ToString("dd-MM-yyyy"));
                        izinsayisi--;
                    }
                    oku4.Close();
                    conn.Close();
                    conn.Open();
                    SqlCommand s8 = new SqlCommand("SELECT * FROM PersonelCalismaGunTakip WHERE sirketid='" + kullanici_giris.kullaniciSİrket_id + "' AND PersonelId='" + tckimlik.Value + "'", conn);
                    SqlDataReader oku5 = s8.ExecuteReader();
                    while (oku5.Read())
                    {
                        h1 = oku5["1"].ToString();
                        h2 = oku5["2"].ToString();
                        h3 = oku5["3"].ToString();
                        h4 = oku5["4"].ToString();
                        h5 = oku5["5"].ToString();
                        h6 = oku5["6"].ToString();
                        h7 = oku5["7"].ToString();
                        if (h1.ToString() == '0'.ToString()) { haftaninizinsayisi = haftaninizinsayisi + 1; }
                        if (h2.ToString() == '0'.ToString()) { haftaninizinsayisi = haftaninizinsayisi + 1; }
                        if (h3.ToString() == '0'.ToString()) { haftaninizinsayisi = haftaninizinsayisi + 1; }
                        if (h4.ToString() == '0'.ToString()) { haftaninizinsayisi = haftaninizinsayisi + 1; }
                        if (h5.ToString() == '0'.ToString()) { haftaninizinsayisi = haftaninizinsayisi + 1; }
                        if (h6.ToString() == '0'.ToString()) { haftaninizinsayisi = haftaninizinsayisi + 1; }
                        if (h7.ToString() == '0'.ToString()) { haftaninizinsayisi = haftaninizinsayisi + 1; }
                        //  isimlers.Items.Add(resmiizin.ToString("dd-MM-yyyy"));
                    }
                    oku5.Close();
                    conn.Close();
         


                    DateTime tarihkalan = Convert.ToDateTime(izinbaslangictarihi.Value);
                    DateTime tarihgecen = Convert.ToDateTime(izinbitistarihi.Value);
                    DateTime tarihson = tarihkalan;

                    int tarihim = tarihgecen.Date.DayOfYear - tarihkalan.Date.DayOfYear;
                    int toplamgunsayisi = tarihim;
                    izintarihleri = new string[toplamgunsayisi + 1];
                    for (int i = 0; i < tarihim; i++)
                    {
                        tarihson = tarihkalan.Date.AddDays(i);
                        izintarihleri[toplamgunsayisi] = tarihson.ToString("dd-MM-yyyy");
                        // isimlers2.Items.Add(tarihson.ToString("dd-MM-yyyy"));
                        // isimlers2.Items.Add(izintarihleri[toplamgunsayisi]);
                        toplamgunsayisi--;
                    }


                    int toplamhespalanana = resmiizintarihleri.Count();
                    hesaplananizintarihleri = new string[toplamgunsayisi + 1];

                    for (int j = 0; j < resmiizintarihleri.Count(); j++)
                    {
                        int toplamhespalanan2a = izintarihleri.Count();

                        for (int k = 0; k < izintarihleri.Count(); k++)
                        {
                            if (izintarihleri[toplamhespalanan2a - 1] == resmiizintarihleri[toplamhespalanana - 1])
                            //if (isimlers2.Items[k].ToString() == isimlers.Items[j].ToString())
                            {
                                isimlers3.Items.Add(izintarihleri[toplamhespalanan2a - 1]);
                            } 
                            toplamhespalanan2a--;
                        }
                        toplamhespalanana--;
                    }

                    int izintarihlerisayisi = isimlers3.Items.Count;

                    isimlers4.Items.Clear();
                    int toplamhespalanan3a = izintarihleri.Count();
                        for (int k = 0; k < izintarihleri.Count(); k++)
                        {
                        DateTime tarih = Convert.ToDateTime(izintarihleri[toplamhespalanan3a - 1]);
                        Boolean ek1 = false;
                        Boolean ek2 = false;
                        Boolean ek3 = false;
                        Boolean ek4 = false;
                        Boolean ek5 = false;
                        Boolean ek6 = false;
                        Boolean ek7 = false;
                        for (int l=0; l < isimlers3.Items.Count; l++)
                         { 
                               // isimlers3.Items.Add(haftaninizinsayisi.ToString());
                         //   isimlers3.Items.Add (Convert.ToInt32(tarih.DayOfWeek).ToString());
                         //   isimlers3.Items.Add(Convert.ToInt32(h2).ToString());
                            if (tarih.ToString() != "1.01.0001 00:00:00")
                            { 
                         //       if (isimlers3.Items[l].ToString() != tarih.ToString("dd-MM-yyyy") )
                        //        { 
                                    if ( Convert.ToInt32(h1).ToString()== "1" && Convert.ToInt32(tarih.DayOfWeek).ToString()=="1" && ek1==false)
                                    {
                                        ek1 = true;
                                        isimlers4.Items.Add(tarih.ToString("dd-MM-yyyy"));
                                    }
                                    if ( Convert.ToInt32(h2).ToString() == "1" && Convert.ToInt32(tarih.DayOfWeek).ToString() == "2" && ek2 == false)
                                    {
                                        ek2 = true;
                                        isimlers4.Items.Add(tarih.ToString("dd-MM-yyyy"));
                                    }
                                    if (Convert.ToInt32(h3).ToString() == "1" && Convert.ToInt32(tarih.DayOfWeek).ToString() == "3" && ek3 == false)
                                    {
                                        ek3 = true;
                                        isimlers4.Items.Add(tarih.ToString("dd-MM-yyyy"));
                                    }
                                    if (Convert.ToInt32(h4).ToString() == "1" && Convert.ToInt32(tarih.DayOfWeek).ToString() == "4" && ek4 == false)
                                    {
                                        ek4 = true;
                                        isimlers4.Items.Add(tarih.ToString("dd-MM-yyyy"));
                                    }
                                    if (Convert.ToInt32(h5).ToString() == "1" && Convert.ToInt32(tarih.DayOfWeek).ToString() == "5" && ek5 == false)
                                    {
                                        ek5 = true;
                                        isimlers4.Items.Add(tarih.ToString("dd-MM-yyyy"));
                                    }
                                    if ( Convert.ToInt32(h6).ToString() == "1" && Convert.ToInt32(tarih.DayOfWeek).ToString() == "6" && ek6 == false)
                                    {
                                        ek6 = true;
                                        isimlers4.Items.Add(tarih.ToString("dd-MM-yyyy"));
                                    }
                                    if (Convert.ToInt32(h7).ToString() == "1" && Convert.ToInt32(tarih.DayOfWeek).ToString() == "7" && ek7 == false)
                                    {
                                        ek7 = true;
                                        isimlers4.Items.Add(tarih.ToString("dd-MM-yyyy"));
                                    }
                               // }
                            }
                        }
                        toplamhespalanan3a--;
                    }
                    isimlers5.Items.Clear();
                    for (int j = 0; j < isimlers4.Items.Count; j++)
                    {
                        Boolean durum = false;
                        for (int k = 0; k < isimlers3.Items.Count; k++)
                        {
                            if (isimlers4.Items[j].ToString() == isimlers3.Items[k].ToString())
                            {
                                durum= true;
                            }
                        }
                        if (durum == false)
                        {
                            isimlers5.Items.Add(isimlers4.Items[j].ToString());
                        }
                    }

                    dogru_uyari.Visible = true;
                    uyari_dogru = ("YILLIK İZNİNİZDEN DÜŞÜLECEK İZİN SAYISI: " + isimlers5.Items.Count.ToString() + " LÜTFEN ONAYLAMADAN ÖNCE KONTROL EDİNİZ.");



                    int tatilgunleri = Convert.ToInt32(izintarihleri.Count())-1;
                    //hesaplanangun = Convert.ToInt32(izintarihleri.Count()) - (Convert.ToInt32(izintarihlerisayisi)) - Convert.ToInt32(isimlers4.Items.Count); 
                    hesaplanangun =  Convert.ToInt32(isimlers5.Items.Count);
                    gunsayisi.Value = hesaplanangun.ToString();
                }
                con.Close();
            }
        }
        protected void izin_Getir()
        {
            con.Open();
            kullanilanizinsuresi = "0";
            izingun = 0;

          try
            {
                temizleyici();
                //con.Open();
                SqlCommand control = new SqlCommand("SELECT *, (select sum(suresi) from personel_izin_view where tcno='" + tckimlik.Value + "' and YillikIzinKaontrol='1') as tatilinsuresi,  (DATEDIFF(DAY,DoğumTarihi,GETDATE()))/365  as 'Yas' , (DATEDIFF(DAY,IşeBaşlamaTarihi,GETDATE())) /365  as 'calismasuresi'  , (select sum(DATEDIFF(DD, Izincikistarihi, IzinDonusTarihi)) as kullanilansure from personel_izin_view where IzinTipi <> '' and tcno='" + tckimlik.Value + "' ) AS KULLANILANSURE,(select sum(DATEDIFF(DD, Izincikistarihi, IzinDonusTarihi)) as kullanilansure from personel_izin_view where IzinTipi = '' and tcno='" + tckimlik.Value + "') AS IDARISURE FROM Personel_izin_view where tcno='" + tckimlik.Value + "'", con);
                SqlDataReader dr = control.ExecuteReader();
                while (dr.Read())
                {
                    adi.Value = dr["ad"].ToString();
                    soyadi.Value = dr["soyad"].ToString();
                    dogumtarihimm = Convert.ToDateTime(dr["DoğumTarihi"]);
                    dogumtarihi.Value = dogumtarihimm.ToString("yyyy-MM-dd");
                    isegiristarihim = Convert.ToDateTime(dr["IşeBaşlamaTarihi"]);
                    isebaslamatarihi.Value = isegiristarihim.ToString("yyyy-MM-dd");
                    //calsureyil = isegiristarihim.Year - BUGUNKUTARIH.Year;
                    kullandigimizinsuresi = dr["tatilinsuresi"].ToString();
                    emeklikdurumu.Value = dr["EmeklilikDurumu"].ToString();
                    calismasuresi = dr["calismasuresi"].ToString();
                    yasi = dr["Yas"].ToString();
                    idarisure = dr["IDARISURE"].ToString();
                    if (dr["KULLANILANSURE"].ToString() != "") { kullanilanizinsuresi = dr["KULLANILANSURE"].ToString(); }
                }
                // TOPLAM HAKEDİLEN İZİN İŞLEMLERİ
                if (Convert.ToInt32(yasi) >= 18 && Convert.ToInt32(yasi) <= 50)
                {
                    if (Convert.ToInt32(calismasuresi) >= 1 && Convert.ToInt32(calismasuresi) < 6)
                    {
                        izingun = 0;
                        izingun = Convert.ToInt32(calismasuresi) * Convert.ToInt32(BESYIL);
                    }
                    if (Convert.ToInt32(calismasuresi) >= 6 && Convert.ToInt32(calismasuresi) < 16)
                    {
                        izingun = 0;
                        calyil1 = Convert.ToInt32(calismasuresi) - 5;
                        calyil = Convert.ToInt32(calismasuresi) * Convert.ToInt32(BESYIL);
                        izingun = (5 * Convert.ToInt32(BESYIL)) + (Convert.ToInt32(ONBESYIL) * calyil1);
                    }
                    if (Convert.ToInt32(calismasuresi) >= 16)
                    {
                        izingun = 0;
                        calyil2 = Convert.ToInt32(calismasuresi) - 15;
                        izingun = (5 * Convert.ToInt32(BESYIL)) + (Convert.ToInt32(ONBESYIL) * 10) + (calyil2 * Convert.ToInt32(ONBESYILDANFAZLA));
                    }
                }
                else
                  if (Convert.ToInt32(yasi) <= 18)
                {
                    izingun = 0;
                    izingun = izingun + Convert.ToInt32(ONSEKIZYASINDANAZ) * (calyil3);
                }
                else
                  if (Convert.ToInt32(yasi) >= 50)
                {
                    izingun = 0;
                    izingun = izingun + Convert.ToInt32(ELLIYASINDANFAZLA) * (calyil3);
                }
                hakedilen.Value = izingun.ToString();
                kullanilan.Value = kullandigimizinsuresi.ToString();
                kalan.Value = (izingun - Convert.ToInt32(kullandigimizinsuresi)).ToString();


                // BU YIL HAKEDİLEN İZİN İŞLEMLERİ

                if (Convert.ToInt32(yasi) >= 18 && Convert.ToInt32(yasi) <= 50)
                {
                    if (Convert.ToInt32(calismasuresi) >= 1 && Convert.ToInt32(calismasuresi) < 6)
                    {
                        izingun = 0;
                        izingun =  Convert.ToInt32(BESYIL);
                    }
                    if (Convert.ToInt32(calismasuresi) >= 6 && Convert.ToInt32(calismasuresi) < 16)
                    {
                        izingun = 0;
                        izingun = Convert.ToInt32(ONBESYIL);
                    }
                    if (Convert.ToInt32(calismasuresi) >= 16)
                    {
                        izingun = 0;
                        izingun = Convert.ToInt32(ONBESYILDANFAZLA);
                    }
                }
                else
  if (Convert.ToInt32(yasi) <= 18)
                {
                    izingun = 0;
                    izingun = izingun + Convert.ToInt32(ONSEKIZYASINDANAZ) * (calyil3);
                }
                else
  if (Convert.ToInt32(yasi) >= 50)
                {
                    izingun = 0;
                    izingun = izingun + Convert.ToInt32(ELLIYASINDANFAZLA) * (calyil3);
                }



                yilicihakedilen.Value = izingun.ToString();
                yilicikullanilan.Value = kullandigimizinsuresi.ToString();
                yilicikalan.Value = (izingun - Convert.ToInt32(kullandigimizinsuresi)).ToString();
                idariizin.Value = IDARIIZINSAYISI.ToString();

            }
            catch
            {
                dogru_uyari.Visible = false;
                yanlis_uyari.Visible = true;
                uyari_yanlis = "Bilgiler tam alınamadı "; 
            }
            con.Close();
        }

        public void izinayargetir()
        {
            conn.Open();

            SqlCommand control = new SqlCommand("SELECT personel_izin_ayarlar_departman_view.* FROM personel_izin_ayarlar_departman_view WHERE departman='" + departmani.Value + "' and kurum_id='" + kullanici_giris.kullaniciSİrket_id + "'", conn);
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
            conn.Close();
        }


        protected void izin_Kaydet(object sender, EventArgs e)
        {       
            con.Open();
                //  
            string izintanimlarial = izintanimlarimiz.Text;
            if (FileUpload1.FileContent != null)
            {
                if(Convert.ToInt32(gunsayisi.Value) > 0 ) 
                { 
                    string dosyaAdi = FileUpload1.FileName; //Dosyanın adı
                    byte[] dosyaIcerik = FileUpload1.FileBytes; //Dosyanın bilgilerini binary formatta getirir
                    string dosyaTipi = FileUpload1.PostedFile.ContentType;
                    SqlCommand cmd = new SqlCommand("PersonelIzinKaydetGuncelle", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PGorevID", izinno.Text);
                    cmd.Parameters.AddWithValue("PPersonelId", tckimlik.Value);
                    cmd.Parameters.AddWithValue("PIzinTipi", izintanimlarimiz.Text);
                    cmd.Parameters.AddWithValue("PRaporDurumu", rapordurum2.Text);
                    cmd.Parameters.AddWithValue("PIzinBaslangicTarihi", izinbaslangictarihi.Value);
                    cmd.Parameters.AddWithValue("PIzinBitisTarihi", izinbitistarihi.Value);
                    cmd.Parameters.AddWithValue("PAciklama", aciklamam1.Value);
                    cmd.Parameters.AddWithValue("PBelgeDosyaAdi", dosyaAdi);
                    cmd.Parameters.AddWithValue("PBelge", dosyaIcerik);
                    cmd.Parameters.AddWithValue("PBelgeTipi", dosyaTipi);
                    cmd.Parameters.AddWithValue("suresi", gunsayisi.Value);
                    cmd.Parameters.AddWithValue("PSirketId", kullanici_giris.kullaniciSİrket_id);
                    cmd.Parameters.AddWithValue("onaydurumu", "TALEP EDILDI");
                    cmd.Parameters.AddWithValue("onaylayanyonetici", "");
                    //con.Open();
                    int k = cmd.ExecuteNonQuery();
                    if (k != 0)
                        {
                            dogru_uyari.Visible = true;
                            uyari_dogru = "Kayıt Başarı ile tamamlandı";
                            mailgonder();
                            con.Close();
                        }
                }
                else if(Convert.ToInt32(gunsayisi.Value) <= 0)
                {
                    yanlis_uyari.Visible = true;
                    uyari_yanlis = "Talep edilen izin 0 gün veya 0 günden az olamaz";
                }
            }
            izintanimlarimiz.Text = izintanimlarial;
            con.Close();
        }
        protected void arama_genel_IDLI()
        {
            //ListBox1.Items.Add( kullanici_giris.kullaniciSİrket_id);
            con.Open();
            SqlCommand C = new SqlCommand("SELECT count(personel_izin_liste_view.sirketid) FROM personel_izin_liste_view  WHERE  personel_izin_liste_view.sirketid='" + kullanici_giris.kullaniciSİrket_id + "' and personelId='" + tckimlik.Value +"'", con);
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
            SqlCommand control = new SqlCommand("SELECT personel_izin_liste_view.* FROM personel_izin_liste_view WHERE personel_izin_liste_view.sirketid='" + kullanici_giris.kullaniciSİrket_id + "' and personelId='" + tckimlik.Value + "'", con);
                SqlDataReader dr = control.ExecuteReader();
            int i = verisay;
            while (dr.Read())
            {
                idm[i-1] = dr["Id"].ToString();
                tc_id[i - 1] = dr["personelId"].ToString();
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

        protected void mailgonder()
        {
            conn.Open();
            string mailadresimails = "";
            string mailgondericimails = "";
            string mailkullanicimails = "";
            string mailsifremails = "";
            string smtpadresmails = "";
            string smtpportmails = "";
            string mailalicimails = "";

            SqlCommand r = new SqlCommand("SELECT * FROM mail_kullanici_view WHERE tc='" + departmanyonetici + "'", conn);
            SqlDataReader okus = r.ExecuteReader();
            if (okus.Read())
            {

                mailadresimails = okus["mailadresi"].ToString();
                mailgondericimails = okus["mailgonderici"].ToString();
                mailkullanicimails = okus["mailkullanici"].ToString();
                mailsifremails = okus["mailsifre"].ToString();
                smtpadresmails = okus["smtpadres"].ToString();
                smtpportmails = okus["smtpport"].ToString();
                mailalicimails = okus["email"].ToString();

            }
            okus.Close();
            conn.Close();

                        

            try
            {
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new MailAddress(mailadresimails, mailgondericimails); ;
                msg.To.Add(new MailAddress(mailalicimails));
                msg.IsBodyHtml = true;
                msg.Subject = " İZİN TALEBİ ";
                msg.Body = @"<html>
                      <body > <a >
                        <div >      
                           <i><font color=black  ><h1><strong> WMSDATA</strong></h1></font> </i>
                          </div>
                 <div >  <i>  <h3> MERHABA;</div>
                 <div >  </ h3 ></ i > " + tckimlik.Value + " Tc Numarlı " + adi.Value + "  " + soyadi.Value + " İsimli Personeliniz </ a > " + izinbaslangictarihi.Value + " ile " + izinbitistarihi.Value+ " tarihleri arasında toplam " + gunsayisi.Value+ " Gün" + izintanimlarimiz.Text+ " İzin talep etmektedir.</div>"+ 
                 "Lütfen ilgili ekranı kontrol ediniz. </ i > </ p >  " +
                "<div >  <i>  <h3>  WMSDATA  SYSTEM </div> </ body > </ html >";



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