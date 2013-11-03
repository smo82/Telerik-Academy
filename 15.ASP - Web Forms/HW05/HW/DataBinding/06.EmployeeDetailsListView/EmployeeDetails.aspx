<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="_06.EmployeeDetailsListView.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListView ID="ListViewEmployees" runat="server"
            ItemType="Northwind.Data.Employee">
            <LayoutTemplate>
                <h3>Employee</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>

            <ItemTemplate>
                <div class="employee-description">
                    <h4><%#: Item.FirstName %> <%#: Item.LastName %></h4>

                    <strong>Title:</strong> <%#: Eval("Title") %>
                    <br />

                    <strong>Country:</strong> <%#: Eval("Country") %>    
                    <br />

                    <strong>City:</strong> <%#: Eval("City") %>    
                    <br />

                    <strong>Address:</strong> <%#: Eval("Address") %>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <hr /> 
        <asp:DataPager ID="DataPagerEmployees" runat="server" PagedControlID="ListViewEmployees" PageSize="5" QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
    
    </div>
    </form>
</body>
</html>
