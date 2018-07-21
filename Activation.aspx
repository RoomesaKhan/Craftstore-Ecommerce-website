<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Activation.aspx.cs" Inherits="Activation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="css/Login.css" rel="stylesheet"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container" >
  <div class="row">
    <div class="Absolute-Center is-Responsive">
        
     <h3 class="text-center">Enter your Activation Code</h3>
     <div class="col-sm-12 col-md-10 col-md-offset-1">
      
          <div class="form-group ">
            <asp:textbox id="code" runat="server" class="form-control" ></asp:textbox>

         </div>

         
          <div class="form-group">
            <asp:Label ID="ErrorMessage" runat="server" Text=""></asp:Label>
             
            <asp:Button ID="btnVerify" runat="server" Class="btn btn-def btn-block" Text="Verify"  OnClick="btnVerify_Click"/>
          </div>
        
          
      </div>  
    </div>    
  </div>
</div>

</asp:Content>

