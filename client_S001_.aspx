﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="client_S001_.aspx.cs" Inherits="client_S001_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

     <!-- CSS  -->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="./css/materialize.css" type="text/css" rel="stylesheet" media="screen,projection"/>
    <link href="./css/style.css" type="text/css" rel="stylesheet" media="screen,projection"/>
  

    <!-- Responsive -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>AIR - Gestion client</title>
    <link rel="shortcut icon" href="./Images/favicon.ico" />
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
    <br />

        
<div class="row">

    <div class="col s4">
      
    <div class="row">
        
        <div class="input-field col s12">
            <asp:DropDownList ID="Liste_Zone" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Liste_Zone_SelectedIndexChanged" ></asp:DropDownList>
            <label>ZONE</label>
        </div>
    </div>

    <div class="row">
        <div class="input-field col s12">
            <asp:DropDownList ID="Liste_DR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Liste_DR_SelectedIndexChanged" ></asp:DropDownList>
            <label>DR</label>
        </div>
    </div>
    <div class="row">
        <div class="input-field col s12">
            <asp:DropDownList ID="Liste_Territoire" runat="server" AutoPostBack="True" ></asp:DropDownList>
            <label>TERRITOIRE</label>
        </div>
    </div>

    <div class="row">
        <div class="input-field col s12">
            <input id="GDO" runat="server" type="text" class="validate" />
            <label for="GDO">GDO</label>
        </div>
    </div>
    <div class="row">
        <div class="input-field col s12">
            <input id="raisonSociale" runat="server" type="text" class="validate" />
            <label for="raisonSociale">Raison sociale</label>
        </div>
    </div>


    <div class="row">
        <div class="input-field col s12">
           <asp:Button ID="button_recherche" runat="server" Text="Rechercher" OnClick="button_recherche_Click" CssClass="btn btn-block" />
        </div>
    </div>
     </div>
    
     <div class="col s8">
   
                 

                <div id="tabTableau" class="col s12">
            <br />
            <asp:GridView ID="GV_Client" runat="server" CssClass="responsive-table bordered highlight" AutoGenerateColumns="False"  AllowPaging="true">
            <Columns>
                
                <asp:BoundField DataField="GDO" HeaderText="GDO" />
                <asp:BoundField DataField="RaisonSociale" HeaderText="Raison sociale" />
                
                
                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="" Text="Détails" CommandName="DETAILS">
                    <ControlStyle CssClass="btn lighten-3"></ControlStyle>
                </asp:ButtonField>
                <asp:BoundField DataField="Client_Id" >
                <ItemStyle CssClass="hiddencol" />
                <ControlStyle CssClass="hiddencol" />
                <FooterStyle CssClass="hiddencol" />
                <HeaderStyle CssClass="hiddencol" />
                </asp:BoundField>

            </Columns>
            <PagerSettings Position="Bottom" />
                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" VerticalAlign="Middle"/>
        </asp:GridView>



        </div>

         </div>


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

$(function () {
    $('.dropdown-button').dropdown({
        inDuration: 300,
        outDuration: 225,
        constrainWidth: false, // Does not change width of dropdown to that of the activator
        hover: true, // Activate on hover
        gutter: 0, // Spacing from edge
        belowOrigin: false, // Displays dropdown below the button
        alignment: 'left', // Displays dropdown with edge aligned to the left of button
        stopPropagation: false // Stops event propagation
    }
    );
});

$(document).ready(function () {
    $('select').material_select();
});

           
window.onload = function () {
document.getElementById('utilisateur').value = '<%= Session["Utilisateur"] %>';
}

</script>
   <asp:TextBox ID="Utilisateur_Id" runat="server" Visible="false"></asp:TextBox>
        
        </form>
    </div>
</body>
</html>
