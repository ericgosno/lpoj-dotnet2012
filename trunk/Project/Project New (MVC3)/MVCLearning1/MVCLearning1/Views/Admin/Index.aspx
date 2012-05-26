<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="MVCLearning1.Models" %>
<script runat="server">
    
    private lpojEntities entity;
    private lpoj_users activeUser;
    private lpoj_users users;
    private lpoj_contest contests;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void initialUserActive()
    {
        //activeUser = new lpoj_users();
        //// error handling untuk menghitung session
        //try
        //{
        //    activeUser = (lpoj_users)Session["userActive"];
        //    lb_activeUser.Text = activeUser.USERS_USERNAME;
        //}
        //catch (Exception ex)
        //{
        //    Response.Redirect("Default.aspx");
        //}
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">

Administrator

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
         <li>  <%: Html.ActionLink("Home Admin","Index","Admin") %> </li>
        <li>  <%: Html.ActionLink("Logout", "Logout", "Admin")%> </li>
    </ul>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<br />
<form id="form1" runat="server">
    <h3>
    Hello, Administrator
    <!--asp:Label ID="lb_activeUser" runat="server" Text="<Nonmae>"></asp:Label-->
    </h3>
</form>
<br />
      

        <br />
        <form id="form2"  action="Admin/ChangePassword" method="post">
            <table border="0">
                <tr>
                    <td colspan="2" style="font-size:large"> Change Password </td>
                </tr>
                <tr>
                    <td > Old Password </td>
                    <td> : </td>
                    <td> <input id="oldPassword" name="oldPassword" type="text" /></td>
                </tr>
                <tr>
                    <td> New Password </td>
                    <td> : </td>
                    <td><input id="newPassword" name="newPassword" type="text" /></td>
                </tr>
                <tr>
                    <td> Confirm New Password </td>
                    <td> : </td>
                    <td> <input id="confirmPassword" name="confirmPassword" type="text" /></td>
                </tr>
                <tr>
                    <td colspan="3" align="center"> <input type="submit" value = "Update" />
                    </td>
                </tr>
            </table>
        </form>
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


