using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Data.DataAccess.Contracts;
using Exercise2WebForms.Entities;
using PagedList;

namespace Exercise2WebForms.Business.Services.Implementation
{
    public class ParcelItemService : IParcelItemService
    {
        private IParcelItemRepository _repository;
        private const int pageSize = 10;

        public ParcelItemService(IParcelItemRepository repository)
        {
            _repository = repository;
        }

        public IPagedList<ParcelItem> GetPagedParcelItems(int? parcelId, int? page)
        {
            int pageNumber = page ?? 1;
            var parcelItems = _repository.GetParcelItemsByParcelId(parcelId);

            return parcelItems.ToPagedList(pageNumber, pageSize);
        }

        public void AddParcelItem(ParcelItem parcelItem)
        {
            _repository.AddParcelItem(parcelItem);
        }

        public ParcelItem GetParcelItemById(int? parcelItemId)
        {
            return _repository.GetParcelItemById(parcelItemId);
        }

        public Parcel GetParcelById(int? parcelId)
        {
            return _repository.GetParcelById(parcelId);
        }

        public void UpdateParcelItem(ParcelItem parcelItem)
        {
            ParcelItem parcelItemUpdate = GetParcelItemById(parcelItem.ParcelItemID);
            parcelItemUpdate.Title = parcelItem.Title;
            parcelItemUpdate.Weight = parcelItem.Weight;

            _repository.UpdateParcelItem(parcelItemUpdate);
        }

        public ParcelItem DeleteParcelItem(int parcelItemId)
        {
            ParcelItem parcelItem = _repository.GetParcelItemById(parcelItemId);

            if (parcelItem != null)
            {
                _repository.DeleteParcelItem(parcelItemId);
            }

            return parcelItem;
        }
    }
}
