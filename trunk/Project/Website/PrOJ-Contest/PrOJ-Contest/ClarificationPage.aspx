<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClarificationPage.aspx.cs" Inherits="PrOJ_Contest.ClarificationPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> Clarification Page
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="ProblemPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Problem</span></a></li>
        <li><a href="UserSubmissionPage.aspx" ><span class="l"></span><span class="r"></span><span class="t">Submission</span></a></li>
        <li><a href="ContestRankPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Ranking</span> </a></li>
        <li><a href="ClarificationPage.aspx"  class="active"><span class="l"></span><span class="r"></span><span class="t">Clarification</span> </a></li>
        <li><a href="UserPage.aspx"><span class="l"></span><span class="r"></span><span class="t">  User Home  </span> </a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<br />
    <h3>Clarification</h3>
    <br />
    <form id="form1" runat="server">
        <br />
        <table>
            <tr>
                <td> Clarification Title : </td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="Clar_Title" text="Judul Klarifikasi" runat="server" /> </td>
            </tr>

            <tr>
                <td> Description : </td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="Clar_Desc" text="Tulis klarifikasi di sini!" TextMode="MultiLine" runat="server" Height="51px" Width="305px" /> </td>
            </tr>
            <tr>
                <td> <asp:Button ID="askButton" Text="Ask" runat="server" 
                        onclick="askButton_Click" /> </td>
            </tr>
        </table>
        <br />
        <br />
        <h4>All Asked Clarification</h4>
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell> From : </asp:TableCell>
                <asp:TableCell> <asp:Label runat="server" ID="usernameAsker" Text="Penanya" /> </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell ColumnSpan="2"> <asp:Label runat="server" ID="question" Text="tempat pertanyaan" /> </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell ColumnSpan="2"> <asp:Label runat="server" ID="answer" Text="tempat jawaban" /> </asp:TableCell></asp:TableRow></asp:Table></form></asp:Content>