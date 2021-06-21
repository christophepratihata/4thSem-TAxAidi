<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="ProjectPSD.View.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Register Page</h3>
    <div>
        <asp:Label Text="Name" runat="server" />
        <asp:TextBox ID="txtName" runat="server" />
    </div>
    <div>
        <asp:Label Text="Username" runat="server" />
        <asp:TextBox ID="txtUsername" runat="server" />
    </div>
    <div>
        <asp:Label Text="Password" runat="server" />
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
    </div>
    <div>
        <asp:Label Text="Confirm Password" runat="server" />
        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" />
    </div>
    <div>
        <asp:Label Text="Role" runat="server" /> <br />
        <asp:DropDownList ID="RoleList"
                    AutoPostBack="False"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">
                  <asp:ListItem Selected="True" Value=""> Choose Your Role </asp:ListItem>
                  <asp:ListItem Value="1"> Seller </asp:ListItem>
                  <asp:ListItem Value="2"> Buyer </asp:ListItem>
        </asp:DropDownList>
    </div>
    <br />
    <asp:Button ID="btnRegister" Text="Register" runat="server" OnClick="btnRegister_Click" />
    <div>
        <asp:Label ID="lblError" Text="" ForeColor="Red" runat="server" />
    </div>
</asp:Content>
