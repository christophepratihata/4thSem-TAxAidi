<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="ProjectPSD.View.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
    </div>
    <br />
    <div>
        <asp:Label Text="Show Name:" runat="server" />
        <br />
        <asp:Label ID="lblShowName" Text="" runat="server" />
    </div>
    <br />
    <div>
        <asp:Label Text="Average Rating:" runat="server" />
        <br />
        <asp:Label ID="lblRating" Text="" runat="server" />
    </div>
    <br />
    <div>
        <asp:Label Text="Description:" runat="server" />
        <br />
        <asp:Label ID="lblDescription" Text="" runat="server" />
    </div>
    <br />

    <asp:GridView runat="server" ID="grToken" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="TransactionHeaderId" HeaderText="Header Id" SortExpression="TransactionHeaderId" />
            <asp:BoundField DataField="Status.Name" HeaderText="Status" SortExpression="Status.Name" />
            <asp:BoundField DataField="Token" HeaderText="Token" SortExpression="Token" />
        </Columns>
    </asp:GridView>
    <br />
    <div>
        <asp:Label ID="lblError" Text="" ForeColor="Green" runat="server" />
    </div>

</asp:Content>
