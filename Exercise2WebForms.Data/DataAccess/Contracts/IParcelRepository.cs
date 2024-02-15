using Exercise2WebForms.Entities;
using System.Collections.Generic;

namespace Exercise2WebForms.Data.DataAccess.Contracts
{
    public interface IParcelRepository
    {
        IEnumerable<Parcel> GetAllParcels();
        Parcel GetParcelById(int? parcelId);
        Parcel GetParcelByName(string title);
        IEnumerable<Parcel> GetParcelByCustomerId(int? customerId);
        List<ParcelItem> GetParcelItemsByParcel(List<int> parcelIds);
        void AddParcel(Parcel parcel);
        void UpdateParcel(Parcel parcel);
        void DeleteParcel(int parcelId);
        void DeleteParcelItems(List<int> parcelItemIds);
    }
}
