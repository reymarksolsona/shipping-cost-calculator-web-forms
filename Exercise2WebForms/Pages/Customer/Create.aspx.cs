using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using System;
using System.Web.UI;

namespace Exercise2WebForms.Pages.Customer
{
    public partial class Create : Page
    {
        private ICustomerService _customerService;

        private void InitDependency()
        {
            var repo = new CustomerRepository();
            _customerService = new CustomerService(repo);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    InitDependency();

                    if (txtPhoneNumber.Text.Length == 0)
                    {
                        txtPhoneNumber.Text = null;
                    }

                    _customerService.AddCustomer(new Exercise2WebForms.Entities.Customer
                    {
                        Name = txtName.Text,
                        PhoneNumber = txtPhoneNumber.Text
                    });

                    Session["SuccessMessage"] = $"Customer {txtName.Text} added successfully.";

                    Response.Redirect("~/", false);
                    Context.ApplicationInstance.CompleteRequest();
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
            Response.Redirect($"~/");
        }
    }
}