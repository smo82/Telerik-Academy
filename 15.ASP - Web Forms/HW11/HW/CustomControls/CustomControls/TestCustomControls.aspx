<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCustomControls.aspx.cs" Inherits="CustomControls.TestCustomControls" %>

<%@ Register Src="~/CustomMenu.ascx" TagPrefix="telerik" TagName="CustomMenu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Example for using the control "Custom menu of links"</h1>

    <asp:Panel runat="server" BorderStyle="Groove">
        <form id="form1" runat="server">
            <telerik:CustomMenu runat="server" ID="CustomMenu" />
        </form>
    </asp:Panel>
    <br />
    <hr />
    <br />

    <h2>How to use the control</h2>
    <ol>
        <li>Add the control to your web form</li>
        <li>Set the control Color property</li>
        <li>Set the control FontName property</li>
        <li>Prepare a list of CustomMenuDataItem objects and set it as DataSource for the control</li>
        <li>Call the CustomMenu DataBind method and the control will be populated with your links</li>
    </ol>
    <br />
    <strong>*Note:</strong> The CustomMenuDataItem object is just an object that has 2 properties "Text" and "Url", which are used to populate the corresponding link item.
</body>
</html>
