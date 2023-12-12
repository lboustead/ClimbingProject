<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ClimbingProject.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>

    <br />

    <br />
    Recent Sends:<br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="10" CellSpacing="30" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
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
