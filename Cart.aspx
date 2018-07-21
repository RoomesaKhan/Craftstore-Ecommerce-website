<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="jumbotron">
    <div class="container">
    <div class="row">
        <div class="col-sm-12 col-md-10 col-md-offset-1" style="margin-top:80px;">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Quantity</th>
                        <th></th>
                        <th class="text-center">Price</th>
                        <th></th>
                        <th> </th>
                    </tr>
                </thead>
                <tbody>
                    <h2  runat="server" id="h2NoItems"></h2>

                     <asp:Repeater ID="rptrCartProducts" runat="server">
                     <ItemTemplate>
                       <tr>

                        <td class="col-sm-8 col-md-6">
                         <div class="media">
                            
                            <div class="media-body">
                                  
                                  <h4 class="media-heading"><%#Eval("ProductName") %></h4>
                                <div class="text-center">
                                    <asp:Image ID="Image1" runat="server" alt="image" style="border:5px solid black; height: 120px;width:250px;"  ImageUrl='<%#Accessible.GetImage(Eval("Image")) %>' />
                                 </div>
                            </div>
                          </div>


                        </td>
                        <td class="col-sm-1 col-md-1" style="text-align: center"><strong><%#Eval("ProductQnty") %></strong></td>
                           <td></td>
                        <td class="col-sm-1 col-md-1 text-center"><strong><%#Eval("Price") %></strong></td>
                       <td></td>
                        <td class="col-sm-1 col-md-1">
                        <asp:LinkButton runat="server" type="button" class="btn btn-danger" CommandArgument='<%#Eval("ProductID") %>' OnClick="btnRemoveItem_Click">
                            <span class="glyphicon glyphicon-remove"></span> Remove
                        </asp:LinkButton></td>
                                
                    </tr>
                    </ItemTemplate>
                  </asp:Repeater>
                    <tr>
                        <td class="col-sm-8 col-md-6" colspan="3">
                         <div class="media">
                            
                            <div class="media-body">
                                  
                                  <h5 class="media-heading">Shipping Address</h5>
                                <div class="text-center">
                                    <asp:TextBox runat="server" ID="ShippingAddress" TextMode="MultiLine" Rows="7" Columns="100" />
                                    </div>
                            <asp:Button ID="AddShippingAddress" runat="server" Text="Confirm Shipping Address" CssClass="btn btn-primary" OnClick="add_ShippingAddress" />
                                 <asp:Label ID="EmptyAddress" runat="server" Text=""></asp:Label> </div>
                         </div>
                        </td>


                    </tr>

                </tbody>
                <tfoot runat="server" id="divPriceDetails">
                    <tr>
                        <td>   </td>
                        <td>   </td>
                        <td>   </td>
                        <td><h5>Subtotal</h5><br/><h5>Discount</h5><h3>Total</h3></td>
                        <td class="text-right"><h5 id="spanCartTotal" runat="server"></h5><br/><h5 id="spanDiscount" runat="server"></h5><h3 id="spanTotal" runat="server"></h3></td>
                    </tr>
                    <tr>
                        <td>   </td>
                        <td>   </td>
                        <td>   </td>
                        <td>
                         <a href="ImageDisplay.aspx" class="btn btn-default btn-md" style="padding-right: 10px;padding-left: 10px; margin-left:15px;">

                            <span class="glyphicon glyphicon-shopping-cart"></span> Continue shopping
                        </a></td>
                                                                              
                        <td>
                       
                        <asp:LinkButton CssClass = "btn btn-primary" runat="server" ID="CheckOutButton" Enabled="false" OnClick="checkOut_Click">
                                 <i class="fa fa-shopping-cart"> Checkout</i>
                              </asp:LinkButton>

                            
                        </td>
                        
 


                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
</div>
</div>

</asp:Content>

