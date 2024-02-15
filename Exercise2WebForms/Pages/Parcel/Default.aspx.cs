using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using Exercise2WebForms.Utilities;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercise2WebForms.Pages.Parcel
{
    public partial class _Default : Page
    {
        private IParcelService _parcelService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindParcels();

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

        private void BindParcels(int? page = 1)
        {
            string customerId = Page.RouteData.Values["id"] as string;
            int? customerIdAsInt = TryParseInt(customerId);

            if (customerId != null || customerIdAsInt != null)
            {
                InitDependency();
                var parcels = _parcelService.GetPagedParcels(int.Parse(customerId), page);
                var pagedParcels = (from p in parcels.ToList()
                                    select new Entities.Response.ParcelResponse()
                                    {
                                        ParcelID = p.ParcelID,
                                        Title = p.Title,
                                        TotalWeight = p.ParcelItems.Select(s => s.Weight).Sum(),
                                        CreatedDate = p.CreatedDate.ToString("dd/MM/yyyy"),
                                        Info = ParcelCalculator.CalculateClassificationAndTotalCost(p.ParcelItems.ToList())
                                    }).ToList();
                
                if (pagedParcels.Any())
                {
                    ViewState["hasData"] = true;
                }

                Session["customerId"] = customerId;

                GridViewParcels.DataSource = pagedParcels;
                GridViewParcels.DataBind();
            }
        }

        protected void GridViewParcels_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewParcels.PageIndex = e.NewPageIndex;
            BindParcels(GridViewParcels.PageIndex + 1);
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