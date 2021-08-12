using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        public int ForJSInt { get; set; } = 500;
        public bool ForJSBool { get; set; } = true;
        public string ForJSString { get; set; } = "Hello world.";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.hf2.Value = "Test Message";
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            // 瀏覽器端的警告訊息
            //MessageBox.Show("123");

            //方法1
            //this.lblName.Text = this.txt1.Text;

            //方法2
            this.lblName.Text = this.hf1.Value;

        }
    }
}