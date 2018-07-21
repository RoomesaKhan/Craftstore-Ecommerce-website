<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminDescription.aspx.cs" Inherits="AdminDescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link href="css/description.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="jumbotron">
        <div class="container text-center">
            <h1><i class="fa fa-paint-brush"></i> Craft Store</h1>   
                   
                  <span class=" glyphicon glyphicon-picture logo-small" style="color:red;  font-size:50px;"></span> 
                      <span class="glyphicon glyphicon-gift logo-small" style="color:yellow;  font-size:50px;"></span> 
                           <span class="glyphicon glyphicon-scissors logo-small" style="color:green;  font-size:50px;"></span>  
                              <i class="fa fa-diamond logo-small" aria-hidden="true" style="color:silver; font-size:50px;"></i>   
                                 <i class="fa fa-paint-brush logo-small" aria-hidden="true" style="color:blue; font-size:50px;"></i>

                   </div>           
    </div>
    <!-- END jumbotron-->
<section>
                <div class="container">
                       <div class = "row">
                              <asp:Repeater ID="rptrImages" runat="server">
                
                               <ItemTemplate>
                              <div class = " col-xs-12 col-sm-offset-1 col-sm-6 col-md-offset-1 col-md-6 pic-size " style="height: 400px;width:530px;">
                                 <div class = "thumbnail">
                                    <asp:Image ID="Image1" runat="server" alt="image" style="border:5px solid black; height: 400px;width:530px;"  ImageUrl='<%#Accessible.GetImage(Eval("Image")) %>' />
                                 </div>
                                 
                                 
                                 </div>
                                   </ItemTemplate>
                                  </asp:Repeater>

                                 <div class = " col-xs-12 col-sm-5 col-md-5 pic-size">
                                         <div class="container-fluid">
                                                <div class="row">
                                                  <div class="col-xs-12 col-sm-12">
                                                     <asp:Repeater ID="rptrProductDetails"  runat="server">
                                                     <ItemTemplate>
                                                    <div class="panel panel-default" style="width: 347px;">
                                                      <div class="panel-heading text-center" >
                                                        <h3><%#Eval("ProductName") %></h3>
                                                      </div>
                                                      <div class="panel-body">
                                                        <p><strong>Category:</strong>  <%#Eval("CategoryName") %></p>
                                                        <p><strong>Sub-Category</strong>  <%#Eval("SubCategoryName") %></p>
                                                        <p><strong>Artist:</strong>  <%#Eval("ArtistName") %></p>
                                                        <p><strong>Price:</strong> <%#Eval("Price") %></p>
                                                        <p><strong>Quantity:</strong> <%#Eval("InStock") %></p>
                                                        <p><strong>Description:</strong> <%#Eval("Description") %></p>
                                                        <p><%# ((int)Eval("FreeDelivery")==1)?"Free Delivery":"" %> <%# ((int)Eval("30DayRet")==1)?"30 Days Returns":"" %> <p><%# ((int)Eval("COD")==1)?"Cash on Delivery":"" %></p>
                                                             
                                                      </div>
                                                        </ItemTemplate>
                                                       </asp:Repeater>
                                                      
                                                      <br/><br/>
                                                    </div> 
                                                   </div> 
                                                </div>

                                                <div class="row">
                                                  <div class="col-xs-6 col-sm-6">
                                                    <div>
                                                        <asp:LinkButton ID="EditButton" OnClick="EditProduct" runat="server" Text="Edit This Product" class="btn btn-primary" style="padding-right: 12px;padding-left: 12px; display:inline; float:left;"/>
                                                        <asp:LinkButton ID ="button_delete" OnClick="DeleteProduct" OnClientClick="return confirm('Are you sure to delete?');" runat="server" Text="" class="btn btn-primary" style=" display:inline; float:left; margin-left:12px;"><i class="fa fa-trash"></i></asp:LinkButton>
                                                         </div>
                                                      
                                                  </div>
                                                     
                                                </div>


                                          </div>
                                          

                                </div>

                          </div>
                          </div>
                          </section>
                          <br><br><br><br>



















    <!-- offers-->
    <div class="container">
        <section>
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




    <!-- END jumbotron-->


</asp:Content>

