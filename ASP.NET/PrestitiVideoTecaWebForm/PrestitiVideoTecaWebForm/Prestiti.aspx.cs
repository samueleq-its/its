using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrestitiVideoTecaWebForm
{
    public partial class Prestiti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbnNonRestituiti_Click(object sender, EventArgs e)
        {
            // TODO
            sdsPrestiti.SelectCommand = sdsPrestiti.SelectCommand + " where DataRestituzione is not null"; // correggere order by
            sdsPrestiti.DataBind();
        }

        protected void lntArchivio_Click(object sender, EventArgs e)
        {
            // TODO

        }
    }
}