<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <th>Account</th>
            <td>
                <asp:Literal ID="ltAccount" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>Name</th>
            <td>
                <asp:Literal ID="ltName" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>Email</th>
            <td>
                <asp:Literal ID="LtEmail" runat="server"></asp:Literal>
            </td>   
        </tr>
    </table>
    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
</asp:Content>
