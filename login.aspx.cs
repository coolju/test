using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;

public partial class login : System.Web.UI.Page
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
        Session.Add("Utilisateur_Id", "");
    }

    protected void connexion_Click(object sender, EventArgs e)
    {
        string pass;
        pass = FormsAuthentication.HashPasswordForStoringInConfigFile(Request["password"].ToString(), "MD5");


        // AUTHENTIFICATION //
        DataSet DS = Datas.Authentification(Request["NNI"].ToString(), pass);

        if (DS.Tables[0].Rows[0]["Result"].ToString() == "Authentification_OK")
        {
            result.Text = "authentification ok";
            Session.Add("Utilisateur_Id", DS.Tables[0].Rows[0]["Utilisateur_Id"].ToString());
            Session.Add("Utilisateur", DS.Tables[0].Rows[0]["Utilisateur"].ToString());
            Session.Add("Zone_Id", DS.Tables[0].Rows[0]["Zone_Id"].ToString());
            Session.Add("MessageValidationContact", DS.Tables[0].Rows[0]["MessageValidationContact"].ToString());

            // redirection vers le tableau de bord //
            Response.Redirect("./tb.aspx");
        }
        else
        {
            result.Text = "NNI ou mot de passe non valide.";
            result.Visible = true;
        }
    }
}