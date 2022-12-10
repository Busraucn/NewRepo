<%@ Page Title="" Language="C#" MasterPageFile="~/Anasablon.Master" AutoEventWireup="true" CodeBehind="hareketGoruntule.aspx.cs" Inherits="WMSDATA.hareketGoruntule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/plugins/select2/select2.min.css" rel="stylesheet">
     <link href="css/bootstrap.min.css" rel="stylesheet">

    <link href="css/plugins/bootstrap-tagsinput/bootstrap-tagsinput.css" rel="stylesheet">

    <link href="css/plugins/colorpicker/bootstrap-colorpicker.min.css" rel="stylesheet">

    <link href="css/plugins/cropper/cropper.min.css" rel="stylesheet">

    <link href="css/plugins/switchery/switchery.css" rel="stylesheet">
        <link href="font-awesome/css/font-awesome.css" rel="stylesheet">
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
   <form id="form1" runat="server">
     
            <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>HAREKET GÖRÜNTÜLE</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="ansayfa.aspx">Anasayfa</a>
                        </li>
                        <li class="breadcrumb-item">
                            <a>Hareket Görüntüle</a>
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
                        <h5>TÜM HAREKETLER</h5>
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
                             <div class="col-sm-2">İLK TARİH: <input id="ilktariharama" runat ="server" type="date" required="" class="form-control"> </div>
                             <div class="col-sm-2">SON TARİH: <input id="sontariharama" runat ="server" type="date" required="" class="form-control">  </div>
                            &nbsp;&nbsp;&nbsp;
                                 <button type="button" class="btn btn-warning" id="arama_button"  runat ="server"  onserverclick ="arama_button_ServerClick"  >  ARA  </button>
                        
                        <div class="table-responsive" style="font-size: xx-small">
                    <table class="table table-striped table-bordered table-hover dataTables-example" >
                    <thead>
                    <tr><th>SEÇ</th>
                                      <th data-hide="phone,tablet">TcNo</th>
                                      <th data-hide="phone,tablet">KartNo</th>
                                      <th data-hide="phone,tablet">Adi</th>
                                      <th data-hide="phone,tablet">Soyad</th>
                                      <th data-hide="phone,tablet">Tarih</th>
                                      <th data-hide="phone,tablet">HareketTipi</th>
                                      <th data-hide="phone,tablet">KayitKaynak</th>
                                      <th data-hide="phone,tablet">Durum</th>

                                      <th data-hide="phone,tablet">KayitKullanici </th>
                           <th data-hide="phone,tablet">Hareket Sonuç </th>
                                      <th data-hide="phone,tablet">Hareket Elle Düzeltildi </th>
                                   
                                      <th data-hide="phone,tablet">Hareket Düzenle </th>
                       
                    
                    </tr>
                    </thead>
                          <tbody>


                                    <%for (int i = 0; i < verisay; i++)
                                        { %>
                              
                            
                                         <% if( TcNo [i] !="" && TcNo [i] !=null  ){ %>
                                <tr class="gradeX">

                     <td>     
                        

                          
                       
                        <%for (int k = 0; k < verisay; k++)
                                        { %>

                         <% if( WMSDATA.kullanici_giris.secilen_id.Contains(TcNo[i].ToString ()) == false){ %>
                        
                         <a href="hareketGoruntule.aspx?id_tut=<%=TcNo[i] %>" class="btn btn-white">
                            <i class="fa fa-check"> </i>
                        </a>
                         <% break; %>     
                          <% } %>
                         <%else{ %>
                         
                          <a href="hareketGoruntule.aspx?id_sil=<%=TcNo[i] %>" class="btn btn-danger">
                            <i class="fa fa-times"> </i>
                        </a>
                         <% break;  %>    
                         <% } %>

                           <% } %>                 
                      
                         

                     </td>
                                   
                                    
                                     <td><%=TcNo [i]%>  </td>
                                     <td><%=KartNo [i]%>  </td>
                                     <td><%=Adi[i] %></td>
                                     <td><%=Soyad[i] %></td>
                                     <td><%=Tarih[i] %></td>
                                     <td><%=HareketTipi[i] %></td>
                                     <td><%=KayitKaynak[i] %></td>
                                     <td><%=Durum[i] %> </td>                                      
                                     <td class="center"><%=KayitKullanici[i] %></td>     
                                         <td><%=HareketSonuc[i] %> </td>    
                                    <%
                                    if( ElleDuzeltildi[i]  == "True" )
                                    { %> 
                                     <td> Düzenlendi  </td>  
                                  <%  }%> 
                                    <%else{ %>
                         
                           <td> Düzenlenme Yok  </td>  
                  
                         <% } %>
 <td> 
                                     <a class="btn  btn-primary dim" href="hareketGoruntule.aspx?id_duzenle=<%= id[i]%>&veri=1"   type="button"><i class="fa fa-check"></i></a>
                                     <a class="btn  btn-warning dim" href="hareketGoruntule.aspx?id_duzenle=<%= id[i]%>&veri=2"  type="button"><i class="fa fa-chevron-down"></i></a>
                                     <a class="btn  btn-danger  dim" href="hareketGoruntule.aspx?id_duzenle=<%= id[i]%>&veri=3"  type="button"><i class="fa fa-close"></i></a>
                                     <a class="btn  btn-success dim" href="hareketGoruntule.aspx?id_duzenle=<%= id[i]%>&veri=4"  type="button"> <i class="fa fa-superscript"></i> </a>



     </td>
                                             
                                  <%--          <a href="#"  type="button" class="btn btn-outline-warning" data-toggle="modal" data-target="#myModal2">
                                    Hareket Düzenle 
                                          
                                </a>
                                             
                                                   <div class="modal inmodal" id="myModal2" tabindex="-1" role="dialog" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content animated flipInY">
                                            <div class="modal-header">
                                                 <h4 class="modal-title">Personel Hareket Düzenle</h4>
                                                <small class="font-bold">Değiştirdiğiniz bilgi tüm kullanıcılar için görünür olacaktir.</small>
                                            </div>
                                            <div class="modal-body">


                                <div class="form-group">
                                    <fieldset>
                                        <div class="col-sm-12" style="text-align: left">Çalışma Zaman Durumu <%= id[i] %>:
                                        &nbsp 
                                        <select id="calismaDurum" name="calismaDurum" onselectedindexchanged="ddlselect_Changed" runat="server">
                                                <option value=""></option>
                                                <option value="Tam">Tam</option>
                                                <option value="Yarım">Yarım</option>
                                                <option value="Eksik Çalışma">Eksik Çalışma</option>
                                                <option value="Mesai">Mesai</option>
                                        </select>
                                             </div>
                                    </fieldset>
                                </div>
                            
                             
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">KAPAT</button>
                                                     <a href="hareketGoruntule.aspx?id_duzenle=<%= id[i]%>"  class="btn btn-primary" id="personelCalismaKaydet" >
                                    <i class="fa fa-check"></i>KAYDET
                                </a>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                         </td>    --%>
                       
                             
                           
                                      </tr> 
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

