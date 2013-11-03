<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="_03.LoginRedirect.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal id="LiteralLoginInfoOutput" runat="server" />
        <br />

        <asp:Button Text="Login" id="ButtonLogin" OnClick="ButtonLogin_Click" runat="server" />
        <br /> 

        <asp:LinkButton Text="Logged users area" PostBackUrl="LoggedUsersOnly.aspx" runat="server" />
    </form>
</body>
</html>
