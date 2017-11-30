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
            using (var con = new System.Data.SQLite.SQLiteConnection(connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    string query = "select id_client, nom, prenom, mail from client;";
                    cmd.CommandText = query;
                    System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                    da.Fill(ds);
                    /*if (ds.Tables[0].Rows.Count > 0)
                    {
                        client.DataSource = ds;
                        client.DataBind();
                        client.Items.Add(new ListItem())
                    }*/
                    int i = 0;
                    while(i < ds.Tables[0].Rows.Count)
                    {
                        string nom = ds.Tables["nom"].Rows[i].ToString();
                        string prenom = ds.Tables["prenom"].Rows[i].ToString();
                        string mail = ds.Tables["mail"].Rows[i].ToString();
                        string id_client = ds.Tables["id_client"].Rows[i].ToString();
                        client.Items.Add(new ListItem(nom + " " + prenom + " : " + mail, id_client));
                        i++;
                    }
                    con.Close();
                }
            }
        }

        protected void continuer()
        {
            string par = nomProjet + ";" + refProjet + ";" + nomClient + ";" + prenomClient + ";";
            var connectionString = String.Format("Data Source={0};Version=3;", "./App_Data/test.sqlite");
            using (var con = new System.Data.SQLite.SQLiteConnection(connectionString))
            {
                Console.Error.WriteLine(" ------> ");
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    DataSet ds = new DataSet();
                    
                    cmd.CommandText = "INSERT INTO devis(nom,date_devis,id_client,id_adresse) " +
                    "VALUES(@nom, @date_devis, @id_client, @id_adresse)";
                    cmd.Parameters.AddWithValue("@nom", nomClient);
                    cmd.Parameters.AddWithValue("@date_devis", prenomClient);
                    cmd.Parameters.AddWithValue("@id_client", mailClient);
                    cmd.Parameters.AddWithValue("@id_adresse", phoneClient);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    Response.Redirect("CreationPlan.aspx");
                }
            }
        }
    }
}