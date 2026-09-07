using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PrestitiVideotecaWebForm
{
    public partial class Film : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCerca_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sdsFilm.SelectCommand = "Select * from Film Where titolo like '%@Cerca%' OR Regista like '%@Cerca%' OR Attori like '%@Cerca%' OR Genere like '%@Cerca%' ORDER BY [Titolo]";
                
            }                  
            
        }
    }
}