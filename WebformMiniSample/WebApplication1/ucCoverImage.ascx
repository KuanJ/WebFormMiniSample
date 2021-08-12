<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCoverImage.ascx.cs" Inherits="WebApplication1.ucCoverImage" %>

<div runat="server" style="background-color:aqua" id="divMain">
    <img src="Images/629299414070067200.png" id="imgCover" runat="server"/>
    <span>
        <asp:Literal ID="litTile" runat="server"></asp:Literal>
    </span>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
</div>
