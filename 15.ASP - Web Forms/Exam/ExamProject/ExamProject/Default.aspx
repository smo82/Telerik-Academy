<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExamProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView runat="server" SelectMethod="ListViewBooks_GetData" ItemType="ExamProject.Models.Category" GroupItemCount="3"
        ID="ListViewBooks">
        <LayoutTemplate>
            <div class="row">
                <div class="span1">
                    <h1>Books</h1>
                </div>
                <div class="search-button">
                    <div class="form-search">
                        <asp:TextBox ID="TextBox_SearchField" runat="server" CssClass="span3 search-query" />
                        <asp:LinkButton ID="LinkButton_Search" Text="Search" runat="server" CssClass="btnn" OnCommand="Search_Command" />
                    </div>
                </div>
            </div>
            <div id="groupPlaceholder" runat="server"></div>
        </LayoutTemplate>

        <GroupTemplate>
            <div class="row">
                <div id="itemPlaceholder" runat="server">
                </div>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="span4">
                <h2><%#: Item.CategoryName %></h2>
                <ul>
                    <asp:Repeater runat="server" ItemType="ExamProject.Models.Book" DataSource="<%# Item.Books %>">
                        <ItemTemplate>
                            <li>
                                <a href="BookDetails.aspx?id=<%# Item.BookId %>">"<%#: Item.Title %>" by <%#: Item.Author %></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <i runat="server" visible='<%# Item.Books.Count == 0 %>'>No books in this category. </i>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
