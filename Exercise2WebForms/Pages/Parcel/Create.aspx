<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Exercise2WebForms.Pages.Parcel.Create" %>

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
        <li class="active">Add Parcel</li>
    </ul>
    <div class="container">
        <div class="row">
            <div class="col-lg-4"></div>
            <div class="col-lg-4">
                <asp:Panel ID="pnlParcel" runat="server" CssClass="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Add Parcel</h4>
                    </div>
                    <div class="modal-body text-center">
                        <div class="form-group text-left">
                            <label for="Title"><span class="text-danger">*</span> Title:</label>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Text='<%# Bind("Title") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title is required" ValidationGroup="CreateParcelValidation" CssClass="text-danger mt-3" />
                            <br />
                            <asp:Label ID="lblTitleError" runat="server" CssClass="text-danger mt-3 " Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button ID="btnSave" runat="server" Text='Save' CssClass="btn btn-default" OnClick="btnSave_Click" ValidationGroup="CreateParcelValidation" />
                                <asp:Button ID="btnCancel" runat="server" Text='Cancel' OnClick="btnCancel_Click" CssClass="btn btn-default" OnClientClick='<%= ResolveUrl("~/") %>' CausesValidation="false" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>