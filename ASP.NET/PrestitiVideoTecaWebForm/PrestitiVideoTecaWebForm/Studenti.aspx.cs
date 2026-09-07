using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrestitiVideoTecaWebForm
{
    public partial class Studenti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cerca = TextBox1.Text;
                dsStudenti.SelectCommand = $"Select * from Studente where cognome like '%cerca%' or nome like '%cerca%' or classe like '%cerca%'";
                dsStudenti.DataBind();
            }
        }
    }
}