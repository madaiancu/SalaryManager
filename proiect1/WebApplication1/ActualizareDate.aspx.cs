using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;

namespace WebApplication1
{
    public partial class ActualizareDate : System.Web.UI.Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;

        // Proprietate pentru retenția expresiei de sortare curentă
        private string SortExpression
        {
            get { return ViewState["SortExpression"] as string ?? "NUME"; }
            set { ViewState["SortExpression"] = value; }
        }

        // Proprietate pentru direcția de sortare (ASC / DESC)
        private string SortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IncarcaAngajati();
            }
        }

        private void IncarcaAngajati(string filtru = "")
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    string sql = @"SELECT ID_ANGAJAT, NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, 
                                          RETINERI, BRUT_IMPOZABIL, TOTAL_BRUT, CAS, CASS, IMPOZIT, VIRAT_CARD 
                                   FROM Angajati";

                    if (!string.IsNullOrEmpty(filtru))
                    {
                        sql += " WHERE UPPER(NUME) LIKE :filtru OR UPPER(PRENUME) LIKE :filtru";
                    }

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(filtru))
                        {
                            cmd.Parameters.Add(new OracleParameter("filtru", $"%{filtru.ToUpper()}%"));
                        }

                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Aplicam sortarea dinamica direct pe DataView
                        DataView dv = dt.DefaultView;
                        dv.Sort = $"{SortExpression} {SortDirection}";

                        gvAngajati.DataSource = dv;
                        gvAngajati.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMesaj.Text = "Eroare la încărcarea datelor: " + ex.Message;
            }
        }

        // Handler apelat automat când se dă click pe oricare antet de coloană
        protected void gvAngajati_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (SortExpression == e.SortExpression)
            {
                // Daca se apasa din nou pe aceeasi coloana, se schimba sensul (ASC <-> DESC)
                if (SortDirection == "ASC")
                    SortDirection = "DESC";
                else
                    SortDirection = "ASC";
            }
            else
            {
                SortExpression = e.SortExpression;
                SortDirection = "ASC";
            }

            IncarcaAngajati(txtCautare.Text.Trim());
        }

        protected void btnCauta_Click(object sender, EventArgs e)
        {
            IncarcaAngajati(txtCautare.Text.Trim());
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtCautare.Text = string.Empty;
            IncarcaAngajati();
        }

        protected void gvAngajati_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAngajati.EditIndex = e.NewEditIndex;
            IncarcaAngajati(txtCautare.Text.Trim());
        }

        protected void gvAngajati_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAngajati.EditIndex = -1;
            IncarcaAngajati(txtCautare.Text.Trim());
        }

        protected void gvAngajati_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int idAngajat = Convert.ToInt32(gvAngajati.DataKeys[e.RowIndex].Value);
                GridViewRow row = gvAngajati.Rows[e.RowIndex];

                string nume = ((TextBox)row.Cells[1].Controls[0]).Text.Trim();
                string prenume = ((TextBox)row.Cells[2].Controls[0]).Text.Trim();
                string functie = ((TextBox)row.Cells[3].Controls[0]).Text.Trim();
                decimal salarBaza = Convert.ToDecimal(((TextBox)row.Cells[4].Controls[0]).Text);
                decimal spor = Convert.ToDecimal(((TextBox)row.Cells[5].Controls[0]).Text);
                decimal premii = Convert.ToDecimal(((TextBox)row.Cells[6].Controls[0]).Text);
                decimal retineri = Convert.ToDecimal(((TextBox)row.Cells[7].Controls[0]).Text);

                using (OracleConnection conn = new OracleConnection(connString))
                {
                    conn.Open();
                    string sql = @"UPDATE Angajati SET 
                                    NUME = :nume, 
                                    PRENUME = :prenume, 
                                    FUNCTIE = :functie, 
                                    SALAR_BAZA = :salar, 
                                    SPOR = :spor, 
                                    PREMII_BRUTE = :premii, 
                                    RETINERI = :retineri 
                                  WHERE ID_ANGAJAT = :id";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("nume", nume));
                        cmd.Parameters.Add(new OracleParameter("prenume", prenume));
                        cmd.Parameters.Add(new OracleParameter("functie", functie));
                        cmd.Parameters.Add(new OracleParameter("salar", salarBaza));
                        cmd.Parameters.Add(new OracleParameter("spor", spor));
                        cmd.Parameters.Add(new OracleParameter("premii", premii));
                        cmd.Parameters.Add(new OracleParameter("retineri", retineri));
                        cmd.Parameters.Add(new OracleParameter("id", idAngajat));

                        cmd.ExecuteNonQuery();
                    }
                }

                gvAngajati.EditIndex = -1;
                IncarcaAngajati(txtCautare.Text.Trim());
            }
            catch (Exception ex)
            {
                lblMesaj.Text = "Eroare la salvarea datelor: " + ex.Message;
            }
        }
    }
}