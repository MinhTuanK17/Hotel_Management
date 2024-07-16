using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CustomerR
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByEmail(string email);
        Task<Customer> GetCustomerById(int customerId);
        Task<bool> CheckLogin(string email, string password);
        Task<List<Customer>> GetAllCustomer();
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
        Task<bool> AuthenticateUser(string email, string password);
    }
}
