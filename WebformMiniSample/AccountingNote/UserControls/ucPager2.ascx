<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPager2.ascx.cs" Inherits="AccountingNote.UserControls.ucPager2" %>
<div>
    <a runat="server" id="aLinkFirst" href="#">First</a>&nbsp;
    <a runat="server" id="aLink1" href="#">1</a> &nbsp;
    <a runat="server" id="aLink2" href="#">2</a> &nbsp;
    <asp:Literal ID="ltlCurrentPage" runat="server"></asp:Literal>
    <a runat="server" id="aLink4" href="#">4</a> &nbsp;
    <a runat="server" id="aLink5" href="#">5</a> &nbsp;
    <a runat="server" id="aLinkLast" href="#">Last</a>&nbsp;
    <asp:Literal ID="ltPager" runat="server"></asp:Literal>
</div>
