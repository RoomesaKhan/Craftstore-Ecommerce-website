<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>

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
        }
         .dropdown-menu {
             background-color:red;
             color:white;
         }

       .dropdown-menu:hover {
        color:black;
        }
 </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                             <asp:LinkButton ID="LinkButton1" NavigateUrl="#" runat="server" CommandArgument='<%# Eval("CategoryID") %>'  OnClick="Cat_Click"  CssClass="btn btn-lg btn-block dropdown-toggle" style="background-color:red; color:white;"><%# Eval("CategoryName") %></asp:LinkButton>
                                             <ul class="dropdown-menu">
                                                 <asp:Repeater ID="rptrSubCat" runat="server">
                                                          <ItemTemplate> 
                                                            <li><asp:LinkButton ID="LinkButton2" NavigateUrl="#" runat="server" CommandArgument='<%# Eval("SubCategoryID") %>' OnClick="SubCat_Click"><%# Eval("SubCategoryName") %></asp:LinkButton></li>
                                                             <%-- <asp:HiddenField ID="hfSubCategoryID" runat="server" Value='<%# Eval("SubCategoryID") %>' />--%>
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
    <asp:Repeater ID="rptrImages" runat="server">
                
                <ItemTemplate>
                 <div class="tab-pane fade in active">    
                    <div class = " col-xs-12 col-sm-4 col-md-4 pic-size">
                       
                        <a href="AdminDescription.aspx?ProductID=<%# Eval("ProductID") %>" style="text-decoration:none;">

                        <div class = "thumbnail">
                           <asp:Image ID="Image1" runat="server" height="200" width="300" style="border:5px solid black"  ImageUrl='<%#Accessible.GetImage(Eval("Image")) %>' />
                        </div>
                                 
                        <div class = "caption">

                           <h3 style="color:black;"><%# Eval("ProductName") %></h3>
                           <p style="color:black;"><%# Eval("Description") %><div style="color:black ; font-size:1px;"><%# Eval("ProductID") %></div></p>
                              
                           <p>
                             <a href="AdminDescription.aspx?ProductID=<%# Eval("ProductID") %>" class = "btn btn-default" role = "button">
                                View Details
                              </a>
                               <asp:LinkButton CommandArgument='<%# Eval("ProductID") %>'  OnCommand="DeleteProduct" ID ="button_delete" OnClientClick="return confirm('Are you sure to delete?');" runat="server" Text="" class="btn btn-default" style=" display:inline; float:left;"><i class="fa fa-trash"></i></asp:LinkButton>
                              </a> 
                           </p>
                                    
                        </div>

                     </a>

                    </div>
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

