<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- CSS  -->
    <link href="css/materialize.min.css" type="text/css" rel="stylesheet" media="screen,projection"/>
    <link href="css/style.css" type="text/css" rel="stylesheet" media="screen,projection"/>



     <!-- Responsive -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>AIR V4 - Login</title>
    <link rel="shortcut icon" href="./Images/favicon.ico" />
</head>
<body>
    <div class="container">
    <form id="form1" runat="server">
        <div>

        <div class="col s12 m7">
            <h4 class="header"></h4>
            <div class="card horizontal">
                <div class="card-image">
                <img src="./Images/logo_AIR.jpg" />
                </div>
            <div class="card-stacked">
                
                <div class="card-content">
                
                    
                    <div class="row">
      <div class="row">
        <div class="input-field col s12">
          <input id="NNI" runat="server" type="text" class="validate" />
          <label for="NNI">NNI</label>
        </div>
        
      </div>
      
      <div class="row">
        <div class="input-field col s12">
          <input id="password" runat="server" type="password" class="validate" />
          <label for="password">Mot de passe</label>
        </div>
      </div>
    
       <div class="row">
        <div class="input-field col s12">

            <asp:Button ID="connexion" runat="server" Text="CONNEXION" CssClass="waves-effect waves-light btn" OnClick="connexion_Click" />
            
      </div>
           </div>
  </div>
                
                </div>


                <div class="card-action">
                <asp:Label runat="server" ID="result" Visible="false" CssClass="red-text lighten-3"></asp:Label>
                </div>
                </div>
            </div>
        </div>



        </div>



    <script src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="js/materialize.js"></script>



    </form>
    </div>
</body>
</html>
