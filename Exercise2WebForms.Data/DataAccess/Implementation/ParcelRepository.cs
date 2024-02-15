using Exercise2WebForms.Data.Context;
using Exercise2WebForms.Data.DataAccess.Contracts;
using Exercise2WebForms.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Exercise2WebForms.Data.DataAccess.Implementation
{
    public class ParcelRepository : IParcelRepository
    {
        public IEnumerable<Parcel> GetAllParcels()
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Parcels.Include(p => p.Customer).ToList();
            }
        }

        public Parcel GetParcelById(int? parcelId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Parcels.Include(p => p.Customer).Include(p => p.ParcelItems).FirstOrDefault(x => x.ParcelID == parcelId);
            }
        }

        public Parcel GetParcelByName(string title)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Parcels.Include(p => p.Customer).Include(p => p.ParcelItems).FirstOrDefault(x => x.Title.ToLower().Equals(title.ToLower()));
            }
        }

        public IEnumerable<Parcel> GetParcelByCustomerId(int? customerId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Parcels.Include(p => p.Customer).Include(p => p.ParcelItems).Where(x => x.CustomerID == customerId).ToList();
            }
        }

        public List<ParcelItem> GetParcelItemsByParcel(List<int> parcelIds)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.ParcelItems.Where(x => parcelIds.Contains(x.ParcelID)).ToList();
            }
        }

        public void AddParcel(Parcel parcel)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                context.Parcels.Add(parcel);
                context.SaveChanges();
            }
        }

        public void UpdateParcel(Parcel parcel)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                context.Entry(parcel).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteParcel(int parcelId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                Parcel parcel = context.Parcels.Find(parcelId);
                if (parcel != null)
                {
                    context.Parcels.Remove(parcel);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteParcelItems(List<int> parcelItemIds)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                var parcelItems = context.ParcelItems.Where(x => parcelItemIds.Contains(x.ParcelItemID)).ToList();
                if (parcelItems != null || parcelItems.Any())
                {
                    context.ParcelItems.RemoveRange(parcelItems);
                    context.SaveChanges();
                }
            }
        }
    }
}
