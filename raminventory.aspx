<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="raminventory.aspx.cs" Inherits="DB_Prpject.raminventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find
              ("tr:first"))).dataTable();
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
            width: 212px;
        }
        .auto-style3 {
            width: 170px;
            height: 137px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>RAM Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                            <%-- imjview is for javascript file --%>
                           <img id="imgview" src="laptopimajes/ram.jpg" class="auto-style3" />
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
                        <label>RAM ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="RAM ID"></asp:TextBox>
                              <asp:Button class="form-control btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                           </div>
                        </div>
                     </div>
                      <div class="col-md-8">
                        <label>Brand Name</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Kingston" Value="Kingston" />
                              <asp:ListItem Text="Hikvision" Value="Hikvision" />
                              <asp:ListItem Text="Kingfast" Value="Kingfast" />
                           </asp:DropDownList>
                        </div>
                             </div>
                  
                  </div>
                 
                      <div class="row">
                         <div class="col-md-6">
                        <label>DDR Version</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="1st" Value="1" />
                              <asp:ListItem Text="2nd" Value="2" />
                              <asp:ListItem Text="3rd" Value="3" />
                               <asp:ListItem Text="4th" Value="4" />
                              <asp:ListItem Text="5th" Value="5" />
                           </asp:DropDownList>
                        </div>
                             </div>
                         <div class="col-md-6">
                        
                      <label>Size</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="----GB" ></asp:TextBox>
                        </div>
                          </div>
                       
                             </div>
                    
                    
                       
                    
                
                    
                  <div class="row">

                      <div class="col-md-6">
                          <label>RAM Price</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Rs----" ></asp:TextBox>
                        </div>   
                          </div>   
                       
                       <div class="col-md-6">
                        <label>Stock</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Stock" ></asp:TextBox>
                        </div>
                     </div>

                      
               
                  </div>
                 
                  <div class="row mx-auto">
                     <div class="col-4 mx-auto">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button1_Click" Width="85px" />
                     </div>
                     <div class="col-4 mx-auto">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" Width="85px" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button2_Click" Width="85px" />
                     </div>
                  </div>
              
           
         </div>
           
            <br>
         </div>
         </div>
          </div>
        </div>
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