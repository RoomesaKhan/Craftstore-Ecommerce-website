<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ImageDisplay.aspx.cs" Inherits="ImageDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
       .pic-size {
             width:320px;
             height:360px;
                 }
       .pic-size-1 {
        width:280px;
        height:210px;
                   }
         p,h3 {
            
    -o-text-overflow: ellipsis;   /* Opera */
    text-overflow:    ellipsis;   /* IE, Safari (WebKit) */
    overflow:hidden;              /* don't show excess chars */
    white-space:nowrap;           /* force single line */
    width: 300px;                 /* fixed width */

         }
         .divider {
         margin: 5px;
          }
       .dropdown:hover .dropdown-menu {
        display: block; 
        background-color:#e8202a;
        border-radius: 10px 10px 10px 10px;
        }
        .dropdown-menu > li > a {
            color:white;
        }
  
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- jumbotron-->

    <div class="jumbotron">
        <div class="container text-center">
            <h1><i class="fa fa-paint-brush"></i> Craft Store</h1>
            <div class="row">
               <div class="col-xs-12">
                    <div class="btn-group">
                      <ul class="nav nav-tabs">
                       <asp:Repeater ID="rptrCat" runat="server" OnItemDataBound="OnItemDataBound">
                              <ItemTemplate>   
                                     <li class="dropdown">
                                         <div class="divider">
                                             <asp:LinkButton NavigateUrl="#" runat="server" OnLoad="GetRandColor" CommandArgument='<%# Eval("CategoryID") %>'  OnClick="Cat_Click"  CssClass="btn btn-lg btn-block dropdown-toggle" style="background-color:red;  color:white;"><%# Eval("CategoryName") %></asp:LinkButton>
                                             <ul class="dropdown-menu">
                                                 <asp:Repeater ID="rptrSubCat" runat="server">
                                                          <ItemTemplate> 
                                                            <li><asp:LinkButton NavigateUrl="#"  runat="server" CssClass="linkbutton" CommandArgument='<%# Eval("SubCategoryID") %>' Text='<%# Eval("SubCategoryName") %>' OnClick="SubCat_Click"></asp:LinkButton></li>
                                                        </ItemTemplate>
                                                </asp:Repeater>
                                                          </ul>   
                                         </div>
                                     </li>
                                  <asp:HiddenField ID="hfCategoryID" runat="server" Value='<%# Eval("CategoryID") %>' />
                              </ItemTemplate>
                          </asp:Repeater>
                        
                    </ul>
                </div>
              </div>
             </div>
        </div>
    </div>
 <!-- END jumbotron-->

    <div class="container">
  <div class="tab-content" style="margin-left:100px;">
    

     <!-- ******************products*************-->
              
                            
         
     <div >
            <!-- Default panel contents -->
      <%--   <div style="height:500px; background-image:url('Images\back1.jpg'); background-size:cover; visibility:hidden;"></div>--%>
            <asp:Repeater ID="rptrImages" runat="server">
                
                <ItemTemplate>
                 <div class="tab-pane fade in active">    
         <%--       <div class = "row">--%>
                    <div class = " col-xs-12 col-sm-4 col-md-4 pic-size">
                       
                        <a href="Description.aspx?ProductID=<%# Eval("ProductID") %>" style="text-decoration:none;">

                        <div class = "thumbnail">
                           <asp:Image ID="Image1" runat="server" height="200" width="300" style="border:5px solid black"  ImageUrl='<%#Accessible.GetImage(Eval("Image")) %>' />
                        </div>
                                 
                        <div class = "caption">

                           <h3 style="color:white;"><%# Eval("ProductName") %></h3>
                           <p style="color:white;"><%# Eval("Description") %><div style="color:black ; font-size:1px;"><%# Eval("ProductID") %></div></p>
                              
                           <p>
                              <a href="Description.aspx?ProductID=<%# Eval("ProductID") %>" class = "btn btn-primary" role = "button">
                                 <i class="fa fa-shopping-cart"> Buy Now</i>
                              </a> 
                              <a href="Description.aspx?ProductID=<%# Eval("ProductID") %>" class = "btn btn-default" role = "button">
                                View Details
                              </a>
                           </p>
                                    
                        </div>

                     </a>

                    </div>
                  <%--  </div>--%>
                </div>
                  
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
      </div>
        </div>
  
</asp:Content>
