<%@ Page Title="Delete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Exercise2WebForms.Pages.ParcelItem.Delete" %> <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumb">
        <li>
            <a href="<%= ResolveUrl("~/") %>"> Customers </a>
        </li>
        <li>
            <a href="<%=ResolveUrl("~/Parcel/" + Session["customerId"]) %>"> Parcels </a>
        </li>
        <li>
            <a href="<%=ResolveUrl("~/Parcel/ParcelItem/" + Session["parcelId"]) %>"> Parcel Items </a>
        </li>
        <li class="active">Delete Parcel</li>
    </ul>
    <div class="container">
        <div class="row">
            <div class="col-lg-4"></div>
            <div class="col-lg-4">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Delete Parcel Item</h4>
                    </div>
                    <div class="modal-body text-center">
                        <p>Are you sure you want to delete this parcel?</p>
                        <dl class="dl-horizontal">
                            <dt>Title :</dt>
                            <dd>
                                <asp:Label ID="lblTitle" runat="server" />
                            </dd>
                            <dt>Weight :</dt>
                            <dd>
                                <asp:Label ID="lblWeight" runat="server" />
                            </dd>
                        </dl>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDelete" runat="server" Text='Delete' CssClass="btn btn-default" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text='Cancel' CssClass="btn btn-default" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>