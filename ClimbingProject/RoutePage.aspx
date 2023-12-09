<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoutePage.aspx.cs" Inherits="ClimbingProject.RoutePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Add a new route:</h1>

    <table style="width: 100%;">
        <tr>
            <td style="width: 141px">Location:</td>
            <td>
                <asp:DropDownList ID="drpLocation" runat="server">
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
        </table>
    <p>
        <asp:Button ID="btnAddRoute" runat="server" Text="Add Route" CssClass="btn btn-primary" OnClick="btnAddLocation_Click"/>
    </p>
    <p>
        <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="#33CC33"></asp:Label>
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="#CC0000"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
