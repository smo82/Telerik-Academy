<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="_01.RegistrationForm.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel runat="server" GroupingText="Registration information">
                <asp:Label Text="Username:" runat="server" AssociatedControlID="textBoxUsername" />
                <asp:TextBox ID="textBoxUsername" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="The Username field is mandatory!" class="red" Text="*" ControlToValidate="textBoxUsername" runat="server" />
                <br />

                <asp:Label Text="Password:" runat="server" AssociatedControlID="textBoxPassword" />
                <asp:TextBox ID="textBoxPassword" runat="server" type="password" />
                <asp:RequiredFieldValidator ErrorMessage="The Password field is mandatory!" class="red" Text="*" ControlToValidate="textBoxPassword" runat="server" />
                <br />

                <asp:Label Text="Repeat Password:" runat="server" AssociatedControlID="textBoxRepeatPassword" />
                <asp:TextBox ID="textBoxRepeatPassword" runat="server" type="password" />
                <asp:RequiredFieldValidator ErrorMessage="The Repeat password field is mandatory!" class="red" Text="*" ControlToValidate="textBoxRepeatPassword" runat="server" />
                <asp:CompareValidator Text="*" class="red" ErrorMessage="The Password and Repeated password fields are not equal" ControlToCompare="textBoxPassword" ControlToValidate="textBoxRepeatPassword" runat="server" />
                <br />

                <asp:Label Text="First Name:" runat="server" AssociatedControlID="textBoxFirstName" />
                <asp:TextBox ID="textBoxFirstName" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="The First name field is mandatory!" class="red" Text="*" ControlToValidate="textBoxFirstName" runat="server" />
                <br />

                <asp:Label Text="Last Name:" runat="server" AssociatedControlID="textBoxLastName" />
                <asp:TextBox ID="textBoxLastName" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="The Last name field is mandatory!" class="red" Text="*" ControlToValidate="textBoxLastName" runat="server" />
                <br />

                <asp:Label Text="Age:" runat="server" AssociatedControlID="textBoxAge" />
                <asp:TextBox ID="textBoxAge" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="The Age field is mandatory!" class="red" Text="*" ControlToValidate="textBoxAge" runat="server" />
                <asp:RangeValidator Text="*" CssClass="red" ErrorMessage="The age must be between 18 and 81" ControlToValidate="textBoxAge" MinimumValue="18" MaximumValue="81" runat="server" />
                <br />

                <asp:Label Text="E-mail:" runat="server" AssociatedControlID="textBoxEmail" />
                <asp:TextBox ID="textBoxEmail" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="The E-mail field is mandatory!" class="red" Text="*" ControlToValidate="textBoxEmail" runat="server" />
                <asp:RegularExpressionValidator runat="server" class="red" Display="Dynamic" text="*"
                    ErrorMessage="Email address is incorrect!" ControlToValidate="textBoxEmail" 
                    ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
                </asp:RegularExpressionValidator>
                <br />

                <asp:Label Text="Local Address:" runat="server" AssociatedControlID="textBoxLocalAddress" />
                <asp:TextBox ID="textBoxLocalAddress" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="The Local address field is mandatory!" class="red" Text="*" ControlToValidate="textBoxLocalAddress" runat="server" />
                <br />

                <asp:Label Text="Phone:" runat="server" AssociatedControlID="textBoxPhone" />
                <asp:TextBox ID="textBoxPhone" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="The Phone field is mandatory!" class="red" Text="*" ControlToValidate="textBoxPhone" runat="server" />
                <asp:RegularExpressionValidator runat="server" class="red" Display="Dynamic" text="*"
                    ErrorMessage="Phone is incorrect! Only numbers and a leading '+' are allowed." ControlToValidate="textBoxPhone" 
                    ValidationExpression="^\+?[0-9 ]+$">
                </asp:RegularExpressionValidator>
                <br />

                <asp:Label Text="Please check that you accept our terms:" runat="server" AssociatedControlID="checkBoxTerms" />
                <br />
                <asp:CheckBox ID="checkBoxTerms" Text="I Accept" runat="server" />
                <asp:CustomValidator runat="server" EnableClientScript="true" ErrorMessage="Please accept the application terms!"
                    OnServerValidate="CheckBoxTermsRequired_ServerValidate" Text="*" CssClass="red" />
                <br />

                <asp:Button Text="Submit" runat="server" OnClick="ButtonSubmit_Click" />
            </asp:Panel>

            <asp:ValidationSummary runat="server" class="red" />

            <asp:Label ID="LiteralMessage" Text="" runat="server" class="green" />
        </div>
    </form>
</body>
</html>
