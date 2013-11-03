<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="_06.Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table runat="server" BorderWidth="1px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:TextBox runat="server" ID="TextBoxResult" />
                        <br /> 
                        <div id="previousValue">
                            <asp:Literal id="LiteralPreviousValue" runat="server" />
                        </div>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Table runat="server" class ="innerLayout">
                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">
                                    <asp:Button Text="1" runat="server" ID="Button1" CommandName="1" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="2" runat="server" ID="Button2" CommandName="2" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="3" runat="server" ID="Button3" CommandName="3" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="+" runat="server" ID="Button4" CommandName="+" OnCommand="OnCommand" />
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">
                                    <asp:Button Text="4" runat="server" ID="Button5" CommandName="4" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="5" runat="server" ID="Button6" CommandName="5" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="6" runat="server" ID="Button7" CommandName="6" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="-" runat="server" ID="Button8" CommandName="-" OnCommand="OnCommand" />
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">
                                    <asp:Button Text="7" runat="server" ID="Button9" CommandName="7" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="8" runat="server" ID="Button10" CommandName="8" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="9" runat="server" ID="Button11" CommandName="9" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="x" runat="server" ID="Button12" CommandName="x" OnCommand="OnCommand" />
                                </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow runat="server">
                                <asp:TableCell runat="server">
                                    <asp:Button Text="Clear" runat="server" ID="Button13" CommandName="Clear" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="0" runat="server" ID="Button14" CommandName="0" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="/" runat="server" ID="Button15" CommandName="/" OnCommand="OnCommand" />
                                </asp:TableCell>
                                <asp:TableCell runat="server">
                                    <asp:Button Text="Sqrt" runat="server" ID="Button16" CommandName="Sqrt" OnCommand="OnCommand" />
                                </asp:TableCell>
                            </asp:TableRow>

                        </asp:Table>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Button Text="=" runat="server" ID="ButtonCalculate" CommandName="=" OnCommand="OnCommand"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <asp:HiddenField ID="HiddenFieldOperation" runat="server" value=""/>
            <asp:HiddenField ID="HiddenFieldPreviousValue" runat="server" value=""/>
        </div>
    </form>
</body>
</html>
