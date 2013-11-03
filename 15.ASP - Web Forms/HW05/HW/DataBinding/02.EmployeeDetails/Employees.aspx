<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02.EmployeeDetails.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false" 
            AllowPaging="True" DataKeyNames="EmployeeID" PageSize="5"
            onpageindexchanging="GridViewEmployees_PageIndexChanging">
            <Columns>
                <asp:HyperLinkField HeaderText="Employee" DataTextField="Name" DataNavigateUrlFields="EmployeeID"
                    DataNavigateUrlFormatString="EmployeeDetails.aspx?id={0}" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
