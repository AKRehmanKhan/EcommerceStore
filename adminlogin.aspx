﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="DB_Prpject.adminlogin" %>
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
                                   <img  width="150px" src="Images/usergeneral.png" /> 
                               </center>
                            </div>
                       </div>


                       <div class="row">
                            <div class="col">
                               <center>
                                   <h3>
                                       Admin Login
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
                              <label>Admin ID</label>
                              <div class="form-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Admin ID" TextMode="SingleLine"></asp:TextBox>
                               </div> 
                           </div>
                       </div>

                        <label>Password</label>
                          <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                          </div>

                   <div class="row mx-auto">
                     <div class="col-4 mx-auto">
                       <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
                        </div>
                         </div>
                       </div>

                       

                   </div>
               </div>
               <a href="homepage.aspx"><<-- Back to Home</a><br><br>
           </div>
       </div>
   </div>
</asp:Content>


