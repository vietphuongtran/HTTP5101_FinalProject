<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_Pages.aspx.cs" Inherits="Final_Project.List_Pages" %>
<asp:Content ID="List_Pages" ContentPlaceHolderID="MainContent" runat="server">
    <div id="search">      
        <asp:TextBox ID="page_search" runat="server" placeholder="Search for an article"></asp:TextBox>
        <asp:Button runat="server" text="Search"/>
        <!-- <div id="sql_debugger" runat="server"></div> -->
    </div>
    <div>
        <a href="NewPage.aspx">New article</a>
    </div>
    <div class="_table" runat="server">
        <div class="listitem">
            <div class="col2"><h2>List of articles</h2></div>
            <div id="side-nav"><h2>Quick Navigation</h2></div>
        </div>
        <div id="pages_result" runat="server"></div>
        <div id="authors" runat="server"></div>
        <div id="quick_nav" runat="server"></div>
    </div>
</asp:Content>