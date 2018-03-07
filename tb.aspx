<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tb.aspx.cs" Inherits="tb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- CSS  -->
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="css/materialize.css" type="text/css" rel="stylesheet" media="screen,projection"/>
    <link href="css/style.css" type="text/css" rel="stylesheet" media="screen,projection"/>
  



    <!-- Responsive -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>AIR - Tableau de bord</title>
    <link rel="shortcut icon" href="./Images/favicon.ico" />
</head>
<body>
    <div class="container">
    <form id="form1" runat="server">
        
    <div>
    
    <header>
        <%
        Response.WriteFile("./include/nav.inc");
        %>
    </header>
    
    <main>

    <blockquote>
        <h5>Tableaux de bord</h5>
        <div class="divider"></div>
    </blockquote>


        <ul class="collapsible" data-collapsible="accordion">
            <li>
      <div class="collapsible-header active"><i class="material-icons">perm_data_setting</i>Filtres <asp:Label ID="txt_filtre" runat="server"></asp:Label></div>
      <div class="collapsible-body"><span>

    <div class="row">
        <div class="input-field col s12 m6 l6">
            <asp:TextBox ID="dateStat" class="datepiker validate" runat="server" AutoPostBack="True" placeholder="DATE" OnTextChanged="dateStat_TextChanged" />
            <label>DATE</label>
        </div>
        <div class="input-field col s12 m6 l6">
            <asp:DropDownList ID="Liste_Zone" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Liste_Zone_SelectedIndexChanged"></asp:DropDownList>
            <label>ZONE</label>
        </div>
    </div>

    <div class="row">
        <div class="input-field col s12 m6 l6">
            <asp:DropDownList ID="Liste_DR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Liste_DR_SelectedIndexChanged"></asp:DropDownList>
            <label>DR</label>
        </div>
        <div class="input-field col s12 m6 l6">
            <asp:DropDownList ID="Liste_Territoire" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Liste_Territoire_SelectedIndexChanged"></asp:DropDownList>
            <label>TERRITOIRE</label>
        </div>
    </div>
          </span></div>
    </li></ul>

        <!-- STATS -->
        
        <div class="section">
        

        <div class="row">

         <div class="col s6 m3 l3">
          <div class="card green darken-1 hoverable">
            <div class="card-content white-text">
              <span class="card-title">
              <i class="medium material-icons">people</i>
                <p><asp:Label ID="NbAgentsAlerte" runat="server"></asp:Label> Agents alertés</p>
                  </span>
            </div>

            <div class="card-action">
                <a onclick="window.open('<%=HL_Stats_AgentsAlertes.Text%>','Agents alertés','width=800,height=500,scrollbars=yes,Zoneectories=no,toolbar=no,location=no,status=no,menubar=no')" class="left-align">Voir détails</a>
                
                <asp:HyperLink runat="server" ID="HL_Stats_AgentsAlertes_download" CssClass="right-align"><i class="small material-icons">file_download</i></asp:HyperLink>
                
            </div>
            
          </div>
            </div>

            <div class="col s6 m3 l3">
          <div class="card green darken-2 hoverable">
            <div class="card-content white-text">
              <span class="card-title">
              <i class="medium material-icons">people</i>
                <p><asp:Label ID="NbClientsAlerte" runat="server"></asp:Label> Clients alertés</p>
                  </span>
            </div>

            <div class="card-action">
                <a onclick="window.open('<%=HL_Stats_ClientsAlertes.Text%>','Agents alertés','width=800,height=500,scrollbars=yes,Zoneectories=no,toolbar=no,location=no,status=no,menubar=no')" class="left-align">Voir détails</a>
                
                <asp:HyperLink runat="server" ID="HL_Stats_ClientsAlertes_download" CssClass="right-align"><i class="small material-icons">file_download</i></asp:HyperLink>
                
            </div>
            
          </div>
            </div>



        <div class="col s6 m3 l3">
          <div class="card green darken-3 hoverable">
            <div class="card-content white-text">
              <span class="card-title">
              <i class="medium material-icons">thumb_up</i>
                <p><asp:Label ID="nbSmsDelivres" runat="server"></asp:Label> SMS Délivrés</p>
                  </span>
            </div>

            <div class="card-action">
                <a onclick="window.open('<%=HL_Stats_SMS_Delivre.Text%>','Agents alertés','width=800,height=500,scrollbars=yes,Zoneectories=no,toolbar=no,location=no,status=no,menubar=no')" class="left-align">Voir détails</a>
                
                <asp:HyperLink runat="server" ID="HL_Stats_SMS_Delivre_download" CssClass="right-align"><i class="small material-icons">file_download</i></asp:HyperLink>
                
            </div>
            
          </div>
            </div>
        


        <div class="col s6 m3 l3">
          <div class="card red darken-2 hoverable">
            <div class="card-content white-text">
              <span class="card-title">
              <i class="medium material-icons">thumb_down</i>
                <p><asp:Label ID="nbSmsErreurs" runat="server"></asp:Label> SMS Erreurs</p>
                  </span>
            </div>
            <div class="card-action">
                
                <a onclick="window.open('<%=HL_Stats_SMS_Erreur.Text%>','Agents alertés','width=800,height=500,scrollbars=yes,Zoneectories=no,toolbar=no,location=no,status=no,menubar=no')" class="left-align">Voir détails</a>
                
                <asp:HyperLink runat="server" ID="HL_Stats_SMS_Erreur_download" CssClass="right-align"><i class="small material-icons">file_download</i></asp:HyperLink>
                

          
            </div>
            </div>
        </div>
            
            

       


         <div class="col s6 m3 l3">
          <div class="card grey darken-1 hoverable">
            <div class="card-content white-text">
              <span class="card-title">
              <i class="medium material-icons">flash_on</i>
                <p><asp:Label ID="NbIncidentsClients" runat="server"></asp:Label> Incidents clients</p>
                  </span>
            </div>

            <div class="card-action">
                <a onclick="window.open('<%=HL_Stats_Incident_Client.Text%>','Agents alertés','width=800,height=500,scrollbars=yes,Zoneectories=no,toolbar=no,location=no,status=no,menubar=no')" class="left-align">Voir détails</a>
                
                <asp:HyperLink runat="server" ID="HL_Stats_Incident_Client_download" CssClass="right-align"><i class="small material-icons">file_download</i></asp:HyperLink>
                
            </div>
            
          </div>
            </div>
        </div></div>

        


      


    
        
    
    <%
    /*Response.WriteFile("./include/footer.inc");*/
    %>        
   
    </main>

        </div>

