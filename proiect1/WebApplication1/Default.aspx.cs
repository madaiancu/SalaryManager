using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace Salarizare
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

            using (OracleConnection conn = new OracleConnection(connString))
            {
                try
                {
                    conn.Open();
                    lblMesaj.Text = "Conexiune la baza de date Oracle reusita!";
                    lblMesaj.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    lblMesaj.Text = "Eroare conexiune: " + ex.Message;
                    lblMesaj.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}