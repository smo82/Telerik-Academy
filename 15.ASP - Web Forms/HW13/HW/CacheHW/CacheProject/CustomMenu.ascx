<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomMenu.ascx.cs" Inherits="CacheProject.CustomMenu" %>

<asp:DataList runat="server" id="DataList_Inner" OnItemDataBound="DataList_Inner_ItemDataBound">
    <ItemTemplate>
        <asp:HyperLink ID="DataList_HyperLinkItem" NavigateUrl='<%# Eval("Url") %>' Text='<%# Eval("Text") %>' runat="server" />
    </ItemTemplate>
</asp:DataList>