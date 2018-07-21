<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="css/Login.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">
  <div class="row">      
    <div class="Absolute-Center is-Responsive">    
      <div class="col-sm-12 col-md-10 col-md-offset-1">
          <h2>Welcome Admin</h2>
        <h5>Please provide the password!</h5> 
            <div class="form-group input-group">
                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                <asp:TextBox ID="passwordAdmin" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>     
            </div>
     <asp:RequiredFieldValidator  ID="RequiredFieldPassword" runat="server" ErrorMessage="Password required" ControlToValidate="passwordAdmin" CssClass="text-danger"></asp:RequiredFieldValidator>  
    <div class="form-group">
        <asp:Button ID="btnLoginAdmin" runat="server" Class="btn btn-def btn-block" Text="Login" OnClick="btnLoginAdmin_Click"/>
    </div>
    <div class="form-group" style="clear: left">                       
           <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
    </div>
      
    </div>
  </div>
 </div>
</div>
</asp:Content>

