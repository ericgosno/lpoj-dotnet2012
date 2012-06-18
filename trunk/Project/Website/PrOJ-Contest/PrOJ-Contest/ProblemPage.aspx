﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProblemPage.aspx.cs" Inherits="PrOJ_Contest.ProblemPage" %>
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
        <h3>
            Hello, <asp:Label ID="lb_userActive" runat="server" Text="&lt;'noName'&gt;" />
        </h3>
        <h4>
            Problem Title : <asp:Label ID="problemTitle" runat="server" Text="&lt;'noName'&gt;" />
        </h4>
        <br />
        <br />
        <table>
            <tr>
                <td colspan="2"> Problem Definition </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Description </td>
            </tr>
            <tr>
                <td> 
                    <asp:TextBox ID="problemDescription" text="Tulis deskripsi di sini!" 
                        TextMode="MultiLine" runat="server" Height="300px" Width="500px" ReadOnly="true"/>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Time Limit (Milidetik) </td>
            </tr>
            <tr>
                <td> <asp:Label ID="timeLimit" runat="server" Text=""/> </td>
            </tr>
            
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Time Limit (Byte) </td>
            </tr>
            <tr>
                <td> <asp:Label ID="memoryLimit" runat="server" Text=""/></td>
            </tr>
            
        </table>
        <br />
        <br />
    </form>
</asp:Content>
