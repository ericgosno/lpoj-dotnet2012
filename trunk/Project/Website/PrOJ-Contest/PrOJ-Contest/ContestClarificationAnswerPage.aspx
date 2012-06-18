<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContestClarificationAnswerPage.aspx.cs" Inherits="PrOJ_Contest.ContestClarificationAnswerPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> Clarification Answer Page
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="ContestClarificationAnswerPage.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Answer Clarification</span></a></li>
        <li><a href="UserContestManagementPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Manager Contest</span> </a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<br />
    <h3>Answer Clarification</h3>
    <form id="form1" runat="server">
        <br />
        <h4> Clarification List : </h4>
        <asp:ListBox ID="clarificationList" runat="server" Height="170px" Width="280px" 
            onselectedindexchanged="clarificationList_SelectedIndexChanged" />
        <br />
        <br />
        <table>
            <tr>
                <td> From : </td>
                <td> <asp:Label ID="Asker" Text="username yang nanya" runat="server" /> </td>
            </tr>
            <tr>
                <td> Question : </td>
            </tr>
            <tr>
                <td> <asp:Label ID="Question" Text="isi pertanyaan" runat="server" /> </td>
            </tr>
        </table>
        <table>
            <tr>
                <td> <asp:TextBox ID="answerText" text="Jawaban tulis di sini!" 
                        TextMode="MultiLine" runat="server" Height="51px" Width="305px" /> </td>
            </tr>
            <tr>
                <td> <asp:Button ID="answerButton" Text="Answer" runat="server" /> </td>
            </tr>
        </table>
    </form>
</asp:Content>
