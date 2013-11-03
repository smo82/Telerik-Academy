<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeData.aspx.cs" Inherits="_04.EmployeeDetailsFormView.EmployeeData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:FormView ID="FormViewEmployee" runat="server" AllowPaging="True" 
            onpageindexchanging="FormViewEmployee_PageIndexChanging">
            <ItemTemplate>
                <asp:LinkButton Id="LinkButtonDetail" Text='<%#: Eval("FirstName") + " " + Eval("LastName") %>' runat="server" 
                    OnClick="LinkButtonDetail_Click"/>
                <hr />
            </ItemTemplate>
            <EditItemTemplate>
                <h3><%#: Eval("FirstName") + " " + Eval("LastName") %></h3>
                <table border="0">
                    <tr>
                        <td><strong>Title:</strong></td>
                        <td><%#: Eval("Title") %></td>
                    </tr>
                    <tr>
                        <td><strong>Country:</strong></td>
                        <td><%# Eval("Country") %></td>
                    </tr>
                    <tr>
                        <td><strong>City:</strong></td>
                        <td><%# Eval("City") %></td>
                    </tr>
                    <tr>
                        <td><strong>E-Address:</strong></td>
                        <td><%#: Eval("Address") %></td>
                    </tr>
                </table>
                <asp:LinkButton Id="LinkButtonMain" Text="Back" runat="server" 
                    OnClick="LinkButtonMain_Click" />
            </EditItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
