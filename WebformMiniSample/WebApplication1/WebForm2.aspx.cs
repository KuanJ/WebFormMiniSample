using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("WebForm2-Page_Load <br/>");
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("WebForm2-Page_Init <br/>");

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("WebForm2-Page_PreRender <br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("WebForm2-Button1_Click <br/>");

        }
    }
}