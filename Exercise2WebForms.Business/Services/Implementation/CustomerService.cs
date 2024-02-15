using Exercise2WebForms.Business.Services.Contracts;
using Exercise2WebForms.Data.DataAccess.Contracts;
using Exercise2WebForms.Entities;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace Exercise2WebForms.Business.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repository;
        private const int pageSize = 10; // Adjust the value based on requirements

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IPagedList<Customer> GetPagedCustomers(int? page)
        {
            List<Customer> customers = _repository.GetCustomers();
            int pageNumber = page ?? 1;
            int pageSize = customers.Count() == 0 ? 1 : customers.Count();
            return customers.ToPagedList(pageNumber, pageSize);
        }

        public void AddCustomer(Customer customer)
        {
            // Perform validation or use another validation approach
            _repository.AddCustomer(customer);
        }

        public Customer GetCustomerById(int? customerId)
        {
            return _repository.GetCustomerById(customerId);
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer customerUpdate = GetCustomerById(customer.CustomerID);
            customerUpdate.PhoneNumber = customer.PhoneNumber;
            customer.Name = customer.Name;

            _repository.UpdateCustomer(customer);
        }

        public string DeleteCustomerAndRelatedData(int customerId)
        {
            return DeleteCustomer(customerId);
        }

        private string DeleteCustomer(int customerId)
        {
            Customer customer = _repository.GetCustomerById(customerId);
            if (customer != null)
            {
                // Delete Parcels and Parcel Items associated with the current customer
                List<Parcel> parcels = _repository.GetParcelsByCustomerId(customer.CustomerID);

                List<ParcelItem> parcelItems = _repository.GetParcelItemsByParcel(parcels.Select(s => s.ParcelID).ToList());

                if (parcelItems != null || parcelItems.Any())
                {
                    _repository.DeleteParcelItems(parcelItems.Select(s => s.ParcelItemID).ToList());
                }

                if (parcels != null || parcels.Any())
                {
                    _repository.DeleteParcels(parcels.Select(s => s.ParcelID).ToList());
                }

                _repository.DeleteCustomer(customerId);

                return customer.Name;
            }

            return string.Empty;
        }
    }
}