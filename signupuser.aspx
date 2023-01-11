<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="signupuser.aspx.cs" Inherits="DB_Prpject.signupuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
   <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="Images/usergeneral.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>SignUp</h4>
                           
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Date of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" TextMode="Phone"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                    <div class="row">
                     <div class="col-md-6">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="City" ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Gender</label>
                       <%-- <div class="form-group">
                           <asp:RadioButton ID="RadioButton1" runat="server" Text="Male" GroupName="gender" />  
                           <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" GroupName="gender" /> 
                        </div>--%>
                          <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Male" Value="Male" />
                              <asp:ListItem Text="Female" Value="Feamle" />
                              <asp:ListItem Text="Not Say" Value="Not Say" />                 
                           </asp:DropDownList>
                         <%--<asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Gender" ></asp:TextBox>--%>

                     </div>
                  </div>


                  <div class="row">
                     <div class="col">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                            <!--Badges BootStrap-->
                           <span class="badge badge-pill badge-info">Login Credentials</span>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>User ID</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="User ID"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                </div>

                   <br />

              <div class="row">
                     <div class="col-md-7">
                          <div class="form-group">
                              <!--class="btn btn-info btn-block btn-lg"-->
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button22" runat="server" Text="Seller " OnClick="Button22_Click" Width="184px" />
                        </div>
                     </div>
                     <div class="col-md-5">
                         <div class="form-group">
                              <!--class="btn btn-info btn-block btn-lg"-->
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button2" runat="server" Text="Buyer"  OnClick="Button2_Click" Width="186px" />
                        </div>
                     </div>
               </div>
                   
                  <br />
            
            <a href="homepage.aspx"><<-- Back to Home</a><br><br>
         </div>           
      </div>
       </div>


</asp:Content>

