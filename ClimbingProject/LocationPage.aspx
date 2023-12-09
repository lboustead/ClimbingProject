<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LocationPage.aspx.cs" Inherits="ClimbingProject.LocationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add a new location:</h1>

    <table style="width: 100%;">
        <tr>
            <td style="width: 141px">State:</td>
            <td>
                <asp:TextBox ID="txtState" runat="server" CssClass="offset-sm-0"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqState" runat="server" ControlToValidate="txtState" ErrorMessage="Please enter a state" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 141px">City:</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqCity" runat="server" ControlToValidate="txtCity" ErrorMessage="Please enter a city" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 141px">Description:</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="Please enter a location description" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <p>
        <asp:Button ID="btnAddLocation" runat="server" Text="Add Location" CssClass="btn btn-primary" OnClick="btnAddLocation_Click"/>
    </p>
    <p>
        <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="#33CC33"></asp:Label>
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="#CC0000"></asp:Label>
    </p>
</asp:Content>
