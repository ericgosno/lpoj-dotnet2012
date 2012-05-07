<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">

Administrator

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
         <li>  <%: Html.ActionLink("Home Admin","Index","Admin") %> </li>
        <li>  <%: Html.ActionLink("Logout", "Logout", "Admin")%> </li>
        <%--<li><a href="AdminPage.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Home Admin</span></a></li>
        <li><a href="Default.aspx"><span class="l"></span><span class="r"></span><span class="t"> Logout </span> </a></li>--%>
    </ul>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
Welcome Admin
<%--<br />
      <form id="form1" runat="server">
    <h3>Hello,
        <asp:Label ID="lb_activeUser" runat="server" Text="Admin"></asp:Label>

        </h3>
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
                <td colspan="3" align="center"> <asp:Button ID="changePassword" Text="Ubah Sekarang" runat="server" 
                        onclick="changePassword_Click" /> </td>
            </tr>
        </table>
        <br />
        <br />
        <table border="0">
            <tr>
                <td colspan="2" style="font-size:large"> User Management </td>
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
                <td align="center" colspan="2"> <asp:Button ID="addUser" text="Tambah User" runat="server" onclick="addUser_Click" Width="200" /> </td>
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
                <td class="style1"> <asp:DropDownList ID="userList" runat="server" 
                        onselectedindexchanged="userList_SelectedIndexChanged"  AutoPostBack="true" /> 
                    
                </td>
                
                <td class="style1" rowspan="2"> <asp:Button ID="btn_penalizeUser" 
                        text="Active / NonActive" runat="server" 
                        onclick="penalizeUser_Click" Height="40px"  />
                   </td>
            </tr>
            <tr>
                <td>Status : <asp:Label ID="statusUser" runat="server" Text="Status"></asp:Label></td>
            </tr>

            <tr>
                <td > Reset user password </td>
                
                <td> <asp:Button ID="btn_changeUserPass" text="Reset Password" runat="server" 
                        onclick="btn_changeUserPass_Click" /> </td>
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
                <td> <asp:DropDownList ID="contestList" runat="server" 
                        onselectedindexchanged="contestList_SelectedIndexChanged" /> </td>
                <td> <asp:Button ID="editContest" text="Edit" runat="server" /> </td>
            </tr>
        </table>
    </form>--%>
</asp:Content>

<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ScriptIncludePlaceHolder">
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/jquery.js") %>"></script>
  <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/script.js") %>"></script>
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
    </style>
</asp:Content>


