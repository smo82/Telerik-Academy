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
            <asp:Panel runat="server" GroupingText="Login information">
                <asp:Label Text="Username:" runat="server" AssociatedControlID="textBoxUsername" />
                <asp:TextBox ID="textBoxUsername" runat="server" ValidationGroup="ValidationGroupLogin" />
                <asp:RequiredFieldValidator ErrorMessage="The Username field is mandatory!" ValidationGroup="ValidationGroupLogin" class="red" ControlToValidate="textBoxUsername" runat="server" />
                <br />

                <asp:Label Text="Password:" runat="server" AssociatedControlID="textBoxPassword" />
                <asp:TextBox ID="textBoxPassword" runat="server" type="password" ValidationGroup="ValidationGroupLogin" />
                <asp:RequiredFieldValidator ErrorMessage="The Password field is mandatory!" ValidationGroup="ValidationGroupLogin" class="red" ControlToValidate="textBoxPassword" runat="server" />
                <br />

                <asp:Label Text="Repeat Password:" runat="server" AssociatedControlID="textBoxRepeatPassword" />
                <asp:TextBox ID="textBoxRepeatPassword" runat="server" type="password" ValidationGroup="ValidationGroupLogin" />
                <asp:RequiredFieldValidator ErrorMessage="The Repeat password field is mandatory!" ValidationGroup="ValidationGroupLogin" class="red" ControlToValidate="textBoxRepeatPassword" runat="server" />
                <asp:CompareValidator class="red" ValidationGroup="ValidationGroupLogin" ErrorMessage="The Password and Repeated password fields are not equal" ControlToCompare="textBoxPassword" ControlToValidate="textBoxRepeatPassword" runat="server" />
                <br />

                <asp:Button ID="ButtonValidateLogin" Text="Validate login information" runat="server" OnClick="ButtonValidateLogin_Click" />
                <asp:Label ID="LableLoginValidMessage" Text="" runat="server" class="green" />
            </asp:Panel>
            <asp:Panel runat="server" GroupingText="Personal information">
                <asp:Label Text="First Name:" runat="server" AssociatedControlID="textBoxFirstName" />
                <asp:TextBox ID="textBoxFirstName" runat="server" ValidationGroup="ValidationGroupPersonalInformation" />
                <asp:RequiredFieldValidator ErrorMessage="The First name field is mandatory!" ValidationGroup="ValidationGroupPersonalInformation" class="red" ControlToValidate="textBoxFirstName" runat="server" />
                <br />

                <asp:Label Text="Last Name:" runat="server" AssociatedControlID="textBoxLastName" />
                <asp:TextBox ID="textBoxLastName" runat="server" ValidationGroup="ValidationGroupPersonalInformation"  />
                <asp:RequiredFieldValidator ErrorMessage="The Last name field is mandatory!" ValidationGroup="ValidationGroupPersonalInformation" class="red" ControlToValidate="textBoxLastName" runat="server" />
                <br />

                <asp:Label Text="Age:" runat="server" AssociatedControlID="textBoxAge" />
                <asp:TextBox ID="textBoxAge" runat="server" ValidationGroup="ValidationGroupPersonalInformation"  />
                <asp:RequiredFieldValidator ErrorMessage="The Age field is mandatory!" ValidationGroup="ValidationGroupPersonalInformation" class="red" ControlToValidate="textBoxAge" runat="server" />
                <asp:RangeValidator CssClass="red" ErrorMessage="The age must be between 18 and 81" ValidationGroup="ValidationGroupPersonalInformation" ControlToValidate="textBoxAge" MinimumValue="18" MaximumValue="81" runat="server" />
                <br />
                <asp:Button ID="ButtonValidatePersonalInformation" Text="Validate Personal Information" runat="server" OnClick="ButtonValidatePersonalInformation_Click" />
                <asp:Label ID="LablePersonalInformationValidMessage" Text="" runat="server" class="green" />
            </asp:Panel>
            <asp:Panel runat="server" GroupingText="Address information">
                <asp:Label Text="E-mail:" runat="server" AssociatedControlID="textBoxEmail" />
                <asp:TextBox ID="textBoxEmail" runat="server" ValidationGroup="ValidationGroupAddressInformation" />
                <asp:RequiredFieldValidator ErrorMessage="The E-mail field is mandatory!" ValidationGroup="ValidationGroupAddressInformation" class="red" ControlToValidate="textBoxEmail" runat="server" />
                <asp:RegularExpressionValidator runat="server" class="red" Display="Dynamic" ValidationGroup="ValidationGroupAddressInformation"
                    ErrorMessage="Email address is incorrect!" ControlToValidate="textBoxEmail"
                    ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
                </asp:RegularExpressionValidator>
                <br />

                <asp:Label Text="Local Address:" runat="server" AssociatedControlID="textBoxLocalAddress" />
                <asp:TextBox ID="textBoxLocalAddress" runat="server" ValidationGroup="ValidationGroupAddressInformation" />
                <asp:RequiredFieldValidator ErrorMessage="The Local address field is mandatory!" ValidationGroup="ValidationGroupAddressInformation" class="red" ControlToValidate="textBoxLocalAddress" runat="server" />
                <br />

                <asp:Label Text="Phone:" runat="server" AssociatedControlID="textBoxPhone" />
                <asp:TextBox ID="textBoxPhone" runat="server" ValidationGroup="ValidationGroupAddressInformation" />
                <asp:RequiredFieldValidator ValidationGroup="ValidationGroupAddressInformation" ErrorMessage="The Phone field is mandatory!" class="red" ControlToValidate="textBoxPhone" runat="server" />
                <asp:RegularExpressionValidator runat="server" class="red" Display="Dynamic" ValidationGroup="ValidationGroupAddressInformation"
                    ErrorMessage="Phone is incorrect! Only numbers and a leading '+' are allowed." ControlToValidate="textBoxPhone"
                    ValidationExpression="^\+?[0-9 ]+$">
                </asp:RegularExpressionValidator>
                <br />

                <asp:Label Text="Please check that you accept our terms:" runat="server" AssociatedControlID="checkBoxTerms" />
                <br />
                <asp:CheckBox ID="checkBoxTerms" Text="I Accept" runat="server"  ValidationGroup="ValidationGroupAddressInformation"/>
                <asp:CustomValidator runat="server" EnableClientScript="true" ErrorMessage="Please accept the application terms!"
                    OnServerValidate="CheckBoxTermsRequired_ServerValidate" CssClass="red"  ValidationGroup="ValidationGroupAddressInformation"/>

                <br />
                <asp:Button ID="ButtonValidateAddressInformation" Text="Validate Address Information" runat="server" OnClick="ButtonValidateAddressInformation_Click" />
                <asp:Label ID="LableAddressInformationValidMessage" Text="" runat="server" class="green" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
