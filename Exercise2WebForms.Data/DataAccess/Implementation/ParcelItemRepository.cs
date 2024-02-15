using Exercise2WebForms.Data.Context;
using Exercise2WebForms.Data.DataAccess.Contracts;
using Exercise2WebForms.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Exercise2WebForms.Data.DataAccess.Implementation
{
    public class ParcelItemRepository : IParcelItemRepository
    {
        public IEnumerable<ParcelItem> GetAllParcelItems()
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.ParcelItems.Include(p => p.Parcel).ToList();
            }
        }

        public ParcelItem GetParcelItemById(int? parcelItemId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.ParcelItems.Include(p => p.Parcel).Where(x => x.ParcelItemID == parcelItemId).FirstOrDefault();
            }
        }

        public IEnumerable<ParcelItem> GetParcelItemsByParcelId(int? parcelId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.ParcelItems.Include(p => p.Parcel).Where(x => x.ParcelID == parcelId).ToList();
            }
        }

        public Parcel GetParcelById(int? parcelId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Parcels.Include(p => p.Customer).Where(x => x.ParcelID == parcelId).FirstOrDefault();
            }
        }

        public void AddParcelItem(ParcelItem parcelItem)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                context.ParcelItems.Add(parcelItem);
                context.SaveChanges();
            }
        }

        public void UpdateParcelItem(ParcelItem parcelItem)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                context.Entry(parcelItem).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteParcelItem(int parcelItemId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                ParcelItem parcelItem = context.ParcelItems.Find(parcelItemId);
                if (parcelItem != null)
                {
                    context.ParcelItems.Remove(parcelItem);
                    context.SaveChanges();
                }
            }
        }
    }
}