<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendPage.aspx.cs" Inherits="ClimbingProject.SendPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add a new send:</h1>
    <table style="width: 100%;">
        <tr>
            <td style="width: 141px">Location:</td>
            <td>
                <asp:DropDownList ID="drpLocation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpLocation_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 141px">Grade:</td>
            <td>
                <asp:DropDownList ID="drpGrade" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 141px">Attempts:</td>
            <td>
                <asp:TextBox ID="txtAttempts" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqAttempts" runat="server" ControlToValidate="txtAttempts" ErrorMessage="Please enter an amount of attempts" ForeColor="#CC0000"></asp:RequiredFieldValidator>
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
