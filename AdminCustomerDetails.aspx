<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCustomerDetails.aspx.cs" Inherits="DB_Prpject.AdminCustomerDetails" %>
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
                Customers List✨;
            </h1>
        </div>

        <div class="row p-3 py-4">
            <div class="col-md-7">
                <div class="row">
                    <div class="col-md-5">
                        <asp:TextBox ID="Admin_Cust_details_user_text" placeholder="User_Id"  CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="Admin_Cust_details_remove_btn" CssClass="btn btn-outline-danger" runat="server" Text="Remove" OnClick="Admin_Cust_details_remove_btn_Click" />
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

            <asp:SqlDataSource ID="Admin_customer_SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbprojectConnectionString2 %>" SelectCommand="SELECT * FROM [customer]"></asp:SqlDataSource>
            <div class="col">
                <asp:GridView CssClass="table table-striped table-bordered" ID="Admin_customer_GridView1" AutoGenerateColumns="False" runat="server" DataSourceID="Admin_customer_SqlDataSource1" DataKeyNames="login_id">
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
        
    </div>
</asp:Content>
