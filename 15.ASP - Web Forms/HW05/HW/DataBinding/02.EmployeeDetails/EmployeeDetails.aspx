<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="_02.EmployeeDetails.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:DetailsView ID="DetailsViewEmployeeDetails" runat="server" 
            AutoGenerateRows="true" AllowPaging="True" 
            onpageindexchanging="DetailsViewEmployeeDetails_PageIndexChanging">            
        </asp:DetailsView>
        <br />
        <asp:LinkButton Text="Back" href="Employees.aspx" runat="server" />
    </div>
    </form>
</body>
</html>
