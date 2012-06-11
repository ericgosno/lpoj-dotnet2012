<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
Login
</asp:Content>

<asp:Content ID="MenuContent" runat="server" ContentPlaceHolderID="MenuContentPlaceHolder">
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
<br />
    <form id="form1"  action="Login/CekLogin" method="post">
        <table style="background-color:transparent; border:#FFFFFF">
            <tr>
                <td> Username </td>
                <td> <input id = "TextName" name="TextName" type = "text" value= "" /> 
                </td>
            </tr>
            <tr>
                <td> Password </td>
                <td> <input id="TextPass" name="TextPass" type="password" value="" /> </td>
            </tr>
            <tr>
                <td colspan="2"> 
                
                <input type="submit" value = "Login" />
                </td>
            </tr>
        </table>
        </form>
</asp:Content>

