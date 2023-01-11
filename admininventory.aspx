<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="admininventory.aspx.cs" Inherits="DB_Prpject.admininventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 189px;
            height: 136px;
        }
        .auto-style3 {
            width: 206px;
            height: 166px;
        }
        .auto-style4 {
            width: 193px;
            height: 169px;
        }
        .auto-style5 {
            width: 182px;
            height: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h2>Inventory Editing</h2>
               </center>
            </div>
         </div>
         <div class="row">
            <div class="col-md-12">
               <center>
                   <img src="Images/laptop1.jpg" class="auto-style3" /><br />
                   <br />
                   <asp:Button ID="Button1" runat="server" BackColor="#009900" ForeColor="White" OnClick="Button1_Click" Text="Edit LAPTOPs" />
&nbsp;<br />
                   <br />
               </center>
            </div>
            <div class="col-md-12">
               <center>
                   <img src="laptopimajes/rmm%20200.jpg" class="auto-style4" /><br />
                   <br />
                   <asp:Button ID="Button2" runat="server" BackColor="#009900" ForeColor="White" OnClick="Button2_Click" Text="Edit RAMs" />
                   <br />
                   <br />
                       </center>
            </div>
            <div class="col-md-12">
               <center>
                   <img src="laptopimajes/ssd.jpg" class="auto-style5" /><br />
                   <br />
                   <asp:Button ID="Button3" runat="server" BackColor="#009900" ForeColor="White" OnClick="Button3_Click" Text="Edit SSDs" />
                       <br />
                   <br />
                       <br />
                       </center>
            </div>
         </div>
      </div>
   </section>
</asp:Content>
