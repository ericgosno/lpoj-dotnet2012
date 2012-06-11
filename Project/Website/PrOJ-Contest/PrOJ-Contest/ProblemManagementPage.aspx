<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProblemManagementPage.aspx.cs" Inherits="PrOJ_Contest.ProblemManagementPage" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
    User Page - Problem Management
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

<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
    <br />
    <form id="form1" runat="server">
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
                        TextMode="MultiLine" runat="server" Height="300px" Width="500px" />
                </td>
            </tr>
            <tr>
                <td> <asp:Button ID="changeDescription" text="Change" runat="server" /> </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Time Limit (Milidetik) </td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="timeLimit" runat="server" /> </td>
            </tr>
            <tr>
                <td> <asp:Button ID="changeTimeLimit" text="Change" runat="server" /> </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Time Limit (Byte) </td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="memoryLimit" runat="server" /> </td>
            </tr>
            <tr>
                <td> <asp:Button ID="changeMemoryLimit" text="Change" runat="server" /> </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td colspan="2"> TestCase Management </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Upload TestCase </td>
            </tr>
            <tr>
                <td> File input  : </td>
                <td> <asp:FileUpload ID="inputFile" runat="server" /> </td>
            </tr>
            <tr>
                <td> File output : </td>
                <td> <asp:FileUpload ID="outputFile" runat="server" /> </td>
            </tr>
            <tr>
                <td> <asp:Button ID="uploadTestCase" text="Upload" runat="server" /> </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td> Remove TestCase </td>
            </tr>
            <tr>
                <td> <asp:DropDownList ID="testCaseList" runat="server" /> </td>
                <td> <asp:Button ID="removeTestCase" text="Remove" runat="server" /> </td>
            </tr>
        </table>
    </form>
</asp:Content>

