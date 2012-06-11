<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContestantInvitationPage.aspx.cs" Inherits="PrOJ_Contest.ContestantInvitationPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> Contestant Invitation Page
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="ProblemPage.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Problem</span></a></li>
        <li><a href="UserSubmissionPage.aspx" ><span class="l"></span><span class="r"></span><span class="t">Submission</span></a></li>
        <li><a href="ContestRankPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Ranking</span> </a></li>
        <li><a href="ClarificationPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Clarification</span> </a></li>
        <li><a href="UserPage.aspx"><span class="l"></span><span class="r"></span><span class="t"> User Home </span> </a></li>
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
                <td> <asp:Button ID="Button1" text="Search" runat="server" /> </td>
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
                <td> <asp:Button ID="regularInviteParticipant" text="Invite As Participant" 
                        runat="server" Width="230px" /> </td>
            </tr>
            <tr>
                <td> <asp:Button ID="regularInviteProblemSetter" text="Invite As Problem Setter" 
                        runat="server" Width="230px" /> </td>
            </tr>
        </table>
        <br />
    </form>
</asp:Content>
