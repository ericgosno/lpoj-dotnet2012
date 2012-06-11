<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
Credit
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
<ul class="art-hmenu">
        <li>  <%: Html.ActionLink("Home","Index","Home") %> </li>
        <li>  <%: Html.ActionLink("Login", "Index", "Login")%> </li>
        <li>  <%: Html.ActionLink("Credits","Credits","Home") %> </li>
        <%--<li><a href="./Home/Index" class="active"><span class="l"></span><span class="r"></span><span class="t">Home</span></a></li>
        <li><a href="LoginPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Login</span></a></li>
        <li><a href="Credits.aspx"><span class="l"></span><span class="r"></span><span class="t">Credits</span></a></li>--%>
    </ul>
</asp:Content>



<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<h3>Dibuat oleh</h3>

  <br />
  <br />
  <br />
</asp:Content>

