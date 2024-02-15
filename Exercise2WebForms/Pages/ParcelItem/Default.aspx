<%@ Page Title="Parcels" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Exercise2WebForms.Pages.ParcelItem._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumb">
        <li>
            <a href="<%= ResolveUrl("~/") %>">
                Customers
            </a>
        </li>
        <li>
            <a href="<%=ResolveUrl("~/Parcel/" + Session["customerId"]) %>">
                Parcels
            </a>
        </li>
        <li class="active">Parcel Items</li>
    </ul>
    <div class="row" id="parcel-item-list">
        <div class="container">
            <h2 class="text-center">Parcel Items</h2>

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
                <a href='<%= ResolveUrl("~/Parcel/ParcelItem/Add/Item") %>' class="btn btn-default">
                    <i class="fa fa-plus-circle"></i> Add Parcel Item
                </a>
            </div>

            <div class="table-responsive mb-5">
                <asp:GridView ID="GridViewParcelItems" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="Info.Classification" HeaderText="Delivery Classification" SortExpression="DeliveryInfo.Classification" />
                        <asp:BoundField DataField="TotalWeight" HeaderText="Total Weight" SortExpression="TotalWeight" />
                        <asp:BoundField DataField="Info.Cost" HeaderText="Total Cost" SortExpression="DeliveryInfo.Cost" DataFormatString="${0:N2}"/>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <a href='<%# Eval("ParcelItemID", "Edit/{0}") %>'>
                                    <i class="fa fa-edit text-success"></i> Edit
                                </a> |
                                <a href='<%# Eval("ParcelItemID", "Delete/{0}") %>'>
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