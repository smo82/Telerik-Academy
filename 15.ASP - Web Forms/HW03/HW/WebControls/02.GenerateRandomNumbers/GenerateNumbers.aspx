<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateNumbers.aspx.cs" Inherits="_02.GenerateRandomNumbers.GenerateNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="formGenerateNumbers" runat="server">
    <div>    
        <asp:Label ID="Label1" Text="The lower border of the range:" runat="server" AssociatedControlID="TextBoxLowerBorder" /> 
        <asp:TextBox ID="TextBoxLowerBorder" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label2" Text="The upper border of the range:" runat="server" AssociatedControlID="TextBoxUpperBorder" /> 
        <asp:TextBox ID="TextBoxUpperBorder" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="ButtonGenerateNumbers" runat="server" Text="Generate Numbers" OnClick="ButtonGenerateNumbers_Click" />
        <br />
        <asp:Panel runat="server" ID="PanelWithNumbers"></asp:Panel>
    </div>
    </form>
</body>
</html>
