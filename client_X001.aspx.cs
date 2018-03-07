using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class client_X001 : System.Web.UI.Page
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
        client_id.Text = (string)Session.Contents["client_id"];
        Utilisateur_Id.Text = (string)Session.Contents["Utilisateur_Id"];

        if (Utilisateur_Id.Text == "")
            Response.Redirect("./login.aspx");

    }

 

   
}