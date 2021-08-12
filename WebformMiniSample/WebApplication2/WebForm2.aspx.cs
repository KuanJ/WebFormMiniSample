using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string product = this.ddlProduct.SelectedValue;
            string quantityText = this.txtQuantity.Text;

            int tempInt;
            if (!int.TryParse(quantityText, out tempInt))
            {
                this.lbMsg.Text = "數量請輸入大於0的整數";
                return;
            }

            if (tempInt <= 0)
            {
                this.lbMsg.Text = "數量請輸入大於0的整數";
                return;
            }

            switch (product)
            {
                case "001":
                    this.lbMsg.Text = $"橘子：共{tempInt * 50} 元";
                    break;
                case "002":
                    this.lbMsg.Text = $"草莓：共{tempInt * 160} 元";
                    break;
                case "003":
                    this.lbMsg.Text = $"梨子：共{tempInt * 400} 元";
                    break;

                default:
                    break;
            }
        }
    }
}