<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorldMainForm.aspx.cs" Inherits="_01.World.Client.WorldMainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:EntityDataSource ID="EntityDataSourceWorldContinents" runat="server"
            ConnectionString="name=WorldDbEntities" DefaultContainerName="WorldDbEntities"
            EntitySetName="Continents" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" />
        <strong>
            <asp:Label AssociatedControlID="ListBoxContinents" Text="Continents:" runat="server" /></strong><br />
        <asp:ListBox ID="ListBoxContinents" runat="server" Rows="4" 
            DataSourceID="EntityDataSourceWorldContinents"
            DataTextField="ContinentName" 
            DataValueField="ContinentId"
            AutoPostBack="true"></asp:ListBox>
        <br />
        <br />

        <asp:EntityDataSource ID="EntityDataSourceWorldCountries" runat="server"
            ConnectionString="name=WorldDbEntities" DefaultContainerName="WorldDbEntities"
            EntitySetName="Countries" EnableFlattening="False" Include="Continent, Languages" 
            EnableDelete="True" EnableInsert="True" EnableUpdate="True"  where="it.ContinentId=@CntnntId">
            <WhereParameters>
                <asp:ControlParameter Name="CntnntId" Type="Int32" ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>
        <asp:EntityDataSource ID="EntityDataSourceWorldLanguages" runat="server"
            ConnectionString="name=WorldDbEntities" DefaultContainerName="WorldDbEntities"
            EntitySetName="Languages" EnableFlattening="False" Include="Countries" EnableDelete="True" EnableInsert="True" EnableUpdate="True" />
        <strong>
            <asp:Label AssociatedControlID="ListBoxContinents" Text="Countries:" runat="server" /></strong><br />
        <asp:GridView ID="GridViewCountries" runat="server" AllowPaging="True" AllowSorting="True" PageSize="5"
            AutoGenerateColumns="False" DataKeyNames="CountryId" DataSourceID="EntityDataSourceWorldCountries"
            OnRowDataBound="GridViewCountries_RowDataBound"
            OnRowUpdating="GridViewCountries_RowUpdating"
            ShowFooter="true"
            OnPreRender="GridViewCountries_PreRender"
            OnRowCommand="GridViewCountries_RowCommand"
            OnRowDeleting="GridViewCountries_RowDeleting"
            ItemType="World.Data.Country">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" ShowEditButton="True"/>
                <asp:TemplateField>
                    <FooterTemplate>
                        <asp:Button runat="server" ID="InsertNewCountry" Text="Insert" CommandName="InsertNew" ValidationGroup="CountryValidation" />
                        <asp:Button runat="server" ID="CancelNewCountry" Text="Cancel" CommandName="CancelNew" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CountryId">
                    <ItemTemplate>
                        <%#: Eval("CountryId") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="EditCountryId" Text='<%# Bind("CountryId") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="InsertCountryId" Text='<%# Bind("CountryId") %>' MaxLength="3"/>
                        <asp:RequiredFieldValidator ControlToValidate="InsertCountryId" runat="server" ForeColor="Red" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="CountryValidation"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="ValidatorContryIdTaken" ControlToValidate="InsertCountryId"  ForeColor="Red"
                            OnServerValidate="ValidatorContryIdTaken_ServerValidate" ValidationGroup="CountryValidation"
                            runat="server" ErrorMessage="This CountryId is already taken!"></asp:CustomValidator>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Country Name">
                    <ItemTemplate>
                        <%#: Eval("CountryName") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="EditCountryName" Text='<%# Bind("CountryName") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="InsertCountryName" Text='<%# Bind("CountryName") %>' />
                        <asp:RequiredFieldValidator ControlToValidate="InsertCountryName" ForeColor="Red" runat="server" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="CountryValidation"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Latitude">
                    <ItemTemplate>
                        <%#: Eval("Latitude") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="EditLatitude" Text='<%# Bind("Latitude") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="InsertLatitude" Text='<%# Bind("Latitude") %>' />
                        <asp:RequiredFieldValidator ControlToValidate="InsertLatitude" ForeColor="Red" runat="server" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="CountryValidation"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Longitude">
                    <ItemTemplate>
                        <%#: Eval("Longitude") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="EditLongitude" Text='<%# Bind("Longitude") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="InsertLongitude" Text='<%# Bind("Longitude") %>' />
                        <asp:RequiredFieldValidator ControlToValidate="InsertLongitude" ForeColor="Red" runat="server" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="CountryValidation"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Surface Area">
                    <ItemTemplate>
                        <%#: Eval("SurfaceArea") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="EditSurfaceArea" Text='<%# Bind("SurfaceArea") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="InsertSurfaceArea" Text='<%# Bind("SurfaceArea") %>' />
                        <asp:RequiredFieldValidator ControlToValidate="InsertSurfaceArea" ForeColor="Red" runat="server" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="CountryValidation"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Population">
                    <ItemTemplate>
                        <%#: Eval("Population") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="EditPopulation" Text='<%# Bind("Population") %>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="InsertPopulation" Text='<%# Bind("Population") %>' />
                        <asp:RequiredFieldValidator ControlToValidate="InsertPopulation" ForeColor="Red" runat="server" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="CountryValidation"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        Continent
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownListContinent" runat="server" SelectedValue="<%# BindItem.ContinentId %>"
                            DataTextField="ContinentName" DataSourceID="EntityDataSourceWorldContinents" DataValueField="ContinentId" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownListContinentInsert" runat="server" SelectedValue="<%# BindItem.ContinentId %>"
                            DataTextField="ContinentName" DataSourceID="EntityDataSourceWorldContinents" DataValueField="ContinentId" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        Language
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ListBox ID="ListBoxLanguages" runat="server" Rows="4" SelectionMode="Multiple"
                            DataSourceID='EntityDataSourceWorldLanguages'
                            DataTextField="LanguageName" DataValueField="LanguageId"></asp:ListBox>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:ListBox ID="ListBoxLanguagesInsert" runat="server" Rows="4" SelectionMode="Multiple"
                            DataSourceID='EntityDataSourceWorldLanguages'
                            DataTextField="LanguageName" DataValueField="LanguageId"></asp:ListBox>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>

            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
        <br />
        <br />

        <asp:EntityDataSource ID="EntityDataSourceWorldCities" runat="server" ConnectionString="name=WorldDbEntities"
            DefaultContainerName="WorldDbEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True"
            EnableUpdate="True" EntitySetName="Cities" Include="Country" where="it.Country.CountryId=@CntryId">
            <WhereParameters>
                <asp:ControlParameter Name="CntryId" Type="String" ControlID="GridViewCountries" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:EntityDataSource ID="EntityDataSourceCountriesUnfiltered" runat="server"
            ConnectionString="name=WorldDbEntities" DefaultContainerName="WorldDbEntities"
            EntitySetName="Countries" EnableFlattening="False" Include="Continent, Languages" 
            EnableDelete="True" EnableInsert="True" EnableUpdate="True">
        </asp:EntityDataSource>
        <strong>
            <asp:Label AssociatedControlID="ListViewCities" Text="Cities:" runat="server" /></strong><br />
        <asp:ListView ID="ListViewCities" runat="server" DataSourceID="EntityDataSourceWorldCities" OnItemInserting="ListViewCities_ItemInserting"
            DataKeyNames="CityID" InsertItemPosition="LastItem" ItemType="World.Data.City" ValidationGroup="CityValidation">

            <AlternatingItemTemplate>
                <tr style="background-color: #FFF8DC;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td><%#: Eval("CityID") %></td>
                    <td><%#: Eval("CityName") %></td>
                    <td><%#: Eval("CityPopulation") %></td>
                    <td><%#: Eval("Latitude") %></td>
                    <td><%#: Eval("Longitude") %></td>
                    <td><%#: Eval("Country.CountryName") %></td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color: #008A8C; color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:Literal ID="LiteralCityId" Text='<%#: Eval("CityId") %>' runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="CityNameTextBox" runat="server" Text='<%# Bind("CityName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CityPopulationTextBox" runat="server" Text='<%# Bind("CityPopulation") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LatitudeTextBox" runat="server" Text='<%# Bind("Latitude") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LongitudeTextBox" runat="server" Text='<%# Bind("Longitude") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListCountryEdit" runat="server" SelectedValue="<%# BindItem.CountryId %>"
                            DataTextField="CountryName" DataSourceID="EntityDataSourceCountriesUnfiltered" DataValueField="CountryId" />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:Literal Text="(CityId)" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="CityNameTextBox" runat="server" Text='<%# Bind("CityName") %>' />
                        <asp:RequiredFieldValidator ControlToValidate="CityNameTextBox" runat="server" ForeColor="Red" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="CityValidation"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="CityPopulationTextBox" runat="server" Text='<%# Bind("CityPopulation") %>' />
                        <asp:RequiredFieldValidator ControlToValidate="CityPopulationTextBox" runat="server" ForeColor="Red" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="CityValidation"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="LatitudeTextBox" runat="server" Text='<%# Bind("Latitude") %>' />
                        <asp:RequiredFieldValidator ControlToValidate="LatitudeTextBox" runat="server" ForeColor="Red" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="CityValidation"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="LongitudeTextBox" runat="server" Text='<%# Bind("Longitude") %>' />
                        <asp:RequiredFieldValidator ControlToValidate="LongitudeTextBox" runat="server" ForeColor="Red" 
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="CityValidation"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListCountry" runat="server" SelectedValue="<%# BindItem.CountryId %>"
                            DataTextField="CountryName" DataSourceID="EntityDataSourceCountriesUnfiltered" DataValueField="CountryId" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color: #DCDCDC; color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td><%#: Eval("CityID") %></td>
                    <td><%#: Eval("CityName") %></td>
                    <td><%#: Eval("CityPopulation") %></td>
                    <td><%#: Eval("Latitude") %></td>
                    <td><%#: Eval("Longitude") %></td>
                    <td><%#: Eval("Country.CountryName") %></td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                    <th runat="server"></th>
                                    <th runat="server">City ID</th>
                                    <th runat="server">City Name</th>
                                    <th runat="server">City Population</th>
                                    <th runat="server">Latitude</th>
                                    <th runat="server">Longitude</th>
                                    <th runat="server">Country Name</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td><%#: Eval("CityID") %></td>
                    <td><%#: Eval("CityName") %></td>
                    <td><%#: Eval("CityPopulation") %></td>
                    <td><%#: Eval("Latitude") %></td>
                    <td><%#: Eval("Longitude") %></td>
                    <td><%#: Eval("Country") %></td>
                    <td><%#: Eval("CityID") %></td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
