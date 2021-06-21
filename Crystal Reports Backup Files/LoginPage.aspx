<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ProjectPSD.View.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Login Page</h3>
    <div>
        <asp:Label Text="Username" runat="server" />
        <asp:TextBox ID="txtUsername" runat="server" />
    </div>
    <div>
        <asp:Label Text="Password" runat="server" />
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
    </div>
    <div>
        <asp:CheckBox ID="chkRemember" Text="Remember Me" runat="server" />
    </div>
    <br />
    <div>
        <asp:button ID="btnLogin" text="Login" runat="server" OnClick="btnLogin_Click" />
    </div>
    <div>
        <asp:Label ID="lblError" Text="" ForeColor="Red" runat="server" />
    </div>
</asp:Content>
