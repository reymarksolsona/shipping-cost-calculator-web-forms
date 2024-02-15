using Exercise2WebForms.Data.Context;
using Exercise2WebForms.Data.DataAccess.Contracts;
using Exercise2WebForms.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Exercise2WebForms.Data.DataAccess.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetCustomers()
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Customers.ToList();
            }
        }

        public Customer GetCustomerById(int? customerId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Customers.Include(p => p.Parcels).FirstOrDefault(c => c.CustomerID == customerId);
            }
        }

        public Customer GetCustomerByName(string name)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Customers.Include(p => p.Parcels).FirstOrDefault(c => c.Name.Equals(name));
            }
        }

        public List<Parcel> GetParcelsByCustomerId(int customerId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.Parcels.Include(p => p.Customer).Where(x => x.CustomerID == customerId).ToList();
            }
        }

        public List<ParcelItem> GetParcelItemsByParcel(List<int> parcelsIds)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                return context.ParcelItems.Where(x => parcelsIds.Contains(x.ParcelID)).ToList();
            }
        }

        public void AddCustomer(Customer customer)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                context.Entry(customer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                var customer = context.Customers.Find(customerId);
                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteParcels(List<int> parcelIds)
        {
            using (Exercise2DbContext context = new Exercise2DbContext())
            {
                var parcels = context.Parcels.Where(x => parcelIds.Contains(x.ParcelID)).ToList();
                if (parcels != null || parcels.Any())
                {
                    context.Parcels.RemoveRange(parcels);
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
