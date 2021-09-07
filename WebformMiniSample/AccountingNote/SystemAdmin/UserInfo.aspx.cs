using AccountingNote.Auth;
using AccountingNote.DBSource;
using System;
using System.Data;

namespace AccountingNote.SystemAdmin
{
    public partial class UserInfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)               // 可能是按鈕跳回本頁，所以要判斷PostBack
            {
                var currentUser = AuthManager.GetCurrentUser();

                this.ltAccount.Text = currentUser.Account;
                this.ltName.Text = currentUser.Name;
                this.LtEmail.Text = currentUser.Email;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            AuthManager.Logout();         //清除登入資訊，導至登入頁
            Response.Redirect("/Login.aspx");
        }
    }
}