<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowPage.aspx.cs" Inherits="Final_Project.ShowPage" %>
<asp:Content ID="ShowPage" ContentPlaceHolderID="MainContent" runat="server">
   
        <div id="show_pagetitle" runat="server"></div>
        <div id="show_pagebody" runat="server"></div>
        <div id="error_summary" runat="server"></div>
    <div id="edit_page" runat="server"></div>
    <asp:Button OnClick="Delete_Page" Text="Delete" Class="button" runat="server" />
    
</asp:Content>
