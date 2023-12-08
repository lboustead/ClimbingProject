<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClimbingProject._Default" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    Hello
    <asp:LoginName ID="UserName" runat="server" />
    <br />
    <p>
&nbsp;&nbsp;
        <table style="width:100%;">
            <tr>
                <td style="width: 351px; height: 142px">
                    <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
                <td style="width: 416px; height: 142px">
                    <table style="width: 100%; height: 102px;">
                        <tr>
                            <td style="width: 224px">
                                <asp:Label ID="Label1" runat="server" Text="Highest Grade Sent:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Highestgradetxt" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 224px">
                                <asp:Label ID="Label4" runat="server" Text="Highest Grade Attempted:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="GradeAttemptedtxt" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 224px">
                                <asp:Label ID="Label2" runat="server" Text="Average Grade Sent:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="AverageGradetxt" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 224px">
                                <asp:Label ID="Label3" runat="server" Text="Most Climbed Location:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="MostClimbedtxt" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

