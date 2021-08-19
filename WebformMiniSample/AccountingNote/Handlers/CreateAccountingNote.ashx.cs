using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountingNote.Handlers
{
    /// <summary>
    /// CreateAccountingNote 的摘要描述
    /// </summary>
    public class CreateAccountingNote : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod != "POST")
            {
                this.ProcessError(context, "POST ONLY");
                return;
            }
            string caption = context.Request.Form["Caption"];
            string amountText = context.Request.Form["Amount"];
            string actTypeText = context.Request.Form["ActType"];
            string body = context.Request.Form["Body"];

            // ID of moudou
            string id = "88ff210c-e8c6-475e-8a25-13cf33b8c173";

            if (string.IsNullOrWhiteSpace(caption) ||
                string.IsNullOrWhiteSpace(amountText) ||
                string.IsNullOrWhiteSpace(actTypeText))
            {
                this.ProcessError(context, "caption, amount, actType is required.");
                return;
            }

            //轉型
            int tempAmount, tempActType;
            if (!int.TryParse(amountText, out tempAmount) ||
                !int.TryParse(actTypeText, out tempActType))
            {
                this.ProcessError(context, "Amount, ActType should be a integer.");
                return;
            }

            //建立流水帳
            //AccountingManager.CreatAccounting(id, caption, tempAmount, tempActType, body);

            context.Response.ContentType = "text/plain";
            context.Response.Write("ok");
        }
        private void ProcessError(HttpContext context, string msg)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "text/plain";
            context.Response.Write(msg);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}