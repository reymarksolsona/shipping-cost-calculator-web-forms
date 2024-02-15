using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Data.DataAccess.Contracts;
using Exercise2WebForms.Entities;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace Exercise2WebForms.Business.Services.Implementation
{
    public class ParcelService : IParcelService
    {
        private IParcelRepository _repository;
        private const int pageSize = 10; // Adjust the value based on requirements

        public ParcelService(IParcelRepository repository)
        {
            _repository = repository;
        }

        public IPagedList<Parcel> GetPagedParcels(int? customerId, int? page)
        {
            int pageNumber = page ?? 1;
            var parcels = _repository.GetParcelByCustomerId(customerId);
            return parcels.ToPagedList(pageNumber, pageSize);
        }

        public bool IsTitleExists(string title)
        {
            var parcel = _repository.GetParcelByName(title);
            if (parcel == null)
            {
                return false;
            }

            return true;
        }

        public void AddParcel(Parcel parcel)
        {
            // Perform validation or use another validation approach
            _repository.AddParcel(parcel);
        }

        public Parcel GetParcelById(int? parcelId)
        {
            return _repository.GetParcelById(parcelId);
        }

        public void UpdateParcel(Parcel parcel)
        {
            Parcel parcelUpdate = GetParcelById(parcel.ParcelID);
            parcelUpdate.Title = parcel.Title;

            _repository.UpdateParcel(parcelUpdate);
        }

        public Parcel DeleteParcelAndRelatedData(int parcelId)
        {
            return DeleteParcel(parcelId);
        }

        private Parcel DeleteParcel(int parcelId)
        {
            Parcel parcel = _repository.GetParcelById(parcelId);
            // Delete Parcel Items associated with the current parcel
            List<ParcelItem> parcelItems = _repository.GetParcelItemsByParcel(new List<int>() { parcel.ParcelID });
            _repository.DeleteParcelItems(parcelItems.Select(s => s.ParcelItemID).ToList());
            // Delete Parcel
            _repository.DeleteParcel(parcelId);

            return parcel;
        }
    }
}
