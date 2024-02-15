using Exercise2WebForms.Entities;
using PagedList;

namespace Exercise2WebForms.Business.Services.Contracts
{
    public interface IParcelService
    {
        IPagedList<Parcel> GetPagedParcels(int? customerId, int? page);
        bool IsTitleExists(string title);
        void AddParcel(Parcel parcel);
        Parcel GetParcelById(int? parcelId);
        void UpdateParcel(Parcel parcel);
        Parcel DeleteParcelAndRelatedData(int parcelId);
    }
}