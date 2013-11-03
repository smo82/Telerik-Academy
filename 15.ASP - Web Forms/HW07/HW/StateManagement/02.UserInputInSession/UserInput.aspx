<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInput.aspx.cs" Inherits="_02.UserInputInSession.UserInput" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label AssociatedControlID="TextBoxUserInput" Text="Your input: " runat="server" />
        <asp:TextBox id="TextBoxUserInput" runat="server" />  
        <br />
        <asp:Button Text="Send input" ID="ButtonSendInput" OnClick="ButtonSendInput_Click" runat="server" />
        <br />
        <hr />

        <strong>Session data:</strong>
        <br />

        <asp:Literal ID="LiteralOutput" runat="server" />
    </form>
</body>
</html>
