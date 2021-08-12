using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Try9x9.Models;

namespace Try9x9
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool CheckData(string inpBase, string inpMulti)
        {
            int tempBase, tempMuliti;

            if (!int.TryParse(inpBase, out tempBase))
                return false;

            if (!int.TryParse(inpMulti, out tempMuliti))
                return false;

            if (tempBase < 1 || tempBase > 99)
                return false;

            if (tempMuliti < 1 || tempMuliti > 99)
                return false;

            return true;

        }

        private string BuildCard(int tempBase, int tempMuliti)
        {
            List<string> list = new List<string>();

            for (var i = 1; i <= tempBase; i++)
            {
                string outputMulti = "";
                for (var j = 1; j <= tempMuliti; j++)
                {
                    outputMulti += $"{i} x {j} = {i * j} <br/>";
                }
                list.Add(
                    $@"
                            <div>
                                <div> 基數 {i} * 1</div>
                                <div>
                                    {outputMulti}
                                </div>
                            </div>
                            ");


            }
            string outputText = string.Join(string.Empty, list);
            return outputText;
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            string inp_Base = this.txtBase.Text;
            string inp_Multi = this.txtMulti.Text;
            if (!this.CheckData(inp_Base, inp_Multi))
            {
                this.ltMsg.Text = "輸入錯誤，請輸入1~99.";
                this.ltCards.Text = string.Empty;
                return;
            }
            this.ltMsg.Text = $"{inp_Base} x {inp_Multi}";

            int tempBase = Convert.ToInt32(inp_Base);
            int tempMuliti = Convert.ToInt32(inp_Multi);

            ConnectionDB.Create(tempBase, tempMuliti);

            string resultHtml = this.BuildCard(tempBase, tempMuliti);
            this.ltCards.Text = resultHtml;
        }
    }
}