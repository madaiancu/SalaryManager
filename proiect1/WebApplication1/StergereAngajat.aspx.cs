using System;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace WebApplication1
{
    public partial class StergereAngajat : System.Web.UI.Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IncarcaListaAngajati();

                // Daca venim dintr-un link direct cu ID (ex: StergereAngajat.aspx?id=5)
                if (Request.QueryString["id"] != null)
                {
                    string idQuery = Request.QueryString["id"];
                    if (ddlAngajati.Items.FindByValue(idQuery) != null)
                    {
                        ddlAngajati.SelectedValue = idQuery;
                        IncarcaDetaliiAngajat(Convert.ToInt32(idQuery));
                    }
                }
            }
        }

        private void IncarcaListaAngajati()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    string sql = "SELECT ID_ANGAJAT, NUME || ' ' || PRENUME || ' (' || FUNCTIE || ')' AS NUME_COMPLET FROM Angajati ORDER BY NUME, PRENUME";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        ddlAngajati.DataSource = dt;
                        ddlAngajati.DataTextField = "NUME_COMPLET";
                        ddlAngajati.DataValueField = "ID_ANGAJAT";
                        ddlAngajati.DataBind();

                        // Adaugam o optiune implicita la inceput
                        ddlAngajati.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Selectează un angajat --", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                lblMesaj.ForeColor = System.Drawing.Color.Red;
                lblMesaj.Text = "Eroare la încărcarea listei de angajați: " + ex.Message;
            }
        }

        protected void ddlAngajati_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idAngajat = Convert.ToInt32(ddlAngajati.SelectedValue);

            if (idAngajat > 0)
            {
                IncarcaDetaliiAngajat(idAngajat);
            }
            else
            {
                pnlConfirmare.Visible = false;
            }
        }

        private void IncarcaDetaliiAngajat(int idAngajat)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    string sql = "SELECT ID_ANGAJAT, NUME, PRENUME, FUNCTIE, SALAR_BAZA FROM Angajati WHERE ID_ANGAJAT = :id";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("id", idAngajat));

                        conn.Open();
                        using (OracleDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                lblID.Text = dr["ID_ANGAJAT"].ToString();
                                lblNumeComplet.Text = $"{dr["NUME"]} {dr["PRENUME"]}";
                                lblFunctie.Text = dr["FUNCTIE"].ToString();
                                lblSalar.Text = Convert.ToDecimal(dr["SALAR_BAZA"]).ToString("N0");

                                pnlConfirmare.Visible = true;
                                lblMesaj.Text = string.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMesaj.ForeColor = System.Drawing.Color.Red;
                lblMesaj.Text = "Eroare la preluarea detaliilor: " + ex.Message;
            }
        }

        protected void btnSterge_Click(object sender, EventArgs e)
        {
            int idAngajat = Convert.ToInt32(ddlAngajati.SelectedValue);

            if (idAngajat <= 0) return;

            try
            {
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    conn.Open();
                    string sql = "DELETE FROM Angajati WHERE ID_ANGAJAT = :id";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("id", idAngajat));
                        cmd.ExecuteNonQuery();
                    }
                }

                // Redirecționăm înapoi la pagina principală de actualizare/afișare
                Response.Redirect("ActualizareDate.aspx");
            }
            catch (Exception ex)
            {
                lblMesaj.ForeColor = System.Drawing.Color.Red;
                lblMesaj.Text = "Eroare la ștergerea angajatului: " + ex.Message;
            }
        }

        protected void btnRenunta_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActualizareDate.aspx");
        }
    }
}