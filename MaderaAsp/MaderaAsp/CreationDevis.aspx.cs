using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaderaAsp
{
    public partial class CreationDevis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            var connectionString = String.Format("Data Source={0};Version=3;", "./App_Data/Madera.db");
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|Madera.db"))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    string query = "select id_client, nom, prenom, mail from client;";
                    cmd.CommandText = query;
                    System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                    da.Fill(ds);
                    int i = 0;
                    while(i < ds.Tables[0].Rows.Count)
                    {
                        string nom = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                        string prenom = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                        string mail = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                        string id_client = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                        client.Items.Add(new ListItem(nom + " " + prenom + " : " + mail, id_client));
                        i++;
                    }
                    con.Close();
                }
            }
        }

        protected void continuer(object o, System.EventArgs arg)
        {
            DataSet ds = new DataSet();
            var connectionString = String.Format("Data Source={0};Version=3;", "./App_Data/Madera.db");
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|Madera.db"))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT id_adresse FROM adresse " +
                        "WHERE libelle = @libelle " +
                        "AND numero = @numero " +
                        "AND code_postal = @cp " +
                        "AND ville = @ville " +
                        "AND pays = @pays;";
                    cmd.Parameters.AddWithValue("@libelle", adresseClient.Text);
                    cmd.Parameters.AddWithValue("@numero", numClient.Text);
                    cmd.Parameters.AddWithValue("@cp", postalClient.Text);
                    cmd.Parameters.AddWithValue("@ville", villeClient.Text);
                    cmd.Parameters.AddWithValue("@pays", paysClient.Text);
                    System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                    da.Fill(ds);
                    int i = 0;
                    string id_adresse = "";
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        while (i < ds.Tables[0].Rows.Count)
                        {
                            id_adresse = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                            i++;
                        }
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO adresse(libelle,numero,code_postal,ville,pays) " +
                            "VALUES(@libelle,@numero,@cp,@ville,@pays)";
                        cmd.Parameters.AddWithValue("@libelle", adresseClient.Text);
                        cmd.Parameters.AddWithValue("@numero", numClient.Text);
                        cmd.Parameters.AddWithValue("@cp", postalClient.Text);
                        cmd.Parameters.AddWithValue("@ville", villeClient.Text);
                        cmd.Parameters.AddWithValue("@pays", paysClient.Text);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT id_adresse FROM adresse " +
                        "WHERE libelle = @libelle " +
                        "AND numero = @numero " +
                        "AND code_postal = @cp " +
                        "AND ville = @ville " +
                        "AND pays = @pays;";
                        cmd.Parameters.AddWithValue("@libelle", adresseClient.Text);
                        cmd.Parameters.AddWithValue("@numero", numClient.Text);
                        cmd.Parameters.AddWithValue("@cp", postalClient.Text);
                        cmd.Parameters.AddWithValue("@ville", villeClient.Text);
                        cmd.Parameters.AddWithValue("@pays", paysClient.Text);
                        da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                        ds.Clear();
                        da.Fill(ds);
                        while (i < ds.Tables[0].Rows.Count)
                        {
                            id_adresse = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                            i++;
                        }
                    }
                    con.Close();

                    Session["nomProjet"] = nomProjet.Text;
                    Session["dateProjet"] = DateTime.Now.ToString("yyyy/MM/dd");
                    Session["idClient"] = client.SelectedValue;
                    Session["idAdresse"] = id_adresse;
                }
            }
            Response.Redirect("/CreationPlan");
        }
    }
}