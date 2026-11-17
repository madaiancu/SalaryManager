using System;

namespace WebApplication1
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["contor"] = 10; // Initializam contorul la prima incarcare
                ActualizeazaCeasSiReclame();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ActualizeazaCeasSiReclame();
        }

        private void ActualizeazaCeasSiReclame()
        {
            // Ceasul se actualizeaza la fiecare secunda (tick)
            lblCeas.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Citim contorul din ViewState (daca nu exista, il setam pe 10)
            int contor = ViewState["contor"] != null ? (int)ViewState["contor"] : 10;

            if (contor >= 10)
            {
                Random rnd = new Random();
                int img1 = rnd.Next(1, 3); // Genereaza 1 sau 2 (img1.jpg sau img2.jpg)
                int img2 = rnd.Next(3, 5); // Genereaza 3 sau 4 (img3.jpg sau img4.jpg)

                imgReclama1.ImageUrl = $"~/Imagini/img{img1}.jpg?v={DateTime.Now.Ticks}";
                imgReclama2.ImageUrl = $"~/Imagini/img{img2}.jpg?v={DateTime.Now.Ticks}";

                contor = 0; // Resetam contorul
            }

            contor++;
            ViewState["contor"] = contor; // Salvam noua valoare in ViewState
        }
    }
}