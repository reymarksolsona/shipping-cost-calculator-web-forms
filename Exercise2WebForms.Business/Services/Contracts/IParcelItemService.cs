using Exercise2WebForms.Entities;
using PagedList;

namespace Exercise2WebForms.Business.Services.Contracts
{
    public interface IParcelItemService
    {
        IPagedList<ParcelItem> GetPagedParcelItems(int? parcelId, int? page);
        void AddParcelItem(ParcelItem parcelItem);
        ParcelItem GetParcelItemById(int? parcelItemId);
        Parcel GetParcelById(int? parcelId);
        void UpdateParcelItem(ParcelItem parcelItem);
        ParcelItem DeleteParcelItem(int parcelItemId);
    }
}
