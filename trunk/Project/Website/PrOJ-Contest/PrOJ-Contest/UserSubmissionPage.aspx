<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserSubmissionPage.aspx.cs" Inherits="PrOJ_Contest.UserSubmissionPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> User Submission Page
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="ProblemPage.aspx" ><span class="l"></span><span class="r"></span><span class="t">Problem</span></a></li>
        <li><a href="UserSubmissionPage.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Submission</span></a></li>
        <li><a href="ContestRankPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Ranking</span> </a></li>
        <li><a href="ClarificationPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Clarification</span> </a></li>
        <li><a href="UserPage.aspx"><span class="l"></span><span class="r"></span><span class="t">  User Home  </span> </a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<br />
    <h3>Submission</h3>
    <br />
    <form id="form1" runat="server">
        <table>
            <tr>
                <td> Select Problem </td>
            </tr>
            <tr>
                <td> <asp:DropDownList ID="problemList" runat="server" Height="20px" Width="150px" AutoPostBack="true" /> </td>
            </tr>
            <tr>
                <td> Upload Source File (auto-detect extension) </td>
            </tr>
            <tr>
                <td> <asp:FileUpload ID="sourceFile" runat="server" /> </td>
            </tr>
            <tr>
                <td> <asp:Button ID="submit" Text="Submit" runat="server" onclick="submit_Click" /> </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <h4> Submitted Solutions </h4>
        <br />
        <asp:DataGrid ID="contestSubmission" runat="server" />
    </form>
</asp:Content>
