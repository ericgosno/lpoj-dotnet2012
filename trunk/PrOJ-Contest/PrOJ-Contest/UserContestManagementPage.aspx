<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserContestManagementPage.aspx.cs" Inherits="PrOJ_Contest.UserContestManagementPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> User - Contest Management Page
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="UserContestManagementPage.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Management Contest</span></a></li>
        <li><a href="UserPage.aspx"><span class="l"></span><span class="r"></span><span class="t"> User Home </span> </a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<br />
   <h3>Contest Managemen User</h3>
   <form id="form1" runat="server">
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
                <td colspan="2"> Problem Management </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Add new problem </td>
            </tr>
            <tr>
                <td> Title </td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="problemName" runat="server" /> </td>
                <td> <asp:Button ID="addProblem" text="Add" runat="server" /> </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Edit problem </td>
            </tr>
            <tr>
                <td> Title </td>
            </tr>
            <tr>
                <td> <asp:DropDownList ID="problemList" runat="server" /> </td>
                <td> <asp:Button ID="editProblem" text="Edit" runat="server" /> </td>
                <td> <asp:Button ID="removeProblem" text="Remove" runat="server" /> </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td colspan="2"> Clarification Management </td>
            </tr>
            <tr>
                <td> <asp:Button ID="viewClarification" text="View Clarifications" runat="server" 
                        onclick="viewClarification_Click" /> </td>
            </tr>
        </table>
    </form>

</asp:Content>
