<%@ Page Title="" Language="C#" MasterPageFile="~/Anasablon.Master" AutoEventWireup="true" CodeBehind="kullanici_sayfasi.aspx.cs" Inherits="WMSDATA.kullanici_sayfasi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <link href="css/plugins/select2/select2.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <form id="form1" runat="server">


          <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>KULLANICI EKLE</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="ansayfa.aspx">Anasayfa</a>
                        </li>
                       
                        <li class="breadcrumb-item active">
                            <strong>Kullanıcı Ekle</strong>
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




   

    <div class="wrapper wrapper-content animated fadeInRight align-content-center">
            <div class="row">
                 &nbsp &nbsp &nbsp 
                 &nbsp &nbsp &nbsp 
             
           <div class="col-lg-7">
                <div class="ibox ">
                    <div class="ibox-title">
                        <h5>KULLANICI KAYDET </h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                <i class="fa fa-wrench"></i>
                            </a>
                            <ul class="dropdown-menu dropdown-user">
                                <li><a href="#" class="dropdown-item">Config option 1</a>
                                </li>
                                <li><a href="#" class="dropdown-item">Config option 2</a>
                                </li>
                            </ul>
                            <a class="close-link">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-6 b-r"><h3 class="m-t-none m-b"></h3>
                                <p></p>
                               
                                    <div class="form-group"><label>TC NO : </label> <input type="text" id="tc" runat ="server"  placeholder="Tc No" class="form-control" required=""></div>
                                    <div class="form-group"><label>AD : </label> <input style="text-transform:uppercase" type="text" id="ad" runat ="server"  placeholder="Ad" class="form-control"  required=""></div>
                                 <div class="form-group"><label>SOYAD : </label> <input style="text-transform:uppercase" type="text" id="soyad" runat ="server" placeholder="Soyad" class="form-control" required=""></div>
                               <div class="form-group"><label id="gizle" runat ="server"  >DOĞUM TARİHİ : </label> <input style="text-transform:uppercase" type="date" id="dt" runat ="server" placeholder="01/01/1900" class="form-control" required=""></div>
                             <button  class="btn btn-primary" id="tcdogrula" onserverclick="tckimlikdogrula" runat ="server">  <i class="fa fa-check"> TC DOĞRULA</i>
                            </button>
                                   <br />
                                
                                
                            </div>
                            <div class="col-sm-6"><h4></h4>
                                <p></p>
                                <p class="text-center"> </p>
                                     <div class="form-group"><label>EMAİL : </label> <input type="email"  id="email" runat ="server" placeholder="Email" class="form-control"></div>
                                 <div class="form-group"><label>ŞİFRE : </label> <input style="text-transform:uppercase" disabled  type="text"  id="sifre" runat ="server" placeholder="İlk şifre:wmsdata" class="form-control"></div>
                              
                                 <div class="form-group"><label>ŞİRKET : </label> <div>  <select id="sirket" runat ="server" style="text-transform:uppercase"  class="select2_demo_3 form-control" required="">
                                       
                                    </select></div></div>
                                   <div >     <br /> <br />
                                <button class="btn btn-sm btn-primary float-right m-t-n-xs" id="kaydet" onserverclick="kaydet_ServerClick"  runat ="server"     type="submit"><strong>KAYDET</strong></button>
                                    </div>
                            </div>
                         


                        </div>
                    </div>
                </div>


               


            </div>
                &nbsp &nbsp &nbsp 
                &nbsp &nbsp &nbsp 
                     <div class="col-lg-4 m-b-lg">
                    <div id="vertical-timeline" class="vertical-container light-timeline no-margins">
                        <div class="vertical-timeline-block">
                            <div class="vertical-timeline-icon navy-bg">
                                <i class="fa fa-file-text"></i>
                            </div>

                            <div class="vertical-timeline-content">
                                <h2>BAŞVURU SAYFASI</h2>
                                <p>YENİ BAŞVURU İÇİN
                                </p>
                                <a href="belge_ekle.aspx" class="btn btn-sm btn-primary">BŞVURU EKLE</a>
                                    <span class="vertical-date">
                                        <br>
                                        <small><%=DateTime.Now.ToString ().Substring  (0,10)  %></small>
                                    </span>
                            </div>
                        </div>

                        <div class="vertical-timeline-block">
                            <div class="vertical-timeline-icon blue-bg">
                                <i class="fa fa-users"></i>
                            </div>

                            <div class="vertical-timeline-content">
                                <h2>KİŞİ SAYFASI</h2>
                                <p>YENİ KİŞİ EKLEMEK İÇİN</p>
                                <a href="uyeKayit.aspx" class="btn btn-sm btn-success"> KİŞİ EKLE </a>
                                    <span class="vertical-date">
                                         <br>
                                        <small><%=DateTime.Now.ToString ().Substring  (0,10)  %></small>
                                    </span>
                            </div>
                        </div>


                    
                    </div>

                </div>

                

                 </div></div>


          <div class="row">
               &nbsp &nbsp &nbsp
               &nbsp &nbsp &nbsp&nbsp
                <div class="col-lg-11">
                    <div class="ibox ">
                        <div class="ibox-title">
                            <h5>TÜM KULLANICILAR</h5>

                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu dropdown-user">
                                    <li><a href="#" class="dropdown-item">Config option 1</a>
                                    </li>
                                    <li><a href="#" class="dropdown-item">Config option 2</a>
                                    </li>
                                </ul>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <input type="text" class="form-control form-control-sm m-b-xs" id="filter"
                                   placeholder="ara..">

                            <table class="footable table table-stripped" data-page-size="20000" data-filter=#filter>
                                <thead>
                                <tr>
                                         <th>TC NO </th>
                                       <th>AD SOYAD </th>
                                    <th data-hide="phone,tablet">ŞİRKET</th>
                                    <th data-hide="phone,tablet">EMAİL</th>
                                    
                                   
                                    <th data-hide="phone,tablet">GÜNCELLE</th>
                                  
                                </tr>
                                </thead>
                                <tbody>

                                   <%for (int i = 0; i < verisay; i++)
                                       { %>
                                 <tr class="gradeX">
                                    <td><%=kullanici_tc[i] %></td>
                                    <td><%=kullanici_ad [i] %> -  <%=kullanici_soyad [i] %>
                                    </td>
                                       <td class="center"><%=kullanici_sirket[i]  %></td>
                                    <td><%=kullanici_email[i] %></td>
                                  
                                  
                                    <td><a type="button" class="btn btn-primary" href="kullanici_sayfasi.aspx?uyeid=<%=id[i] %>" >
                                DÜZENLE
                            </a>
                                            
                                        </td>
                                  
                                      
                                  

                                </tr>
                           <%} %>
                           
                                </tbody>
                                <tfoot>
                                <tr>
                                    <td colspan="10">
                                        <ul class="pagination float-right"></ul>
                                    </td>
                                </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>


    
    <!-- Custom and plugin javascript -->
    <script src="js/inspinia.js"></script>
    <script src="js/plugins/pace/pace.min.js"></script>
                    <!-- Mainly scripts -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
             <!-- Select2 -->
    <script src="js/plugins/select2/select2.full.min.js"></script>

    <!-- Page-Level Scripts -->
    <script>
        $(document).ready(function() {

            $('.footable').footable();
            $('.footable2').footable();

        });

        $(".select2_demo_1").select2();
        $(".select2_demo_2").select2();
        $(".select2_demo_3").select2({
            placeholder: "Select a state",
            allowClear: true
        });

        $(".touchspin1").TouchSpin({
            buttondown_class: 'btn btn-white',
            buttonup_class: 'btn btn-white'
        });

     

        $('.chosen-select').chosen({ width: "100%" });
    </script>
            

            </form> 



</asp:Content>
