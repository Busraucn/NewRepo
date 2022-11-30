<%@ Page Title="" Language="C#" MasterPageFile="~/Anasablon.Master" AutoEventWireup="true" CodeBehind="personel_ekle.aspx.cs" Inherits="WMSDATA.personel_ekle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
   <link href="css/plugins/select2/select2.min.css" rel="stylesheet">
     <link href="css/bootstrap.min.css" rel="stylesheet">

    <link href="css/plugins/bootstrap-tagsinput/bootstrap-tagsinput.css" rel="stylesheet">

    <link href="css/plugins/colorpicker/bootstrap-colorpicker.min.css" rel="stylesheet">

    <link href="css/plugins/cropper/cropper.min.css" rel="stylesheet">

    <link href="css/plugins/switchery/switchery.css" rel="stylesheet">

    <link href="css/plugins/jasny/jasny-bootstrap.min.css" rel="stylesheet">

    <link href="css/plugins/nouslider/jquery.nouislider.css" rel="stylesheet">

    <link href="css/plugins/datapicker/datepicker3.css" rel="stylesheet">

    <link href="css/plugins/ionRangeSlider/ion.rangeSlider.css" rel="stylesheet">
    <link href="css/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css" rel="stylesheet">

    <link href="css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet">

    <link href="css/plugins/clockpicker/clockpicker.css" rel="stylesheet">

    <link href="css/plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet">

    <link href="css/plugins/select2/select2.min.css" rel="stylesheet">

    <link href="css/plugins/touchspin/jquery.bootstrap-touchspin.min.css" rel="stylesheet">

    <link href="css/plugins/dualListbox/bootstrap-duallistbox.min.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <form id="personel_ekle" runat="server">
     
            <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>PERSONEL KAYDET</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="ansayfa.aspx">Anasayfa</a>
                        </li>
                        <li class="breadcrumb-item">
                            <a>PERSONEL Kaydet</a>
                        </li>
                       
                    </ol>
                </div>
                <div class="col-lg-2">

                </div>
            </div>

      <br />
                  <div class="animated fadeIn">
      <div class="alert alert-success text-center" runat ="server"  id="dogru_uyari"  role="alert">
                                     <%=uyari_dogru  %>
                                    </div></div>
                     <div class="animated fadeIn">
      <div class="alert alert-danger text-center" runat ="server"  id="yanlis_uyari"  role="alert">
                                   <%=uyari_yanlis  %>
                                    </div></div>
       <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
             <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>PERSONEL KAYDET <small>  </small></h5>
                        <div class="ibox-tools">
                                <button class="btn btn-white"  id="temizle" runat ="server" onserverclick ="temizle_ServerClick"     >
                                <i class="fa fa-trash-o"></i> TEMİZLE
                            </button>
                             <button  class="btn btn-primary" id="kaydet" runat ="server" onserverclick="Personel_Kaydet"       >
                                <i class="fa fa-check"></i> KAYDET
                            </button>
                            <button class="btn btn-danger close-link">
                                <i class="fa fa-times"></i> KAPAT
                            </button>                            
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </div>
       <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
             <div class="col-lg-8">
                 <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-6 2-r"><h3 class="m-t-none m-b"></h3> <div>
        <asp:Image ID="imgPicture" Width="160" Height="90" runat="server" />
        <asp:FileUpload ID="fluPicture" onchange="this.form.submit();"
            runat="server" Width="240" />
            </div>&nbsp
                                
                                                                   <div class="form-group">
                                                                      
                                     <asp:DropDownList  id="tckimlik1" runat ="server" AutoPostBack="True" onselectedindexchanged="Personel_Getir" style="text-transform:uppercase" class="select2_demo_3 form-control col-sm-6" required="">
                                     </asp:DropDownList>
                                   </div> 

                                                     <asp:Textbox name="textarea-input" id="tckimlik" MaxLength="11"  runat="server" AutoPostBack="True"  OnTextChanged="Personel_Getir2" placeholder="TC Kimlik No.." class="form-control col-sm-6" required="" ></asp:Textbox>  
                                &nbsp 
                           <textarea name="textarea-input" id="isim"  runat="server" style="text-transform:uppercase" placeholder="İsim.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                                    &nbsp 
                           <textarea name="textarea-input" id="soyisim"  runat="server" style="text-transform:uppercase" placeholder="Soyisim.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                                    &nbsp
                            <div class="form-group"><label>DOĞUM TARİHİ:&nbsp &nbsp &nbsp &nbsp &nbsp</label> 
                                                                  &nbsp
                             <input runat ="server" href="#" type="date" required="" id="DOGUMTARIHI" class="form-control col-sm-6"></> 
                                &nbsp
                                <div> 
                                  <button  class="btn btn-primary" id="tcdogrula" onserverclick="tckimlikdogrula" runat ="server">  <i class="fa fa-check"> TC DOĞRULA</i>
                            </button> &nbsp &nbsp
                                      <% if( tcsecilen !="" && tcsecilen !=null  ){ %>
                                    <td class="client-status"><a href="personel_adina_izin_ekle.aspx?idtc=<%=tcsecilen %>"  class="label label-primary">İZİN AL</a></td>
                                      <% } %>
                                </div> </div> 
                               
                                      <textarea name="textarea-input" id="dogumyeri"  runat="server" style="text-transform:uppercase" placeholder="Doğum Yeri.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                            &nbsp 
                                <div class="form-group">
                           <fieldset><label>CİNSİYET:</label>  &nbsp  <select id="cinsiyet1" name="cinsiyet" runat="server">
                            <option value=""></option>
                            <option value="KADIN">KADIN</option>
                            <option value="ERKEK">ERKEK</option>
                            <option value="DİĞER">DİĞER</option> </select> </fieldset>   
                                    </div>
                                      <textarea name="textarea-input" id="kizliksoyadi"  runat="server" style="text-transform:uppercase" placeholder="EVLENMEDEN ÖNCEKİ SOYADI:"  class="form-control col-sm-6" rows="1" required="" ></textarea>
                                          &nbsp 
                                      <textarea name="textarea-input" id="anneadi"  runat="server" style="text-transform:uppercase" placeholder="Anne Adı.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                                   &nbsp 
                                      <textarea name="textarea-input" id="babaadi"  runat="server" style="text-transform:uppercase" placeholder="Baba Adı.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                                
                                &nbsp 
                                <div class="form-group">
                             <fieldset><label>MEDENİ DURUM</label> &nbsp <select id="medenidurum1" name="medenidurum" runat="server">
                             <option value=""></option>
                             <option value="EVLİ">EVLİ</option>
                             <option value="BEKAR">BEKAR</option>
                             <option value="DİĞER">DİĞER</option> </select> </fieldset>
                                </div>
                               <textarea name="textarea-input" id="cocuksayisi"  runat="server" style="text-transform:uppercase" placeholder="Çocuk Sayısı.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                          
                                   
                                &nbsp 
                           <div class="form-group">
                           <fieldset><label>KAN GRUBU:</label> &nbsp <select id="kangrubu1" name="kangrubu" runat="server">
                            <option value=""></option>
                            <option value="A(+)">A (+)</option>
                            <option value="A(-)">A (-)</option>
                            <option value="B(+)">B (+)</option> 
                            <option value="B(-)">B (-)</option>
                            <option value="0(+)">0 (+)</option> 
                            <option value="0(-)">0 (-)</option>
                            <option value="AB(+)">AB (+)</option> 
                            <option value="AB(-)">AB (-)</option>
                                     </select> </fieldset>  </div>
                                &nbsp 
                                   </div> 
                                                           <div class="col-sm-6 1-r"> <h3 class="m-t-none m-b"></h3>
 &nbsp 
                                      <textarea name="textarea-input" id="telefon1"  runat="server" style="text-transform:uppercase" placeholder="Telefon1.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                               &nbsp 
                                      <textarea name="textarea-input" id="telefon2"  runat="server" style="text-transform:uppercase" placeholder="Telefon2.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                          &nbsp 
                                      <textarea type="email" name="textarea-input" id="mailadresi"  runat="server" placeholder="Mail Adresi.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                         
                                <p class="text-center"> </p> 
                                      <textarea name="textarea-input" id="ulke"   runat="server" style="text-transform:uppercase" placeholder="Adres Ülke:" class="form-control col-sm-6" rows="1" required="" ></textarea>
                                   &nbsp  
                                   <div class="form-group">
                                   <label>İL:&nbsp &nbsp &nbsp </label>  <asp:DropDownList ID="anafirma" runat ="server" AutoPostBack="True" onselectedindexchanged="fTextChanged" style="text-transform:uppercase" class="select2_demo_3 form-control col-sm-5" required="">
                                    </asp:DropDownList>
                                  </div> 
                                   <div class="form-group">
                                   <label>İLÇE:</label>  <asp:DropDownList  id="ilcesec" runat ="server" style="text-transform:uppercase" class="select2_demo_3 form-control col-sm-5" required="">
                                     </asp:DropDownList>
                                   </div> 
                                      <textarea name="textarea-input" id="mahalle"  runat="server" style="text-transform:uppercase" placeholder="Adres Mahalle.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                                    &nbsp
                                      <textarea name="textarea-input" id="adres"  runat="server" style="text-transform:uppercase" placeholder="Adres.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                                   &nbsp 
                                      <textarea name="textarea-input" id="no"  runat="server" style="text-transform:uppercase" placeholder="Kapı No.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                                    &nbsp
                                      <textarea name="textarea-input" id="postakodu"  runat="server" style="text-transform:uppercase" placeholder="Posta Kodu.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                                   &nbsp 
                                                                                              <div class="form-group">
                               <fieldset><label>ENGEL DURUMU:</label>  &nbsp <select id="engeldurumu1" name="engeldurumu" runat="server">
                               <option value=""></option>
                               <option value="ENGELLİ">ENGELSİZ</option>
                               <option value="ENGELSİZ">ENGELLİ</option>
                               </select> </fieldset>  </div>
                                <div class="form-group">
                                   <label>ENGEL ORANI:</label> <textarea name="textarea-input" id="engelorani"  runat="server" style="text-transform:uppercase" placeholder="Engel Oranı %.."  class="form-control col-sm-6" rows="1" required="" ></textarea>
                                    </div><div class="form-group">
                                                               <textarea name="textarea-input" id="not"  runat="server" style="text-transform:uppercase" placeholder="Not.."  class="form-control col-sm-6" rows="2" required="" ></textarea>
                              </div> 
                                                               <div class="form-group">
                                                               <asp:Image ID="qrimage" Width="100" Height="100" runat="server" />
                                                           </div>   
                                                               </div> 
                           </div>
                     
                          </div>
                       </div>

        
                     <div class="col-lg-3 m-b-lg">
                    <div id="vertical-timeline" class="vertical-container light-timeline no-margins">

                        <div class="vertical-timeline-block">
                            <div class="vertical-timeline-icon blue-bg">
                                <i class="fa fa-users"></i>
                            </div>

                            <div class="vertical-timeline-content">
                                <h2>KİŞİ ÇALIŞMA GÜNLERİ</h2>
                                <div><asp:CheckBox id="checkbox1" onchecked="true" runat="server" Text="Pazartesi" TextAlign="Right" /></div>
                                &nbsp 
                                <div><asp:CheckBox id="checkbox2" onchecked="true" runat="server" Text="Salı" TextAlign="Right" /></div>
                                &nbsp 
                                <div><asp:CheckBox id="checkbox3" onchecked="true" runat="server" Text="Çarşamba" TextAlign="Right" /></div>
                                &nbsp 
                                <div><asp:CheckBox id="checkbox4" onchecked="true" runat="server" Text="Perşembe" TextAlign="Right" /></div>
                                &nbsp 
                               <div> <asp:CheckBox id="checkbox5" onchecked="true" runat="server" Text="Cuma" TextAlign="Right" /></div>
                                &nbsp 
                               <div> <asp:CheckBox id="checkbox6" runat="server" Text="Cumartesi" TextAlign="Right" /></div>
                                &nbsp 
                              <div>  <asp:CheckBox id="checkbox7" runat="server" Text="Pazar" TextAlign="Right" /></div>
                            </div>

                            <div class="vertical-timeline-block">
                            <div class="vertical-timeline-icon navy-bg">
                                <i class="fa fa-file-text"></i>
                            </div>

                            <div class="vertical-timeline-content">
                                <h2>ÇALIŞMA BİLGİLERİ</h2>
                                   <div class="form-group">
                                   <label>DEPARTMAN:</label>  <asp:DropDownList  id="departmanlist" runat ="server" style="text-transform:uppercase" class="select2_demo_3 form-control col-sm-10" required="">
                                   </asp:DropDownList>
                                   </div> 


                                   <div class="form-group">
                                   <label>GÖREV</label>  <asp:DropDownList  id="gorevlist" runat ="server" style="text-transform:uppercase" class="select2_demo_3 form-control col-sm-10" required="">
                                     </asp:DropDownList>
                                   </div> 
                            <div class="form-group">
                             <fieldset><label>SİGORTA DURUMU:</label> &nbsp <select id="emeklidurumu1" name="emeklidurumu1" runat="server" >
                             <option value=""></option>
                             <option value="SİGORTALI">SİGORTALI</option>
                             <option value="EMEKLİ">EMEKLİ</option> </select> </fieldset>
                                </div>
                                 <div class="form-group">
                               <fieldset><label>ÇALIŞMA DURUMU:</label>  &nbsp <select id="calismadurumu1" name="calismadurumu" runat="server">
                               <option value=""></option>
                               <option value="ÇALIŞIYOR">ÇALIŞIYOR</option>
                               <option value="AYRILDI">AYRILDI</option>
                               </select> </fieldset>  </div>
                                <div class="form-group"><label>İŞE BAŞLAMA TARİHİ:</label>
                                <input runat ="server" href="#" type="date" required="" id="isebaslamatarihi" class="form-control col-sm-10"></>
                            </div>
                            <div class="form-group"><label>İŞTEN AYRILMA TARİHİ:</label>
                                <input runat ="server" href="#" type="date" required="" id="istenayrilmatarihi" class="form-control col-sm-10"></>
                            </div>
                                    <div class="form-group">
                                    <textarea name="textarea-input" id="kartkodu"  runat="server" style="text-transform:uppercase" placeholder="Kart Kodu.."  class="form-control col-sm-10" rows="1" required="" ></textarea>
                                    </div>
                                      
                            </div>
                        </div>


                        </div>

            </div>
                       </div>
                    </div>
                </div>
    
   
       <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-lg-12">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>PERSONEL LİSTESİ</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                <i class="fa fa-wrench"></i>
                            </a>
                            <ul class="dropdown-menu dropdown-user">
                               
                            </ul>
                            <a class="close-link">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <div class="table-responsive" style="font-size: 16">
                    <table class="table table-striped table-bordered table-hover dataTables-example" aria-sort="ascending" dir="ltr" >
                    <thead>
                    <tr><th>SEÇ</th>
                                      <th data-hide="phone,tablet">TC NO</th>
                                      <th data-hide="phone,tablet">İSİM</th>
                                      <th data-hide="phone,tablet">SOYİSİM</th>
                                      <th data-hide="phone,tablet">DOĞUM TARİHİ</th>
                                      <th data-hide="phone,tablet">DOĞUM YERİ </th>
                                      <th data-hide="phone,tablet">KAN GRUBU</th>
                                      <th data-hide="phone,tablet">TELEFON</th>
                                      <th data-hide="phone,tablet">MAİL ADRESİ</th>                                      
                                      <th data-hide="phone,tablet">ÇALIŞMA DURUMU</th>   
                                      <th data-hide="phone,tablet">İŞE BAŞLAMA TARİHİ</th>   
                                      <th data-hide="phone,tablet">İŞTEN AYRILMA TARİHİ</th>   
                    </tr>
                    </thead>
                          <tbody>
                                    <%for (int i = 0; i < verisay; i++)
                                        { %>
                             <% if( tc_id [i] !="" && tc_id [i] !=null  ){ %>
                                <tr class="gradeX">
                     <td>  
                     </td>
                                     <td><%=tc_id [i]%>  </td>
                                     <td><%=ad_id [i]%>  </td>
                                      <td><%=soyad_id [i] %>  </td>
                                     <td><%=dogumtarihi_id[i] %></td>
                                     <td><%=dogumyeri_id[i] %></td>
                                    <td><%=kangrubu_id[i] %> </td> 
                                    <td><%=telefon_id[i] %></td> 
                                     <td><%=mailadresi_id[i] %></td>
                                     <td><%=calismadurumu_id[i] %></td>                                                                                                     
                                     <td class="center"><%=isebaslamatarihi_id[i] %></td>
                                     <td class="center"><%=istenayrilmatarihi_id[i] %></td>
                                    <% } %>
                           <% } %>
                                </tbody>
                    <tfoot>
                    </tfoot>
                    </table>
                        </div>

                    </div>
                </div>
            </div>
            </div>
        </div>
    <!-- FooTable -->
    <script src="js/plugins/footable/footable.all.min.js"></script>
    <!-- Custom and plugin javascript -->
    <script src="js/inspinia.js"></script>
    <script src="js/plugins/pace/pace.min.js"></script>
                     <!-- Mainly scripts -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/popper.min.js"></script>
             <!-- Select2 -->
    <script src="js/plugins/select2/select2.full.min.js"></script>
        <!-- Chosen -->
    <script src="js/plugins/chosen/chosen.jquery.js"></script>
   <!-- JSKnob -->
   <script src="js/plugins/jsKnob/jquery.knob.js"></script>

   <!-- Input Mask-->
    <script src="js/plugins/jasny/jasny-bootstrap.min.js"></script>

   <!-- Data picker -->
   <script src="js/plugins/datapicker/bootstrap-datepicker.js"></script>

   <!-- NouSlider -->
   <script src="js/plugins/nouslider/jquery.nouislider.min.js"></script>

   <!-- Switchery -->
   <script src="js/plugins/switchery/switchery.js"></script>

    <!-- IonRangeSlider -->
    <script src="js/plugins/ionRangeSlider/ion.rangeSlider.min.js"></script>

    <!-- iCheck -->
    <script src="js/plugins/iCheck/icheck.min.js"></script>

    <!-- MENU -->
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>

    <!-- Color picker -->
    <script src="js/plugins/colorpicker/bootstrap-colorpicker.min.js"></script>

    <!-- Clock picker -->
    <script src="js/plugins/clockpicker/clockpicker.js"></script>

    <!-- Image cropper -->
    <script src="js/plugins/cropper/cropper.min.js"></script>

    <!-- Date range use moment.js same as full calendar plugin -->
    <script src="js/plugins/fullcalendar/moment.min.js"></script>

    <!-- Date range picker -->
    <script src="js/plugins/daterangepicker/daterangepicker.js"></script>

    <!-- Select2 -->
    <script src="js/plugins/select2/select2.full.min.js"></script>

    <!-- TouchSpin -->
    <script src="js/plugins/touchspin/jquery.bootstrap-touchspin.min.js"></script>

    <!-- Tags Input -->
    <script src="js/plugins/bootstrap-tagsinput/bootstrap-tagsinput.js"></script>

    <!-- Dual Listbox -->
    <script src="js/plugins/dualListbox/jquery.bootstrap-duallistbox.js"></script>
    <!-- Page-Level Scripts -->
    <script>
        $(document).ready(function () {
            $('.footable').footable();
            $('.footable2').footable();
        });
        $(".select2_demo_1").select2();
        $(".select2_demo_2").select2();
        $(".select2_demo_3").select2({
            placeholder: "seçiniz..",
            allowClear: true
        });
    </script>
            </form> 
</asp:Content>
