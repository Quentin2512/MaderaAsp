using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaderaAsp
{
    public partial class CreationPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                var connectionString = String.Format("Data Source={0};Version=3;", "./App_Data/Madera.db");
                using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|Madera.db"))
                {
                    con.Open();
                    using (var cmd = con.CreateCommand())
                    {
                        gammeMaison.Items.Clear();
                        string query = "SELECT nom, id_gamme FROM gamme;";
                        cmd.CommandText = query;
                        System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                        da.Fill(ds);
                        int i = 0;
                        while (i < ds.Tables[0].Rows.Count)
                        {
                            string nomGamme = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                            string id_gamme = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                            gammeMaison.Items.Add(new ListItem(nomGamme, id_gamme));
                            i++;
                        }
                        getModelesModules(new Object(), new EventArgs());
                        setEtage(new Object(), new EventArgs());
                        setPlan(new Object(), new EventArgs());
                        con.Close();
                    }
                }
            }
        }

        public void getModelesModules(object o, System.EventArgs arg)
        {
            DataSet ds = new DataSet();
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|Madera.db"))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    modeleMaison.Items.Clear();
                    string query = "SELECT id_modele_gamme, nom, nb_etage, forme " +
                        "FROM modele_gamme " +
                        "WHERE id_gamme = @idGamme;";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idGamme", gammeMaison.SelectedValue);
                    System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                    da.Fill(ds);
                    int i = 0;
                    while (i < ds.Tables[0].Rows.Count)
                    {
                        string id_modele = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                        string nomModele = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                        string nbEtagesModele = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                        string formeModele = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                        modeleMaison.Items.Add(new ListItem(nomModele + " - " + nbEtagesModele + " étage(s) - " + formeModele, id_modele));
                        i++;
                    }
                    con.Close();
                }
            }
            setEtage(new Object(), new EventArgs());
        }

        public void setEtage(object o, System.EventArgs arg)
        {
            int nb_etage = Convert.ToInt32(modeleMaison.SelectedItem.Text.Split('-')[1].Substring(1,1));
            choixEtage.Items.Clear();
            for (int i=0; i<nb_etage; i++)
            {
                choixEtage.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            setPlan(new Object(), new EventArgs());
        }

        public void setPlan(object o, System.EventArgs arg)
        {
            DataSet ds = new DataSet();
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|Madera.db"))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    listeOptions.Items.Clear();
                    string query = "SELECT module.id_module, module.nom, module.prix, plan_module.nb_module " +
                        "FROM module, plan_module, plan " +
                        "WHERE plan.id_modele_gamme = @idModele " +
                        "AND plan_module.id_plan = plan.id_plan " +
                        "AND plan_module.id_module = module.id_module " +
                        "AND plan_module.valeur=1 " +
                        "AND plan.nu_etage = @nuEtage;";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idModele", modeleMaison.SelectedValue);
                    cmd.Parameters.AddWithValue("@nuEtage", choixEtage.SelectedValue);
                    System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                    ds.Clear();
                    da.Fill(ds);
                    int i = 0;
                    while (i < ds.Tables[0].Rows.Count)
                    {
                        string id_module = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                        string nomModule = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                        string prixModule = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                        string quantite = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                        listeOptions.Items.Add(new ListItem(quantite + " : " + nomModule + " - " + prixModule + "€", id_module));
                        i++;
                    }
                    con.Close();
                }
            }
            DataSet ds2 = new DataSet();
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|Madera.db"))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    choixOption.Items.Clear();
                    string query = "SELECT module.id_module, module.nom, module.prix, plan_module.nb_module " +
                        "FROM module, plan_module, plan " +
                        "WHERE plan.id_modele_gamme = @idModele " +
                        "AND plan_module.id_plan = plan.id_plan " +
                        "AND plan_module.id_module = module.id_module " +
                        "AND plan_module.valeur=0 " +
                        "AND plan.nu_etage = @nuEtage;";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@idModele", modeleMaison.SelectedValue);
                    cmd.Parameters.AddWithValue("@nuEtage", choixEtage.SelectedValue);
                    System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                    ds2.Clear();
                    da.Fill(ds2);
                    int i = 0;
                    while (i < ds2.Tables[0].Rows.Count)
                    {
                        string id_module = ds2.Tables[0].Rows[i].ItemArray[0].ToString();
                        string nomModule = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
                        string prixModule = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                        string quantite = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
                        choixOption.Items.Add(new ListItem(quantite + " x " + nomModule + " - " + prixModule + "€", id_module));
                        i++;
                    }
                    con.Close();
                }
            }
            DataSet ds3 = new DataSet();
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|Madera.db"))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    string query = "SELECT id_plan, image " +
                        "FROM plan " +
                        "WHERE nu_etage = @nuEtage " +
                        "AND id_modele_gamme = @idModele;";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@nuEtage", choixEtage.SelectedValue);
                    cmd.Parameters.AddWithValue("@idModele", modeleMaison.SelectedValue);
                    System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                    da.Fill(ds3);
                    int i = 0;
                    while (i < ds3.Tables[0].Rows.Count)
                    {
                        plan.ImageUrl = "/Images/"+ ds3.Tables[0].Rows[i].ItemArray[1].ToString();
                        plan.Height = 430;
                        plan.Width = 600;
                        Session["idPlan"] = ds3.Tables[0].Rows[i].ItemArray[0].ToString();
                        i++;
                    }
                    con.Close();
                }
            }
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            ListItem item = choixOption.SelectedItem;
            
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|Madera.db"))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE plan_module SET valeur=1 " +
                        "WHERE id_module=@idModule " +
                        "AND id_plan=@idPlan;";
                    cmd.Parameters.AddWithValue("@idModule", item.Value);
                    cmd.Parameters.AddWithValue("@idPlan", Session["idPlan"].ToString());
                    cmd.ExecuteNonQuery();

                    setPlan(new object(), new EventArgs());
                }
            }
        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
            ListItem item = listeOptions.SelectedItem;
            
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|Madera.db"))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE plan_module SET valeur=0 " +
                        "WHERE id_module=@idModule " +
                        "AND id_plan=@idPlan;";
                    cmd.Parameters.AddWithValue("@idModule", item.Value);
                    cmd.Parameters.AddWithValue("@idPlan", Session["idPlan"].ToString());
                    cmd.ExecuteNonQuery();

                    setPlan(new object(), new EventArgs());
                }
            }
        }

        protected void btnValider_Click(object sender, EventArgs e)
        {
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=|DataDirectory|Madera.db"))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    /* insertion du devis */
                    cmd.CommandText = "INSERT INTO devis(nom,date_devis,id_client,id_modele_gamme,id_adresse) " +
                        "VALUES(@nomProjet,@dateProjet,@idClient,@idModele,@idAdresse);";
                    cmd.Parameters.AddWithValue("@nomProjet", Session["nomProjet"].ToString());
                    cmd.Parameters.AddWithValue("@dateProjet", Session["dateProjet"].ToString());
                    cmd.Parameters.AddWithValue("@idClient", Session["idClient"].ToString());
                    cmd.Parameters.AddWithValue("@idModele", modeleMaison.SelectedValue);
                    cmd.Parameters.AddWithValue("@idAdresse", Session["idAdresse"].ToString());
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    /* récupération de l'id du devis */
                    DataSet ds = new DataSet();
                    cmd.CommandText = "SELECT devis.id_devis FROM devis " +
                        "WHERE nom=@nomDevis " +
                        "AND date_devis=@dateDevis " +
                        "AND id_client=@idClient " +
                        "AND id_modele_gamme=@idModele " +
                        "AND id_adresse=@idAdresse;";
                    cmd.Parameters.AddWithValue("@nomDevis", Session["nomProjet"].ToString());
                    cmd.Parameters.AddWithValue("@dateDevis", Session["dateProjet"].ToString());
                    cmd.Parameters.AddWithValue("@idClient", Session["idClient"].ToString());
                    cmd.Parameters.AddWithValue("@idModele", modeleMaison.SelectedValue);
                    cmd.Parameters.AddWithValue("@idAdresse", Session["idAdresse"].ToString());
                    System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                    da.Fill(ds);
                    int i = 0;
                    while (i < ds.Tables[0].Rows.Count)
                    {
                        Session["idDevis"] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                        i++;
                    }

                    cmd.Parameters.Clear();

                    /* pour chaque étage */
                    foreach (ListItem item in choixEtage.Items)
                    {
                        /* récupération des caractéristiques du plan */
                        cmd.CommandText = "SELECT id_plan, nom, image " +
                            "FROM plan " +
                            "WHERE nu_etage = @nuEtage " +
                            "AND id_modele_gamme = @idModele;";
                        cmd.Parameters.AddWithValue("@nuEtage", item.Value);
                        cmd.Parameters.AddWithValue("@idModele", modeleMaison.SelectedValue);
                        da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                        ds.Tables.Clear();
                        da.Fill(ds);
                        i = 0;
                        cmd.Parameters.Clear();
                        while (i < ds.Tables[0].Rows.Count)
                        {
                            string idPlan = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                            string nom = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                            string image = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                            /* insertion du plan au devis */
                            cmd.CommandText = "INSERT INTO devis_plan(nom, nu_etage, image, id_devis) " +
                                    "VALUES(@nomDevis, @nuEtageDevis, @imageDevis, @idDevis);";
                            cmd.Parameters.AddWithValue("@nomDevis", nom);
                            cmd.Parameters.AddWithValue("@nuEtageDevis", item.Value);
                            cmd.Parameters.AddWithValue("@imageDevis", image);
                            cmd.Parameters.AddWithValue("@idDevis", Session["idDevis"].ToString());
                            cmd.ExecuteNonQuery();

                            cmd.Parameters.Clear();

                            /* récupération de l'id du plan qui vient d'être inséré */
                            DataSet ds2 = new DataSet();
                            cmd.CommandText = "SELECT id_devis_plan FROM devis_plan " +
                                "WHERE nom = @nomDevis " +
                                "AND nu_etage = @nuEtageDevis " +
                                "AND image = @imageDevis " +
                                "AND id_devis = @idDevis;";
                            cmd.Parameters.AddWithValue("@nomDevis", nom);
                            cmd.Parameters.AddWithValue("@nuEtageDevis", item.Value);
                            cmd.Parameters.AddWithValue("@imageDevis", image);
                            cmd.Parameters.AddWithValue("@idDevis", Session["idDevis"].ToString());
                            da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                            da.Fill(ds2);
                            int j = 0;
                            while (j < ds2.Tables[0].Rows.Count)
                            {
                                Session["idPlanDevis"] = ds2.Tables[0].Rows[j].ItemArray[0].ToString();
                                j++;
                            }
                            
                            cmd.Parameters.Clear();
                            
                            /* récupération des caractéristiques des modules */
                            cmd.CommandText = "SELECT module.id_module, plan_module.nb_module " +
                                "FROM module, plan_module, plan " +
                                "WHERE plan_module.id_plan = plan.id_plan " +
                                "AND plan_module.id_module = module.id_module " +
                                "AND plan_module.valeur=1 " +
                                "AND plan.id_plan = @idPlan;";
                            cmd.Parameters.AddWithValue("@idPlan", idPlan);
                            da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                            ds2.Tables.Clear();
                            da.Fill(ds2);
                            cmd.Parameters.Clear();
                            j = 0;
                            while (j < ds2.Tables[0].Rows.Count)
                            {
                                string id_module = ds2.Tables[0].Rows[j].ItemArray[0].ToString();
                                string quantite = ds2.Tables[0].Rows[j].ItemArray[1].ToString();

                                /* insertion des différents modules du plan de l'étage dans le devis */
                                cmd.CommandText = "INSERT INTO devis_module(id_plan, id_module, nb_module) " +
                                    "VALUES(@idPlan, @idModule, @nbModule);";
                                cmd.Parameters.AddWithValue("@idPlan", Session["idPlanDevis"].ToString());
                                cmd.Parameters.AddWithValue("@idModule", id_module);
                                cmd.Parameters.AddWithValue("@nbModule", quantite);
                                cmd.ExecuteNonQuery();
                                j++;
                            }
                            i++;
                        }
                    }

                    cmd.Parameters.Clear();
                    
                    /* récupération des caractéristiques du devis */
                    cmd.CommandText = "SELECT devis.nom as devisNom, devis.date_devis, " +
                        "client.nom, client.prenom, client.mail, client.telephone, " +
                        "adresse.numero, adresse.libelle, adresse.code_postal, adresse.ville, adresse.pays, " +
                        "modele_gamme.nb_etage, modele_gamme.forme, " +
                        "gamme.nom as gammeNom " +
                        "FROM devis, client, adresse, modele_gamme, gamme " +
                        "WHERE devis.id_devis = @idDevis " +
                        "AND devis.id_client = client.id_client " +
                        "AND devis.id_modele_gamme = modele_gamme.id_modele_gamme " +
                        "AND devis.id_adresse = adresse.id_adresse " +
                        "AND modele_gamme.id_gamme = gamme.id_gamme;";
                    cmd.Parameters.AddWithValue("idDevis", Session["idDevis"].ToString());
                    da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                    ds.Tables.Clear();
                    da.Fill(ds);
                    i = 0;
                    while (i < ds.Tables[0].Rows.Count)
                    {
                        string devisNom = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                        string dateDevis = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                        string nom = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                        string prenom = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                        string mail = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                        string telephone = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                        string numero = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                        string libelle = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                        string codePostal = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                        string ville = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                        string pays = ds.Tables[0].Rows[i].ItemArray[10].ToString();
                        string nb_etage = ds.Tables[0].Rows[i].ItemArray[11].ToString();
                        string forme = ds.Tables[0].Rows[i].ItemArray[12].ToString();
                        string gammeNom = ds.Tables[0].Rows[i].ItemArray[13].ToString();

                        using (StreamWriter sw = new StreamWriter(Server.MapPath("~/" + devisNom + "_" + nom + "_" + prenom + ".txt"), true))
                        {
                            sw.WriteLine("SOCIETE MADERA");
                            sw.WriteLine("----------");
                            sw.WriteLine("DEVIS :");
                            sw.WriteLine("Nom : " + devisNom);
                            sw.WriteLine("Créé le : " + dateDevis);
                            sw.WriteLine("----------");
                            sw.WriteLine("CLIENT :");
                            sw.WriteLine("Nom : " + nom);
                            sw.WriteLine("Prénom : " + prenom);
                            sw.WriteLine("Mail : " + mail);
                            sw.WriteLine("Téléphone : " + telephone);
                            sw.WriteLine("Adresse : " + numero + " " + libelle + ", " + codePostal + " " + ville + ", " + pays);
                            sw.WriteLine("----------");
                            sw.WriteLine("MAISON :");
                            sw.WriteLine("Gamme : " + gammeNom);
                            sw.WriteLine("Nombre étages : " + nb_etage);
                            sw.WriteLine("Forme : " + forme);
                            sw.WriteLine("----------");
                            sw.WriteLine("DETAILS :");
                        }

                        cmd.Parameters.Clear();

                        /* récupération des modules et de leur prix */
                        DataSet ds2 = new DataSet();
                        cmd.CommandText = "SELECT module.nom, module.prix, " +
                            "devis_module.nb_module, " +
                            "devis_plan.nu_etage " +
                            "FROM module, devis_module, devis_plan " +
                            "WHERE devis_module.id_module = module.id_module " +
                            "AND devis_module.id_plan = devis_plan.id_devis_plan " +
                            "AND devis_plan.id_devis = @idDevis;";
                        cmd.Parameters.AddWithValue("@idDevis", Session["idDevis"].ToString());
                        da = new System.Data.SQLite.SQLiteDataAdapter(cmd);
                        da.Fill(ds2);
                        int j = 0;
                        double prixTotal = 0;
                        while (j < ds2.Tables[0].Rows.Count)
                        {
                            string moduleNom = ds2.Tables[0].Rows[j].ItemArray[0].ToString();
                            double prix = Convert.ToDouble(ds2.Tables[0].Rows[j].ItemArray[1].ToString());
                            int nb_module = Convert.ToInt32(ds2.Tables[0].Rows[j].ItemArray[2].ToString());
                            string nu_etage = ds2.Tables[0].Rows[j].ItemArray[3].ToString();
                            prixTotal += prix * nb_module;

                            using (StreamWriter sw = new StreamWriter(Server.MapPath("~/" + devisNom + "_" + nom + "_" + prenom + ".txt"), true))
                            {
                                sw.WriteLine("Etage : "+nu_etage+" -> "+nb_module.ToString()+" "+moduleNom+" : "+(prix*nb_module).ToString()+"€");
                            }
                            j++;
                        }
                        using (StreamWriter sw = new StreamWriter(Server.MapPath("~/" + devisNom + "_" + nom + "_" + prenom + ".txt"), true))
                        {
                            sw.WriteLine("----------");
                            sw.WriteLine("COUT TOTAL : "+prixTotal+"€");
                            sw.WriteLine("..........");
                        }
                        i++;
                    }
                }
                con.Close();
            }

            Response.Redirect("/home");
        }
    }
}