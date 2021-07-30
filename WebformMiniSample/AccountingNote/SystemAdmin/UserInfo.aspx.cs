using AccountingNote.Auth;
using AccountingNote.DBSource;
using System;
using System.Data;

namespace AccountingNote.SystemAdmin
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)               // 可能是按鈕跳回本頁，所以要判斷PostBack
            {
                if (!AuthManager.IsLogined())   // 如果尚未登入，導致登入頁
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                var currentUser = AuthManager.GetCurrentUser();

                if (currentUser == null)                 //如果帳號不存在，導至登入頁
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

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