<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_Pages.aspx.cs" Inherits="Final_Project.List_Pages" %>
<asp:Content ID="List_Pages" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:label for="page_search" runat="server">Search:</asp:label>
        <asp:TextBox ID="page_search" runat="server" placeholder="Search for an article"></asp:TextBox>
        <asp:Button runat="server" text="Search"/>
        <div id="sql_debugger" runat="server"></div>
    </div>
    <div>
        <a href="NewArticle.aspx">New article</a>
    </div>
    <div class="_table" runat="server">
        <div class="listitem">
            <div class="col2">List of articles</div>
            <div id="side-nav">Quick Navigation</div>
        </div>
        <div id="pages_result" runat="server"></div>
        <div id="quick_nav" runat="server"></div>
    </div>
</asp:Content>
