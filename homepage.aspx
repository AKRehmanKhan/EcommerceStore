<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="DB_Prpject.homepage" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 38px;
            text-align: center;
            width: 338px;
            background-color: #009933;
        }
        .auto-style3 {
            text-align: center;
            color: #000000;
            width: 338px;
            background-color: #009933;
        }
        .auto-style5 {
            height: 38px;
            text-align: center;
            width: 338px;
            font-weight: bold;
            background-color: #009933;
        }
        .auto-style6 {
            color: #663300;
            font-size: medium;
        }
        .auto-style7 {
            font-weight: normal;
            color: #0000FF;
            font-size: large;
        }
        .auto-style8 {
            color: #0000FF;
            font-size: large;
        }
        .auto-style9 {
            font-size: medium;
        }
        .auto-style10 {
            height: 20px;
            text-align: center;
            width: 338px;
            background-color: #009933;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

    <setion>
        <div>
            <center>
            <h1  style="color:blue">Our Products&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="51px" ImageUrl="~/Images/s.png" OnClick="ImageButton1_Click" Width="57px" />
                <asp:ImageButton ID="ImageButton2" runat="server" Height="51px" ImageUrl="~/Images/restore.jpg" OnClick="ImageButton2_Click" Width="57px" />
                <asp:ImageButton ID="ImageButton3" runat="server" Height="44px" ImageUrl="~/laptopimajes/addtocart.jpg" OnClick="ImageButton3_Click" Width="46px" />
                </h1>
                <p  style="color:blue">&nbsp;</p>
            </center>
        </div>

    </setion>
    
     <setion>
        <div>
           <hr />

        </div>
    </setion>

   <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" BorderColor="White" BorderWidth="5px" CellPadding="20" CellSpacing="100" HorizontalAlign="Center" BackColor="White" OnItemCommand="DataList1_ItemCommand"   >
                    <ItemTemplate>
                        <table class="w-100" border="1" style="color: #008080">
                            <tr>
                                <td class="auto-style3" style="border-width: medium; border-color: #008000; background-color: #CCCCCC;">
                                    <asp:Image ID="Image1" runat="server" Height="227px" ImageURl='<%#  Bind("_image")%>' Width="327px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1" style="border-width: medium; border-color: #008000; background-color: #CCCCCC;">
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label1" runat="server" style="font-weight: 700; text-align: center; text-decoration: underline; color: #0033CC; font-size: x-large; font-family: Bahnschrift;" Text='<%# Bind("namep")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5" style="border-width: medium; border-color: #008000; background-color: #CCCCCC;">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("_name")%>' CssClass="auto-style6"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5" style="border-width: medium; border-color: #008000; background-color: #CCCCCC;">
                                    <span class="auto-style8">R</span><span class="auto-style7"><strong>s.</strong></span>
                                    <asp:Label ID="Label5" runat="server" style="color: #FF0000" Text='<%# Bind("price")%>' CssClass="auto-style9"></asp:Label>
                                    <span class="auto-style6">&nbsp;</span></td>
                            </tr>
                            <tr>
                                <td class="auto-style5" style="border-width: medium; border-color: #008000; background-color: #CCCCCC;">
                                    <asp:Label ID="Label8" runat="server" Text="Stock   "></asp:Label>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5" style="border-width: medium; border-color: #008000; background-color: #CCCCCC;">
                                    <asp:LinkButton ID="LinkButton14" runat="server" CommandArgument='<%#Eval("ID")%>' CommandName="details" Font-Bold="True" Font-Italic="True" Font-Overline="False" ForeColor="#009900">Details</asp:LinkButton>
                                    &nbsp;<asp:Label ID="Label6" runat="server"  Text='Stock   <%# Bind("Stock") %>' Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10" style="border-width: medium; border-color: #008000; background-color: #CCCCCC;">
                                    <asp:LinkButton ID="LinkButton15" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#009900" CommandArgument='<%#Eval("ID")%>' CommandName="cart">Add to cart</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>



                <br />
                <br />
                &nbsp;
                <br />
                <br />
            </div>
         </div>
         <div class="row">
            <div class="col-md-12">
                <br />
            </div>
         </div>
      </div>
   </section>
  
</asp:Content>