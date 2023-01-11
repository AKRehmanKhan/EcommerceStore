<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminOrderDetails.aspx.cs" Inherits="DB_Prpject.AdminOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row p-3 py-4">
            <h1>
                Order Details🎁;
            </h1>
        </div>

        <%--<div class="row p-3 py-4">
            <div class="col-md-7">
                <div class="row">
                    <div class="col-md-5">
                        <asp:TextBox ID="Admin_Order_details_email_text" placeholder="Email" type="email" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="Admin_Order_details_remove_btn" CssClass="btn btn-outline-danger" runat="server" Text="Remove"  />
                    </div>
                </div>
            </div>
        </div>--%>

        <div class="row mt-3 mb-3">
            <div class="col">
                <hr>
            </div>
        </div>

        <div class="row py-4">
            <asp:SqlDataSource ID="Admin_order_SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbprojectConnectionString2 %>" SelectCommand="SELECT * FROM [OrderDetails]"></asp:SqlDataSource>
            <div class="col">
                <asp:GridView ID="Admin_order_GridView1" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" runat="server" DataSourceID="Admin_order_SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Transacation_ID" HeaderText="Transacation ID" SortExpression="Transacation_ID" />
                        <asp:BoundField DataField="Customer_ID" HeaderText="Customer ID" SortExpression="Customer_ID" />
                        <asp:BoundField DataField="Seller_ID" HeaderText="Seller ID" SortExpression="Seller_ID" />
                        <asp:BoundField DataField="Product_ID" HeaderText="Product ID" SortExpression="Product_ID" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                        <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price" />
                        <asp:BoundField DataField="Date_Time" HeaderText="Date_Time" SortExpression="Date_Time" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
