using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Exercise2WebForms
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Customer Routes
            routes.MapPageRoute("CustomerIndexRoute", "Customer", "~/Pages/Customer/Default.aspx");
            routes.MapPageRoute("CustomerCreateRoute", "Customer/Create", "~/Pages/Customer/Create.aspx");
            routes.MapPageRoute("CustomerEditRoute", "Customer/Edit/{id}", "~/Pages/Customer/Edit.aspx");
            routes.MapPageRoute("CustomerDeleteRoute", "Customer/Delete/{id}", "~/Pages/Customer/Delete.aspx");
            //Parcel Routes
            routes.MapPageRoute("ParcelRoute", "Parcel/{id}", "~/Pages/Parcel/Default.aspx");
            routes.MapPageRoute("ParcelCreateRoute", "Parcel/Add/Item", "~/Pages/Parcel/Create.aspx");
            routes.MapPageRoute("ParcelEditRoute", "Parcel/Edit/{id}", "~/Pages/Parcel/Edit.aspx");
            routes.MapPageRoute("ParcelDeleteRoute", "Parcel/Delete/{id}", "~/Pages/Parcel/Delete.aspx");
            //Parcel Items Routes
            routes.MapPageRoute("ParcelItemRoute", "Parcel/ParcelItem/{id}", "~/Pages/ParcelItem/Default.aspx");
            routes.MapPageRoute("ParcelItemCreateRoute", "Parcel/ParcelItem/Add/Item", "~/Pages/ParcelItem/Create.aspx");
            routes.MapPageRoute("ParcelItemEditRoute", "Parcel/ParcelItem/Edit/{id}", "~/Pages/ParcelItem/Edit.aspx");
            routes.MapPageRoute("ParcelItemDeleteRoute", "Parcel/ParcelItem/Delete/{id}", "~/Pages/ParcelItem/Delete.aspx");
            //Error Route
            routes.MapPageRoute("ErrorRoute", "Error", "~/Pages/Shared/Error.aspx");
        }
    }
}
