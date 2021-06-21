<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="AccountPage.aspx.cs" Inherits="ProjectPSD.View.AccountPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Account Profile</h3>
    <div>
        <asp:label text="Name: " runat="server" />
        <asp:label ID="lblName" text="" runat="server" />
    </div>
    <div>
        <asp:label text="Username: " runat="server" />
        <asp:label ID="lblUsername" text="" runat="server" />
    </div>
    <br />
    <h3>Update Profile</h3>
    <div>
        <asp:label text="Name: " runat="server" />
        <asp:TextBox ID="txtName" runat="server" />
    </div>
    <div>
        <asp:Label Text="Old Password" runat="server" />
        <asp:TextBox ID="txtOldPassword" TextMode="Password" runat="server" />
    </div>
    <div>
        <asp:Label Text="New Password" runat="server" />
        <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server" />
    </div>
    <div>
        <asp:Label Text="Confirm Password" runat="server" />
        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" />
    </div>
    <br />
    <asp:Button ID="btnUpdateProfile" Text="Update Profile" OnClick="btnUpdateProfile_Click" runat="server" />
    <div>
        <asp:Label ID="lblError" Text="" ForeColor="Red" runat="server" />
    </div>
</asp:Content>
