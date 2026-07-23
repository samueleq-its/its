using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrestitiVideoTecaWebForm
{
    public partial class Film : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            string cerca = txtCerca.Text;

            string sql = $"select * from Film where titolo like '%{cerca}%' OR Regista like '%{cerca}%' or Attori like '%{cerca}%' OR Genere like '%{cerca}%'";

            sdsFilm.SelectCommand = sql;
            sdsFilm.DataBind();

        }
    }
}