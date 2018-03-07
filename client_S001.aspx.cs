using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class client_client_S001 : System.Web.UI.Page
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

        

        if (Utilisateur_Id.Text == "")
            Response.Redirect("./login.aspx");

        GetListeZone();
        GetListeDR();
        GetListeTerritoire();
        GetListeClientFirst();
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

        // Sauvegarde de la zone en cours dans une variable session //
        Session.Add("zone_id", int.Parse(Liste_Zone.SelectedValue.ToString()));
    }

    protected void Liste_DR_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListeTerritoire();
    }


    private void GetListeClientFirst()
    {
        

        try
        {
            // Liste des clients //
            DataTable dt = Datas.Client_S001(int.Parse(Liste_Zone.SelectedValue.ToString()), int.Parse(Liste_DR.SelectedValue.ToString()), int.Parse(Liste_Territoire.SelectedValue.ToString()), "", "").Tables[0];

            int NbClients;
            NbClients = dt.Rows.Count;

            HttpContext.Current.Session.Add("Clients", dt);
            GV_Client.DataSource = new DataView(dt);
            GV_Client.DataBind();
        }
        catch (Exception exp)
        {
            Response.Write(exp.ToString());
        }
    }

    private void GetListeClient()
    {


        try
        {
            // Liste des clients //
            DataTable dt = Datas.Client_S001(int.Parse(Liste_Zone.SelectedValue.ToString()), int.Parse(Liste_DR.SelectedValue.ToString()), int.Parse(Liste_Territoire.SelectedValue.ToString()), Request["GDO"].ToString(), Request["raisonSociale"].ToString()).Tables[0];

            int NbClients;
            NbClients = dt.Rows.Count;

            HttpContext.Current.Session.Add("Clients", dt);
            GV_Client.DataSource = new DataView(dt);
            GV_Client.DataBind();
        }
        catch (Exception exp)
        {
            Response.Write(exp.ToString());
        }
    }

    protected void button_recherche_Click(object sender, EventArgs e)
    {
        GetListeClient();
    }

    protected void GV_Client_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DETAILS")
        {

            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GV_Client.Rows[index];

            ListItem item = new ListItem();

            Session.Contents["client_id"] = Server.HtmlDecode(row.Cells[3].Text);
            Session.Contents["gdo"] = Server.HtmlDecode(row.Cells[0].Text);
            Session.Contents["raisonSociale"] = Server.HtmlDecode(row.Cells[1].Text);

            Response.Redirect("./client_X001.aspx");
        }
    }


    

    protected void GV_Client_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Client.PageIndex = e.NewPageIndex;
        GetListeClient();
    }
}