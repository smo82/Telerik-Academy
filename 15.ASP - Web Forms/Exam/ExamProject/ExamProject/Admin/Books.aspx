<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="ExamProject.LoggedUsers.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Books</h1>

    <asp:GridView runat="server" ID="MainContent_GridViewBooks" CssClass="gridview" AllowPaging="True" AllowSorting="True" PageSize="5"
        ItemType="ExamProject.Models.BookViewModel" AutoGenerateColumns="False" SelectMethod="GridViewBooks_GetData">
        <Columns>
            
            <asp:BoundField DataField="Title" HeaderText="Title"
                SortExpression="Title" />
            <asp:BoundField DataField="Author" HeaderText="Author"
                SortExpression="Author" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN"
                SortExpression="ISBN" />

            <asp:TemplateField HeaderText="Web Site" SortExpression="WebSite" >
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl='<%#: Eval("WebSite") %>' Text='<%#: Eval("WebSite") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="CategoryName" HeaderText="Category"
                SortExpression="CategoryName" />

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton Text="Edit" runat="server" CssClass="link-button"
                        CommandArgument="<%#: Item.BookId %>"
                        OnCommand="Edit_Command" />
                    <asp:LinkButton Text="Delete" runat="server" CssClass="link-button"
                        CommandArgument="<%#: Item.BookId %>"
                        OnCommand="Delete_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="create-link">
        <asp:LinkButton ID="LinkButton_Create" Text="Create" runat="server" CssClass="link-button" OnCommand="Create_Command" />
    </div>

    <asp:Panel runat="server" ID="MainContent_PanelCreate" CssClass="panel">
        <h2>Create New Book</h2>
        <asp:Label Text="" AssociatedControlID="TextBox_CreateTitle" runat="server">
            <span>Title: </span>
            <asp:TextBox runat="server" ID="TextBox_CreateTitle" />
        </asp:Label>
        <asp:Label Text="" AssociatedControlID="TextBox_CreateAuthor" runat="server">
            <span>Author(s): </span>
            <asp:TextBox runat="server" ID="TextBox_CreateAuthor" />
        </asp:Label>
        <asp:Label AssociatedControlID="TextBox_CreateISBN" runat="server">
            <span>ISBN: </span>
            <asp:TextBox runat="server" ID="TextBox_CreateISBN" />
        </asp:Label>
        <asp:Label AssociatedControlID="TextBox_CreateWebSite" runat="server">
            <span>Web site: </span>
            <asp:TextBox runat="server" ID="TextBox_CreateWebSite" />
        </asp:Label>
        <asp:Label AssociatedControlID="TextBox_CreateDescription" runat="server">
            <span>Description: </span>
            <asp:TextBox runat="server" ID="TextBox_CreateDescription" TextMode="MultiLine" Columns="20" Rows="2" style="height:160px;"/>
        </asp:Label>        
        <asp:Label AssociatedControlID="DropDown_CategoriesCreate" runat="server">
            <span>Category: </span>
            <asp:DropDownList ID="DropDown_CategoriesCreate" runat="server" AutoPostBack="false" SelectMethod="DropDownListCategories_GetData"
                DataTextField="CategoryName" DataValueField="CategoryId">
            </asp:DropDownList>
        </asp:Label>
        
        <asp:LinkButton ID="LinkButton_SaveCreate" Text="Create" runat="server" CssClass="link-button" OnCommand="SaveCreate_Command" />
        <asp:LinkButton ID="LinkButton_CancelCreate" Text="Cancel" runat="server" CssClass="link-button" OnCommand="CancelCreate_Command" />
    </asp:Panel>

    <asp:Panel runat="server" ID="MainContent_PanelEdit" CssClass="panel">
        <h2>Edit Book</h2>
        <asp:Label Text="" AssociatedControlID="TextBox_EditTitle" runat="server">
            <span>Title: </span>
            <asp:TextBox runat="server" ID="TextBox_EditTitle" />
        </asp:Label>
        <asp:Label Text="" AssociatedControlID="TextBox_EditAuthor" runat="server">
            <span>Author(s): </span>
            <asp:TextBox runat="server" ID="TextBox_EditAuthor" />
        </asp:Label>
        <asp:Label AssociatedControlID="TextBox_EditISBN" runat="server">
            <span>ISBN: </span>
            <asp:TextBox runat="server" ID="TextBox_EditISBN" />
        </asp:Label>
        <asp:Label AssociatedControlID="TextBox_EditWebSite" runat="server">
            <span>Web site: </span>
            <asp:TextBox runat="server" ID="TextBox_EditWebSite" />
        </asp:Label>
        <asp:Label AssociatedControlID="TextBox_EditDescription" runat="server">
            <span>Description: </span>
            <asp:TextBox runat="server" ID="TextBox_EditDescription" TextMode="MultiLine" Columns="20" Rows="2" style="height:160px;"/>
        </asp:Label>        
        <asp:Label AssociatedControlID="DropDown_CategoriesEdit" runat="server">
            <span>Category: </span>
            <asp:DropDownList ID="DropDown_CategoriesEdit" runat="server" AutoPostBack="false" SelectMethod="DropDownListCategories_GetData"
                DataTextField="CategoryName" DataValueField="CategoryId">
            </asp:DropDownList>
        </asp:Label>

        <asp:LinkButton ID="LinkButton_SaveEdit" Text="Save" runat="server" CssClass="link-button" OnCommand="SaveEdit_Command" />
        <asp:LinkButton ID="LinkButton_CancelEdit" Text="Cancel" runat="server" CssClass="link-button" OnCommand="CancelEdit_Command" />
    </asp:Panel>

    <asp:Panel runat="server" ID="MainContent_PanelDelete" CssClass="panel">
        <h2>Confirm Book Deletion?</h2>
        <asp:Label Text="Title: " AssociatedControlID="TextBox_DeleteTitle" runat="server">
            <asp:TextBox runat="server" ID="TextBox_DeleteTitle" Enabled="false" TextMode="MultiLine" />
        </asp:Label>

        <asp:LinkButton ID="LinkButton_YesDelete" Text="Yes" runat="server" CssClass="link-button" OnCommand="YesDelete_Command" />
        <asp:LinkButton ID="LinkButton_NoDelete" Text="No" runat="server" CssClass="link-button" OnCommand="NoDelete_Command" />
    </asp:Panel>

    <div class="back-link">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
