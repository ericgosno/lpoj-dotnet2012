<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="PrOJ_Contest.UserPage" %>
<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server"> User Page
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="UserPage.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Deskripi Lomba</span></a></li>
        <li><a href="UserManagement.aspx"><span class="l"></span><span class="r"></span><span class="t"> Managemen User </span> </a></li>
        <li><a href="Default.aspx"><span class="l"></span><span class="r"></span><span class="t"> Logout </span> </a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
<br />
    <h3>Hello, 
        <asp:Label ID="lb_userActive" runat="server" Text="&lt;'noName'&gt;"></asp:Label>
    </h3>
      <h3>National Programming Contest 2012</h3>
      <br />
      <p style="text-align:justify">National Programming Contest 2012 adalah perlombaan programming nasional terbesar di Indonesia. National Programming contest telah berjalan sejak tahun 2006, yang dahulu bernama LPC (Logic Programming Competition)</p>
      <br />
      <br />


    </form>


</asp:Content>

