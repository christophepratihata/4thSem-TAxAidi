<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="ProjectPSD.View.OrderPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .button {
            margin-left: 100px;
        }

        .bold {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Order Page</h3>

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Label CssClass="bold" Text="Show Name: " runat="server" />
                    <asp:Label ID="lblShowName" Text="" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label CssClass="bold" Text="Show Price: " runat="server" />
                    <asp:Label ID="lblShowPrice" Text="" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label CssClass="bold" Text="Seller Name: " runat="server" />
                    <asp:Label ID="lblSellerName" Text="" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label CssClass="bold" Text="Description: " runat="server" />
                    <asp:Label ID="lblDescription" Text="" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label CssClass="bold" Text="Average Rating: " runat="server" />
                    <asp:Label ID="lblRating" Text="" runat="server" />
                </div>
                <br />
                <div>
                    <asp:Label Text="Quantity: " runat="server" />
                    <asp:TextBox ID="txtQuantity" TextMode="Number" runat="server" />
                </div>

                <asp:Calendar ID="pickDate" runat="server"></asp:Calendar>

                <asp:GridView runat="server" ID="showTimeGrid" AutoGenerateColumns="False" OnRowDataBound="showTimeGrid_RowDataBound" OnRowCommand="showTimeGrid_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="timeList" HeaderText="Show Time">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </asp:BoundField>

                        <asp:ButtonField ButtonType="button" Text="Order" CommandName="Order" ShowHeader="false" ItemStyle-BorderWidth="0px">
                            <ItemStyle HorizontalAlign="center" Width="130px" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>

                <div>
                    <asp:Label ID="lblError" ForeColor="Green" Text="" runat="server" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>



    </div>
</asp:Content>
