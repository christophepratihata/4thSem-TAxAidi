<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ShowDetailPage.aspx.cs" Inherits="ProjectPSD.View.ShowDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Show Detail Page</h3>
    <div>
        <asp:Button ID="btnOrder" Text="Order" runat="server" OnClick="btnOrder_Click" />
        <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" />
    </div>
    <br />
    <div>
        <asp:Label Text="Show Name:" runat="server" />
        <br />
        <asp:Label ID="lblShowName" Text="" runat="server" />
    </div>
    <br />
    <div>
        <asp:Label Text="Show Price:" runat="server" />
        <br />
        <asp:Label ID="lblShowPrice" Text="" runat="server" />
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
        <asp:Label Text="Average Rating:" runat="server" />
        <br />
        <asp:Label ID="lblRating" Text="" runat="server" />
    </div>
    <br />
    <div>
        <asp:Label Text="Show Reviews:" runat="server" />
        <asp:GridView ID="grdReview" AutoGenerateColumns="False" runat="server">
            <Columns>
                <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
