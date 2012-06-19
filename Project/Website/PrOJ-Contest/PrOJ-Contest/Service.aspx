<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="PrOJ_Contest.Service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
 <ul class="art-hmenu">
        <li><a href="Default.aspx"><span class="l"></span><span class="r"></span><span class="t">Home</span></a></li>
        <li><a href="LoginPage.aspx"><span class="l"></span><span class="r"></span><span class="t">Login</span></a></li>
        <li><a href="Credits.aspx"><span class="l"></span><span class="r"></span><span class="t">Credits</span></a></li>
        <li><a href="Service.aspx" class="active">><span class="l"></span><span class="r"></span><span class="t">Service</span></a></li>
    </ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="server">
<h3>ASPX WebService</h3>

<br />
<form id="Form1" runat="server">
 <b>WebService Cek Informasi </b>
 <br />
 <asp:TextBox ID = "usernametxt" runat = "server" /> 
 <br />
 <asp:Button ID = "btn_service" runat = "server" Text = "Check" 
     onclick="btn_service_Click"/>
 <br />
 <b>Jumlah Kontest yang diikuti </b> <br /> <asp:Label ID = "JumAnswerResp" runat ="server" />
 <br />
 <b>Submission Problem </b > <br /> <asp:Label ID = "JumSubmission" runat ="server" />
</form>
</asp:Content>

