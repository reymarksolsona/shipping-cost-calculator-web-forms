using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Business.Services.Implementation;
using Exercise2WebForms.Data.DataAccess.Implementation;
using Exercise2WebForms.Utilities;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercise2WebForms.Pages.ParcelItem
{
    public partial class _Default : Page
    {
        private IParcelItemService _parcelItemService;

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
            string parcelId = Page.RouteData.Values["id"] as string;
            int? parcelIdAsInt = TryParseInt(parcelId);

            if (parcelId != null || parcelIdAsInt != null)
            {
                InitDependency();
                var parcels = _parcelItemService.GetPagedParcelItems(int.Parse(parcelId), page);
                var pagedParcels = (from p in parcels.ToList()
                                    select new Entities.Response.ParcelItemResponse()
                                    {
                                        ParcelItemID = p.ParcelItemID,
                                        Title = p.Title,
                                        TotalWeight = p.Weight,
                                        Info = ParcelCalculator.CalculateClassificationAndCost(p.Weight)
                                    }).ToList();

                if (pagedParcels.Any())
                {
                    ViewState["hasData"] = true;
                }

                Session["parcelId"] = parcelId;
                GridViewParcelItems.DataSource = pagedParcels;
                GridViewParcelItems.DataBind();
            } else
            {
                Response.Redirect("~/");
            }
        }

        protected void GridViewCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewParcelItems.PageIndex = e.NewPageIndex;
            BindParcels(GridViewParcelItems.PageIndex + 1);
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