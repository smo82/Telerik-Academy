<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.SumNumbersWebForms._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <h1>Sum two numbers (Web Forms)</h1>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Label Text="First Number" AssociatedControlId="tb_firstNumber" runat="server"/>
    <asp:TextBox runat="server" id="tb_firstNumber"/>
    <asp:Label Text="Second Number" runat="server"  AssociatedControlId="tb_secondNumber"/>
    <asp:TextBox runat="server" id="tb_secondNumber"/>
    <br />
    <asp:Button Text="Sum" onclick="ProcessSumClick" runat="server" />
    <br />
    <asp:Label Text="Sum:" AssociatedControlId="sumResult" runat="server" />
    <asp:Literal id="sumResult" Text="" runat="server" />
</asp:Content>
