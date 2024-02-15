 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Exercise2WebForms.Pages.Shared.Error" %>
<!DOCTYPE html>
<head runat="server">
    <title></title>
</head>
<body>
    <hgroup>
        <h1>Error.</h1>
        <h2>An error occurred while processing your request.</h2>
    </hgroup>
    <p style="margin-top: 25px;">
        <a href='<%# ResolveUrl("~/") %>'> Return to Home </a>
    </p>
</body>