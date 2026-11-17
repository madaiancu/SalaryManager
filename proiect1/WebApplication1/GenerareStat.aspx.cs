using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WebApplication1
{
    public partial class GenerareStat : System.Web.UI.Page
    {
        ReportDocument rpt = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Calea catre fisierul tau .rpt
            string rptPath = Server.MapPath("~/StatDePlata.rpt"); // sau numele fisierului tau .rpt

            rpt.Load(rptPath);

            // Daca raportul se conecteaza direct la Oracle:
            rpt.SetDatabaseLogon(
     System.Configuration.ConfigurationManager.AppSettings["OracleUser"],
     System.Configuration.ConfigurationManager.AppSettings["OraclePassword"]
 );

            // Atribuirea raportului catre viewer-ul din ASPX
            crvStatDePlata.ReportSource = rpt;
            crvStatDePlata.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Eliberarea resurselor
            if (rpt != null)
            {
                rpt.Close();
                rpt.Dispose();
            }
        }
    }
}