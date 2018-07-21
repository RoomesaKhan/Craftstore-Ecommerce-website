<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="css/Login.css" rel="stylesheet"/>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
  <div class="row">
    <div class="Absolute-Center is-Responsive">
     
      <div class="col-sm-12 col-md-10 col-md-offset-1">
          <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
            <asp:textbox id="username" runat="server" class="form-control" placeholder="username"></asp:textbox>         
          </div>
          <asp:RequiredFieldValidator ID="RequiredFieldUsername" runat="server" ErrorMessage="Username required" ControlToValidate="username" CssClass="text-danger" Visible="False"></asp:RequiredFieldValidator>
          <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
              <asp:TextBox ID="password" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>     
          </div>
           <asp:RequiredFieldValidator  ID="RequiredFieldPassword" runat="server" ErrorMessage="Password required" ControlToValidate="password" CssClass="text-danger" Visible="False"></asp:RequiredFieldValidator>  
         
           <div class="form-group">
                        <div class="col-md-2"></div>                    
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Remember me ?"></asp:Label>
                   
          </div>
           
          <div class="form-group">
           <asp:Button ID="btnLogin" runat="server" Class="btn btn-def btn-block" Text="Login" OnClick="btnLogin_Click"/>
          </div>

           <div class="form-group" style="clear: left">                       
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
            </div>

          <br />
         
          <div class="form-group text-center">
           <a href="AdminLogin.aspx">Login as Admin</a>
            <br />Don't have a account yet? <a href="Signup.aspx">Sign Up</a>
          </div>        
      </div>  
    </div>    
  </div>
</div>
</asp:Content>

