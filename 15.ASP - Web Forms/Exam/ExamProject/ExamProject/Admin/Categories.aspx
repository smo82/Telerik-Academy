<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="ExamProject.LoggedUsers.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>

    <asp:GridView runat="server" ID="GridViewCategories" CssClass="gridview" AllowPaging="True" AllowSorting="True" PageSize="5"
        ItemType="ExamProject.Models.Category" AutoGenerateColumns="False" SelectMethod="GridViewCategories_GetData">
        <Columns>

            <asp:BoundField DataField="CategoryName" HeaderText="Category Name"
                SortExpression="CategoryName" />

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton Text="Edit" runat="server" CssClass="link-button"
                        CommandArgument="<%#: Item.CategoryId %>"
                        OnCommand="Edit_Command" />
                    <asp:LinkButton Text="Delete" runat="server" CssClass="link-button"
                        CommandArgument="<%#: Item.CategoryId %>"
                        OnCommand="Delete_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="create-link">
        <asp:LinkButton ID="LinkButton_Create" Text="Create" runat="server" CssClass="link-button" OnCommand="Create_Command" />
    </div>

    <asp:Panel runat="server" ID="MainContent_PanelCreate" CssClass="panel">
        <h2>Create New Category</h2>
        <asp:Label Text="Category: " AssociatedControlID="TextBox_CreateCategoryName" runat="server">
            <asp:TextBox runat="server" ID="TextBox_CreateCategoryName" />
        </asp:Label><asp:LinkButton ID="LinkButton_SaveCreate" Text="Create" runat="server" CssClass="link-button" OnCommand="SaveCreate_Command" />
        <asp:LinkButton ID="LinkButton_CancelCreate" Text="Cancel" runat="server" CssClass="link-button" OnCommand="CancelCreate_Command" />
    </asp:Panel>

    <asp:Panel runat="server" ID="MainContent_PanelEdit" CssClass="panel">
        <h2>Edit Category</h2><asp:Label Text="Category: " AssociatedControlID="TextBox_CategoryName" runat="server">
            <asp:TextBox runat="server" ID="TextBox_CategoryName" />
        </asp:Label><asp:LinkButton ID="LinkButton_SaveEdit" Text="Save" runat="server" CssClass="link-button" OnCommand="SaveEdit_Command" />
        <asp:LinkButton ID="LinkButton_CancelEdit" Text="Cancel" runat="server" CssClass="link-button" OnCommand="CancelEdit_Command" />
    </asp:Panel>

    <asp:Panel runat="server" ID="MainContent_PanelDelete" CssClass="panel">
        <h2>Confirm Category Deletion?</h2><asp:Label Text="Category: " AssociatedControlID="TextBox_DeleteCategoryName" runat="server">
            <asp:TextBox runat="server" ID="TextBox_DeleteCategoryName" Enabled="false" />
        </asp:Label><asp:LinkButton ID="LinkButton_YesDelete" Text="Yes" runat="server" CssClass="link-button" OnCommand="YesDelete_Command" />
        <asp:LinkButton ID="LinkButton_NoDelete" Text="No" runat="server" CssClass="link-button" OnCommand="NoDelete_Command" />
    </asp:Panel>

    <div class="back-link">
        <a href="/">Back to books</a> </div></asp:Content>