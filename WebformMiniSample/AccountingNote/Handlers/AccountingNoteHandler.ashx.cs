using AccountingNote.DBSource;
using AccountingNote.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AccountingNote.Handlers
{
    /// <summary>
    /// AccountingNoteHandler 的摘要描述
    /// </summary>
    public class AccountingNoteHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string actionName = context.Request.QueryString["ActionName"];

            if (string.IsNullOrEmpty(actionName))
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain";
                context.Response.Write("ActionName is required");
                context.Response.End();
            }
            if (actionName == "create")
            {
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
                try
                {
                    //建立流水帳
                    AccountingManager.CreatAccounting(id, caption, tempAmount, tempActType, body);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("ok");
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 503;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Error");
                }
            }
            else if (actionName == "update")
            {

            }
            else if (actionName == "delete")
            {

            }
            else if (actionName == "list")
            {
                string userID = "88ff210c-e8c6-475e-8a25-13cf33b8c173";

                DataTable dataTable = AccountingManager.GetAccountingList(userID);

                List<AccountingNoteViewModel> list = new List<AccountingNoteViewModel>();
                foreach (DataRow drAccounting in dataTable.Rows)
                {
                    AccountingNoteViewModel model = new AccountingNoteViewModel()
                    {
                        ID = drAccounting["ID"].ToString(),
                        Caption = drAccounting["Caption"].ToString(),
                        Amount = drAccounting.Field<int>("Amount"),
                        ActType = (drAccounting.Field<int>("ActType") == 0) ? "支出" : "收入",
                        CreateDate = drAccounting.Field<DateTime>("CreateDate").ToString("yyyy-MM-dd")
                    };

                    list.Add(model);
                }
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(list);

                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
            }
            //讀取單筆
            else if (actionName == "query")
            {
                string idText = context.Request.Form["ID"];
                int id;
                int.TryParse(idText, out id);
                string userID = "88ff210c-e8c6-475e-8a25-13cf33b8c173";

                var drAccounting = AccountingManager.GetAccounting(id, userID);

                if (drAccounting == null)
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("No data");
                    context.Response.End();
                }

                AccountingNoteViewModel model = new AccountingNoteViewModel()
                {
                    ID = drAccounting["ID"].ToString(),
                    Caption = drAccounting["Caption"].ToString(),
                    Body = drAccounting["Body"].ToString(),
                    CreateDate = drAccounting.Field<DateTime>("CreateDate").ToString("yyy-MM-dd"),
                    ActType = drAccounting.Field<int>("ActType").ToString(),
                    Amount = drAccounting.Field<int>("Amount")
                };

                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
            }

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