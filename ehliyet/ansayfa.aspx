<%@ Page Title="" Language="C#" MasterPageFile="~/Anasablon.Master" AutoEventWireup="true" CodeBehind="ansayfa.aspx.cs" Inherits="WMSDATA.ansayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- c3 Charts -->
    <link href="css/plugins/c3/c3.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <form id="form1" runat="server">

        
     <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-9">
                    <h2> <strong > ANASAYFA  </strong> </h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="ansayfa.aspx"></a>
                        </li>
          
                    </ol>
                </div>
            </div>




        <div class="wrapper wrapper-content animated fadeInRight">
            
        <div class="row">
          <div class="col-lg-3">
                <div class="widget style1 red-bg">
                    <div class="row">
                        <div class="col-4">
                            <i class="fa fa-file-pdf-o fa-5x"></i>
                        </div>
                        <div class="col-8 text-right">
                            <span> TOPLAM PROJE </span>
                            <h2 class="font-bold"><%=sirket_toplambasvuru %></h2>
                        </div>
                    </div>
                </div>
            </div>

            
            <div class="col-lg-3">
                <div class="widget style1 navy-bg">
                    <div class="row">
                        <div class="col-4">
                            <i class="fa fa-users fa-5x"></i>
                        </div>
                        <div class="col-8 text-right">
                            <span> TOPLAM OLAY </span>
                            <h2 class="font-bold"><%=uye_toplamkisi %></h2>
                        </div>
                    </div>
                </div>
            </div>
              <div class="col-lg-3">
                <div class="widget style1 yellow-bg">
                    <div class="row">
                        <div class="col-4">
                            <i class="fa fa-user fa-5x"></i>
                        </div>
                        <div class="col-8 text-right">
                            <span> TOPLAM PERSONEL </span>
                            <h2 class="font-bold"><%=veri_toplam_personel %></h2>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="widget style1 lazur-bg">
                    <div class="row">
                        <div class="col-4">
                            <i class="fa fa-calendar-check-o fa-5x"></i>
                        </div>
                        <div class="col-8 text-right">
                            <span> <%=DateTime.Now.ToString ().Substring (0,10)     %> </span>
                            <h2 class="font-bold"> <span> <%=DateTime.Today.DayOfWeek   %> </span></h2>
                        </div>
                    </div>
                </div>
            </div>          
        </div>                  
            <div class="row">
                <div class="col-lg-3">
                    <div class="ibox ">
                        <div class="ibox-title">
                            <h5>PERSONEL GRAFİĞİ</h5>
                             
                        </div>
                        <div class="ibox-content">
                            <div>                             
                                <div id="pie"></div>
                               <strong> <small class ="text-lg-right " >Veri1: Gelen</small></strong>  &nbsp &nbsp &nbsp   
                                   <small class ="text-lg-right " > Veri2: Gelmeyen     </small> 
                            </div>
                        </div>
                         </div></div>
                  <div class="col-lg-9">
                    <div class="ibox ">
                        <div class="ibox-title">
                            <h5> OLAY TAKİP GRAFİĞİ SON 6 AY</h5>
                             
                        </div>
                        <div class="ibox-content">
                            <div>
                                <div id="stocked"></div>
                                <strong> <small class ="text-lg-right " >Veri1: Tamamlanan</small></strong>  &nbsp &nbsp &nbsp   
                                   <small class ="text-lg-right " > Veri2: Devam Eden     </small> 
                            </div>
                        </div>
                    </div>
 </div>
