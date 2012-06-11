<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
User

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
<ul class="art-hmenu">
         <li> <%: Html.ActionLink("Deskripsi Lomba","Index","User") %> </li>
        <li>  <%: Html.ActionLink("Managemen User", "ManUser", "User")%> </li>
        <li>  <%: Html.ActionLink("Logout", "Logout", "User")%> </li>
        <%--<li><a href="UserPage.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Deskripi Lomba</span></a></li>
        <li><a href="UserManagement.aspx"><span class="l"></span><span class="r"></span><span class="t"> Managemen User </span> </a></li>
        <li><a href="Default.aspx"><span class="l"></span><span class="r"></span><span class="t"> Logout </span> </a></li>--%>
    </ul>
</asp:Content>



<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<h3>National Programming Contest 2012</h3>
      <br />
      <p style="text-align:justify">National Programming Contest 2012 adalah perlombaan programming nasional terbesar di Indonesia. National Programming contest telah berjalan sejak tahun 2006, yang dahulu bernama LPC (Logic Programming Competition)</p>
      <br />
      <br />
</asp:Content>


