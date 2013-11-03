<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageForCacheControl.aspx.cs" Inherits="CacheProject.PageForCacheControl" %>
<%@ OutputCache Duration="10" VaryByParam="none" %>

<%@ Register Src="~/CustomMenu.ascx" TagPrefix="telerik" TagName="CustomMenu" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cashable custom control:</h1>
    <br />
    <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove">
        <h2>The control is cached for 10 seconds: <%= DateTime.Now.ToString() %></h2>
        <telerik:CustomMenu runat="server" ID="CustomMenu" />
    </asp:Panel>
</asp:Content>
