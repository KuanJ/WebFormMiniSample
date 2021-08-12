using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ucCoverImage : System.Web.UI.UserControl
    {
        public string MyTitle { get; set; }

        public enum BColor
        {
            Blue,
            Red,
            Green
        }
        public BColor BackColor { get; set; } = BColor.Green;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.MyTitle))
            {
                this.litTile.Text = this.MyTitle;
                this.imgCover.Alt = this.MyTitle;
            }
            this.divMain.Style.Add("background-color",this.BackColor.ToString());

            Response.Write("ucCoverImage-Page_Load <br/>");

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("ucCoverImage-Page_Init <br/>");
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("ucCoverImage-Page_PreRender <br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.litTile.Text = "ucCoverImage_Click";
            this.imgCover.Alt = "ucCoverImage_Click";

            Response.Write("ucCoverImage-Button1_Click <br/>");

        }

        public void SetText(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                this.litTile.Text = title;
                this.imgCover.Alt = title;
            }
        }
    }
}