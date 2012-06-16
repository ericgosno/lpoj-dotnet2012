<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContestantInvitationPage.aspx.cs" Inherits="PrOJ_Contest.ContestantInvitationPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> 
Contestant Invitation Page
</asp:Content>


<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="#" class="active"><span class="l"></span><span class="r"></span><span class="t">Invitation</span></a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <br />
        <h3>
            Contest Title : <asp:Label ID="lb_contestName" runat="server" Text="&lt;'noName'&gt;" />
        </h3>
        <br />
        <table>
            <tr>
                <td> Search Username</td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="regexpText" text= "Tulis regular expression di sini!" 
                        runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td> <asp:Button ID="searchButton" text="Search" runat="server" 
                        onclick="searchButton_Click" /> </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td> Usernames </td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="usernameList" text= "Tulis user-user yang ingin di-invite! Pisahkan antar-user dengan newline!" 
                        TextMode="MultiLine" runat="server" Height="150px" Width="300px" />
                </td>
            </tr>
            <tr>
                <td> 
                    <asp:Button ID="regularInviteParticipant" text="Invite As Participant" 
                        runat="server" Width="230px" onclick="regularInviteParticipant_Click" /> </td>
            </tr>
            <tr>
                <td> 
                    <asp:Button ID="regularInviteProblemSetter" text="Invite As Problem Setter" 
                        runat="server" Width="230px" onclick="regularInviteProblemSetter_Click" /> </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button ID="backButton" Text="Back" runat="server" 
            onclick="backButton_Click" />
    </form>
</asp:Content>

