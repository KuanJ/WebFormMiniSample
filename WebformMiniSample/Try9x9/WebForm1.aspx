<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Try9x9.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            基數：<asp:TextBox ID="txtBase" runat="server"></asp:TextBox>
            係數：<asp:TextBox ID="txtMulti" runat="server"></asp:TextBox>
            <asp:Button ID="btn" runat="server" Text="Button" OnClick="btn_Click" />
            <asp:Literal runat="server" ID="ltMsg"></asp:Literal>
        </div>
        <div>
            <div">
                <asp:Literal runat="server" ID="ltCards"></asp:Literal>
            </div>
        </div>

    </form>
</body>
</html>
