<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="avatarsec.aspx.cs" Inherits="WMSDATA.avatarsec" %>

<!DOCTYPE html>

<<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>INSPINIA | 404 Error</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">

</head>
<body>
   <form id="form1" runat="server">
        <br />
        <br />
       <div class="middle-box text-center lockscreen animated fadeInDown">

           
            <h3><%=WMSDATA .avatarsec .kullanisim  %>  <%=WMSDATA .avatarsec .kullansoyisim  %></h3>
            <p>LÜTFEN AVATARINIZI SEÇİN</p>

           </div>

           <div class="row">
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
              &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
              &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
             &nbsp &nbsp &nbsp &nbsp &nbsp
           
                  
         <div class="col-lg-2">
                <div class="contact-box">
                    <a class="row" runat ="server" onserverclick ="Unnamed_ServerClick"  >
                    <div class="col-500">
                        <div class="text-center">
                            <img alt="image" runat ="server"  class="rounded-circle m-t-xs img-fluid" src="kullanici/k3.png">
                            <div class="m-t-xs font-bold"></div>
                        </div>
                    </div>
                   
                        </a>
                </div>
            </div>
        &nbsp &nbsp  &nbsp &nbsp
         <div class="col-lg-2">
                <div class="contact-box">
                    <a class="row" runat ="server" onserverclick ="Unnamed_ServerClick1"   >
                    <div class="col-500">
                        <div class="text-center">
                            <img alt="image" class="rounded-circle m-t-xs img-fluid" src="kullanici/e2.png">
                            <div class="m-t-xs font-bold"></div>
                        </div>
                    </div>
                       
                        </a>
                </div>
            </div>


             </div>
  
  
      


    <!-- Mainly scripts -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.js"></script>
    </form>
</body>
</html>
