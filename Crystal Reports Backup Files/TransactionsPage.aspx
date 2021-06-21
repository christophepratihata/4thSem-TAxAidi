<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="TransactionsPage.aspx.cs" Inherits="ProjectPSD.View.TransactionsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
     .grTransaction:hover
        {
            background-color: lightgray;
            border-top: solid;
            font-weight:800;
        }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Transactions Page</h3>
    <br />
    <asp:GridView runat="server" ID="grTransactions" AutoGenerateColumns="False" 
        OnRowDataBound="grTransactions_RowDataBound" OnSelectedIndexChanged="grTransactions_SelectedIndexChanged"
        CellPadding="1" RowStyle-CssClass="grTransaction">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Header ID" SortExpression="Id" />
            <asp:BoundField DataField="CreatedAt" HeaderText="Payment Date" SortExpression="CreatedAt" />
            <asp:BoundField DataField="ShowName" HeaderText="Show Name" SortExpression="ShowName" />
            <asp:BoundField DataField="ShowTime" HeaderText="Show Time" SortExpression="ShowTime" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" SortExpression="TotalPrice" />
        </Columns>
    </asp:GridView>
</asp:Content>
