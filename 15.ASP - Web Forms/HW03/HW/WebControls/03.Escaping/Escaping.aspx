<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="_03.Escaping.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="Input text:" runat="server" AssociatedControlID="TextBoxInputText" /> 
        <asp:TextBox ID="TextBoxInputText" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonEscapeText" runat="server" Text="Escape text" OnClick="ButtonEscapeText_Click" />
        <br />
        <hr />
        <asp:Label Text="Escaped text in a text box:" runat="server" AssociatedControlID="TextBoxEscapedText" /> 
        <asp:TextBox ID="TextBoxEscapedText" runat="server"></asp:TextBox>
        <br />
        Escaped text in a Label:
        <asp:Label ID="LabelEscapedText" Text="" runat="server"/> 
    </div>
    </form>
</body>
</html>
