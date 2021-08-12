using AccountingNote.Auth;
using AccountingNote.DBSource;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;

namespace AccountingNote.SystemAdmin
{
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check is logined
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentUser = AuthManager.GetCurrentUser();

            //string account = this.Session["UserLoginInfo"] as string;
            //var dr = UserInfoManager.GetUserInfoByAccount(account);

            if (currentUser == null)                 //如果帳號不存在，導至登入頁
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }

            // read accounting data
            var dt = AccountingManager.GetAccountingList(currentUser.ID);

            if (dt.Rows.Count > 0)  // check is empty data
            {
                var dtPaged = this.GetPagedDataTable(dt);

                this.ucPager2.TotalSize = dt.Rows.Count;
                this.ucPager2.Bind();

                this.gvAccountingList.DataSource = dtPaged;
                this.gvAccountingList.DataBind();

                //this.ucPager.TotalSize = dt.Rows.Count;
                //this.ucPager.Bind();
            }
            else
            {
                this.gvAccountingList.Visible = false;
                this.plcNoData.Visible = true;
            }
        }


        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;

            if (intPage <= 0)
                return 1;

            return intPage;
        }

        private DataTable GetPagedDataTable(DataTable dt)
        {
            DataTable dtPaged = dt.Clone();
            //int pagesize = 

            int startIndex = (this.GetCurrentPage() - 1) * 10;
            int endIndex = (this.GetCurrentPage()) * 10;

            if (endIndex > dt.Rows.Count)
                endIndex = dt.Rows.Count;

            for (var i = startIndex; i < endIndex; i++)
            {
                DataRow dr = dt.Rows[i];
                var drNew = dtPaged.NewRow();
                foreach (DataColumn dc in dt.Columns)
                {
                    drNew[dc.ColumnName] = dr[dc];
                }
                dtPaged.Rows.Add(drNew);
            }
            return dtPaged;
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AccountingDetail.aspx");

        }
        //不太懂
        protected void gvAccountingList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;
            //Literal ltl = row.FindControl("ltActType") as Literal;

            if (row.RowType == DataControlRowType.DataRow)
            {
                //Literal ltl = row.FindControl("ltActType") as Literal;
                Label lbl = row.FindControl("lblActType") as Label;

                var dr = row.DataItem as DataRowView;
                int actType = dr.Row.Field<int>("ActType");

                if (actType == 0)
                {
                    //ltl.Text = "支出";
                    lbl.Text = "支出";
                }
                else
                {
                    //ltl.Text = "收入";
                    lbl.Text = "收入";
                }

                if (dr.Row.Field<int>("Amount") > 1500)
                {
                    lbl.ForeColor = Color.Red;
                }
            }
        }
    }
}