using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;

public partial class tb : System.Web.UI.Page
{
    protected Sql _Datas;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitPage();
        }
    }
    private Sql Datas
    {
        get
        {
            if (_Datas == null)
                _Datas = new Sql(System.Configuration.ConfigurationManager.AppSettings["ConnectionString_AIR"]);
            return _Datas;
        }
    }


    private void InitPage()
    {
        Utilisateur_Id.Text = (string)Session.Contents["Utilisateur_Id"];

        dateStat.Text = DateTime.Now.ToShortDateString();

        if (Utilisateur_Id.Text == "")
            Response.Redirect("./login.aspx");

        GetListeZone();
        GetListeDR();
        GetListeTerritoire();
        GetStats();

        InitHyperlink();
        SetLabelFiltre();
        
    }

    private void SetLabelFiltre()
    {
        txt_filtre.Text = "&nbsp;:&nbsp;" + Liste_Zone.SelectedItem.ToString();

        if (Liste_DR.SelectedValue.ToString() != "0")
        {
            txt_filtre.Text = txt_filtre.Text + "&nbsp;>&nbsp;" + Liste_DR.SelectedItem.ToString();
        }

        if (Liste_Territoire.SelectedValue.ToString() != "0")
        {
            txt_filtre.Text = txt_filtre.Text + "&nbsp;>&nbsp;" + Liste_Territoire.SelectedItem.ToString();
        }

    }

    private void InitHyperlink()
    {

        // Hyperlink //
        string urlJasper = "";
        if (System.Configuration.ConfigurationManager.AppSettings["environment"] == "DEV")
            urlJasper = System.Configuration.ConfigurationManager.AppSettings["ReportURL_DEV"];

        if (System.Configuration.ConfigurationManager.AppSettings["environment"] == "PROD")
            urlJasper = System.Configuration.ConfigurationManager.AppSettings["ReportURL_PROD"];


        // Clients Alertes
        HL_Stats_ClientsAlertes.Text = urlJasper + "/Client_Alerte_Jour.html?Zone_Id="
           + Liste_Zone.SelectedValue.ToString()
        + "&dr_acr_id=" + Liste_DR.SelectedValue.ToString()
        + "&territoire_id=" + Liste_Territoire.SelectedValue.ToString()
        + "&jour=" + DateTime.Parse(dateStat.Text).Day
        + "&mois=" + DateTime.Parse(dateStat.Text).Month
        + "&annee=" + DateTime.Parse(dateStat.Text).Year
        + "&j_acegi_security_check&k&j_username=air&j_password=air";

        HL_Stats_ClientsAlertes_download.NavigateUrl = urlJasper + "/Client_Alerte_Jour.xls?Zone_Id="
        + Liste_Zone.SelectedValue.ToString()
        + "&dr_acr_id=" + Liste_DR.SelectedValue.ToString()
        + "&territoire_id=" + Liste_Territoire.SelectedValue.ToString()
        + "&jour=" + DateTime.Parse(dateStat.Text).Day
        + "&mois=" + DateTime.Parse(dateStat.Text).Month
        + "&annee=" + DateTime.Parse(dateStat.Text).Year
        + "&j_acegi_security_check&k&j_username=air&j_password=air";

        // SMS DELIVRE
        HL_Stats_SMS_Delivre.Text = urlJasper + "/Sms_Delivre_Jour.html?Zone_Id="
        +  Liste_Zone.SelectedValue.ToString()
        + "&dr_acr_id=" + Liste_DR.SelectedValue.ToString()
        + "&territoire_id=" + Liste_Territoire.SelectedValue.ToString()
        + "&jour=" + DateTime.Parse(dateStat.Text).Day
        + "&mois=" + DateTime.Parse(dateStat.Text).Month
        + "&annee=" + DateTime.Parse(dateStat.Text).Year
        + "&j_acegi_security_check&k&j_username=air&j_password=air";

        HL_Stats_SMS_Delivre_download.NavigateUrl = urlJasper + "/Sms_Delivre_Jour.xls?Zone_Id="
            + Liste_Zone.SelectedValue.ToString()
            + "&dr_acr_id=" + Liste_DR.SelectedValue.ToString()
            + "&territoire_id=" + Liste_Territoire.SelectedValue.ToString()
            + "&jour=" + DateTime.Parse(dateStat.Text).Day
            + "&mois=" + DateTime.Parse(dateStat.Text).Month
            + "&annee=" + DateTime.Parse(dateStat.Text).Year
            + "&j_acegi_security_check&k&j_username=air&j_password=air";


        // SMS ERREUR
        HL_Stats_SMS_Erreur.Text = urlJasper + "/Sms_Erreur_Jour.html?Zone_Id="
              + Liste_Zone.SelectedValue.ToString()
            + "&dr_acr_id=" + Liste_DR.SelectedValue.ToString()
            + "&territoire_id=" + Liste_Territoire.SelectedValue.ToString()
            + "&jour=" + DateTime.Parse(dateStat.Text).Day
            + "&mois=" + DateTime.Parse(dateStat.Text).Month
            + "&annee=" + DateTime.Parse(dateStat.Text).Year
            + "&j_acegi_security_check&k&j_username=air&j_password=air";

        HL_Stats_SMS_Erreur_download.NavigateUrl = urlJasper + "/Sms_Erreur_Jour.xls?Zone_Id="
          + Liste_Zone.SelectedValue.ToString()
            + "&dr_acr_id=" + Liste_DR.SelectedValue.ToString()
            + "&territoire_id=" + Liste_Territoire.SelectedValue.ToString()
            + "&jour=" + DateTime.Parse(dateStat.Text).Day
            + "&mois=" + DateTime.Parse(dateStat.Text).Month
            + "&annee=" + DateTime.Parse(dateStat.Text).Year
            + "&j_acegi_security_check&k&j_username=air&j_password=air";



        // INCIDENTS CLIENTS
        HL_Stats_Incident_Client.Text = urlJasper + "/Incident_Client_Jour.html?Zone_Id="
            + Liste_Zone.SelectedValue.ToString()
            + "&dr_acr_id=" + Liste_DR.SelectedValue.ToString()
            + "&territoire_id=" + Liste_Territoire.SelectedValue.ToString()
            + "&jour=" + DateTime.Parse(dateStat.Text).Day
            + "&mois=" + DateTime.Parse(dateStat.Text).Month
            + "&annee=" + DateTime.Parse(dateStat.Text).Year
            + "&j_acegi_security_check&k&j_username=air&j_password=air";

        HL_Stats_Incident_Client_download.NavigateUrl = urlJasper + "/Incident_Client_Jour.xls?Zone_Id="
        + Liste_Zone.SelectedValue.ToString()
            + "&dr_acr_id=" + Liste_DR.SelectedValue.ToString()
            + "&territoire_id=" + Liste_Territoire.SelectedValue.ToString()
            + "&jour=" + DateTime.Parse(dateStat.Text).Day
            + "&mois=" + DateTime.Parse(dateStat.Text).Month
            + "&annee=" + DateTime.Parse(dateStat.Text).Year
            + "&j_acegi_security_check&k&j_username=air&j_password=air";

    }


    private void GetListeZone()
    {
        // Liste zone //
        Liste_Zone.DataSource = Datas.Zone_S001(int.Parse(Utilisateur_Id.Text));
        Liste_Zone.DataTextField = "Zone_Libelle";
        Liste_Zone.DataValueField = "Zone_Id";
        Liste_Zone.DataBind();


        if (Session["zone_id"].ToString() != null)
        {
            Liste_Zone.SelectedIndex = Liste_Zone.Items.IndexOf(Liste_Zone.Items.FindByValue(Session["zone_id"].ToString()));
        }
        else
        {
            // Sauvegarde de la zone en cours dans une variable session //
            Session.Add("zone_id", int.Parse(Liste_Zone.SelectedValue.ToString()));
        }
    }


    private void GetListeDR()
    {
        // Liste DR //
        Liste_DR.DataSource = Datas.DR_S001(int.Parse(Liste_Zone.SelectedValue.ToString()), int.Parse(Utilisateur_Id.Text));
        Liste_DR.DataTextField = "DR_Libelle";
        Liste_DR.DataValueField = "DR_Id";
        Liste_DR.DataBind();
    }

    private void GetListeTerritoire()
    {
        // Liste Territoire //
        Liste_Territoire.DataSource = Datas.Territoire_S001(int.Parse(Liste_DR.SelectedValue.ToString()));
        Liste_Territoire.DataTextField = "Territoire_Libelle";
        Liste_Territoire.DataValueField = "Territoire_Id";
        Liste_Territoire.DataBind();
    }

    protected void Liste_Zone_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListeDR();
        GetListeTerritoire();
        GetStats();
        SetLabelFiltre();

        // Sauvegarde de la zone en cours dans une variable session //
        Session.Add("zone_id", int.Parse(Liste_Zone.SelectedValue.ToString()));
    }

    protected void Liste_DR_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListeTerritoire();
        GetStats();
        SetLabelFiltre();
    }

    private void GetStats()
    {

        DataSet DS = Datas.TB_InfosJour(1, DateTime.Parse(dateStat.Text), int.Parse(Liste_Zone.SelectedValue.ToString()), int.Parse(Liste_DR.SelectedValue.ToString()), int.Parse(Liste_Territoire.SelectedValue.ToString()));


        if (DS.Tables[0].Rows.Count == 0)
        {
            //   RESULT_VALIDER.Text = "Pb technique";
            return;
        }

        nbSmsDelivres.Text = DS.Tables[0].Rows[0]["NbSMSDelivre"].ToString();
        nbSmsErreurs.Text = DS.Tables[0].Rows[0]["NbSMSErreur"].ToString();
        NbAgentsAlerte.Text = DS.Tables[0].Rows[0]["NbAgentsAlerte"].ToString();
        NbClientsAlerte.Text = DS.Tables[0].Rows[0]["NbClientsAlerte"].ToString();
        NbIncidentsClients.Text = DS.Tables[0].Rows[0]["NbIncidentsClients"].ToString();

        /*
        if (int.Parse(DS.Tables[0].Rows[0]["NbAgentsAlerte"].ToString()) == 0)
            this.TXT_NbAgentsAlerte.Text = DS.Tables[0].Rows[0]["NbAgentsAlerte"].ToString();
        else
            this.TXT_NbAgentsAlerte.Text = DS.Tables[0].Rows[0]["NbAgentsAlerte"].ToString();

        if (int.Parse(DS.Tables[0].Rows[0]["NbClientsAlerte"].ToString()) == 0)
            this.TXT_NbClientsAlerte.Text = DS.Tables[0].Rows[0]["NbClientsAlerte"].ToString();
        else
            this.TXT_NbClientsAlerte.Text = DS.Tables[0].Rows[0]["NbClientsAlerte"].ToString();

        
        
        this.TXT_NbIncidentsClients.Text = DS.Tables[0].Rows[0]["NbIncidentsClients"].ToString();
        this.TXT_NbIncidentsClientsEnCours.Text = DS.Tables[0].Rows[0]["NbIncidentsClientsEnCours"].ToString();
        
        */

    }

    protected void dateStat_TextChanged(object sender, EventArgs e)
    {
        GetStats();
    }

    protected void Liste_Territoire_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetStats();
        SetLabelFiltre();
    }
}