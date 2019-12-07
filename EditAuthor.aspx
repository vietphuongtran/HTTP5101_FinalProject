<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAuthor.aspx.cs" Inherits="Final_Project.EditAuthor" %>
<asp:Content ID="EditAuthor" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Editing information about <span id ="show_authorfullname" runat="server"></span></h2>
    <div>Current first name: <span id="show_authorfname" runat="server"></span></div>
    <div>New first name: <asp:TextBox runat="server" ID="edit_authorfname"></asp:TextBox></div>
    <div>Curent last name: <span id="show_authorlname" runat="server"></span></div>
    <div>New last name: <asp:TextBox runat="server" ID="edit_authorlname"></asp:TextBox></div>
    <asp:Button OnClick="Update_Author" Text="Confirm editting" Class="button" runat="server" />
    <div id="editauthor" runat="server"></div>
</asp:Content>
