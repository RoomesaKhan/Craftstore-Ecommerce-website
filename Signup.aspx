<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="css/Login.css" rel="stylesheet"/>
    
  <script src="http://codepen.io/assets/libs/fullpage/jquery.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" >
  <div class="row">
    <div class="Absolute-Center is-Responsive">
     <div class="col-sm-12 col-md-10 col-md-offset-1">
      <%--  <form id="contact_form">--%>

          <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
            <asp:textbox id="username" runat="server" class="form-control" placeholder="username"></asp:textbox>
             <%-- <input class="form-control" type="text" name='username' placeholder="username"/>--%>
         </div>

          <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
            <asp:TextBox ID="email" runat="server" class="form-control" placeholder="email" TextMode="Email"></asp:TextBox>
          </div>

        
          <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
              <asp:TextBox ID="password" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
            <!--<input class="form-control" type="password" name='password' placeholder="password"/>-->     
        </div>

          <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
              <asp:TextBox ID="confirm_password" runat="server" class="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
           <!-- <input class="form-control" type="password" name='retypepassword' placeholder="retype password"/>-->     
          </div>

            <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-phone"></i></span>
            <asp:TextBox ID="contact_number" runat="server" class="form-control" placeholder="Contact Number" TextMode="Phone"></asp:TextBox>
          </div>

        <%--  <div class="checkbox">
            <label>
              <input type="checkbox"> I agree to the <a href="#">Terms and Conditions</a>
            </label>
          </div>--%>
          <div class="form-group">
            <%--<button type="button" class="btn btn-def btn-block" id="btnSignup" onclick="btnSignup_Click">Signup</button>--%>
            <asp:Label ID="ErrorMessage" runat="server" Text=""></asp:Label>
              <asp:Button ID="btnSignup" runat="server" Class="btn btn-def btn-block" Text="Sign Up" OnClick="btnSignup_Click" />
              
          </div>
          <div class="form-group text-center">
            <br />Already have a account? <a href="Login.aspx">Login</a>
          </div>
       <%-- </form> --%>       
      </div>  
    </div>    
  </div>
</div>
<%--    <script src="Login.js"></script>
<script src="bootstrap.js"></script>
<script src="/js/formvalidation/formValidation(.min).js"></script>
<script src="/js/formvalidation/bootstrap(.min).js"></script  --%>  
</asp:Content>

