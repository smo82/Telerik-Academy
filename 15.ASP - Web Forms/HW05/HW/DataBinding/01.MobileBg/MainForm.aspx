<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="_01.MobileBg.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>
                <asp:Label Text="Producer:" runat="server" AssociatedControlID="DropDownProducers" /></strong>
            <asp:DropDownList ID="DropDownProducers" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="DropDownProducers_SelectedIndexChanged"
                DataTextField="Name" DataValueField="Id">
            </asp:DropDownList>
            <br />

            <strong>
                <asp:Label Text="Model:" runat="server" AssociatedControlID="DropDownModels" /></strong>
            <asp:DropDownList ID="DropDownModels" runat="server" DataTextField="Name">
            </asp:DropDownList>
            <br />

            <strong>
                <asp:Label Text="Extras:" runat="server" AssociatedControlID="CheckBoxListExtras" /></strong>
            <asp:CheckBoxList ID="CheckBoxListExtras" runat="server"
                DataTextField="Name">
            </asp:CheckBoxList>

            <br />
            <strong>
                <asp:Label Text="Engine type:" runat="server" AssociatedControlID="RadioButtonListEngineType" /></strong>
            <asp:RadioButtonList ID="RadioButtonListEngineType" runat="server"></asp:RadioButtonList>

            <br />
            <asp:Button ID="ButtonSubmit" runat="server" Text="Process Form Data" OnClick="ButtonSubmit_Click" />

            <br />
            <asp:DetailsView ID="DetailsViewSelection" runat="server" AutoGenerateRows="true" AllowPaging="false">          
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>
