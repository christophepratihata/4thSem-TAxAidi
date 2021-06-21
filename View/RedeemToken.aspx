<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="RedeemToken.aspx.cs" Inherits="ProjectPSD.View.RedeemToken" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div
        style="margin-left: auto; margin-right: auto; margin-top: 100px; width: 264px">
        <h3 style="text-align:center">Redeem Token Page</h3>
        <asp:TextBox ID="txtToken" placeholder="Insert token" Style="text-align: center; font-size: 16pt; font-weight: 800; font-family:'Lucida Sans Typewriter';" runat="server" />
        <asp:Button ID="btnRedeem" CssClass="btnRedeem" Text="Redeem Token" Style="margin-left: 83px; margin-top: 20px;" runat="server" OnClick="btnRedeem_Click" />
        <br />
        <br />

        <asp:Label ID="errToken" Text="" Style="text-align: center; margin-left: 86px; color: red" runat="server" />
    </div>


</asp:Content>
