<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolForm.aspx.cs" Inherits="_04.SchollForm.SchoolForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>School registration form</h1>
        <asp:Label Text="First name:" runat="server" AssociatedControlID="TextBoxFirstName" /> 
        <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
        <br />

        <asp:Label Text="Last name:" runat="server" AssociatedControlID="TextBoxLastName" /> 
        <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
        <br />

        <asp:Label Text="Faculty number:" runat="server" AssociatedControlID="TextBoxFacultyNumber" /> 
        <asp:TextBox ID="TextBoxFacultyNumber" runat="server"></asp:TextBox>
        <br />

        <asp:Label Text="University:" runat="server" AssociatedControlID="DropDownListUniversity" /> 
        <asp:DropDownList ID="DropDownListUniversity" runat="server">
            <asp:ListItem Value="Sofia University">Sofia University</asp:ListItem>
            <asp:ListItem Value="Telerik Academy">Telerik Academy</asp:ListItem>
        </asp:DropDownList>
        <br />

        <asp:Label Text="Specialty:" runat="server" AssociatedControlID="DropDownListSpecialty" /> 
        <asp:DropDownList ID="DropDownListSpecialty" runat="server">
            <asp:ListItem Value="Web development">Web development</asp:ListItem>
            <asp:ListItem Value="Backend development">Backend development</asp:ListItem>
        </asp:DropDownList>
        <br />

        <asp:Label Text="Courses:" runat="server" AssociatedControlID="ListBoxCourses" /> 
        <br />
        <asp:ListBox ID="ListBoxCourses" runat="server" SelectionMode="Multiple">
            <asp:ListItem Value="C#">C#</asp:ListItem>
            <asp:ListItem Value="Java Script">Java Script</asp:ListItem>
            <asp:ListItem Value="HTML">HTML</asp:ListItem>
            <asp:ListItem Value="CSS">CSS</asp:ListItem>
            <asp:ListItem Value="ASP">ASP</asp:ListItem>
        </asp:ListBox>
        <br />        

        <asp:Button ID="ButtonSubmitForm" runat="server" Text="Submit form" OnClick="ButtonSubmitForm_Click" />
        <hr />
        <asp:Panel ID="PanelOutput" runat="server"></asp:Panel>
    </div>
    </form>
</body>
</html>
