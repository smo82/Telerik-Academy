<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CacheProject.About" %>
<%@ OutputCache Duration="3600" VaryByParam="none" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>Page caching:</h1>
        <br />
        <h2>Date to check cashe: <%= DateTime.Now.ToString() %></h2>
    </hgroup>

</asp:Content>