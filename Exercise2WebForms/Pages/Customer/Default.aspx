<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Exercise2WebForms.Pages.Customer._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" id="customer-list">
        <div class="container">
            <h2 class="text-center">Customers</h2>

            <% if (ViewState["ErrorMessage"] != null)
                { %>
                <div class="alert alert-danger alert-dismissible fade in">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Error!</strong> <%= ViewState["ErrorMessage"] %>
                </div>
            <% } %>

            <% if (ViewState["SuccessMessage"] != null)
                { %>
                <div class="alert alert-success alert-dismissible fade in">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Success!</strong> <%= ViewState["SuccessMessage"] %>
                </div>
            <% } %>

            <div class="text-right">
                <a href='<%= ResolveUrl("~/Customer/Create") %>' class="btn btn-default">
                    <i class="fa fa-plus-circle"></i> Add Customer
                </a>
            </div>

            <div class="table-responsive mb-5">
                <asp:GridView ID="GridViewParcels" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <a href='<%# Eval("CustomerID", "Parcel/{0}") %>'>
                                    <i class="fa fa-eye text-info"></i> View Parcels
                                </a> |
                                <a href='<%# Eval("CustomerID", "Customer/Edit/{0}") %>'>
                                    <i class="fa fa-edit text-success"></i> Edit
                                </a> |
                                <a href='<%# Eval("CustomerID", "Customer/Delete/{0}") %>'>
                                    <i class="fa fa-trash text-danger"></i> Delete
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <% if (ViewState["hasData"] == null) { %>
            <div class="text-center">
                <span>No Data Found.</span>
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>