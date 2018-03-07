using System;
using System.Data;
using System.Data.SqlClient;

public class Sql
{

    SqlConnection cnn;
    SqlCommand cmd;

    public Sql(string ConnectionString)
    {
        cnn = new SqlConnection(ConnectionString);
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
    }

    public DataSet Authentification(string Login, string Pass)
    {
        DataSet DS = new DataSet();
        DS.Tables.Add("Authentification");

        SqlDataAdapter DTA = new SqlDataAdapter(cmd);

        try
        {
            cmd.CommandText = "[dbo].[spAuthentification]";
            cmd.Parameters.Clear();


            cmd.Parameters.Add("@Login", SqlDbType.VarChar);
            cmd.Parameters["@Login"].Value = Login;

            cmd.Parameters.Add("@Pass", SqlDbType.VarChar);
            cmd.Parameters["@Pass"].Value = Pass;


            DTA.Fill(DS, "Authentification");
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
        }

        return DS;
    }

    public DataSet Zone_S001(int Utilisateur_Id)
    {
        DataSet DS = new DataSet();
        DS.Tables.Add("Zone");

        SqlDataAdapter DTA = new SqlDataAdapter(cmd);

        try
        {
            cmd.CommandText = "[dbo].[spZone_S001]";
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@Utilisateur_Id", SqlDbType.Int);
            cmd.Parameters["@Utilisateur_Id"].Value = Utilisateur_Id;

            DTA.Fill(DS, "Zone");
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
        }

        return DS;
    }

    public DataSet DR_S001(int Zone_Id, int Utilisateur_Id)
    {
        DataSet DS = new DataSet();
        DS.Tables.Add("DR");

        SqlDataAdapter DTA = new SqlDataAdapter(cmd);

        try
        {
            cmd.CommandText = "[dbo].[spDR_S001]";
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@Zone_Id", SqlDbType.Int);
            cmd.Parameters["@Zone_Id"].Value = Zone_Id;

            cmd.Parameters.Add("@Utilisateur_Id", SqlDbType.Int);
            cmd.Parameters["@Utilisateur_Id"].Value = Utilisateur_Id;

            DTA.Fill(DS, "DR");
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
        }

        return DS;
    }

    public DataSet Territoire_S001(int DR_Id)
    {
        DataSet DS = new DataSet();
        DS.Tables.Add("Territoire");

        SqlDataAdapter DTA = new SqlDataAdapter(cmd);

        try
        {
            cmd.CommandText = "[dbo].[spTerritoire_S001]";
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@DR_Id", SqlDbType.Int);
            cmd.Parameters["@DR_Id"].Value = DR_Id;

            DTA.Fill(DS, "Territoire");
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
        }

        return DS;
    }


    public DataSet TB_InfosJour(
        int Periode_Id,
        DateTime Date,
        int Zone_Id,
        int DR_Id,
        int Territoire_Id
)
    {
        DataSet DS = new DataSet();
        DS.Tables.Add("Clients");

        SqlDataAdapter DTA = new SqlDataAdapter(cmd);

        try
        {
            cmd.CommandText = "[dbo].[spTB_InfosJour]";
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@Periode_Id", SqlDbType.Int);
            cmd.Parameters["@Periode_Id"].Value = Periode_Id;

            cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            cmd.Parameters["@Date"].Value = Date;

            cmd.Parameters.Add("@DR_Id", SqlDbType.Int);
            cmd.Parameters["@DR_Id"].Value = DR_Id;

            cmd.Parameters.Add("@Territoire_Id", SqlDbType.Int);
            cmd.Parameters["@Territoire_Id"].Value = Territoire_Id;

            cmd.Parameters.Add("@Zone_Id", SqlDbType.Int);
            cmd.Parameters["@Zone_Id"].Value = Zone_Id;

            DTA.Fill(DS, "Clients");
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
        }

        return DS;
    }


    public DataSet Client_S001(
        int Zone_Id,
        int DR_Id,
        int Territoire_Id,
        string GDO,
        string RaisonSociale
)
    {
        DataSet DS = new DataSet();
        DS.Tables.Add("Clients");

        SqlDataAdapter DTA = new SqlDataAdapter(cmd);

        try
        {
            cmd.CommandText = "[dbo].[spClient_S001]";
            cmd.Parameters.Clear();

            if (GDO.Equals("")) cmd.Parameters.AddWithValue("@GDO", DBNull.Value);
            else
            {
                cmd.Parameters.Add("@GDO", SqlDbType.VarChar);
                cmd.Parameters["@GDO"].Value = GDO;
            }

            if (RaisonSociale.Equals("")) cmd.Parameters.AddWithValue("@RaisonSociale", DBNull.Value);
            else
            {
                cmd.Parameters.Add("@RaisonSociale", SqlDbType.VarChar);
                cmd.Parameters["@RaisonSociale"].Value = RaisonSociale;
            }

            cmd.Parameters.Add("@Zone_Id", SqlDbType.Int);
            cmd.Parameters["@Zone_Id"].Value = Zone_Id;

            cmd.Parameters.Add("@DR_Id", SqlDbType.Int);
            cmd.Parameters["@DR_Id"].Value = DR_Id;

            cmd.Parameters.Add("@Territoire_Id", SqlDbType.Int);
            cmd.Parameters["@Territoire_Id"].Value = Territoire_Id;

            DTA.Fill(DS, "Clients");
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
        }

        return DS;
    }

}