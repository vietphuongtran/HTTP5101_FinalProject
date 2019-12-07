<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_Authors.aspx.cs" Inherits="Final_Project.List_Authors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h1>Authors</h1>
    
        <asp:label for="author_search" runat="server">Search:</asp:label>
        <asp:TextBox ID="author_search" runat="server"></asp:TextBox>
        <asp:Button runat="server" text="submit"/>
        <div id="sql_debugger" runat="server"></div>
    
    <a href="NewAuthor.aspx">New Author</a>
    <div class="_table" runat="server">
        <div class="listitem">
            <div class="col3">First Name</div>
            <div class="col3">Last Name</div>
            <div class="col3last">Modify</div>
        </div>
        <div id="authors_result" runat="server"></div>
    </div>
</asp:Content>
