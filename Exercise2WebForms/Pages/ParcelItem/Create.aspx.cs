using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using System;
using System.Web.UI;

namespace Exercise2WebForms.Pages.ParcelItem
{
    public partial class Create : Page
    {
        private IParcelItemService _parcelItemService;

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    InitDependency();

                    string parcelId = Session["parcelId"] as string;
                    int? parcelIdAsInt = TryParseInt(parcelId);
                    decimal? weight = TryParseDecimal(txtWeight.Text);

                    if (weight != null || parcelIdAsInt != null)
                    {
                        _parcelItemService.AddParcelItem(new Entities.ParcelItem
                        {
                            ParcelID = int.Parse(parcelId),
                            Title = txtTitle.Text,
                            Weight = (weight == null ? 0 : (decimal)weight)
                        });

                        Session["SuccessMessage"] = $"Parcel Item {txtTitle.Text} added successfully.";

                        Response.Redirect($"~/Parcel/ParcelItem/{parcelId}", false);
                        Context.ApplicationInstance.CompleteRequest();
                    } else {
                        Session["ErrorMessage"] = "Unable to update. Please check inputs.";
                        Response.Redirect("~/");
                    }
                }
            }
            catch (Exception ex)
            {
                Session["ErrorMessage"] = "An error occurred during the update.";
                Response.Redirect("~/Error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to parcel index
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

        private decimal? TryParseDecimal(string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result;
            }
            return null;
        }
    }
}