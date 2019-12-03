<%@ Page Title="New Article" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewArticle.aspx.cs" Inherits="Final_Project.NewArticle" %>
<asp:Content ID="AddPage" ContentPlaceHolderID="MainContent" runat="server">
    <h2>New Article</h2>
     <div>
        <asp:TextBox runat="server" Id="pagetitle"></asp:TextBox>
    </div>
    <div>
        <asp:TextBox runat="server" Id="pagebody"></asp:TextBox>
    </div>
     <asp:Button OnClick="Add_Page" Text="Publish" runat="server" />
</asp:Content>
