using BusinessObject;
using DataLayerAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CustomerR
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task AddCustomer(Customer customer) => await CustomerDAO.Instance.AddCustomer(customer);

        public async Task<bool> AuthenticateUser(string email, string password) => await CustomerDAO.Instance.AuthenticateUser(email, password);

        public async Task<bool> CheckLogin(string email, string password) => await CustomerDAO.Instance.CheckLogin(email, password);

        public async Task DeleteCustomer(Customer customer) => await CustomerDAO.Instance.DeleteCustomer(customer);

        public async Task<List<Customer>> GetAllCustomer() => await CustomerDAO.Instance.GetAllCustomer();

        public async Task<Customer> GetCustomerByEmail(string email) => await CustomerDAO.Instance.GetCustomerByEmail(email);

        public async Task<Customer> GetCustomerById(int customerId) => await CustomerDAO.Instance.GetCustomerById(customerId);

        public async Task UpdateCustomer(Customer customer) => await CustomerDAO.Instance.UpdateCustomer(customer);
    }
}
