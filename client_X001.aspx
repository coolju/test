<%@ Page Language="C#" AutoEventWireup="true" CodeFile="client_X001.aspx.cs" Inherits="client_X001" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AIR - Client</title>


     <!-- CSS  -->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="./css/materialize.css" type="text/css" rel="stylesheet" media="screen,projection"/>
    <link href="./css/style.css" type="text/css" rel="stylesheet" media="screen,projection"/>
  

    <!-- Responsive -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
       
        <header>
            <%
            Response.WriteFile("./include/nav.inc");
            %>
        </header>
<main>
            <blockquote>
        <h5>Détails client <asp:Label ID="client_id" runat="server"></asp:Label></h5>
        <div class="divider"></div>
    </blockquote>

            
    

       
    

    <div class="row">
        <div class="input-field col s12 m3 l3">
            <i class="material-icons prefix">code</i>
            <input disabled id="gdo" type="text" class="validate" />
        </div>
        <div class="input-field col s12 m9 l9">
                
            <i class="material-icons prefix">business</i>
            <input id="raisonSociale" disabled runat="server" type="text" class="validate" />
        </div>
    </div>


    <div class="row">
        <div class="input-field col s12 m12 l12">
             <i class="material-icons prefix">map</i>
            <input id="map" disabled runat="server" type="text" class="validate" />
        </div>
        
    </div>


     <blockquote>
        <h5>Contact </h5>
        <div class="divider"></div>
    </blockquote>
                

    <blockquote>
        <h5>Historique </h5>
        <div class="divider"></div>
    </blockquote>
          </main>


           
<script src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
<script src="./js/materialize.js"></script>

<script type="text/javascript">

$(function () {
    $(document).ready(function () {
        // the "href" attribute of the modal trigger must specify the modal ID that wants to be triggered
        $('.button-collapse').sideNav();
    });
});

window.onload = function () {
    document.getElementById('raisonSociale').value = '<%= Session["raisonSociale"] %>';
    document.getElementById('gdo').value = '<%= Session["gdo"] %>';

    var gdo = '<%= Session["gdo"] %>';
    var raisonSociale = '<%= Session["raisonSociale"] %>'
    document.getElementById('map').value = gdo.concat('>> ', raisonSociale);
}
    </script>

             <asp:TextBox ID="Utilisateur_Id" runat="server" Visible="false"></asp:TextBox>
        </form>
       </div>

</body>
</html>
