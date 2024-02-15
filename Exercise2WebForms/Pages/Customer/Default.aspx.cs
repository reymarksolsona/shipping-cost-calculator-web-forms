using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercise2WebForms.Pages.Customer
{
    public partial class _Default : Page
    {
        private ICustomerService _customerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUrl();

                BindCustomers();

                if (Session["SuccessMessage"] != null)
                {
                    string message = Session["SuccessMessage"].ToString();
                    ViewState["SuccessMessage"] = message;
                    Session.Remove("SuccessMessage");
                }

                if (Session["ErrorMessage"] != null)
                {
                    string message = Session["ErrorMessage"].ToString();
                    ViewState["ErrorMessage"] = message;
                    Session.Remove("ErrorMessage");
                }
            }
        }

        private void InitDependency()
        {
            var repo = new CustomerRepository();
            _customerService = new CustomerService(repo);
        }

        private void BindCustomers(int? pageIndex = 0)
        {
            InitDependency();
            var customers = _customerService.GetPagedCustomers(pageIndex + 1);
            GridViewParcels.DataSource = customers;
            GridViewParcels.DataBind(); 
            
            if (customers.Any())
            {
                ViewState["hasData"] = true;
            }
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Customer/Create.aspx");
        }

        private void CheckUrl()
        {
            string rawUrl = Request.RawUrl as string;
            if (!rawUrl.Equals("/"))
            {
                Response.Redirect($"~/");
            }
        }
    }
}
