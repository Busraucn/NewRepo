<%@ Page Title="" Language="C#" MasterPageFile="~/Anasablon.Master" AutoEventWireup="true" CodeBehind="personel_navigation.aspx.cs" Inherits="WMSDATA.personel_navigation" %>
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

   <form id="personel_navigation" runat="server">
     
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
                        <h5>PERSONEL YÖNETİMİ <small>  </small></h5>
                        <div class="ibox-tools">
                           
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </div>
       <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
             <div class="col-lg-10">
                 <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-6 2-r"><h3 class="m-t-none m-b"></h3> <div>
        <asp:Image ID="imgPicture" Width="160" Height="160" runat="server" />

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
                                    &nbsp <div class="form-group">
                                                               <asp:Image ID="qrimage" Width="100" Height="100" runat="server" />
                                                           
</div></div>
                             <div class="col-sm-4 2-r"><h3 class="m-t-none m-b"></h3> <div>                                   
                                       <div class="form-group">
                                    <button  class="btn btn-primary" id="Button9"  runat ="server">  <i class="fa fa-check"> PERSONEL KAYIT</i>
                            </button>  &nbsp  &nbsp &nbsp</div> 
                                <div class="form-group">
                                    <button  class="btn btn-primary" id="Button10"  runat ="server">  <i class="fa fa-check"> PERSONEL BELGE KAYIT</i>
                            </button>  &nbsp &nbsp &nbsp</div> 
                                    <div class="form-group">
                                    <button  class="btn btn-primary" id="Button11"  runat ="server">  <i class="fa fa-check"> PERSONEL MAAŞ İŞLEMLERİ</i>
                            </button> &nbsp &nbsp &nbsp</div>  
         <div class="form-group">
                                    <button  class="btn btn-primary" id="Button12"  runat ="server">  <i class="fa fa-check"> PERSONEL YÖVMİYE İŞLEMLERİ</i>
                            </button> &nbsp &nbsp &nbsp </div> 
                                        <div class="form-group">
                                    <button  class="btn btn-primary" id="Button13"  runat ="server">  <i class="fa fa-check"> İZİN AL</i>
                            </button> &nbsp &nbsp &nbsp</div>  
                                            <div class="form-group">
                                    <button  class="btn btn-primary" id="Button14"  runat ="server">  <i class="fa fa-check"> PERSONEL ADINA İZİN AL</i>
                            </button> &nbsp &nbsp &nbsp</div>  
                                                <div class="form-group">
                                    <button  class="btn btn-primary" id="Button15"  runat ="server">  <i class="fa fa-check"> PERSONEL İZİN YÖNETİMİ</i>
                            </button> &nbsp &nbsp &nbsp</div>  
                                                    <div class="form-group">
                                    <button  class="btn btn-primary" id="Button16"  runat ="server">  <i class="fa fa-check"> PERSONEL HAREKETLER</i>
                            </button> &nbsp &nbsp &nbsp</div>  
                                  </div>
 </div>  </div>  </div>
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
