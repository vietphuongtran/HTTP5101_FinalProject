<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="Final_Project.EditPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id ="editpage" runat="server"></div>
    <div id="show_pagetitle" runat="server"></div>
    <div>
        <asp:TextBox runat="server" ID="edit_pagetitle" Class="input_pagetitle" placeholder="Make a great title"></asp:TextBox>
    </div>
     <div id="show_pagebody" runat="server"></div>
    <div>
        <asp:TextBox runat="server" ID="edit_pagebody" Class="input_pagebody" placeholder="Make an equally great body"></asp:TextBox>
    </div>
     <asp:Button OnClick="Update_Page" Text="Publish" Class="button" runat="server" />
</asp:Content>