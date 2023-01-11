<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="DB_Prpject.Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

  <div class="container">
    <div>
        <center>
            <h3>
                Logout Successfully
            </h3>
        </center>
    </div>
      <div class="row">
         <div class="col">
            <hr>
       </div>
     </div>

     <br />
    <div>
        <center>
            <h6>
                Thank You for using Al-Mashory Zaman
            </h6>
        </center>
    </div>

     <br />
    <div>
        
        <div class="row">
            <div class="col-md-5 mx-auto">
                 <div class="form-group">
            <a href="login.aspx"><input class="btn btn-info btn-block btn-lg" id="Button2" type="button" value="Login" /></a>
                </div>
            </div>
        </div>
      
                     

    </div>


      <br />


    <div>
        <center>
            <a href="homepage.aspx"><<-- Back to Home</a><br><br>
        </center>
    </div>
  </div>


</asp:Content>
