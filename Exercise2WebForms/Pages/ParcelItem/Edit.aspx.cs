using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using System;
using System.Web.UI;

namespace Exercise2WebForms.Pages.ParcelItem
{
    public partial class Edit : System.Web.UI.Page
    {
        private IParcelItemService _parcelItemService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadParcelItemData();
            }
        }

        private void LoadParcelItemData()
        {
            string parcelItemId = Page.RouteData.Values["id"] as string;
            int? parcelItemIdAsInt = TryParseInt(parcelItemId);

            if (parcelItemId == null || parcelItemIdAsInt == null)
            {
                Response.Redirect("~/");
                return;
            }

            InitDependency();

            Entities.ParcelItem parcelItem = _parcelItemService.GetParcelItemById(int.Parse(parcelItemId));

            if (parcelItem == null)
            {
                Session["ErrorMessage"] = "Parcel Item not found.";
                Response.Redirect("~/");
                return;
            }

            txtTitle.Text = parcelItem.Title;
            txtWeight.Text = parcelItem.Weight.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string parcelItemId = Page.RouteData.Values["id"] as string;
                if (parcelItemId == null)
                {
                    Response.Redirect("~/");
                    return;
                }
;
                InitDependency();

                Entities.ParcelItem parcelItem = new Entities.ParcelItem
                {
                    ParcelItemID = int.Parse(parcelItemId),
                    Title = txtTitle.Text,
                    Weight = decimal.Parse(txtWeight.Text)
                };

                if (ModelState.IsValid)
                {
                    _parcelItemService.UpdateParcelItem(parcelItem);

                    Session["SuccessMessage"] = $"Parcel Item {parcelItem.Title} updated successfully.";

                    string parcelId = Session["parcelId"] as string;

                    Response.Redirect($"~/Parcel/ParcelItem/{parcelId}", false);
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
            // Redirect to parcel item index
            string customerId = Session["parcelId"] as string;
            Response.Redirect($"~/Parcel/ParcelItem/{customerId}");
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