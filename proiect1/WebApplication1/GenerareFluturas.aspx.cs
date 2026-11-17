using System;
using System.Configuration;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using Oracle.ManagedDataAccess.Client;

namespace WebApplication1
{
    public partial class GenerareFluturas : System.Web.UI.Page
    {
        ReportDocument rpt = new ReportDocument();
        private string connString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IncarcaAngajati();
            }

            IncarcaRaportFluturas();
        }

        private void IncarcaAngajati()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    conn.Open();
                    // Interogare adaptata la ID_ANGAJAT
                    string query = "SELECT ID_ANGAJAT, NUME || ' ' || PRENUME AS NUME_COMPLET FROM ANGAJATI ORDER BY NUME";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            ddlAngajati.DataSource = dt;
                            ddlAngajati.DataTextField = "NUME_COMPLET";
                            ddlAngajati.DataValueField = "ID_ANGAJAT";
                            ddlAngajati.DataBind();

                            ddlAngajati.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Selectează un Angajat --", "0"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblEroare.Text = "Eroare la încărcarea listei de angajați: " + ex.Message;
            }
        }

        private void IncarcaRaportFluturas()
        {
            try
            {
                string rptPath = Server.MapPath("~/FluturasSalariu.rpt");

                if (!System.IO.File.Exists(rptPath))
                {
                    return;
                }

                // 1. Încarcă raportul .rpt
                rpt.Load(rptPath);

                // 2. Autentificare simplă la Oracle
                rpt.SetDatabaseLogon(
    System.Configuration.ConfigurationManager.AppSettings["OracleUser"],
    System.Configuration.ConfigurationManager.AppSettings["OraclePassword"]
);

                // 3. Filtrare exactă pe coloana ID_ANGAJAT din Oracle
                if (ddlAngajati.SelectedValue != null && ddlAngajati.SelectedValue != "0")
                {
                    rpt.RecordSelectionFormula = "{ANGAJATI.ID_ANGAJAT} = " + ddlAngajati.SelectedValue;
                }
                else
                {
                    rpt.RecordSelectionFormula = "";
                }

                // 4. Afișare în viewer
                crvFluturas.ReportSource = rpt;
                crvFluturas.DataBind();
            }
            catch (Exception ex)
            {
                lblEroare.Text = "Eroare la generarea fluturașului: " + ex.Message;
            }
        }

        protected void ddlAngajati_SelectedIndexChanged(object sender, EventArgs e)
        {
            IncarcaRaportFluturas();
        }

        protected void btnToate_Click(object sender, EventArgs e)
        {
            ddlAngajati.SelectedValue = "0";
            IncarcaRaportFluturas();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (rpt != null)
            {
                rpt.Close();
                rpt.Dispose();
            }
        }
    }
}