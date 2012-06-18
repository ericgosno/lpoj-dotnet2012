<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="PrOJ_Contest.AdminPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> Admin Page
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="AdminPage.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Home Admin</span></a></li>
        <li><a href="Default.aspx"><span class="l"></span><span class="r"></span><span class="t"> Logout </span> </a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
    <br />
    <form id="form1" runat="server">
        <h3> Hello Admin </h3>
        <br />
        <table border="0">
            <tr>
                <td colspan="2" style="font-size:large"> Change Password </td>
            </tr>
            <tr>
                <td > Old Password </td>
                <td> : </td>
                <td> <asp:TextBox ID="oldPassword" runat="server"  TextMode="Password"/> </td>
            </tr>
            <tr>
                <td> New Password </td>
                <td> : </td>
                <td> <asp:TextBox ID="newPassword" runat="server" TextMode="Password"/> </td>
            </tr>
            <tr>
                <td> Confirm New Password </td>
                <td> : </td>
                <td> <asp:TextBox ID="confirmPassword" runat="server" TextMode="Password"/> </td>
            </tr>
            <tr>
                <td colspan="3"> <asp:Button ID="changePassword" Text="Change" runat="server" 
                        onclick="changePassword_Click" /> </td>
            </tr>
        </table>
        <br />
        <br />
        <table border="0">
            <tr>
                <td style="font-size:large"> User Management </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td style="font-style:italic" > Add new user </td>
            </tr>
            <tr>
                <td> Username </td>
                <td> Password </td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="userName" runat="server" /> </td>
                <td> <asp:TextBox ID="userPass" runat="server" TextMode="Password" /> </td>
                
            </tr>
            <tr>
                <td> <asp:Button ID="addUser" text="Add" runat="server" /> </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td style="font-style:italic"> Edit user </td>
            </tr>
            <tr>
                <td> Username </td>
            </tr>
            <tr>
                <td> <asp:DropDownList ID="userList" runat="server" 
                        onselectedindexchanged="userList_SelectedIndexChanged"  AutoPostBack="true" /> 
                    
                </td>
            </tr>
            <tr>
                <td>Status : <asp:Label ID="statusUser" runat="server" Text="Status"></asp:Label></td>
                <td> <asp:Button ID="penalizeUser"  text="Active / NonActive" runat="server" 
                        onclick="penalizeUser_Click" Width="170px" />
                </td>
            </tr>
            <tr>
                <td > Reset user password </td>
                <td> 
                    <asp:Button ID="btn_changeUserPass" text="Reset Password" runat="server" 
                        onclick="btn_changeUserPass_Click" Width="170px" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td colspan="2" style="font-size:large"> Contest Management </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td style="font-style:italic"> Add new contest </td>
            </tr>
            <tr>
                <td> Title </td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="contestName" runat="server" /> </td>
                <td> <asp:Button ID="addContest" text="Add" runat="server" 
                        onclick="addContest_Click" /> </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td style="font-style:italic"> Edit contest </td>
            </tr>
            <tr>
                <td> Title </td>
            </tr>
            <tr>
                <td> <asp:DropDownList ID="contestList" runat="server" /> </td>
                <td> <asp:Button ID="editContest" text="Edit" runat="server" 
                        onclick="editContest_Click" /> </td>
            </tr>
        </table>
    </form>


</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ScriptIncludePlaceHolder">
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/jquery.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/script.js") %>"></script>
</asp:Content>
