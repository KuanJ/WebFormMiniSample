<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr><th>產品</th><td>
            <asp:DropDownList ID="ddlProduct" runat="server">
                <asp:ListItem Value="001">橘子</asp:ListItem>
                <asp:ListItem Value="002">草莓</asp:ListItem>
                <asp:ListItem Value="003">梨子</asp:ListItem>
            </asp:DropDownList></td></tr>
            <tr><th>單價</th><td>
            <asp:TextBox ID="txtPrice" runat="server" Enabled="false">0</asp:TextBox></td></tr>
            <tr><th>數量</th><td>
            <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number">0</asp:TextBox></td></tr>
        </table>
        <asp:Label ID="lblTotalPrice" runat="server">0</asp:Label><br />
        <asp:Button ID="btnSave" runat="server" Text="Button" OnClick="btnSave_Click"/><br />
        <asp:Label ID="lbMsg" runat="server" Text="Label1">0</asp:Label>
    
        <script>
            //抓取目標
            var ddlProduct = document.getElementById("ddlProduct");
            var txtPrice = document.getElementById("txtPrice");
            var txtQuantity = document.getElementById("txtQuantity");
            var lblTotalPrice = document.getElementById("lblTotalPrice");

            var priceMapping = {
                "001": 50,
                "002": 160,
                "003": 400
            };

            //選擇 下拉式選單時(ddlProduct) 連動到 單價(txtPrice)
            ddlProduct.onchange = function () {
                var productID = ddlProduct.value;
                var price = priceMapping[productID];
                txtPrice.value = price;
            }

            //選好產品，數量填寫後，自動輸出總價至Label(lblTotalPrice)
            txtQuantity.onblur = function () {
                var quantity = parseInt(txtQuantity.value, 10); //parseInt後寫的10為[十進位]
                var price = txtPrice.value;

                var totalPrice = quantity * price;
                lblTotalPrice.innerText = totalPrice;
            }
        </script>
    </form>
</body>
</html>
