<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminSellerDetails.aspx.cs" Inherits="DB_Prpject.AdminSellerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div class="row p-3 mt-4">
            <h1>
                Sellers Lists ✨;
            </h1>
        </div>

        <div class="row p-3 py-4">
            <div class="col-md-7">
                <div class="row">
                    <div class="col-md-5">
                        <asp:TextBox ID="Admin_seller_details_user_text" placeholder="User_Id" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="Admin_seller_details_remove_btn" CssClass="btn btn-outline-danger" runat="server" Text="Remove" OnClick="Admin_seller_details_remove_btn_Click" />
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
            <asp:SqlDataSource ID="Admin_seller_SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbprojectConnectionString2 %>" SelectCommand="SELECT * FROM [sellers]"></asp:SqlDataSource>
            <div class="col">
                <asp:GridView CssClass="table table-striped table-bordered" ID="Admin_seller_GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="Admin_seller_SqlDataSource1" DataKeyNames="login_id">
                    <Columns>
                        <asp:BoundField DataField="login_id" HeaderText="login_id" SortExpression="login_id" ReadOnly="True" />
                        <asp:BoundField DataField="_password" HeaderText="_password" SortExpression="_password" />
                        <asp:BoundField DataField="full_name" HeaderText="full_name" SortExpression="full_name" />
                        <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="dob" />
                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                        <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                        <asp:BoundField DataField="_address" HeaderText="_address" SortExpression="_address" />
                        <asp:BoundField DataField="phone_number" HeaderText="phone_number" SortExpression="phone_number" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <%--<div class="row p-3 px-5">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Name</th>
                        <th scope="col">Email</th>
                        <th scope="col">Number</th>
                        <th scope="col">Total Products</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">1</th>
                        <td>Arslan</td>
                        <td>abc@gmail.com</td>
                        <td>123456789</td>
                        <td>10</td>
                        <td>
                            <asp:Button CssClass="btn btn-sm p-1 btn-danger text-white" ID="Button1" runat="server" Text="Remove" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">2</th>
                        <td>Rasheed</td>
                        <td>abc@gmail.com</td>
                        <td>123456789</td>
                        <td>20</td>
                        <td>
                            <asp:Button CssClass="btn btn-sm p-1 btn-danger text-white" ID="Button2" runat="server" Text="Remove" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">3</th>
                        <td>Arham</td>
                        <td>abc@gmail.com</td>
                        <td>123456789</td>
                        <td>50</td>
                        <td>
                            <asp:Button CssClass="btn btn-sm p-1 btn-danger text-white" ID="Button3" runat="server" Text="Remove" />
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">4</th>
                        <td>Taimor</td>
                        <td>abc@gmail.com</td>
                        <td>123456789</td>
                        <td>70</td>
                        <td>
                            <asp:Button CssClass="btn btn-sm p-1 btn-danger text-white" ID="Button4" runat="server" Text="Remove" />
                        </td>
                    </tr>
                                
                </tbody>
            </table>
        </div>--%>
    </div>

</asp:Content>
