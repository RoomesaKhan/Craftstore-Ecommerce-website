<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>

  <link href="css/about.css" rel="stylesheet" type="text/css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <link href="css/About.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
    <!-- jumbotron-->

    <div class="jumbotron" style="background-color:#eee;">
        <div class="container text-center" style="color:#333;">
            <h1><i class="fa fa-paint-brush"></i> Craft Store</h1>
            <p>20% off ALL items<br> Stock up on products must haves.<br>Save on painting, frames, sketches, and more! </p>
                

           
                <a href="ImageDisplay.aspx" class="btn btn-lg btn-warning">Visit Store and Shop Now</a>
          
        </div>
    </div>
    <!-- END jumbotron-->

<!-- Container (About Section) -->
<div id="about" class="container-fluid">
  <div class="row">
    <div class="col-sm-8">
      <h2 style="color:orange;">About Company</h2><br>
      <h4>CraftStore was established to offer a range of  accessories featuring different creative designs. Each product is made by hand in our studio, using a range of techniques from painting to embroidery.</h4><br>
     
    </div>
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-signal logo" style="color:#f4511e;"></span>
    </div>
  </div>
</div>

<div class="container-fluid bg-grey">
  <div class="row">
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-globe logo slideanim" style="color:green;"></span>
    </div>
    <div class="col-sm-8">
      <h2>Our Values</h2><br>
      <h4 style="color:black;"><strong>MISSION:</strong> Our mission is to supplies craft including paintings, interior designed wallpapers, handicrafts items and more is just a click away.
        Our Company prides itself on sourcing and producing only the best quality goods.

      </h4><br>
   
    </div>
  </div>
</div>

<!-- Container (Services Section) -->
<div id="services" class="container-fluid text-center">
  <h2 style="color:aqua">SERVICES</h2>
  <h4>What we offer</h4>
  <br>
  <div class="row slideanim">
    <div class="col-sm-4">
      <span class=" glyphicon glyphicon-picture logo-small" style="color:red;"></span>
      <h4>WALLPAPERS</h4>

    </div>
    <div class="col-sm-4">
      <span class="glyphicon glyphicon-gift logo-small" style="color:yellow;"></span>
      <h4>GIFTS</h4>

    </div>
    <div class="col-sm-4">
       <span class="glyphicon glyphicon-scissors logo-small" style="color:green;"></span>
      <h4>CRAFT-WORK</h4>


    </div>
  </div>
  <br><br>
  <div class="row slideanim">
  <div class="col-sm-2"></div>
    <div class="col-sm-4">
      <i class="fa fa-diamond logo-small" aria-hidden="true" style="color:silver;"></i>
      <h4>JEWELLERY</h4>

    </div>
    <div class="col-sm-4">
      <i class="fa fa-paint-brush logo-small" aria-hidden="true" style="color:blue;"></i>
      <h4>PAINTINGS</h4>

    </div>
    <div class="col-sm-2"></div>
  </div>
</div>


  <div class="jumbotron">
        <div class="container text-center">
        <div id="contact" class="container-fluid bg-grey">

  <h2 class="text-center">What our customers say</h2>
  <div id="myCarousel" class="carousel slide text-center" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner" role="listbox">
      <div class="item active">
        <h4 style="color:black;">"This company is the best. I am so happy with the result!"<br><span>Michael Roe, Vice President, Comment Box</span></h4>
      </div>
      <div class="item">
        <h4 style="color:black;">"One word... WOW!!"<br><span>John Doe, Salesman, Rep Inc</span></h4>
      </div>
      <div class="item">
        <h4 style="color:black;">"Could I... BE any more happy with this company?"<br><span>Chandler Bing, Actor, FriendsAlot</span></h4>
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
</div>
</div>
</div>


<!-- RESERVATION modal feature implementation -->
        <div id="reserveModal" class="modal fade" role="dialog">
          <div class="modal-dialog">
            <!-- Modal content -->
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" style="color:black;">CONTACT US </h4>
              </div>
              <div class="modal-body">
                <!-- Original Reservation Form implementation  -->
                 <form class="form-horizontal" role="form" id="reservationForm">
                            <div class="form-group">
                                <label for="user-name" class="col-lg-2 control-label" style="color:black;">Name</label>
                                <div class="col-lg-10">
                                    <input type="text" class="form-control" id="user-name" placeholder="Enter your name" />
                                </div>
                            </div>
                            <!--end form group-->


                            <div class="form-group">
                                <label for="user-email" class="col-lg-2 control-label" style="color:black;">Email</label>
                                <div class="col-lg-10">
                                    <input type="text" class="form-control" id="user-email" placeholder="Enter your email" />
                                </div>
                            </div>
                            <!--end form group-->

                          

                            <div class="form-group">
                                <label for="user-message" class="col-lg-2 control-label" style="color:black;">Any message</label>
                                <div class="col-lg-10">
                                    <textarea name="user-message" id="user-message" class="form-control" cols="20" rows="10"
                                        placeholder="Enter your message"></textarea>
                                </div>
                            </div>
                            <!--end form group-->



                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <button type="submit" class="btn btn-primary">Submit</button>
                                </div>
                            </div>        
                                           
                 </form>
              </div> <!-- /End modal Body -->
            </div> <!--/End modal Content -->
          </div> <!-- /End modal Dialog -->
        </div> <!-- /End RESERVE modal -->




    
<script>
    $(document).ready(function () {
        // Add smooth scrolling to all links in navbar + footer link
        $(".navbar a, footer a[href='#myPage']").on('click', function (event) {
            // Make sure this.hash has a value before overriding default behavior
            if (this.hash !== "") {
                // Prevent default anchor click behavior
                event.preventDefault();

                // Store hash
                var hash = this.hash;

                // Using jQuery's animate() method to add smooth page scroll
                // The optional number (900) specifies the number of milliseconds it takes to scroll to the specified area
                $('html, body').animate({
                    scrollTop: $(hash).offset().top
                }, 900, function () {

                    // Add hash (#) to URL when done scrolling (default click behavior)
                    window.location.hash = hash;
                });
            } // End if
        });

        $(window).scroll(function () {
            $(".slideanim").each(function () {
                var pos = $(this).offset().top;

                var winTop = $(window).scrollTop();
                if (pos < winTop + 600) {
                    $(this).addClass("slide");
                }
            });
        });
    })
</script>
</asp:Content>

