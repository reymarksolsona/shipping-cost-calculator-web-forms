using Exercise2WebForms.Entities;
using PagedList;
using System.Collections.Generic;

namespace Exercise2WebForms.Business.Services.Contracts
{
    public interface ICustomerService
    {
        IPagedList<Customer> GetPagedCustomers(int? page);
        //IEnumerable<Customer> GetPagedCustomers(int? page);
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int? customerId);
        void UpdateCustomer(Customer customer);
        string DeleteCustomerAndRelatedData(int customerId);
    }
}
