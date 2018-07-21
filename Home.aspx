<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
         .divider {
         margin: 5px;

         }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 
    <!-- slider-->
    <div class="container" style=" width:100%; height: 400px;">
        <section >

            <div class="carousel slide" id="screenshot-carousel" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#screenshot-carousel" data-slide-to="0" class="active"></li>
                    <li data-target="#screenshot-carousel" data-slide-to="1"></li>
                    <li data-target="#screenshot-carousel" data-slide-to="2"></li>
                    <li data-target="#screenshot-carousel" data-slide-to="3"></li>
                </ol>

                <div class="carousel-inner">
                    <div class="item active">
                        <img src="Images\slider\image1.jpg" alt="text of the image" style=" width:100%; height: 400px;" />
                       
                    </div>
                    <div class="item">
                        <img src="Images\slider\image2.jpg" alt="text of the image" style=" width:100%; height: 400px;" />
                        
                    </div>
                    <div class="item">
                        <img src="Images\slider\image1.jpg" alt="text of the image" style=" width:100%; height: 400px;"/>
                        
                    </div>
                    <div class="item">
                        <img src="Images\slider\image2.jpg" alt="text of the image" style=" width:100%; height: 400px;" />
                        
                    </div>
                </div>
                <!--end carousel inner-->



                <a href="#screenshot-carousel" class="left carousel-control" data-slide="prev">
                    <span class="glyphicon  glyphicon-chevron-left"></span>
                </a>

                <a href="#screenshot-carousel" class="right carousel-control" data-slide="next">
                    <span class="glyphicon  glyphicon-chevron-right"></span>
                </a>

            </div>
            <!--end carousel-->
        </section>
    </div>
    <!--end slider-->





    <!-- jumbotron-->

    <div class="jumbotron">
        <div class="container text-center">
            <h1><i class="fa fa-paint-brush"></i> Craft Store</h1>
            <p>20% off ALL items<br> Stock up on products must haves.<br>Save on painting, frames, sketches, and more! </p>

                

           
                <a href="ImageDisplay.aspx" class="btn btn-lg btn-warning">Visit Store and Shop Now</a>
          
        </div>
    </div>
    <!-- END jumbotron-->

   <!-- videos and one pic-->
    <div class="container">
        <section>
            
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-7 text-center" >
                        <img src = "Images\image14.png" alt = "Generic placeholder thumbnail" >
                    <br /><br />
                        <p style="color:pink;">
                            It’s great to send a card/painting when it’s someone’s birthday or a special 
                            occasion but what about sending someone a card for no
                             reason other than to make them smile?
                        </p>

                     <iframe width="320" height="345" style="margin-bottom:20px; margin-right:5px; border:5px;" src="https://www.youtube.com/embed/VYYZzZ2rE6o">
                      </iframe>
                      <iframe width="320" height="345" style="margin-bottom:20px; border:5px;" src="https://www.youtube.com/embed/gssiA9tBbD0">
                      </iframe>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-5 text-center">
                    <img src = "Images\image9.jpg" alt = "Generic placeholder thumbnail" style="height: 500px;width: 500px;">
                </div>
               
            </div>
        </section>
    </div>
    <!-- END container-->



    <!-- jumbotron-->

    <div class="jumbotron">
        <div class="container text-center">

          <div class="row">
           <div class="col-xs-12">
            <div class="btn-group">
                <ul class="nav nav-tabs">
                       <asp:Repeater ID="rptrCat" runat="server">
                              <ItemTemplate>   
                                   <li>
                                         <div class="divider">
                                             <asp:LinkButton ID="LinkButton1" NavigateUrl="#" runat="server" OnClick="Cat_Click" OnLoad="GetRandColor" CommandArgument='<%# Eval("CategoryID") %>'  CssClass="btn btn-lg btn-block dropdown-toggle" style="color:white;"><%# Eval("CategoryName") %></asp:LinkButton> 
                                         </div>
                                 </li>
                                  <asp:HiddenField ID="hfCategoryID" runat="server" Value='<%# Eval("CategoryID") %>' />
                              </ItemTemplate>
                          </asp:Repeater>
                        
                    </ul>




               <%-- <a href="" class="btn btn-lg " style="background-color:red; color:white;">Paintings</a>
                <a href="" class="btn btn-lg " style="background-color:orange; color:white;">Handicrafts</a>
                <a href="" class="btn btn-lg " style="background-color:yellow; color:white;">Graphics</a>
                <a href="" class="btn btn-lg " style="background-color:green; color:white;">Jewellery</a>
                <a href="" class="btn btn-lg " style="background-color:blue; color:white;">Interios</a>
                <a href="" class="btn btn-lg " style="background-color:purple; color:white;">Potraits</a>
                <a href="" class="btn btn-lg " style="background-color:black; color:white;">Sketches</a>--%>
            </div>
            </div>
           </div>
        </div>
    </div>
    <!-- END jumbotron-->


    <!-- products-->
    <div class="container">
        <section>
            
            <div class = "row" style="margin-left:100px;">
                

                <asp:Repeater ID="rptrImages" runat="server">
                <HeaderTemplate>
                   
                </HeaderTemplate>
                <ItemTemplate>
                 <div class="tab-pane fade in active">    
         <%--       <div class = "row">--%>
                    <div class = " col-xs-12 col-sm-4 col-md-4 pic-size">
                        <div class = "thumbnail">
                        <asp:Image ID="Image1" runat="server" alt="image" height="200" width="300" style="border:5px solid black"  ImageUrl='<%#Accessible.GetImage(Eval("Image")) %>' />
                        </div>
                                 
                        <div class = "caption">
                     
                        <h3 style="color:white;"><%# Eval("ProductName") %></h3>
                        <p style="color:white;"><%# Eval("Description") %>.</p>
                              
                         <p>

                              <a href="Description.aspx?ProductID=<%# Eval("ProductID") %>" class = "btn btn-primary" role = "button"><span class=" fa fa-shopping-cart"></span>
                                Buy Now
                              </a>
                              <a href="Description.aspx?ProductID=<%# Eval("ProductID") %>" class = "btn btn-default" role = "button">
                                View Details
                              </a>
                           </p>

                                    
                        </div>
                    </div>
                  <%--  </div>--%>
                </div>
                  
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>


                
            </div> <!-- end row-->

                 
            <div class = "row" style="margin-left:100px;">
                              <div class = " col-xs-offset-4 col-xs-12 col-sm-offset-4 col-sm-4 col-md-offset-4 col-md-4">
                                    <a href="ImageDisplay.aspx" class="btn btn-lg btn-warning">View more products. . .</a>
                              </div>
            </div>



            <hr />

            <div class="row">
                <div class="col-sm-4">
                    <div class="panel panel-default text-center">
                        <div class="panel-body">
                           <span class="glyphicon glyphicon-gift " style="color:purple; font-size: 50px;"></span>
                            <h4>GIFTS</h4>
                            <p>
                            It’s great to send a card/painting when it’s someone’s birthday or a special 
                            occasion to make them smile , right ?
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4">
                    <div class="panel panel-default text-center">
                        <div class="panel-body">
                            <span class=" glyphicon glyphicon-picture " style="color:red; font-size:50px;"></span>
                             <h4>WALLPAPERS</h4>
                            <p>
                                Lovingly crafted to order, Papercuts intricately designed wallpapers are perfect for any room.<br /><br />
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-sm-4">
                    <div class="panel panel-default text-center">
                        <div class="panel-body">
                            <span class="glyphicon glyphicon-scissors " style="color:green; font-size:50px;"></span>
                            <h4>CRAFT-WORK</h4>
                            <p>
                                CraftStore’s delicately handcrafted accessories are super quirky and cute.
                                Want an Alice in Wonderland inspired bracelet? This is the place to go      
                                <br />
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <!--end row-->

        </section>
    </div>
    <!-- end products-->




    <!-- drawing with natasha-->

    <div class="jumbotron">
        <div class="container text-center">
            <div class="row">
                <div class="col-sm-5 col-md-4 text-center" >
                        <img src = "Images\image11.jpg" alt = "Generic placeholder thumbnail" >
                        
                </div>
                <div class="col-sm-3 col-md-4 text-center" >
                        
                        <p> Hi! My name is Natasha! Since 2004, 
                            I've been running my own studio, 
                            creating art and teaching to all ages.
                            
                        </p>
                </div>

                <div class="col-sm-3 col-md-4  text-center">
                    <img src = "Images\image10.png" alt = "Generic placeholder thumbnail">
                </div>
               
            </div>
          
        </div>
    </div>
    <!-- END jumbotron-->




</asp:Content>

