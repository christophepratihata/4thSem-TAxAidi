<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="UpdateShowPage.aspx.cs" Inherits="ProjectPSD.View.UpdateShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Update Show Page</h3>
    <div>
        <asp:Label Text="Show Name: " runat="server" />
        <asp:TextBox ID="txtName" runat="server" />
    </div>
    <div>
        <asp:Label Text="Show Price: " runat="server" />
        <asp:TextBox ID="txtPrice" TextMode="Number" runat="server" />
    </div>
    <div>
        <asp:Label Text="Description: " runat="server" />
        <asp:TextBox ID="txtDescription" runat="server" />
    </div>
    <div>
        <asp:Label Text="URL: " runat="server" />
        <asp:TextBox ID="txtURL" runat="server" />
    </div>
    <br />
    <asp:Button ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" runat="server" />
    <div>
        <asp:Label ID="lblError" Text="" ForeColor="Red" runat="server" />
    </div>
</asp:Content>
