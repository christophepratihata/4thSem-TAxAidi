<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="AddShowPage.aspx.cs" Inherits="ProjectPSD.View.AddShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Add Show Page</h3>


    <div>
        <asp:Label Text="Name" runat="server" />
        <asp:TextBox ID="txtName" runat="server" />
    </div>
    <div>
        <asp:Label Text="URL" runat="server" />
        <asp:TextBox ID="txtURL" runat="server" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Invalid URL"
            ControlToValidate="txtURL" runat="server" ForeColor="Red"
            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" />
    </div>
    <div>
        <asp:Label Text="Description" runat="server" />
        <asp:TextBox ID="txtDescription" runat="server" />
    </div>
    <div>
        <asp:Label Text="Price" runat="server" />
        <asp:TextBox ID="txtPrice" TextMode="Number" runat="server" />
    </div>
    <br />
    <div>
        <asp:Button ID="btnAddShow" Text="Add Show" OnClick="btnAddShow_Click" runat="server" />
    </div>
    <asp:Label ID="lblError" Text="" ForeColor="Red" runat="server" />
</asp:Content>
