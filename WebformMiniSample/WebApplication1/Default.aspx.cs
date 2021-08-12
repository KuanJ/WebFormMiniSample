using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Main mainMaster = this.Master as Main;
            mainMaster.MyTitle = "預設頁AA";
            mainMaster.SetPageCaption("預設頁");

            this.ucCoverImage1.SetText("第二個uc");
            this.ucCoverImage2.SetText("第三個uc");
        }
    }
}