<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PrOJ_Contest.LoginPage" %>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Menu" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <ul class="art-hmenu">
        <li><a href="Default.aspx" ><span class="l"></span><span class="r"></span><span class="t">Home</span></a></li>
        <li><a href="LoginPage.aspx" class="active"><span class="l"></span><span class="r"></span><span class="t">Login</span></a></li>
        <li><a href="Credits.aspx"><span class="l"></span><span class="r"></span><span class="t">Credits</span></a></li>
    </ul>
</asp:Content>

<asp:Content ID="Sheet" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<br />
    <form id="form1" runat="server">
        <table style="background-color:transparent; border:#FFFFFF">
            <tr>
                <td> Username </td>
                <td> <asp:TextBox ID="textName" runat="server" /> </td>
            </tr>
            <tr>
                <td> Password </td>
                <td> <asp:TextBox  ID="textPass" TextMode="Password" runat="server" /> </td>
            </tr>
            <tr>
                <td colspan="2"> 
                
                <asp:Button ID="buttonLogin" text="Login" runat="server" 
                        onclick="buttonLogin_Click"  /> 
                </td>
            </tr>
        </table>
        </form>
</asp:Content>
