using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using System;
using System.Web.UI;

namespace Exercise2WebForms.Pages.Customer
{
    public partial class Delete : Page
    {
        private ICustomerService _customerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the customer ID from query string
                string customerId = Page.RouteData.Values["id"] as string;
                int? customerIdAsInt = TryParseInt(customerId);

                if (customerId != null || customerIdAsInt != null)
                {
                    // Load customer details
                    LoadCustomerDetails((int)customerIdAsInt);
                }
                else
                {
                    // Redirect to customer index if no valid ID is provided
                    Response.Redirect("~/");
                }
            }
        }

        private void LoadCustomerDetails(int customerId)
        {
            InitDependency();

            Entities.Customer customer = _customerService.GetCustomerById(customerId);

            if (customer != null)
            {
                // Display customer details
                lblName.Text = customer.Name;
                lblPhoneNumber.Text = customer.PhoneNumber;
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
            string customerId = Page.RouteData.Values["id"] as string;
            if (customerId != null)
            {
                try
                {
                    InitDependency();

                    // Delete customer and related data
                    var customer = _customerService.DeleteCustomerAndRelatedData(int.Parse(customerId));

                    Session["SuccessMessage"] = $"Customer {customer} deleted successfully.";

                    Response.Redirect("~/", false);
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
            Response.Redirect("~/");
        }

        private void InitDependency()
        {
            var repo = new CustomerRepository();
            _customerService = new CustomerService(repo);
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