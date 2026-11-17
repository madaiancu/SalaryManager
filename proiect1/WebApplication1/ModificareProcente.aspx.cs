
using System;
using System.Configuration;
using System.Globalization;
using System.Security.Cryptography;
using Oracle.ManagedDataAccess.Client;

namespace WebApplication1
{
    public partial class ModificareProcente : System.Web.UI.Page
    {
        private string connString =
            ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        private const int Iteratii = 100000;

        private string GenereazaHash(string parola, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                parola, salt, Iteratii, HashAlgorithmName.SHA256))
            {
                return Convert.ToBase64String(pbkdf2.GetBytes(32));
            }
        }

        private bool ComparaHash(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            int diferenta = 0;

            for (int i = 0; i < a.Length; i++)
            {
                diferenta |= a[i] ^ b[i];
            }

            return diferenta == 0;
        }

      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                IncarcaProcenteCurente();
            }
        }

        private void IncarcaProcenteCurente()
        {
            try
            {
                using (var conn = new OracleConnection(connString))
                {
                    conn.Open();

                    using (var cmd = new OracleCommand(
                        "SELECT CAS, CASS, IMPOZIT FROM SETARI WHERE ID = 1",
                        conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtCAS.Text =
                                (Convert.ToDecimal(reader["CAS"]) * 100)
                                .ToString("0.##");

                            txtCASS.Text =
                                (Convert.ToDecimal(reader["CASS"]) * 100)
                                .ToString("0.##");

                            txtImpozit.Text =
                                (Convert.ToDecimal(reader["IMPOZIT"]) * 100)
                                .ToString("0.##");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Eroare la incarcare: " + ex.Message;
            }
        }

        protected void btnSalveaza_Click(object sender, EventArgs e)
        {
            try
            {
                string parola = txtParola.Text;

                if (string.IsNullOrWhiteSpace(parola))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Introduceti parola!";
                    return;
                }

                using (var conn = new OracleConnection(connString))
                {
                    conn.Open();

                    string parolaSalvata;

                    using (var cmd = new OracleCommand(
                        "SELECT PAROLA_CRIPTATA FROM SETARI WHERE ID = 1",
                        conn))
                    {
                        parolaSalvata = Convert.ToString(cmd.ExecuteScalar());
                    }

                    string[] parti = parolaSalvata.Split(':');

                    if (parti.Length != 2)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Parola nu este initializata!";
                        return;
                    }

                    byte[] salt = Convert.FromBase64String(parti[0]);

                    byte[] hashCalculat = Convert.FromBase64String(
                        GenereazaHash(parola, salt));

                    byte[] hashSalvat = Convert.FromBase64String(parti[1]);

                    if (!ComparaHash(hashCalculat, hashSalvat))
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Parola incorecta!";
                        return;
                    }

                    decimal cas = decimal.Parse(
                        txtCAS.Text.Replace(',', '.'),
                        CultureInfo.InvariantCulture) / 100;

                    decimal cass = decimal.Parse(
                        txtCASS.Text.Replace(',', '.'),
                        CultureInfo.InvariantCulture) / 100;

                    decimal impozit = decimal.Parse(
                        txtImpozit.Text.Replace(',', '.'),
                        CultureInfo.InvariantCulture) / 100;

                    if (cas < 0 || cas > 1 ||
                        cass < 0 || cass > 1 ||
                        impozit < 0 || impozit > 1)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text =
                            "Procentele trebuie sa fie intre 0 si 100!";
                        return;
                    }

                    using (var cmd = new OracleCommand(
                        @"UPDATE SETARI
                          SET CAS = :cas,
                              CASS = :cass,
                              IMPOZIT = :impozit
                          WHERE ID = 1",
                        conn))
                    {
                        cmd.BindByName = true;

                        cmd.Parameters.Add(
                            "cas", OracleDbType.Decimal).Value = cas;

                        cmd.Parameters.Add(
                            "cass", OracleDbType.Decimal).Value = cass;

                        cmd.Parameters.Add(
                            "impozit", OracleDbType.Decimal).Value = impozit;

                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text =
                    "Procentele au fost actualizate cu succes!";

                txtParola.Text = "";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Eroare: " + ex.Message;
            }
        }
    }
}
