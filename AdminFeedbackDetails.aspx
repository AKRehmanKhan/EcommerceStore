<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminFeedbackDetails.aspx.cs" Inherits="DB_Prpject.AdminFeedbackDetails" %>
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
                Feedback Details 🎁
            </h1>
        </div>

        <div class="row mt-3 mb-3">
            <div class="col">
                <hr>
            </div>
        </div>

        <div class="row py-4">
            <asp:SqlDataSource ID="AdminFeedbackSqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbprojectConnectionString2 %>" SelectCommand="SELECT * FROM [feedback]"></asp:SqlDataSource>
            <div class="col">
                <asp:GridView ID="Admin_feedback_GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="AdminFeedbackSqlDataSource1" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="True" />
                        <asp:BoundField DataField="customerID" HeaderText="customerID" SortExpression="customerID" />
                        <asp:BoundField DataField="productID" HeaderText="productID" SortExpression="productID" />
                        <asp:BoundField DataField="feedbackDate" HeaderText="feedbackDate" SortExpression="feedbackDate" />
                        <asp:BoundField DataField="fdescrip" HeaderText="fdescrip" SortExpression="fdescrip" />
                        <asp:BoundField DataField="rating" HeaderText="rating" SortExpression="rating" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
