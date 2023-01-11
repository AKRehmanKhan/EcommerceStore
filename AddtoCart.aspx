<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AddtoCart.aspx.cs" Inherits="DB_Prpject.AddtoCart" EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div align="center">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <h1><strong>


    <asp:Label ID="Label1" runat="server" Text="My Cart" style="text-align: center"></asp:Label>




        </strong></h1>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkButton14_Click">&lt;-- Continue Shopping</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton15" runat="server" OnClick="LinkButton15_Click">clear cart</asp:LinkButton>
        </p>
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No Product Available In Cart" ForeColor="Black" BorderColor="#000099" BorderWidth="5px" Font-Bold="True" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="srno" HeaderText="Sr No">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="pid" HeaderText="Product ID">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:ImageField DataImageUrlField="pimage" HeaderText="Product Image">
                <ControlStyle Height="300px" Width="340px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:ImageField>
            <asp:BoundField DataField="pname" HeaderText="Product Name">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="pprice" HeaderText="Price">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="pquantity" HeaderText="Quantitiy">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ptotalprice" HeaderText="Total Price">
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#0066FF" />
        <HeaderStyle BackColor="#187E18" ForeColor="White" />
    </asp:GridView>--%>
        <div class="text-sm-center">
        <asp:GridView ID="GridView1" runat="server" ForeColor="Black" Height="45px" Width="623px"  HorizontalAlign="Center" EmptyDataText="Your Cart Is Empty" >
        </asp:GridView>
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label2" runat="server" Text="Total" Width="100px"></asp:Label>
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        &nbsp;
    <asp:Button ID="Button1" runat="server" BackColor="#187E18" ClientIDMode="Predictable" CssClass="active" Font-Bold="True" ForeColor="White" Text="Buy" Width="104px" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
                <div ID="pane" runat="server" style="top: 700px; position: absolute; left: 500px; color: #000000; background-color: #3399FF;">

                <asp:Panel ID="Panel1" runat="server" Height="251px" HorizontalAlign="Center" Width="348px" CssClass="auto-style1">
                    <div class="text-sm-center">
                        <br />
                        <br />
                        &nbsp;<asp:Label ID="Label9" runat="server" Text="Purchased Successful"></asp:Label>
                        <br />
                        &nbsp;<br /> &nbsp;<asp:Button ID="Button2" runat="server" Height="35px" OnClick="Button2_Click" Text="close" Width="99px" />
                        <br />
                        <br />
                    </div>
                </asp:Panel>
                    

                </div>
                <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />

        </div>


</asp:Content>
