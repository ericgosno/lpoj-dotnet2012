<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">

Manajemen User

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
<ul class="art-hmenu">
         <li> <%: Html.ActionLink("Deskripsi Lomba","Index","User") %> </li>
        <li>  <%: Html.ActionLink("Managemen User", "ManUser", "User")%> </li>
        <li>  <%: Html.ActionLink("Logout", "Logout", "User")%> </li>
        <%--<li><a href="UserPage.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Deskripi Lomba</span></a></li>
        <li><a href="UserManagement.aspx"><span class="l"></span><span class="r"></span><span class="t"> Managemen User </span> </a></li>
        <li><a href="Default.aspx"><span class="l"></span><span class="r"></span><span class="t"> Logout </span> </a></li>--%>
    </ul>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<br />
        <form id="form1"  action="User/ChangePassword" method="post">
            <table>
                <tr>
                    <td colspan="2"> Change Password </td>
                </tr>
                <tr>
                    <td> Old Password </td>
                    <td> : </td>
                
                    <td><input id="oldPassword" name="oldPassword" type="password" /> </td>
                </tr>
                <tr>
                    <td> New Password </td>
                    <td> : </td>
                    <td> <input id="newPassword" name="newPassword" type="password" /> </td>
                </tr>
                <tr>
                    <td> Confirm New Password </td>
                    <td> : </td>
                    <td> <input id="confirmPassword" name="confirmPassword" type="password" /> </td>
                </tr>
                <tr>
                    <td  colspan="3" align="center"> <input type="submit" value = "Change" />  </td>
                </tr>
            </table>
        </form>
        <br />
        <br />
            <form id = "form2" action = "User/SelectContest" method = post >
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
