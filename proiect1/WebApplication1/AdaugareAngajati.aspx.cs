using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace WebApplication1
{
    public partial class AdaugareAngajat : System.Web.UI.Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSalveaza_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            try
            {
                string nume = txtNume.Text.Trim();
                string prenume = txtPrenume.Text.Trim();
                string functie = txtFunctie.Text.Trim();
                decimal salarBaza = Convert.ToDecimal(txtSalarBaza.Text);
                decimal spor = Convert.ToDecimal(txtSpor.Text);
                decimal premii = Convert.ToDecimal(txtPremii.Text);
                decimal retineri = Convert.ToDecimal(txtRetineri.Text);

                using (OracleConnection conn = new OracleConnection(connString))
                {
                    conn.Open();

                    // Introducem datele de baza. Columnile calculate (TOTAL_BRUT, CAS, CASS, IMPOZIT, VIRAT_CARD) 
                    // vor fi populate automat de trigger-ul 'trg_calcul_salariu' din Oracle!
                    string sql = @"INSERT INTO Angajati (NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, RETINERI) 
                                   VALUES (:nume, :prenume, :functie, :salar, :spor, :premii, :retineri)";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("nume", nume));
                        cmd.Parameters.Add(new OracleParameter("prenume", prenume));
                        cmd.Parameters.Add(new OracleParameter("functie", functie));
                        cmd.Parameters.Add(new OracleParameter("salar", salarBaza));
                        cmd.Parameters.Add(new OracleParameter("spor", spor));
                        cmd.Parameters.Add(new OracleParameter("premii", premii));
                        cmd.Parameters.Add(new OracleParameter("retineri", retineri));

                        cmd.ExecuteNonQuery();
                    }
                }

                // Redirecționăm utilizatorul către pagina de actualizare/afișare a datelor
                Response.Redirect("ActualizareDate.aspx");
            }
            catch (Exception ex)
            {
                lblMesaj.ForeColor = System.Drawing.Color.Red;
                lblMesaj.Text = "Eroare la adăugarea angajatului: " + ex.Message;
            }
        }

        protected void btnRenunta_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActualizareDate.aspx");
        }
    }
}