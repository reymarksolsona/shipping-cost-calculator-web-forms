<%@ Page Title="Delete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Exercise2WebForms.Pages.Customer.Delete" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delete Customer</h2>
    <ul class="breadcrumb">
        <li>
            <a href="Index.aspx">Customers</a>
        </li>
        <li class="active">Delete Customer</li>
    </ul>
    <div class="container">
        <div class="row">
            <div class="col-lg-4"></div>
            <div class="col-lg-4">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Delete Customer</h4>
                    </div>
                    <div class="modal-body text-center">
                        <p>Are you sure you want to delete this customer?</p>
                        <dl class="dl-horizontal">
                            <dt>Name:</dt>
                            <dd><asp:Label ID="lblName" runat="server" /></dd>

                            <dt>Phone Number:</dt>
                            <dd><asp:Label ID="lblPhoneNumber" runat="server" /></dd>
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