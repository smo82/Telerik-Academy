<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormWithoutViewState.aspx.cs" Inherits="_04.NoViewState.FormWithoutViewState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/Libs/jquery-2.0.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label Text="Enter some input:" AssociatedControlID="TextBoxUserInput" runat="server" />
        <asp:TextBox id="TextBoxUserInput" runat="server" />  
        <br />

        <asp:Button Text="Refresh Page" runat="server" />
        <asp:button runat="server" Text="Remove View State" OnClientClick="removeViewState(); return false" />
        <br />
        <hr />
        <strong>
            <p>
                When you write something in the TextBox and press the "Refresh Page" button, the page is refreshed and your data is still in the TextBox because it is saved in the Hidded Field __VIEWSTATE.
            </p>

            <p>
                If you first click the "Remove View State" button, the __VIEWSTATE field is deleted and after that when you press the "Refresh Page" button and the page refreshes the TextBox is empty.
            </p>
        </strong>
    </form>
    <script>
        function removeViewState(event) {
            $("#__VIEWSTATE").remove();
        }
    </script>
</body>
</html>
