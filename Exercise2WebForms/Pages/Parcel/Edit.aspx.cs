using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using System;
using System.Web.UI;

namespace Exercise2WebForms.Pages.Parcel
{
    public partial class Edit : Page
    {
        private IParcelService _parcelService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadParcelDetails();
            }
        }

        private void LoadParcelDetails()
        {
            string parcelId = Page.RouteData.Values["id"] as string;
            int? parcelIdIdAsInt = TryParseInt(parcelId);

            if (parcelId == null || parcelIdIdAsInt == null)
            {
                Response.Redirect("~/");
                return;
            }

            InitDependency();

            Entities.Parcel parcel = _parcelService.GetParcelById((int)parcelIdIdAsInt);
            if (parcel == null)
            {
                Session["ErrorMessage"] = "Parcel not found.";
                Response.Redirect("~/");
                return;
            }

            txtTitle.Text = parcel.Title;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string parcelId = Page.RouteData.Values["id"] as string;
                if (parcelId == null)
                {
                    Response.Redirect("~/");
                    return;
                }
;
                InitDependency();

                Entities.Parcel parcel = new Entities.Parcel
                {
                    ParcelID = int.Parse(parcelId),
                    Title = txtTitle.Text,
                };

                if (ModelState.IsValid)
                {
                    _parcelService.UpdateParcel(parcel);

                    Session["SuccessMessage"] = $"Parcel {parcel.Title} updated successfully.";

                    string customerId = Session["customerId"] as string;

                    Response.Redirect($"~/Parcel/{customerId}", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                Session["ErrorMessage"] = "An error occurred during the update.";
                Response.Redirect("~/Error");
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