</div>



              <div class="row">
                      
                   <div class="col-lg-3">
                <div class="ibox ">
                    <div class="ibox-title">
                        
                        <h5><%=WMSDATA .ansayfa .sirketadi %></h5>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-4">
                                <small class="stats-label">FİRMANIZA AİT   </small>
                                <h4></h4>
                            </div>

                            <div class="col-4">
                                <small class="stats-label"> TOPLAM KULLANICI </small>
                                
                            </div>
                            <div class="col-4">
                                <strong class="stats-label"><%=sirket_toplamkullanici %></strong>
                                <h4></h4>
                            </div>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-4">
                                <small class="stats-label">FİRMANIZA AİT </small>
                                
                            </div>

                            <div class="col-4">
                                <small class="stats-label">TOPLAM   ÇALIŞAN</small>
                                
                            </div>
                            <div class="col-4">
                                <strong class="stats-label"><%=sirket_toplambasvuru %></strong>
                                
                            </div>
                        </div>
                    </div>
                   
                </div>
            </div>

                     <div class="col-lg-4">
                <div class="contact-box center-version">

                    <a href="#">
                        <%if (avatarid == 1)
                            { %>
                         <img alt="image" runat ="server"  class="rounded-circle m-t-xs img-fluid" src="kullanici/k3_buyuk.png">
                       

                        <%} %>
                           <%if (avatarid == 2)
                            { %>
                           <img alt="image" class="rounded-circle m-t-xs img-fluid" src="kullanici/e2_buyuk.png">

                        <%} %>
                        <h3 class="m-b-xs"><strong  style="text-transform:uppercase" ><label>ID'niz: </label> <%= ViewState["key"]%>   <%=WMSDATA.ansayfa.kullanisim  %>   <%=WMSDATA.ansayfa.kullansoyisim  %></strong></h3>

                        <div class="font-bold"  style="text-transform:uppercase" ><%=WMSDATA.ansayfa.sirketadi  %></div>
                                                                                    <div class="form-group">
                                                               <asp:Image ID="qrimage" Width="100" Height="100" runat="server" />
                                                           </div>   

                    </a>
                    <div class="contact-box-footer">
                        <div class="m-t-xs btn-group">
                          
                           
                            <div > 
                             <button type="button" class="btn btn-outline-warning" data-toggle="modal" data-target="#myModal2">
                                EMAİL
                            </button>
                            <div class="modal inmodal" id="myModal2" tabindex="-1" role="dialog" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content animated flipInY">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <h4 class="modal-title">EMAİLİNİZİ GÜNCELLEYİN</h4>
                                            <small class="font-bold">Lütfen Yeni Emailinizi Girin.</small>
                                        </div>
                                        <div class="modal-body">
                                             <div class="dd-handle" ><label>EMAİL: </label>


                                            <input type="email" id="yeniemail" runat ="server" name="product_name" style="text-transform:uppercase" required=""  placeholder=" Email.." ></div>


                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-white" data-dismiss="modal">İPTAL</button>
                                            <button type="button" id="emaildegis" runat ="server" onserverclick ="emaildegis_ServerClick"   class="btn btn-primary">GÜNCELLE</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                             </div>
                             &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp 
                             <div> 
                             <button type="button" class="btn btn-outline-warning" data-toggle="modal" data-target="#myModal3">
                                ŞİFRE
                            </button>
                            <div class="modal inmodal" id="myModal3" tabindex="-1" role="dialog" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content animated flipInY">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <h4 class="modal-title">ŞİFRENİZİ GÜNCELLEYİN </h4>
                                            <small class="font-bold"></small>
                                        </div>
                                        <div class="modal-body">
                     <div class="animated fadeIn">
      <div class="alert alert-danger text-center" runat ="server"  id="uyari2"  role="alert">
                                       <%=uyari_yanlis  %>
                                    </div></div>
                                            <br />

                                            <div class="dd-handle" ><label>ESKİ ŞİFRENİZ : </label>
                                                    <input type="password" id="eskisifre" runat ="server" name="product_name" style="text-transform:uppercase"  required="" placeholder=" Şifre.." ></div>

                                                <div class="dd-handle" ><label>YENİ ŞİFRENİZ : </label>
                                                    <input type="password" id="yenisifre" runat ="server" name="product_name" style="text-transform:uppercase" required=""  placeholder=" Şifre.." ></div>

                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-white" data-dismiss="modal">İPTAL</button>
                                            <button type="button" id="sifredegis" runat ="server" onserverclick ="sifredegis_ServerClick"  class="btn btn-primary">GÜNCELLE</button>
                                        </div>
                                    </div>
                                </div>
                            </div> 
                            </div>
                        </div>
                    </div>

                </div>
            </div>
                        <div class="col-lg-5">
                                <div class="ibox ">
                                    <div class="ibox-title">
                                        <h5> NOT EDİN VE LİSTELEYİN</h5>
                                        <div class="ibox-tools">
                                            <a class="collapse-link">
                                                <i class="fa fa-chevron-up"></i>
                                            </a>
                                            <a class="close-link">
                                                <i class="fa fa-times"></i>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="ibox-content">
                                        <ul class="todo-list m-t small-list">
                                             <li>
                                                      
                                                <span class="b-r-lg"> <input type="text" id="metin" runat ="server" name="product_name" style="text-transform:uppercase"  placeholder=" Listeye Ekle.." ></span>
                                                 
                                                            <a href="#" class="btn btn-primary dim " type ="button" id="yapilacak" runat ="server" onserverclick ="yapilacak_ServerClick" ><i class="fa fa-check"></i> </a>
                                                
                                            </li>
                                            <%if (yapilacak_say > 0  ){ %>
                                            <li>
                                                 <span class="m-l-xs "><%=neyapilacak[0] %></span>
                                                <a href="#" id="degis1" runat ="server" onserverclick ="degis1_ServerClick" class="fa fa-check  float-right"> </a>
                                            </li>
                                            <%} %>
                                              <%   if (yapilacak_say > 1){ %>
                                            <li>
                                                 <span class="m-l-xs"><%=neyapilacak[1] %></span>
                                                <a href="#" runat ="server" id="degis2" onserverclick ="degis2_ServerClick"  class="fa fa-check  float-right"> </a>
                                               

                                            </li>
                                            <%} %>
                                               <%  if (yapilacak_say > 2) {%>
                                            <li>
                                                 <span class="m-l-xs"><%=neyapilacak[2] %></span>
                                                <a href="#" runat ="server" id="degis3" onserverclick ="degis3_ServerClick"   class="fa fa-check  float-right"> </a>
                                               
                                               
                                            </li>
                                            <%} %>
                                               <% if (yapilacak_say > 3){ %>
                                            <li>
                                                 <span class="m-l-xs"><%=neyapilacak[3] %></span>
                                                <a href="#" runat ="server" id="degis4" onserverclick ="degis4_ServerClick"   class="fa fa-check  float-right"> </a>
                                               
                                            </li>
                                            <%} %>
                                               <%if (yapilacak_say > 4){ %>
                                            <li>
                                                 <span class="m-l-xs "><%=neyapilacak[4] %></span>
                                                <a href="#" runat ="server" id="degis5" onserverclick ="degis5_ServerClick"   class="fa fa-check  float-right"> </a>
                                               
                                            </li>
                                            <%} %>
                                               <%if (yapilacak_say > 5){ %>
                                            <li>
                                                 <span class="m-l-xs"><%=neyapilacak[5] %></span>
                                                <a href="#" runat ="server"  id="degis6" onserverclick ="degis6_ServerClick"  class="fa fa-check right  float-right"> </a>
                                               
                                            </li>
                                            <%} %>
                                               <%if (yapilacak_say > 6){ %>
                                            <li>
                                                 <span class="m-l-xs"><%=neyapilacak[6] %></span>
                                                <a href="#" runat ="server" id="degis7" onserverclick ="degis7_ServerClick"   class="fa fa-check  float-right"> </a>
                                            </li>
                                            <%} %>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                  </div>
      </div>
   
          <!-- Mainly scripts -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

    <!-- Custom and plugin javascript -->
    <script src="js/inspinia.js"></script>
    <script src="js/plugins/pace/pace.min.js"></script>

          <!-- Flot -->
    <script src="js/plugins/flot/jquery.flot.js"></script>
    <script src="js/plugins/flot/jquery.flot.tooltip.min.js"></script>
    <script src="js/plugins/flot/jquery.flot.spline.js"></script>
    <script src="js/plugins/flot/jquery.flot.resize.js"></script>
    <script src="js/plugins/flot/jquery.flot.pie.js"></script>

    <!-- Peity -->
    <script src="js/plugins/peity/jquery.peity.min.js"></script>
    <script src="js/demo/peity-demo.js"></script>


        
    <!-- Custom and plugin javascript -->
    <script src="js/inspinia.js"></script>
    <script src="js/plugins/pace/pace.min.js"></script>

    <!-- jQuery UI -->
    <script src="js/plugins/jquery-ui/jquery-ui.min.js"></script>

    <!-- GITTER -->
    <script src="js/plugins/gritter/jquery.gritter.min.js"></script>

    <!-- Sparkline -->
    <script src="js/plugins/sparkline/jquery.sparkline.min.js"></script>

    <!-- Sparkline demo data  -->
    <script src="js/demo/sparkline-demo.js"></script>

    <!-- ChartJS-->
    <script src="js/plugins/chartJs/Chart.min.js"></script>

    <!-- Toastr -->
    <script src="js/plugins/toastr/toastr.min.js"></script>


    <script>
        $(document).ready(function () {
      


            var data1 = [
                [0, 4], [1, 8], [2, 5], [3, 10], [4, 4], [5, 16], [6, 5], [7, 11], [8, 6], [9, 11], [10, 30], [11, 10], [12, 13], [13, 4], [14, 3], [15, 3], [16, 6]
            ];
            var data2 = [
                [0, 1], [1, 0], [2, 2], [3, 0], [4, 1], [5, 3], [6, 1], [7, 5], [8, 2], [9, 3], [10, 2], [11, 1], [12, 0], [13, 2], [14, 8], [15, 0], [16, 0]
            ];
            $("#flot-dashboard-chart").length && $.plot($("#flot-dashboard-chart"), [
                data1, data2
            ],
                {
                    series: {
                        lines: {
                            show: false,
                            fill: true
                        },
                        splines: {
                            show: true,
                            tension: 0.4,
                            lineWidth: 1,
                            fill: 0.4
                        },
                        points: {
                            radius: 0,
                            show: true
                        },
                        shadowSize: 2
                    },
                    grid: {
                        hoverable: true,
                        clickable: true,
                        tickColor: "#d5d5d5",
                        borderWidth: 1,
                        color: '#d5d5d5'
                    },
                    colors: ["#1ab394", "#1C84C6"],
                    xaxis: {
                    },
                    yaxis: {
                        ticks: 4
                    },
                    tooltip: false
                }
            );

            var doughnutData = {
                labels: ["App", "Software", "Laptop"],
                datasets: [{
                    data: [300, 50, 100],
                    backgroundColor: ["#a3e1d4", "#dedede", "#9CC3DA"]
                }]
            };


            var doughnutOptions = {
                responsive: false,
                legend: {
                    display: false
                }
            };


            var ctx4 = document.getElementById("doughnutChart").getContext("2d");
            new Chart(ctx4, { type: 'doughnut', data: doughnutData, options: doughnutOptions });

            var doughnutData = {
                labels: ["App", "Software", "Laptop"],
                datasets: [{
                    data: [70, 27, 85],
                    backgroundColor: ["#a3e1d4", "#dedede", "#9CC3DA"]
                }]
            };


            var doughnutOptions = {
                responsive: false,
                legend: {
                    display: false
                }
            };


            var ctx4 = document.getElementById("doughnutChart2").getContext("2d");
            new Chart(ctx4, { type: 'doughnut', data: doughnutData, options: doughnutOptions });

        });
    </script>


    <!-- ChartJS-->
    <script src="js/plugins/chartJs/Chart.min.js"></script>
    <script src="js/demo/chartjs-demo.js"></script>

          <!-- d3 and c3 charts -->
    <script src="js/plugins/d3/d3.min.js"></script>
    <script src="js/plugins/c3/c3.min.js"></script>

    <script>

        $(document).ready(function () {

            c3.generate({
                bindto: '#lineChart',
                data: {
                    columns: [
                        ['data1', 30, 200, 100, 400, 150, 250],
                        ['data2', 50, 20, 10, 40, 15, 25]
                    ],
                    colors: {
                        data1: '#1ab394',
                        data2: '#BABABA'
                    }
                }
            });

            c3.generate({
                bindto: '#slineChart',
                data: {
                    columns: [
                        ['data1', 30, 200, 100, 400, 150, 250],
                        ['data2', 130, 100, 140, 200, 150, 50]
                    ],
                    colors: {
                        data1: '#1ab394',
                        data2: '#BABABA'
                    },
                    type: 'spline'
                }
            });

            c3.generate({
                bindto: '#scatter',
                data: {
                    xs: {
                        data1: 'data1_x',
                        data2: 'data2_x'
                    },
                    columns: [
                        ["data1_x", 3.2, 3.2, 3.1, 2.3, 2.8, 2.8, 3.3, 2.4, 2.9, 2.7, 2.0, 3.0, 2.2, 2.9, 2.9, 3.1, 3.0, 2.7, 2.2, 2.5, 3.2, 2.8, 2.5, 2.8, 2.9, 3.0, 2.8, 3.0, 2.9, 2.6, 2.4, 2.4, 2.7, 2.7, 3.0, 3.4, 3.1, 2.3, 3.0, 2.5, 2.6, 3.0, 2.6, 2.3, 2.7, 3.0, 2.9, 2.9, 2.5, 2.8],
                        ["data2_x", 3.3, 2.7, 3.0, 2.9, 3.0, 3.0, 2.5, 2.9, 2.5, 3.6, 3.2, 2.7, 3.0, 2.5, 2.8, 3.2, 3.0, 3.8, 2.6, 2.2, 3.2, 2.8, 2.8, 2.7, 3.3, 3.2, 2.8, 3.0, 2.8, 3.0, 2.8, 3.8, 2.8, 2.8, 2.6, 3.0, 3.4, 3.1, 3.0, 3.1, 3.1, 3.1, 2.7, 3.2, 3.3, 3.0, 2.5, 3.0, 3.4, 3.0],
                        ["data1", 1.4, 1.5, 1.5, 1.3, 1.5, 1.3, 1.6, 1.0, 1.3, 1.4, 1.0, 1.5, 1.0, 1.4, 1.3, 1.4, 1.5, 1.0, 1.5, 1.1, 1.8, 1.3, 1.5, 1.2, 1.3, 1.4, 1.4, 1.7, 1.5, 1.0, 1.1, 1.0, 1.2, 1.6, 1.5, 1.6, 1.5, 1.3, 1.3, 1.3, 1.2, 1.4, 1.2, 1.0, 1.3, 1.2, 1.3, 1.3, 1.1, 1.3],
                        ["data2", 2.5, 1.9, 2.1, 1.8, 2.2, 2.1, 1.7, 1.8, 1.8, 2.5, 2.0, 1.9, 2.1, 2.0, 2.4, 2.3, 1.8, 2.2, 2.3, 1.5, 2.3, 2.0, 2.0, 1.8, 2.1, 1.8, 1.8, 1.8, 2.1, 1.6, 1.9, 2.0, 2.2, 1.5, 1.4, 2.3, 2.4, 1.8, 1.8, 2.1, 2.4, 2.3, 1.9, 2.3, 2.5, 2.3, 1.9, 2.0, 2.3, 1.8]
                    ],
                    colors: {
                        data1: '#1ab394',
                        data2: '#BABABA'
                    },
                    type: 'scatter'
                }
            });

            c3.generate({
                bindto: '#stocked',
                data: {
                    columns: [
                        ['data1', <%=g6%>,  <%=g5%>,  <%=g4%>,  <%=g3%>,  <%=g2%>,  <%=g1%>],
                        ['data2', <%=g6_2%>, <%=g5_2%>, <%=g4_2%>, <%=g3_2%>, <%=g2_2%>, <%=g1_2%>]
                    ],
                    colors: {
                        data1: '#B0C4DE',
                        data2: '#E6E6FA'
                    },
                    type: 'bar',
                    groups: [
                        ['data1', 'data2']
                    ]
                }
            });

            c3.generate({
                bindto: '#gauge',
                data: {
                    columns: [
                        ['data', 91.4]
                    ],

                    type: 'gauge'
                },
                color: {
                    pattern: ['#1ab394', '#BABABA']

                }
            });

            c3.generate({
                bindto: '#pie',
                data: {
                    columns: [
                        ['data1', <%=veri_odenen %>],
                        ['data2', <%=veri_odenmeyen %>]
                    ],
                    colors: {
                        data1: '#1ab394',
                        data2: '#BABABA'
                    },
                    type: 'pie'
                }
            });

        });

    </script>

  
     
    </form>

</asp:Content>
