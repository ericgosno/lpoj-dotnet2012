<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminContestManagementPage.aspx.cs" Inherits="PrOJ_Contest.AdminContestManagementPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> Admin Pages -  Contest Management
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="#" class="active"><span class="l"></span><span class="r"></span><span class="t">Contest Description</span> </a></li>
        <li><a href="AdminPage.aspx" ><span class="l"></span><span class="r"></span><span class="t">Home Admin</span></a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<br />
    <h3>Hello, 
        <asp:Label ID="lb_userActive" runat="server" Text="&lt;'noName'&gt;"></asp:Label>
    </h3>
    <h4>Current Contest : <asp:Label ID="lb_contestActive" runat="server" Text="&lt;'noName'&gt;"></asp:Label></h4>

    <br />
      <form id="form1" runat="server">
        <table>
            <tr>
                <td> Contest Description </td>
            </tr>
            <tr>
                <td> <asp:TextBox  TextMode="MultiLine" ID="contestDescription" Text="&lt;'noDesc'&gt;" runat="server" /> </td>
            </tr>
            <tr>
                <td> <asp:Button ID="changeDescription" text="Change" runat="server" 
                        onclick="changeDescription_Click" /> </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td colspan="2"> Time Management </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Start Time </td>
                <td> <asp:TextBox ID="startTime" runat="server" /> </td>
                <td> <asp:Button ID="setStartTime" text="Set" runat="server" /> </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Freeze Time </td>
                <td> <asp:TextBox ID="freezeTime" runat="server" /> </td>
                <td> <asp:Button ID="setFreezeTime" text="Set" runat="server" /> </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Finish Time </td>
                <td> <asp:TextBox ID="finishTime" runat="server" /> </td>
                <td> <asp:Button ID="setFinishTime" text="Set" runat="server" /> </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td colspan="2"> Contestant Management </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Invite user </td>
            </tr>
            <tr>
                <td> Username </td>
            </tr>
            <tr>
                <td> <asp:DropDownList ID="userList" runat="server" /> </td>
                <td> <asp:Button ID="problemSetterInvitation" text="As Problem Setter" runat="server" /> </td>
                <td> <asp:Button ID="participantInvitation" text="As Participant" runat="server" /> </td>
            </tr>
        </table>
    </form>


</asp:Content>
