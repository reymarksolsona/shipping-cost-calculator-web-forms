using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using System;
using System.Web.UI;

namespace Exercise2WebForms.Pages.Parcel
{
    public partial class Delete : Page
    {
        private IParcelService _parcelService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the parcel ID from query string
                string parcelId = Page.RouteData.Values["id"] as string;
                int? parcelIdAsInt = TryParseInt(parcelId);

                if (parcelId != null || parcelIdAsInt != null)
                {
                    // Load parcel details
                    LoadParcelDetails((int.Parse(parcelId)));
                }
                else
                {
                    // Redirect to customer index if no valid ID is provided
                    Response.Redirect("~/");
                }
            }
        }

        private void LoadParcelDetails(int parcelId)
        {
            InitDependency();

            Entities.Parcel parcel = _parcelService.GetParcelById(parcelId);

            if (parcel != null)
            {
                // Display parcel details
                lblTitle.Text = parcel.Title;
            }
            else
            {
                // Redirect to customer index if customer not found
                Response.Redirect("~/");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the customer ID from query string
            string parcelId = Page.RouteData.Values["id"] as string;
            string customerId = Session["customerId"] as string;

            if (parcelId != null && customerId != null)
            {
                try
                {
                    InitDependency();

                    // Delete parcel and related data
                    var parcel = _parcelService.DeleteParcelAndRelatedData(int.Parse(parcelId));

                    Session["SuccessMessage"] = $"Parcel {parcel.Title} deleted successfully.";

                    Response.Redirect($"~/Parcel/{customerId}", false);
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
            // Redirect to customer index
            string customerId = Session["customerId"] as string;
            Response.Redirect($"~/Parcel/{customerId}");
        }

        private void InitDependency()
        {
            var repo = new ParcelRepository();
            _parcelService = new ParcelService(repo);
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