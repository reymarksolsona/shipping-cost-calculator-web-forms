<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Exercise2WebForms.Pages.Parcel.Edit" %> <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumb">
        <li>
            <a href="<%= ResolveUrl("~/") %>"> Customers </a>
        </li>
        <li>
            <a href="<%=ResolveUrl("~/Parcel/" + Session["customerId"]) %>"> Parcels </a>
        </li>
        <li class="active">Edit Parcel</li>
    </ul>
    <div class="container">
        <div class="row">
            <div class="col-lg-4"></div>
            <div class="col-lg-4">
                <asp:Panel ID="pnlParcel" runat="server" CssClass="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Edit Parcel</h4>
                    </div>
                    <div class="modal-body text-center">
                        <div class="form-group text-left">
                            <label for="Title">
                                <span class="text-danger">*</span> Title: </label>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Text='<%# Bind("Title") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title is required" ValidationGroup="CreateParcelValidation" CssClass="text-danger mt-3" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button ID="btnUpdate" runat="server" Text='Save' CssClass="btn btn-default" OnClick="btnUpdate_Click" ValidationGroup="CreateParcelValidation" />
                                <asp:Button ID="btnCancel" runat="server" Text='Cancel' CssClass="btn btn-default" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
</asp:Content>