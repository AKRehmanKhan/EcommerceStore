<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminProductDetails.aspx.cs" Inherits="DB_Prpject.AdminProductDetails" %>
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
                Product Details ✨;
            </h1>
        </div>

        
         <div class="row p-3 py-2">
            <div class="col">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label1" runat="server" Text="Product ID"></asp:Label>
                        <asp:TextBox ID="Admin_Prod_ID_text" placeholder="Product ID" type="text" CssClass="form-control" runat="server"></asp:TextBox>
                    </div> 
                    
                    <div class="col-md-6">
                        <div class="pt-4">
                            <asp:Button ID="Admin_Prod_details_remove_btn" CssClass="btn btn-outline-danger" runat="server" Text="Remove" OnClick="Admin_Prod_details_remove_btn_Click" />
                        
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-3 mb-3">
            <div class="col">
                <hr>
            </div>
        </div>

        <div class="row">
            <asp:SqlDataSource ID="Admin_product_SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbprojectConnectionString2 %>" SelectCommand="SELECT * FROM [ProductDeatils]"></asp:SqlDataSource>
            <div class="col">
                <asp:GridView  ID="Admin_product_GridView1" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" runat="server" DataSourceID="Admin_product_SqlDataSource1" DataKeyNames="Product_ID">
                    <Columns>
                        <asp:BoundField DataField="Product_ID" HeaderText="Product_ID" SortExpression="Product_ID" ReadOnly="True" />
                        <asp:BoundField DataField="Product_Name" HeaderText="Product_Name" SortExpression="Product_Name" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand" ReadOnly="True" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                        <asp:BoundField DataField="Seller_Id" HeaderText="Seller_Id" SortExpression="Seller_Id" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>

</asp:Content>