<script src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
<script src="js/materialize.js"></script>

<script type="text/javascript">

    $(function () {
    $(document).ready(function () {
        // the "href" attribute of the modal trigger must specify the modal ID that wants to be triggered
        $('.button-collapse').sideNav();
    });
    });

           
    $(function () {
        $('#dateStat').pickadate({
        selectMonths: true,
        selectYears: 15,
        today: 'Today',
        weekdaysShort: ['Di', 'Lu', 'Ma', 'Me', 'Je', 'Ve', 'Sa'],
        monthsShort: ['Jan', 'Fev', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
        monthsFull: ['Janvier', 'Fevrier', 'Mars', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
        showMonthsShort: false,
        format: 'dd/mm/yyyy',
        closeOnSelect: true
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
    document.getElementById('utilisateur').value = '<%=Session["Utilisateur"] %>';
    }



    

</script>
        <asp:TextBox ID="Utilisateur_Id" runat="server" Visible="false"></asp:TextBox>
        <asp:Label ID="HL_Stats_SMS_Delivre" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="HL_Stats_SMS_Erreur" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="HL_Stats_AgentsAlertes" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="HL_Stats_ClientsAlertes" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="HL_Stats_Incident_Client" runat="server" Visible="False"></asp:Label>
</form>
</div>
</body>
</html>
