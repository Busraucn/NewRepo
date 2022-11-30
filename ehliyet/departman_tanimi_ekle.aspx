<%@ Page Title="" Language="C#" MasterPageFile="~/Anasablon.Master" AutoEventWireup="true" CodeBehind="departman_tanimi_ekle.aspx.cs" Inherits="WMSDATA.departman_tanimi_ekle" %>
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

   <form id="departman_tanimi_ekle" runat="server">
     
            <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>GÖREV TANIMI KAYDET</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="ansayfa.aspx">Anasayfa</a>
                        </li>
                        <li class="breadcrumb-item">
                            <a>GÖREV TANIMI Kaydet</a>
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
                        <h5>GÖREV TANIMI KAYDET <small>  </small></h5>
                        <div class="ibox-tools">
                                <button class="btn btn-white"  id="temizle" runat ="server" onserverclick ="temizle_ServerClick"     >
                                <i class="fa fa-trash-o"></i> TEMİZLE
                            </button>
                            <% if (onyazi_acilsin_mi != 0)
                                { %>
                              <button class="btn btn-white"  id="onyazi" runat ="server" data-toggle="modal" data-target="#myModal15" >
                                <i class="fa fa-file-text-o "></i>
                            </button>
                            <%} %>
                             <button  class="btn btn-primary" id="belge_state" runat ="server"   data-toggle="modal" data-target="#myModal6"      >
                                <i class="fa fa-cogs"></i> TÜMÜNÜ SEÇ
                            </button>
                             <button  class="btn btn-primary" id="kaydet" runat ="server" onserverclick="Gorev_Kaydet"       >
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
             <div class="col-lg-12">
                 <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-6 2-r"><h3 class="m-t-none m-b"></h3>
                                                                
                                <asp:Textbox name="textarea-input" disabled id="gorevidm"  runat="server" AutoPostBack="True"  placeholder="Departman Id.." class="form-control col-sm-4 b-r" required="" ></asp:Textbox>  
                                &nbsp 
                                      <textarea name="textarea-input" id="departmankodum"  runat="server" style="text-transform:uppercase" placeholder="Departman Kodu.."  class="form-control col-sm-4 b-r" rows="1" required="" ></textarea>
                                   
                                    &nbsp 
                                      <textarea name="textarea-input" id="departmanadim"  runat="server" style="text-transform:uppercase" placeholder="Departman Adı.."  class="form-control col-sm-4 b-r" rows="1" required="" ></textarea>
                                    &nbsp 

                                                            <div class="form-group">
                                   <div><label>ÜST DEPARTMAN:</label></div>  
                                    <asp:DropDownList  id="ustdepartmankodw" runat ="server" style="text-transform:uppercase" class="select2_demo_3 form-control col-sm-4" required="" >
                                     </asp:DropDownList>
                                   </div> 

                                                   <div class="form-group">
                                                       <div><label>DEPARTMAN YÖNETİCİSİ:</label></div>
                                     <asp:DropDownList  id="departmanyoneticim" runat ="server" style="text-transform:uppercase" class="select2_demo_3 form-control col-sm-4" required="">
                                     </asp:DropDownList>
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
                        <h5>TÜM GÖREVLER</h5>
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

                                         <th data-hide="phone,tablet">ID </th>
                                         <th data-hide="phone,tablet">DEPARTMAN KODU</th>
                                         <th data-hide="phone,tablet">DEPARTMAN ADI</th>
                                         <th data-hide="phone,tablet">ÜST DEPARTMAN KODU</th>
                                         <th data-hide="phone,tablet">DEPARTMAN YÖNETİCİ</th>
                                         <th data-hide="phone,tablet">DÜZENLE</th>
                    </tr>
                    </thead>
                          <tbody>
                                    <%for (int i = 0; i < verisay; i++)
                                        { %>
                                    <% if( departmankodus [i] !="" && departmankodus [i] !=null  ){ %>
                                      <tr class="gradeX">

                                     <td><%=idm [i]%>  </td>
                                     <td><%=departmankodus [i]%>  </td>
                                     <td><%=departmanadis [i]%>  </td>
                                      <td><%=ustdepartmankodus [i] %>  </td>
                                      <td><%=departmanyoneticis [i] %>  </td>
                                                                               <td><a type="button" class="btn btn-primary" href="departman_tanimi_ekle.aspx?uyeid=<%=idm[i] %>" >
                                DÜZENLE
                            </a>
                                            
                                        </td>
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
