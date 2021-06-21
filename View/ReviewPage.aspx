<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ReviewPage.aspx.cs" Inherits="ProjectPSD.View.ReviewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .resizenone {
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div>
        <asp:Button ID="btnRate" Text="Rate" runat="server" OnClick="btnRate_Click"/>
        <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="btnDelete_Click" />
    </div>
    <br />

    <div>
        <asp:Label Text="Show Name:" runat="server" />
        <br />
        <asp:Label ID="lblShowName" Text="" runat="server" />
    </div>
    <br />

    <div>
        <asp:Label Text="Seller Name:" runat="server" />
        <br />
        <asp:Label ID="lblSellerName" Text="" runat="server" />
    </div>
    <br />

    <div>
        <asp:Label Text="Description:" runat="server" />
        <br />
        <asp:Label ID="lblDescription" Text="" runat="server" />
    </div>
    <br />

    <div>
        <asp:Label Text="Rating:" runat="server" />
        <br />
        <asp:TextBox ID="txtRating" Text="" TextMode="Number" runat="server" />
    </div>
    <br />

    <div>
        <asp:Label Text="Description:" runat="server" />
        <br />
        <asp:TextBox CssClass="resizeNone" ID="txtDescription" Text="" TextMode="MultiLine" Rows="5" runat="server" />
    </div>
    <br />
    <div>
        <asp:Label ID="errReview" Text="" runat="server" />
    </div>
    <br />

</asp:Content>
