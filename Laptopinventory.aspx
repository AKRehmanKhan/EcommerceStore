<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Laptopinventory.aspx.cs" Inherits="DB_Prpject.Laptopinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 274px;
        }
        .auto-style3 {
            width: 172px;
            height: 128px;
        }
        .auto-style4 {
            left: 0px;
            top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Laptop Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                            <%-- imjview is for javascript file --%>
                           <img id="imgview" src="laptopimajes/laptop.jpg" class="auto-style3" />
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
                        <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Laptop ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Laptop ID"></asp:TextBox>
                              <asp:Button class="form-control btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-8">
                        <label>Laptop Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Laptop Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6 ">
                        <label>Generation</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="1st Generation" Value="1st Generation" />
                              <asp:ListItem Text="2nd Generation" Value="2nd Generation" />
                              <asp:ListItem Text="3rd Generation" Value="3rd Generation" />
                              <asp:ListItem Text="4rt Generation" Value="4th Generation" />
                              <asp:ListItem Text="5th Generation" Value="5th Generation" />
                              <asp:ListItem Text="6th Generation" Value="6th Generation" />
                              <asp:ListItem Text="7th Generation" Value="7th Generation" />
                              <asp:ListItem Text="8th Generation" Value="8th Generation" />
                              <asp:ListItem Text="9th Generation" Value="9th Generation" />
                              <asp:ListItem Text="10th Generation" Value="10th Generation" />
                              <asp:ListItem Text="11th Generation" Value="11th Generation" />
                              <asp:ListItem Text="12th Generation" Value="12th Generation" />
                           </asp:DropDownList>
                        </div>
                         </div>
                          <div class="col-md-6">
                        <label>Processor</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Processor(i3,i5 etc)"></asp:TextBox>
                       
                      </div>
                
                       </div>
                      </div>
                         <div class="row">
                         <div class="col-md-6">
                        <label>Brand Name</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="HP" Value="HP" />
                              <asp:ListItem Text="DELL" Value="DELL" />
                              <asp:ListItem Text="APPLE" Value="APPLE" />
                           </asp:DropDownList>
                        </div>
                             </div>
                         <div class="col-md-6">
                        
                              <label>RAM</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="----GB" ></asp:TextBox>
                        </div>
                          </div>
                       
                             </div>
                    
                    
                       
                    
                  <div class="row">
                     <div class="col-md-6">
                        <label>Hard Disk</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="____GB"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>SSD</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="____GB" ></asp:TextBox>
                        </div>
                     </div>
                     
                  </div>
    
                  
                      <div class="row">
                      <div class="col-md-6">
                          <label>Laptop Price</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Rs----" ></asp:TextBox>
                        </div>   
                          </div>   
                       
                       <div class="col-md-6">
                        <label>Stock</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Stock"  ></asp:TextBox>
                        </div>
                    
               
                  </div>
                 
                  <div class="row mx-auto">
                     <div class="col-4 mx-auto">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button1_Click" Width="82px" />
                     </div>
                     <div class="col-4 mx-auto">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" Width="83px" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button2_Click" Width="82px" />
                     </div>
                  </div>
               </div>
            </div>
         </div>
           
            <br>
         </div>
         </div>
          </div>
    <br />
             <div class="auto-style4">
      <br />
    <br />
                 <asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkButton14_Click">&lt;&lt; Back to Edit inventory</asp:LinkButton>
                 <br />
    <br />
    <a href="homepage.aspx"><< Back to Home</a><br>
    <br />
    <br />
    <br />
</asp:Content>