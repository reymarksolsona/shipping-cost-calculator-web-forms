using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using System;
using System.Web.UI;

namespace Exercise2WebForms.Pages.ParcelItem
{
    public partial class Delete : System.Web.UI.Page
    {
        private IParcelItemService _parcelItemService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the customer ID from query string
                string parcelItemId = Page.RouteData.Values["id"] as string;
                int? parcelItemIdAsInt = TryParseInt(parcelItemId);

                if (parcelItemId != null || parcelItemIdAsInt != null)
                {
                    // Load customer details
                    LoadParcelItemDetails((int)parcelItemIdAsInt);
                }
                else
                {
                    // Redirect to customer index if no valid ID is provided
                    Response.Redirect("~/");
                }
            }
        }

        private void LoadParcelItemDetails(int parcelItemId)
        {
            InitDependency();

            Entities.ParcelItem parcelItem = _parcelItemService.GetParcelItemById(parcelItemId);

            if (parcelItem != null)
            {
                // Display parcel item details
                lblTitle.Text = parcelItem.Title;
                lblWeight.Text = parcelItem.Weight.ToString();
            }
            else
            {
                // Redirect to customer index if parcelItem not found
                Response.Redirect("~/");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the customer ID from query string
            string parcelItemId = Page.RouteData.Values["id"] as string;
            string parcelId = Session["parcelId"] as string;

            if (parcelItemId != null && parcelId != null)
            {
                try
                {
                    InitDependency();

                    // Delete customer and related data
                    var parcel = _parcelItemService.DeleteParcelItem(int.Parse(parcelItemId));

                    Session["SuccessMessage"] = $"Parcel {parcel.Title} deleted successfully.";

                    Response.Redirect($"~/Parcel/ParcelItem/{parcelId}", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                    Session["ErrorMessage"] = "An error occurred during the update.";
                    Response.Redirect("~/Error");
                }
            }
            else
            {
                // Redirect to customer index if no valid ID is provided
                Response.Redirect("~/");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to parcel item index
            string parcelId = Session["parcelId"] as string;
            Response.Redirect($"~/Parcel/ParcelItem/{parcelId}");
        }

        private void InitDependency()
        {
            var repo = new ParcelItemRepository();
            _parcelItemService = new ParcelItemService(repo);
        }

        private int? TryParseInt(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return null;
        }
    }
}