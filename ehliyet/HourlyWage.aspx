<%@ Page Title="" Language="C#" MasterPageFile="~/Anasablon.Master" AutoEventWireup="true" CodeBehind="HourlyWage.aspx.cs" Inherits="WMSDATA.HourlyWage" %>

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
                            <h5> Personel Ödeme Bilgisi Oluştur<small></small></h5>
                            <div class="ibox-tools">

                              

                                <button type="button" class="btn btn-outline-warning" data-toggle="modal" data-target="#myModal2">
                                    Personel Ödeme Bilgisi Oluştur
                                </button>
                                <div class="modal inmodal" id="myModal2" tabindex="-1" role="dialog" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content animated flipInY">
                                            <div class="modal-header">
                                                 <h4 class="modal-title">Personel Ödeme Bilgisi</h4>
                                                <small class="font-bold">İstediğiniz personel için ödeme bilgisi oluşturun.</small>
                                            </div>
                                            <div class="modal-body">


                                <div class="form-group"><fieldset>
                                    <div class="col-sm-12" style="text-align: left">
                                                        Personel: 
                                  
                                        <asp:DropDownList ID="personel" runat="server" AutoPostBack="false" Style="text-transform: uppercase" class="select2_demo_3 form-control col-sm-6" required="">
                                        </asp:DropDownList>
                                    
                                </div></fieldset></div>

                                <div class="form-group">
                                    <div class="col-sm-12" style="text-align: left">
                                    Çalışma saati Tanımı
                                    <asp:DropDownList ID="calismaSaatiTanim" runat="server" AutoPostBack="false" Style="text-transform: uppercase" class="select2_demo_3 form-control col-sm-6" required="">
                                    </asp:DropDownList>
                                </div></div>
                                <div class="form-group">
                                    <fieldset>
                                        <div class="col-sm-12" style="text-align: left">Ödeme Durumu :
                                        &nbsp 
                                        <select id="onay" name="onay" runat="server">
                                            <option value=""></option>
                                            <option value="true">ÖDENDİ</option>
                                            <option value="false">ÖDENMEDİ</option>
                                        </select>
                                             </div>
                                    </fieldset>
                                </div>
                            
                                <div class="form-group">
                                     <div class="col-sm-12" style="text-align: left">Tarihler için uygula :
                                    <input class="form-control" runat="server" ClientIDMode="Static" type="text" name="daterange" id="daterange" value="01/01/2022 - 01/31/2023" />
                                </div></div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">KAPAT</button>
                                                     <button class="btn btn-primary" id="personelCalismaKaydet" runat="server" onserverclick="personelCalismaKaydet_ServerClick">
                                    <i class="fa fa-check"></i>KAYDET
                                </button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <button class="btn btn-outline-info" id="Button4" runat="server" data-toggle="modal" data-target="#myModal3">
                                    <i class="fa fa-fire"></i>ÇALIŞMA SAATİ TANIMLA
                                </button>
                                <div class="modal inmodal" id="myModal3" tabindex="-1" role="dialog" aria-hidden="true">
                                    <div class="modal-dialog modal-lg" >
                                        <div class="modal-content animated flipInY">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                                <h4 class="modal-title">ÇALIŞMA SAATİ TANIMLA</h4>
                                                <small class="font-bold">ÇALIŞMA SAATİ TANIMLA</small>
                                            </div>
                                            <div class="modal-body">


                                                <div class="dd-handle">
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">BAŞLAMA SAATİ:
                                                            <div class="input-group clockpicker" data-autoclose="true">
                                <input type="time" id="baslamaS" runat="server" name="input-a" class="form-control" value="09:30" >
                               
                            </div> </div>  
                                                    </div>
                                                </div>
                                               
                                                <div class="dd-handle">
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">BİTİŞ SAATİ:
                                                           <div class="input-group clockpicker" data-autoclose="true">
                                <input type="time" id="bitisS" runat="server"  class="form-control" value="09:30" >
                               
                            </div>     </div>
                                                    </div>
                                                </div>
                                                   <div class="dd-handle">
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">GEÇ KALMA TOLERANSI:
                                                           <div class="input-group clockpicker" data-autoclose="true">
                                <input type="time" id="lateness" runat="server"  class="form-control" value="00:10" >
                               
                            </div>     </div>
                                                    </div>
                                                </div>
                                                <div class="dd-handle">
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">AÇIKLAMA :
                                                            <input id="description" runat="server" type="text" required="" class="form-control">
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="dd-handle">
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">Yevmiye :
                                                   <input id="yevmiye" type="number" min="0.50" max="10.00" step="0.50" runat="server"  required="" class="form-control">
                                               
                                                        </div>
                                                    </div>
                                                </div>

                                               
                                                <div class="dd-handle">
                                                 <div class="form-group">
                                      <div class="col-sm-12" style="text-align: left">Tarihleri için uygula :
                                    <input class="form-control" runat="server" ClientIDMode="Static" type="text" name="daterangemodal1" id="daterangemodal1" value="01/01/2022 - 01/31/2023" />
                                </div>  </div></div>
                                                
                                                  
                                                                <div class="ibox-content">
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <div class="table-responsive" style="font-size: 16">
                            <table class="table table-striped table-bordered table-hover dataTables-example" aria-sort="ascending" dir="ltr">
                                <thead>
                                    <tr>
                                        <th>SEÇ</th>

                                        <th data-hide="phone,tablet">BAŞLAMA SAATİ</th>
                                        <th data-hide="phone,tablet">BİTİŞ SAATİ</th>
                                        <th data-hide="phone,tablet">AÇIKLAMA</th>
                                        <th data-hide="phone,tablet">ÜCRET</th>
                                        <th data-hide="phone,tablet">BAŞLANGIÇ </th>
                                        <th data-hide="phone,tablet">GEÇERLİLİK BAŞLANGIÇ TARİHİ</th>
                                        <th data-hide="phone,tablet">GEÇERLİLİK BİTİŞ TARİHİ</th>

                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                                <tfoot>
                                </tfoot>
                            </table>
                        </div>

                                                 </div>
              


                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">KAPAT</button>
                                                    <button type="button" id="tanimKaydet" runat="server" onserverclick="tanimKaydet_ServerClick" class="btn btn-primary">KAYDET</button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <button class="btn btn-outline-info" id="yevmiyeTanimla" runat="server" data-toggle="modal" data-target="#myModal4">
                                    <i class="fa fa-fire"></i>Yevmiye Tanımla
                                </button>
                                <div class="modal inmodal" id="myModal4" tabindex="-1" role="dialog" aria-hidden="true">
                                    <div class="modal-dialog modal-lg" >
                                        <div class="modal-content animated flipInY">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                                <h4 class="modal-title">Yevmiye Tanımla</h4>
                                                <small class="font-bold">Yevmiye Tanımla</small>
                                            </div>
                                            <div class="modal-body">
                                                <div class="form-group"><fieldset>
                                    <div class="col-sm-12" style="text-align: left">
                                                        Personel: 
                                  
                                        <asp:DropDownList ID="yevmiyePersonel" runat="server" AutoPostBack="false" Style="text-transform: uppercase" class="select2_demo_3 form-control col-sm-6" required="">
                                        </asp:DropDownList>
                                    
                                </div></fieldset></div>

                                                 <div class="dd-handle">
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">Yevmiye bedeli :
                                                   <input id="price" type="money"  runat="server"  required="" class="form-control">
                                               
                                                        </div>
                                                    </div>
                                                </div>

                                               

                                               
                                                <div class="dd-handle">
                                                 <div class="form-group">
                                      <div class="col-sm-12" style="text-align: left">Başlangıç Tarihi :
                                    <input class="form-control" runat="server" ClientIDMode="Static" type="date" name="daterangemodal1" id="bdate" value="01/01/2023"  />
                                </div>  </div></div>
                                                
                                                  
                                                   

                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-white" data-dismiss="modal">KAPAT</button>
                                                    <button type="button" id="yevmiyekaydet" runat="server" onserverclick="yevmiyekaydet_ServerClick"  class="btn btn-primary">KAYDET</button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <button class="btn btn-danger close-link">
                                    <i class="fa fa-times"></i>KAPAT
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
                            <div class="col-sm-6 2-r">
                                <h3 class="m-t-none m-b"></h3>
                                
                                 <h4 class="modal-title">ÖDEME HESAPLA</h4>
                                                <small class="font-bold">İstediğiniz tarihler için hesaplama yapın</small>
                                   <div class="dd-handle">
                                                    <div class="col-sm-12" style="text-align: left">
                                                        Personel: 
                                      <asp:DropDownList ID="personelmodal" runat="server" Style="text-transform: uppercase" class="select2_demo_3 form-control col-sm-6" required="">
                                      </asp:DropDownList>
                                                    </div>
                                                </div>
                                              
                                                   <div class="dd-handle">
                                                 <div class="form-group">
                                      <div class="col-sm-12" style="text-align: left">Tarihleri için hesapla :
                                    <input class="form-control" runat="server" ClientIDMode="Static" type="text" name="daterangemodal2" id="daterangemodal2" value="01/01/2022 - 01/31/2023" />
                                </div>  </div></div>
                                                <div class="dd-handle">
                                                    <div class="form-group">
                                                        <div class="col-sm-12" style="text-align: left">Toplam:
                                                            <input id="Toplam" disabled runat="server" type="text" required="" class="form-control">
                                                        </div>
                                                    </div>
                                                </div>
                                   <button type="button" id="Button3" runat="server" onserverclick="Button1_ServerClick" class="btn btn-warning" >Hesapla</button>
                                             <button type="button" id="payall" runat="server" onserverclick="payall_ServerClick" class="btn btn-primary" >Hepsini Öde</button>
                              
                            </div>

                              <div class="col-sm-6 2-r">

                                             
                             </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

              <div class="col-lg-12 ">
                    <div class="tabs-container">
                        <ul class="nav nav-tabs" role="tablist">
                            <li><a class="nav-link active" data-toggle="tab" href="#tab-1"> Planlanan Çalışma Planı</a></li>
                            <li><a class="nav-link" data-toggle="tab" href="#tab-2">Gerçekleşen Çalışma Planı</a></li>
                        </ul>
                        <div class="tab-content">
                            <div role="tabpanel" id="tab-1" class="tab-pane active">
                                <div class=" panel-body">
                                   
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
                                             <%for (int i = 0; i < verisay; i++)
                                        { %>
                              
                          
                                <tr class="gradeX">
                     <td>  
                     </td>
                                       <td><%=Id                   [i]%>  </td>
                                      <td><%= Tc                    [i]%>  </td>
                                      <td><%= CalismaZamaniTanimId  [i]%>  </td>
                                      <td><%= OdemeBilgisi          [i] %>  </td>
                                      <td><%= CalismaGunu          [i]  %>  </td>
                                      
                             
                           <% } %>
                                </tbody>
                                <tfoot>
                                </tfoot>
                            </table>
                        </div>             </div>
                            </div>
                            <div role="tabpanel" id="tab-2" class="tab-pane">
                                <div class="panel-body">
                                   <div class="table-responsive" style="font-size: 16">
                            <table class="table table-striped table-bordered table-hover dataTables-example" aria-sort="ascending" dir="ltr">
                                <thead>
                                    <tr>
                                        <th>SEÇ</th>
                                          <th data-hide="phone,tablet">ID </th>
                                        <th data-hide="phone,tablet">TC </th>
                                        <th data-hide="phone,tablet">Ad</th>
                                        <th data-hide="phone,tablet">Soyad</th>
                                        <th data-hide="phone,tablet">Kart NO</th>
                                        <th data-hide="phone,tablet">Hareket Tipi</th>
                                        <th data-hide="phone,tablet">CalismaZamaniTanimId</th>
                                        <th data-hide="phone,tablet">OdemeBilgisi</th>
                                        <th data-hide="phone,tablet">CalismaGunu</th>

                                    </tr>
                                </thead>
                                <tbody>
                                             <%for (int i = 0; i < Gverisay; i++)
                                        { %>
                              
                          
                                <tr class="gradeX">
                     <td>  
                     </td>
                                       <td><%=GId                   [i]%>  </td>
                                      <td><%= GTc                    [i]%>  </td>
                                      <td><%= GAd  [i]%>  </td>
                                      <td><%= GSoyad         [i] %>  </td>
                                        <td><%= GKartNo                    [i]%>  </td>
                                      <td><%= GHareketTipi         [i]  %>  </td>
                                      <td><%= GCalismaZamaniTanimId  [i]%>  </td>
                                      <td><%= GOdemeBilgisi          [i] %>  </td>
                                      <td><%= GCalismaGunu          [i]  %>  </td>
                                     
                                      
                             
                           <% } %>
                                </tbody>
                                <tfoot>
                                </tfoot>
                            </table>
                        </div>        </div>
                            </div>
                        </div>


                    </div>
                </div>


     


    </form>
   
</asp:Content>
