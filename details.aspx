<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="DB_Prpject.details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="col" style="font-size: x-large; color: #0000FF;">
          <center>
                         <br />
                         Details<br />
                         <br />
              </center>
          </div>
   <div class="row" runat="server" ID="ssd">
        <center>
                   
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                         <br />
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SSD_ID" AllowSorting="True" Width="1153px">
                           <Columns>           
                               <asp:BoundField DataField="SSD_ID" HeaderText="SSD_ID" SortExpression="SSD_ID" ReadOnly="True" >                           
                                 <ControlStyle Font-Bold="True" />
                                 <ItemStyle Font-Bold="True" />
                              </asp:BoundField>
                              <asp:TemplateField>
                                 <ItemTemplate>
                                    <div class="container-fluid">
                                       <div class="row">
                                           <div class="col-lg-10">
                                             <div class="row">
                                                <div class="col-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("Brand") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>Size - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Size") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;</span>Price - </span>
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("Price") %>'></asp:Label>
                                                   &nbsp;| 
                                                   <span>
                                                      Stock -<span>&nbsp;</span>
                                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Stock") %>'></asp:Label>
                                                   </span>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-2">                                         
                                              <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("SSD_Pic") %>' />
                                          </div>
                                       </div>
                                    </div>
                                 </ItemTemplate>
                              </asp:TemplateField>
                           </Columns>
                        </asp:GridView>
                         <br />
                  
                </center>
                  </div>


<%--    ///////////////////////////////--%>
   <div class="row" runat="server"  id="laptop">
        <center>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Laptop_ID" AllowSorting="True">
                           <Columns>           
                               <asp:BoundField DataField="Laptop_ID" HeaderText="Laptop_ID" SortExpression="Laptop_ID" ReadOnly="True" >                           
                                 <ControlStyle Font-Bold="True" />
                                 <ItemStyle Font-Bold="True" />
                              </asp:BoundField>
                              <asp:TemplateField>
                                 <ItemTemplate>
                                    <div class="container-fluid">
                                       <div class="row">
                                          <div class="col-lg-10">
                                             <div class="row">
                                                <div class="col-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("Laptop_Name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>Brand - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Brand") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;</span>Generation - </span>
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("Generation") %>'></asp:Label>
                                                   &nbsp;| 
                                                   <span>
                                                      Processor -<span>&nbsp;</span>
                                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Proceesor") %>'></asp:Label>
                                                   </span>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   RAM -
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("RAM") %>'></asp:Label>
                                                   &nbsp;| HDD -
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("HDD") %>'></asp:Label>
                                                   &nbsp;| SSD -
                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("SSD") %>'></asp:Label>   
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Price -
                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("Price") %>'></asp:Label>
                                                   &nbsp;| Stock -
                                                   <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("Stock") %>'></asp:Label>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-2">                                         
                                              <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("Laptop_Pic") %>' />
                                          </div>
                                       </div>
                                    </div>
                                 </ItemTemplate>
                              </asp:TemplateField>
                           </Columns>
                        </asp:GridView>
                     </div>
           </center>
                  </div>
    <br />
&nbsp;<%--//////////////////--%><div class="col" runat="server" id="ram">
        <center>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="RAM_ID" AllowSorting="True">
                           <Columns>           
                               <asp:BoundField DataField="RAM_ID" HeaderText="RAM_ID" SortExpression="RAM_ID" ReadOnly="True" >                           
                                 <ControlStyle Font-Bold="True" />
                                 <ItemStyle Font-Bold="True" />
                              </asp:BoundField>
                              <asp:TemplateField>
                                 <ItemTemplate>
                                    <div class="container-fluid">
                                       <div class="row">
                                          <div class="col-lg-10">
                                             <div class="row">
                                                <div class="col-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("Brand") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>Size - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Size") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;  
                                                   <span>DDR - </span>
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("DDR_Version") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;      

                                                   </span>Price - </span>
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("Price") %>'></asp:Label>
                                                   &nbsp;| 
                                                   <span>
                                                      Stock -<span>&nbsp;</span>
                                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Stock") %>'></asp:Label>
                                                   </span>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-2">                                         
                                              <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("RAM_Pic") %>' />
                                          </div>
                                       </div>
                                    </div>
                                 </ItemTemplate>
                              </asp:TemplateField>
                           </Columns>
                        </asp:GridView>
                        <br />
            </center>
                     </div>
</asp:Content>
