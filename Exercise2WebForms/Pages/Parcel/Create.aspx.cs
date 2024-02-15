using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using System;
using System.Web.UI;

namespace Exercise2WebForms.Pages.Parcel
{
    public partial class Create : Page
    {
        private IParcelService _parcelService;

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    InitDependency();

                    string customerId = Session["customerId"] as string;
                    int? customerIdAsInt = TryParseInt(customerId);
                    if (customerIdAsInt != null)
                    {
                        lblTitleError.Visible = false;
                        lblTitleError.Text = String.Empty;

                        if (!_parcelService.IsTitleExists(txtTitle.Text.ToString()))
                        {
                            _parcelService.AddParcel(new Entities.Parcel
                            {
                                CustomerID = int.Parse(customerId),
                                Title = txtTitle.Text
                            });

                            Session["SuccessMessage"] = $"Parcel {txtTitle.Text} added successfully.";

                            Response.Redirect($"~/Parcel/{customerId}", false);
                            Context.ApplicationInstance.CompleteRequest();
                        } else
                        {
                            lblTitleError.Text = $"Parcel with title {txtTitle.Text} already exists.";
                            lblTitleError.Visible = true;
                        }
                    } else {
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