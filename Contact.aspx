<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
.bigicon {
        font-size: 35px;
        color: #36A0FF;
    }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <!-- jumbotron-->

    <div class="jumbotron" style="background-color:#eee;">
        <div class="container text-center" style="color:#333;">
            <br />
            <h1>Contact us at <i class="fa fa-paint-brush"></i> Craft Store</h1>
            <br />
        </div>
    </div>
    <!-- END jumbotron-->

 <div class="container" >
  <div class="row">
      <div class="form-horizontal">
      <div class="col-xs-12 col-sm-offset-2 col-sm-8 col-md-offset-4 col-md-8">
        <h1 style="color:white">Fill out the form below!</h1>
  
         <div class="form-group">
                            <span class="col-xs-1 col-sm-1 col-md-1  text-center"><i class="fa fa-user bigicon"></i></span>
                            <div class="col-xs-11 col-sm-7 col-md-6">
                                <input id="username" name="username" type="text" placeholder="Name" class="form-control"/>
                            </div>
                        </div>

                        <div class="form-group">
                            <span class="col-xs-1 col-sm-1 col-md-1 text-center"><i class="fa fa-pencil-square-o bigicon"></i></span>
                            <div class="col-xs-11 col-sm-7 col-md-6">
                                <textarea class="form-control" id="usermsg" name="usermsg" placeholder="Enter your message for us here." rows="7"></textarea>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-offset-1 col-sm-7 col-md-offset-1 col-md-6 text-center">
                                <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
                                <asp:Button ID="btnForm" runat="server" Class="btn btn-primary btn-block" Text="Submit" OnClick="btnForm_Click" />
                                <asp:Label ID="lblStatus" runat="server" ></asp:Label>
                            </div>
                       </div>

              </div>
         </div>         
    </div>  
    </div>

</asp:Content>

