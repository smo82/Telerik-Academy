<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintInfo.aspx.cs" Inherits="_02.AssemblyLocation.PrintInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>Hello, ASP.NET! (From the aspx code)</strong>
            <br />
            <%
                Response.Write("<strong>Hello, ASP.NET! (From C# code in the aspx form)</strong>");
            %>
            <br />
            <br />
            Current assembly location:
            <br />
            <strong>
                <%
                    string currentExecutionPath = GetCurrentAssemblyExecutionPath();
                    Response.Write(currentExecutionPath);
                %>
            </strong>
        </div>
    </form>
</body>
</html>
