﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminAddCategory.aspx.cs" Inherits="AdminAddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="margin-bottom:200px">
        <div class="form-horizontal">
            <h2>Add Category</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Name"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="CategoryName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="CategoryName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" OnClick="btnAdd_Click" />
                    <asp:Label ID="ErrorMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
 
        
<h1>Categories</h1>
        <hr />
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All Artists</div>

            <asp:Repeater ID="rptrCategories" runat="server" OnItemCommand="ItemCommand">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Categories</th>
                              <th>Delete</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("CategoryID") %></th>
                        <td><%# Eval("CategoryName") %></td>
                        <td><asp:LinkButton ID ="button_delete" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm('Are you sure to delete?');" CommandArgument = '<%# Eval("CategoryID") %>'   Text ="Delete" runat="server" ></asp:LinkButton>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
