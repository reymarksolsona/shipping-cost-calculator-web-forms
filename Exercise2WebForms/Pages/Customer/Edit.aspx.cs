using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using System;
using System.Web.UI;

namespace Exercise2WebForms.Pages.Customer
{
    public partial class Edit : Page
    {
        private ICustomerService _customerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomerData();
                Button1.PostBackUrl = "~/";
            }
        }

        private void LoadCustomerData()
        {
            string customerId = Page.RouteData.Values["id"] as string;
            int? customerIdAsInt = TryParseInt(customerId);

            if (customerId == null || customerIdAsInt == null)
            {
                Response.Redirect("~/");
                return;
            }

            InitDependency();

            Entities.Customer customer = _customerService.GetCustomerById((int)customerIdAsInt);
            if (customer == null)
            {
                Session["ErrorMessage"] = "Customer not found.";
                Response.Redirect("~/");
                return;
            }

            txtName.Text = customer.Name;
            txtPhoneNumber.Text = customer.PhoneNumber;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string customerId = Page.RouteData.Values["id"] as string;
                if (customerId == null)
                {
                    Response.Redirect("~/");
                    return;
                }
;
                InitDependency();
                Exercise2WebForms.Entities.Customer customer = new Exercise2WebForms.Entities.Customer
                {
                    CustomerID = int.Parse(customerId),
                    Name = txtName.Text,
                    PhoneNumber = txtPhoneNumber.Text
                };

                if (ModelState.IsValid)
                {
                    _customerService.UpdateCustomer(customer);

                    Session["SuccessMessage"] = $"Customer {customer.Name} updated successfully.";

                    Response.Redirect("~/", false);
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