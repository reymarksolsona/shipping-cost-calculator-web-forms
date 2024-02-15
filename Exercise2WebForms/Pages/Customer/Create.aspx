<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Exercise2WebForms.Pages.Customer.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="breadcrumb">
        <li>
            <a href="<%= ResolveUrl("~/") %>">
                Customers
            </a>
        </li>
        <li class="active">Add Customer</li>
    </ul>
    <div class="container">
        <div class="row">
            <div class="col-lg-4"></div>
            <div class="col-lg-4">
                <asp:Panel ID="pnlCustomer" runat="server" CssClass="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Add Customer</h4>
                    </div>
                    <div class="modal-body text-center">
                        <div class="form-group text-left">
                            <label for="Name"><span class="text-danger">*</span> Name:</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Text='<%# Bind("Name") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required" ValidationGroup="CreateCustomerValidation" CssClass="text-danger mt-3" />
                        </div>

                        <div class="form-group text-left">
                            <label for="PhoneNumber">PhoneNumber:</label>
                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid phone number" CssClass="text-danger mt-3" ValidationGroup="CreateCustomerValidation" ValidationExpression="^\d{10}$" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button ID="btnSave" runat="server" Text='Save' CssClass="btn btn-default" OnClick="btnSave_Click" ValidationGroup="CreateCustomerValidation" />
                                <asp:Button ID="btnCancel" runat="server" Text='Cancel' OnClick="btnCancel_Click" CssClass="btn btn-default" OnClientClick='<%= ResolveUrl("~/") %>' CausesValidation="false" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>