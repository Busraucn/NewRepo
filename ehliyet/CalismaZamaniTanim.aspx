<%@ Page Title="" Language="C#" MasterPageFile="~/Anasablon.Master" AutoEventWireup="true" CodeBehind="CalismaZamaniTanim.aspx.cs" Inherits="WMSDATA.CalismaZamaniTanim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="hourly_wage" runat="server">
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-lg-10">
                <h2>Personel Çalışma Saatleri ve Ücretleri Görüntüleme Ekranı</h2>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item">
                        <a href="ansayfa.aspx">Anasayfa</a>
                    </li>
                    <li class="breadcrumb-item">
                        <a>Personel Çalışma Saatleri ve Ücretleri Görüntüleme Ekranı</a>
                    </li>

                </ol>
            </div>
            <div class="col-lg-2">
            </div>
        </div>

        <br />
        <div class="animated fadeIn">
            <div class="alert alert-success text-center" runat="server" id="dogru_uyari" role="alert">
            </div>
        </div>
        <div class="animated fadeIn">
            <div class="alert alert-danger text-center" runat="server" id="yanlis_uyari" role="alert">
            </div>
        </div>
        <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-lg-12">
                    <div class="ibox ">
                        <div class="ibox-content">
                            <h5> <small></small></h5>
                            <div class="ibox-tools">

                                <a href="HourlyWage.aspx" class="btn btn-info" >Personel Çalışma Günü Oluştur </a>
                                  <button type="button" id="tanimKaydet" runat="server" onserverclick="tanimKaydet_ServerClick" class="btn btn-primary">KAYDET</button>
      
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
                            <div class="col-sm-6 2-r">
                                <h3 class="m-t-none m-b"></h3>
                                
                                  <h4 class="modal-title">ÇALIŞMA SAATİ TANIMLA</h4>
                                                <small class="font-bold">ÇALIŞMA SAATİ TANIMLA</small>
                                           
                                      
                                                
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">BAŞLAMA SAATİ:
                                                            <div class="input-group clockpicker" data-autoclose="true">
                                <input type="time" runat="server"  id="baslamaS" name="input-a" class="form-control" value="09:30" >
                                
                            </div>  
                                                    </div>
                                                </div>
                                                
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">BİTİŞ SAATİ:
                                                           <div class="input-group clockpicker" data-autoclose="true">
                                <input type="time" id="bitisS" runat="server"   class="form-control" value="09:30" >
                                
                            </div>     </div>
                                                    </div>
                                                
                                  <div class="dd-handle">
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">GEÇ KALMA TOLERANSI:
                                                           <div class="input-group clockpicker" data-autoclose="true">
                                <input type="time" id="lateness" runat="server"  class="form-control" value="00:10" >
                               
                            </div>     </div>
                                                    </div>
                                                </div>
                                               
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">AÇIKLAMA :
                                                            <input id="description" runat="server" type="text" required="" class="form-control">
                                                        </div>
                                                    </div>
                                                
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">Yevmiye :
                                                            <input id="yevmiye" type="number" min="0.50" max="10.00" step="0.50" runat="server"  required="" class="form-control">
                                                        </div>
                                                    </div>
                                                
                                                 <div class="form-group">
                                      <div class="col-sm-12" style="text-align: left">Tarihleri için uygula :
                                    <input class="form-control" runat="server" ClientIDMode="Static" type="text" name="daterangemodal1" id="daterangemodal1" value="01/01/2022 - 01/31/2023" />
                                </div>  </div></div>
                                                
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
                            <table class="table table-striped table-bordered table-hover dataTables-example" aria-sort="ascending" dir="ltr">
                                <thead>
                                    <tr>
                                        <th>SEÇ</th>
                                        <th data-hide="phone,tablet">ID </th>
                                        <th data-hide="phone,tablet">TC </th>
                                        <th data-hide="phone,tablet">CalismaZamaniTanimId</th>
                                        <th data-hide="phone,tablet">OdemeBilgisi</th>
                                        <th data-hide="phone,tablet">CalismaGunu</th>

                                    </tr>
                                </thead>
                                <tbody>

                           
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


    </form>
</asp:Content>
