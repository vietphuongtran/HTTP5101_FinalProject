<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowAuthor.aspx.cs" Inherits="Final_Project.ShowAuthor" %>
<asp:Content ID="ShowAuthor" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Details information about <span id ="show_authorfullname" runat="server"></span></h2>
    <div>First name: <span id="show_authorfname" runat="server"></span></div>
    <div>Last name: <span id="show_authorlname" runat="server"></span></div>
    <div><a href ="EditAuthor.aspx?authorid= + authorid">Edit</a></div>
   <h2>List of articles: </h2>
        <div id ="show_author_article" runat="server"></div>
     
</asp:Content>
