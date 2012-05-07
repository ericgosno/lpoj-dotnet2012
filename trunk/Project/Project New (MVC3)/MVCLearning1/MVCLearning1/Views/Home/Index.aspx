

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Title" runat="server" ContentPlaceHolderID="TitleContentPlaceHolder">Halaman Utama</asp:Content>

<asp:Content ID="MenuContent" runat="server" ContentPlaceHolderID="MenuContentPlaceHolder">
    <ul class="art-hmenu">
        <li>  <%: Html.ActionLink("Home","Index","Home") %> </li>
        <li>  <%: Html.ActionLink("Login","Index","Login") %> </li>
        <li>  <%: Html.ActionLink("Credits","Credits","Home") %> </li>
        <%--<li><a href="./Home/Index" class="active"><span class="l"></span><span class="r"></span><span class="t">Home</span></a></li>
        <li><a href="LoginPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Login</span></a></li>
        <li><a href="Credits.aspx"><span class="l"></span><span class="r"></span><span class="t">Credits</span></a></li>--%>
    </ul>
</asp:Content>



<asp:Content ID="SheetContent" runat="server" ContentPlaceHolderID="SheetContentPlaceHolder">

  <h3>National Programming Contest 2012</h3>
  <br />
  <p>
  
  </p>
  <p style="text-align:justify">National Programming Contest 2012 adalah perlombaan programming nasional terbesar di Indonesia. National Programming contest telah berjalan sejak tahun 2006, yang dahulu bernama LPC (Logic Programming Competition)</p>
  <br />
  <br />

</asp:Content>

