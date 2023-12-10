<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ClimbingProject.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <table style="width: 100%; height: 102px;">
        <tr>
            <td style="width: 224px">
                <asp:Label ID="Label1" runat="server" Text="Highest Grade Sent:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="HGSlbl" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 224px">
                <asp:Label ID="Label2" runat="server" Text="Average Grade Sent:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="AGSlbl" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 224px">
                <asp:Label ID="Label3" runat="server" Text="Most Climbed Location:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="MCLlbl" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
