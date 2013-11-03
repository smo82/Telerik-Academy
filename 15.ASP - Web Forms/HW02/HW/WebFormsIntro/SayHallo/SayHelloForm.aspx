<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SayHelloForm.aspx.cs" Inherits="SayHallo.SayHelloForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="Your name:" runat="server" AssociatedControlID="TextBoxName"/>
        <asp:TextBox runat="server" id="TextBoxName"/>
        <br />
        <asp:Button Text="ServerSays" runat="server" id="ButtonSayHallo" OnClick="ButtonSayHallo_Click"/>
        <br />  
        The server says:
        <br /> 
        <strong><asp:Literal runat="server" ID="LiteralSayHallo" /></strong>
    </div>
    </form>
</body>
</html>
