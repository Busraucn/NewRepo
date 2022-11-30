<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ilkGiris.aspx.cs" Inherits="WMSDATA.ilkGiris" %>

<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>INSPINIA | 404 Error</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">

</head>

<body class="gray-bg">
    <form id="form1" runat="server">
        <br />
        <br />
           <div class="animated fadeIn">
      <div class="alert alert-danger text-center" runat ="server"  id="yanlis_uyari"  role="alert">
                                       <%=uyari_yanlis  %>
                                    </div></div>
    <div class="middle-box text-center lockscreen animated fadeInDown">

           
            <h3><%=WMSDATA .kullanici_giris .kullaniciİsim  %>  <%=WMSDATA .kullanici_giris .kullaniciSoyisim  %></h3>
            <p>LÜTFEN ŞİFRENİZİ BELİRLEYİN</p>
            
                <div class="form-group">
                    <input type="password" class="form-control" id="ilksifre" runat ="server"  placeholder="******" required="">
                </div>
                        <div class="form-group">
                    <input type="password" class="form-control" id="ilksifre2" runat ="server"  placeholder="******" required="">
                </div>
                <button type="submit" id="sifrekaydet" runat ="server" onserverclick ="sifrekaydet_ServerClick"  class="btn btn-primary block full-width">KAYDET</button>
            
        </div>
  
     


    <!-- Mainly scripts -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.js"></script>
    </form>
</body>
</html>
