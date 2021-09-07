<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList" %>

<%@ Register Src="~/UserControls/ucPager2.ascx" TagPrefix="uc1" TagName="ucPager2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnCreate" runat="server" Text="Add Accounting" OnClick="btnCreate_Click" />
    <asp:GridView ID="gvAccountingList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvAccountingList_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
        <alternatingrowstyle backcolor="White" />
        <columns>
            <asp:BoundField HeaderText="標題" DataField="Caption" />
            <asp:BoundField HeaderText="金額" DataField="Amount" />
            <asp:TemplateField HeaderText="In/Out">
                <itemtemplate>
                    <asp:Image ID="imgCover" runat="server" Width="80" Height="50" Visible="false" />
                    <%-- <asp:Image ID="imgCover" runat="server" Visible='<%#Eval("CoverImage") != null %>'
                                        ImageUrl='<%# "../FileDownload/Accounting/" + Eval("CoverImage") %>'--%>

                    <%--<%# ((int)Eval("ActType") == 0) ? "支出" : "收入" %>--%>
                    <asp:Literal ID="ltActType" runat="server"></asp:Literal>

                    <asp:Label ID="lblActType" runat="server"></asp:Label>
                </itemtemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="建立日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Act">
                <itemtemplate>
                    <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                </itemtemplate>
            </asp:TemplateField>
        </columns>
        <editrowstyle backcolor="#2461BF" />
        <footerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
        <headerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
        <pagerstyle backcolor="#2461BF" forecolor="White" horizontalalign="Center" />
        <rowstyle backcolor="#EFF3FB" />
        <selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
        <sortedascendingcellstyle backcolor="#F5F7FB" />
        <sortedascendingheaderstyle backcolor="#6D95E1" />
        <sorteddescendingcellstyle backcolor="#E9EBEF" />
        <sorteddescendingheaderstyle backcolor="#4870BE" />
    </asp:GridView>
    <asp:Literal runat="server" ID="ltPager"></asp:Literal>

    <div>
        <uc1:ucpager2 runat="server" id="ucPager2" pagesize="10" url="/SystemAdmin/AccountingList.aspx" />
    </div>
    <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
        <p>
            No data in your Accounting Note.
        </p>
    </asp:PlaceHolder>
</asp:Content>
