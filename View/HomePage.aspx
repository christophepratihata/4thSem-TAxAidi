<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ProjectPSD.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Home Page</h3>
    <div>
        <asp:GridView runat="server" ID="gvShow" AutoGenerateColumns="False" OnRowEditing="gvShow_RowEditing">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Show ID" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Show Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Show Description" SortExpression="Description" />
                <asp:BoundField DataField="Price" HeaderText="Show Price" SortExpression="Price" />
                <asp:BoundField DataField="URL" HeaderText="Show URL" SortExpression="URL" />
                <asp:BoundField DataField="User.Name" HeaderText="Seller Name" SortExpression= "User.Name" />
                <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Action" ShowHeader="True" Text="View Details" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
