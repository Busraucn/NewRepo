               <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kullanici_giris.aspx.cs" Inherits="WMSDATA.kullanici_giris" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
 <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>WMSDATA | Kullanıcı Girişi</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
</head>
<body> 
     <form id="form1" runat="server">
        <div>
              <br />
            <br />  
   <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <div>
               <h1 class="Logo-name"></h1>
            </div>
            <h3>WMSDATA</h3>    
            <p>
            </p>
            <p>Email ve şifreniz ile giriş yapın.</p>
            
            <div class="alert alert-danger" id="uyari" runat ="server" visible ="false"  >
              <%=uyaritext  %>         <a class="alert-link" ></a>
            </div>
                <div class="form-group">
                    <input type="email" runat ="server" id="email" class="form-control" placeholder="email" required="">
                </div>
                <div class="form-group">
                    <input type="password" runat ="server" id="sifre" class="form-control" placeholder="şifre" required="">
                </div>
                <button type="submit" id="giris" runat ="server" onserverclick ="giris_ServerClick"  class="btn btn-primary block full-width m-b">Giriş</button>
                                 <div class="form-group">
                    <input visible="false"  runat ="server" id="tckimlikno" class="form-control" placeholder="Tc Kimlik No.." required="">
                </div>
                <a href="#" runat ="server" onserverclick ="Unnamed_ServerClick2"  ><small>Şifremi unuttum ?</small></a>
                <a href="#" runat ="server" visible="false" id="sifreyenile" onserverclick ="Unnamed_ServerClick"  ><small>Şifrem Yenile</small></a>
                <p class="text-muted text-center"><small></small></p>
             <div class="g-recaptcha" data-sitekey="6LdctJ4dAAAAAKwLcZRdt2HfU4t3WHV1rbcf0s-Y"></div>         
            <p class="m-t"> <small>
                            </small> </p>
        </div>
    </div>
    <!-- Mainly scripts -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.js"></script>
        </div>
   </form>
</body>
</html>