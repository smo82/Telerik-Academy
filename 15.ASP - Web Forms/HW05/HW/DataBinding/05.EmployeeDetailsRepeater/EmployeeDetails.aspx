<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="_05.EmployeeDetailsRepeater.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th>Name</th>
                    <th>Title</th>
                    <th>Country</th>
                    <th>City</th>
                    <th>Address</th>
                </tr>
                <asp:Repeater ID="RepeaterEmployeeDetail" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#: Eval("FirstName") + " " + Eval("LastName") %>
                            </td>
                            <td>
                                <%#: Eval("Title") %>
                            </td>
                            <td>
                                <%#: Eval("Country") %>
                            </td>
                            <td>
                                <%#: Eval("City") %>
                            </td>
                            <td>
                                <%#: Eval("Address") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>