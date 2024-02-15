using Exercise2WebForms.Entities;
using System.Collections.Generic;

namespace Exercise2WebForms.Data.DataAccess.Contracts
{
    public interface IParcelItemRepository
    {
        IEnumerable<ParcelItem> GetAllParcelItems();
        ParcelItem GetParcelItemById(int? parcelItemId);
        IEnumerable<ParcelItem> GetParcelItemsByParcelId(int? parcelId);
        Parcel GetParcelById(int? parcelId);
        void AddParcelItem(ParcelItem parcelItem);
        void UpdateParcelItem(ParcelItem parcelItem);
        void DeleteParcelItem(int parcelItemId);
    }
}
