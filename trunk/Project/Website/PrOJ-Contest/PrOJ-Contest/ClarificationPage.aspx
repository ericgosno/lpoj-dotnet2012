<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClarificationPage.aspx.cs" Inherits="PrOJ_Contest.ClarificationPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> Clarification Page
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
    <% string tes = Request.QueryString["Id"]; %>
        <li><a href="ProblemPage.aspx?Id=<%=tes %>"><span class="l"></span><span class="r"></span><span class="t">Problem</span></a></li>
        <li><a href="UserSubmissionPage.aspx?Id=<%=tes %>" ><span class="l"></span><span class="r"></span><span class="t">Submission</span></a></li>
        <li><a href="ContestRankPage.aspx?Id=<%=tes %>"><span class="l"></span><span class="r"></span><span class="t">Ranking</span> </a></li>
        <li><a href="#"  class="active"><span class="l"></span><span class="r"></span><span class="t">Clarification</span> </a></li>
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
        <br />
        <h4> Clarification List : </h4>
        <asp:ListBox ID="clarificationList" runat="server" Height="170px" Width="280px" 
            onselectedindexchanged="clarificationList_SelectedIndexChanged" AutoPostBack="true" />
        <br />
        <br />
        <table>
            <tr>
                <td> From : </td>
                <td> 
                <asp:Label ID="Asker" Text="username yang nanya" runat="server" /> 
                <asp:Label ID="idAsker" Text="" runat = "server" Visible ="false"/>
                </td>
            </tr>
            <tr>
                <td> 
                    <b> Question : </b> <asp:Label ID="Question" Text="isi pertanyaan" runat="server" /> 
                </td>
            </tr>
            
        </table>
        <table>
            <tr>
                <td> 
                <b> Answer : </b><asp:Label ID ="answerText" runat="server" Text="<wew>" /> 
                </td>
            </tr>
        </table>
 
 </form></asp:Content>