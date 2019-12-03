<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewPage.aspx.cs" Inherits="Final_Project.NewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- hello, I am a new page -->
    <div>
        <asp:TextBox runat="server" ID="add_pagetitle" placeholder="Make a great title"></asp:TextBox>
    </div>
    <div>
        <asp:TextBox runat="server" ID="add_pagebody" placeholder="Make an equally great body"></asp:TextBox>
    </div>
</asp:Content>
