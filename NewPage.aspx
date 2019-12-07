<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewPage.aspx.cs" Inherits="Final_Project.NewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- hello, I am a new page -->
    <div>
        <asp:TextBox runat="server" ID="add_pagetitle" Class="input_pagetitle" placeholder="Make a great title"></asp:TextBox>
    </div>
    <div>
        <asp:TextBox runat="server" ID="add_pagebody" Class="input_pagebody" placeholder="Make an equally great body"></asp:TextBox>
    </div>
    <div>
        <label for ="add_authorid">Please enter your ID </label>
        <asp:TextBox runat="server" ID="add_authorid" Class="input_authorid" placeholder="42"></asp:TextBox>
    </div>
     <asp:Button OnClick="Add_Page" Text="Publish" Class="button" runat="server" />
</asp:Content>
