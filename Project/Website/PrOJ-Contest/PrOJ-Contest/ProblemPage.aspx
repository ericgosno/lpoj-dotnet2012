<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProblemPage.aspx.cs" Inherits="PrOJ_Contest.ProblemPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> Problem Page
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
    <br />
    <h3>Problem Browse</h3>
    <form id="form1" runat="server">
        <asp:DataGrid ID="contestProblem" runat="server" />
    </form>
</asp:Content>
