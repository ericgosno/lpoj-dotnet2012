<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PrOJ_Contest._Default" %>


<asp:Content ID="Title" runat="server" ContentPlaceHolderID="TitleContentPlaceHolder">Main Page</asp:Content>

<asp:Content ID="MenuContent" runat="server" ContentPlaceHolderID="MenuContentPlaceHolder">
    <ul class="art-hmenu">
        <li><a href="Default.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Home</span></a></li>
        <li><a href="LoginPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Login</span></a></li>
        <li><a href="Credits.aspx"><span class="l"></span><span class="r"></span><span class="t">Credits</span></a></li>
    </ul>
</asp:Content>



<asp:Content ID="SheetContent" runat="server" ContentPlaceHolderID="SheetContentPlaceHolder">

  <h3>National Programming Contest 2012</h3>
  <br />
  <p style="text-align:justify">National Programming Contest 2012 adalah perlombaan programming nasional terbesar di Indonesia. National Programming contest telah berjalan sejak tahun 2006, yang dahulu bernama LPC (Logic Programming Competition)</p>
  <br />
  <br />

</asp:Content>

