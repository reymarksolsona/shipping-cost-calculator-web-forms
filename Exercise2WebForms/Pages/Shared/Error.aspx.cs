using System;
using System.Web.UI;

namespace Exercise2WebForms.Pages.Shared
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure that data binding is explicitly called
            Page.DataBind();
        }
    }
}