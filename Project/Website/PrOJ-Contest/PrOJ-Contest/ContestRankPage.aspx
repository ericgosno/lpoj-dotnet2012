<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContestRankPage.aspx.cs" Inherits="PrOJ_Contest.ContestRankPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> Contest Rank Page
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
    <% string tes = Request.QueryString["Id"]; %>
        <li><a href="ProblemPage.aspx?Id=<%=tes %>" ><span class="l"></span><span class="r"></span><span class="t">Problem</span></a></li>
        <li><a href="UserSubmissionPage.aspx?Id=<%=tes %>" ><span class="l"></span><span class="r"></span><span class="t">Submission</span></a></li>
        <li><a href="#" class="active"><span class="l"></span><span class="r"></span><span class="t">Ranking</span> </a></li>
        <li><a href="ClarificationPage.aspx?Id=<%=tes %>"><span class="l"></span><span class="r"></span><span class="t">Clarification</span> </a></li>
        <li><a href="UserPage.aspx"><span class="l"></span><span class="r"></span><span class="t"> User Home  </span> </a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<br />
    <h3>Contest Rank</h3>
    <br />
    <form id="form1" runat="server">
        Active contest : <asp:Label ID="activeContestLabel" Text="contestName" runat="server" /><br />
        Maximum score  : <asp:Label ID="maxScore" Text="0" runat="server" /><br />
        <br />   
        <asp:Table ID="TblScore" runat="server" CssClass="table">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Username</asp:TableHeaderCell>
                <asp:TableHeaderCell>TotalScore</asp:TableHeaderCell>
                <asp:TableHeaderCell>Total Time</asp:TableHeaderCell>
            </asp:TableHeaderRow>

       </asp:Table></form></asp:Content>