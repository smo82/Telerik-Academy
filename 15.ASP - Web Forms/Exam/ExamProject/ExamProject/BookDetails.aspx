<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="ExamProject.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container"></div>
    <asp:FormView runat="server" ID="FormView_Book" ItemType="ExamProject.Models.Book" >
        <HeaderTemplate>
            <h1>Book Details</h1>
            <p class="book-title"><%#: Eval("Title") %></p>
            <p class="book-author"><i>by <%#: Eval("Author") %></i></p>
            <p class="book-isbn" runat="server" visible='<%# Item.WebSite != "" %>'><i>ISBN <%#: Eval("ISBN") %></p>
            <p class="book-website" runat="server" visible='<%# Item.WebSite != "" %>'><i>Web Site <a href="<%#: Eval("WebSite") %>"><%#: Eval("WebSite") %></a></p>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="row-fluid" runat="server" visible='<%# Item.WebSite != "" %>'>
                <div class="span12 book-description">
                    <p><%#: Eval("Description") %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <div class="back-link">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
