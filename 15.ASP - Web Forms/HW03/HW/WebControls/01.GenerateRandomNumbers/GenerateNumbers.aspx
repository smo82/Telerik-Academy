<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateNumbers.aspx.cs" Inherits="_01.GenerateRandomNumbers.GenerateNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formGenerateNumbers" runat="server">
    <div>    
        <label for="TextBoxLowerBorder">The lower border of the range:</label>
        <input id="TextBoxLowerBorder" type="text" runat="server"/>
        <br />

        <label for="TextBoxUpperBorder">The upper border of the range:</label>
        <input id="TextBoxUpperBorder" type="text" runat="server"/>
        <br />

        <input id="ButtonGenerateNumbers" type="button" value="Generate Numbers" onserverclick="ButtonGenerateNumbers_Click" runat="server"/>
        <br />
        <div runat="server" ID="PanelWithNumbers" runat="server"></div>
    </div>
    </form>
</body>
</html>
