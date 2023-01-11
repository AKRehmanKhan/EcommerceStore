<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="DB_Prpject.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
       <div clss="row">
           <div class="col-md-6 mx-auto">
               <div class="card">
                   <div class="card-body">
                      
                       


                       <div class="row">
                            <div class="col">
                               <center>
                                   <h3>
                                       FeedBack Form
                                   </h3>
                               </center>
                            </div>
                       </div>
                        <div class="row">
                         <div class="col">
                              <hr>
                         </div>
                      </div>
                       <div class="row">
                            <div class="col">
                              
                                   <h5>
                                       Enter Details
                                   </h5>
                               
                            </div>
                       </div>


                        <div class="row">
                         <div class="col">
                              <hr>
                         </div>
                      </div>

                       <div class="row">
                           <div class="col">
                              <label>Product ID</label>
                              <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Product ID"></asp:TextBox>
                               </div> 
                           </div>
                       </div>

                        <div class="col-md-6">
                        <label>Rating</label>
                       
                          <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="1" Value="1" />
                              <asp:ListItem Text="2" Value="2" />
                              <asp:ListItem Text="3" Value="3" />
                              <asp:ListItem Text="4" Value="4" />    
                              <asp:ListItem Text="5" Value="5" />  
                           </asp:DropDownList>

                         <%--<asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Gender" ></asp:TextBox>--%>

                     </div>

                       <div class="row">
                     <div class="col">
                        <label>FeedBack Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="FeedBack Description...." TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                       <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Submitt" Width="461px" OnClick="Button1_Click1" />
                        </div>
                       

                       

                   </div>
               </div>
               <a href="homepage.aspx"><<-- Back to Home</a><br><br>
           </div>
       </div>
   </div>

</asp:Content>