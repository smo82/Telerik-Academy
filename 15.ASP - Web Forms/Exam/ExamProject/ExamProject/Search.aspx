<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ExamProject.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="span12">
            <h1>Search Results for Query “<asp:Literal ID="Literal_Query" runat="server" />”:</h1>
        </div>

        <div class="span12 search-results">
            <ul>
                <asp:Repeater runat="server" ID="Repeater_Books" ItemType="ExamProject.Models.Book">
                    <ItemTemplate>
                        <li>
                            <a href="BookDetails.aspx?id=<%#: Item.BookId %>">"<%#: Item.Title %>" <i>by <%#: Item.Author %></i></a> (Category: <%#: Item.Category.CategoryName %>)
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

    <div class="back-link">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
