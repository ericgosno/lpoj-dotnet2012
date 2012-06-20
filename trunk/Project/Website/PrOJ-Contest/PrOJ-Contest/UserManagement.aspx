<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="PrOJ_Contest.UserManagement" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> User Page
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="UserPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Deskripsi Lomba</span></a></li>
        <li><a href="UserManagement.aspx"  class="active"><span class="l"></span><span class="r"></span><span class="t"> Managemen User </span> </a></li>
        <li><a href="Default.aspx"><span class="l"></span><span class="r"></span><span class="t"> Logout </span> </a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
    <br />
    <form id="form1" runat="server">
        <br />
        <h3>
            Hello, <asp:Label ID="lb_userActive" runat="server" Text="&lt;'noName'&gt;" />
        </h3>
        <br />
        <table>
            <tr>
                <td colspan="2"> Change Password </td>
            </tr>
            <tr>
                <td> Old Password </td>
                <td> : </td>
                <td> <asp:TextBox ID="oldPassword" TextMode="Password" runat="server" /> </td>
            </tr>
            <tr>
                <td> New Password </td>
                <td> : </td>
                <td> <asp:TextBox ID="newPassword" TextMode="Password" runat="server" /> </td>
            </tr>
            <tr>
                <td> Confirm New Password </td>
                <td> : </td>
                <td> <asp:TextBox ID="confirmPassword" TextMode="Password" runat="server" /> </td>
                <td> <asp:CompareValidator ID="validator" runat="server" ErrorMessage="Password Not Match" ControlToCompare="newPassword" ControlToValidate="confirmPassword" /> </td>
            </tr>
            <tr>
                <td> <asp:Button ID="changePassword" Text="Change" runat="server" 
                        onclick="changePassword_Click" /> </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
        <tr>
            <td colspan="2"> Select Contest </td>
        </tr>
        <tr>
            <td> <asp:DropDownList ID="cmbox_listContest" runat="server" 
                    OnTextChanged="cmbox_listContest_SelectedIndexChanged" AutoPostBack="true"/> </td>
        </tr>
        <tr>
            <td> <asp:Button ID="btn_enterContest" Text="Enter" runat="server" Visible="true" 
                    onclick="btn_enterContest_Click" /> </td>
        </tr>
        <tr>
            <td> 
                <asp:Button ID="btn_manageContest" Text="Manage" runat="server" 
                    Visible = "false" onclick="btn_manageContest_Click" /> </td>
        </tr>
        </table>
    </form>

</asp:Content>
