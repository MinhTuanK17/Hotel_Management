using BusinessObject;
using BusinessObject.Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class CustomerDAO : SingletonBase<CustomerDAO>
    {
        private HotelDbContext? _context;
        private AdminAccount? _admin;
        public async Task<Customer> GetCustomerByEmail(string email)
        {
            try
            {
                _context = new();
                var account = await _context.Customers.FirstOrDefaultAsync(c => c.EmailAddress.Equals(email));
                return account!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Customer> GetCustomerById(int customerId)
        {
            try
            {
                _context = new();
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerID == customerId);
                return customer!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<bool> CheckLogin(string email, string password)
        {
            try
            {
                _context = new();
                var account = await _context.Customers.FirstOrDefaultAsync(b => b.EmailAddress.Equals(email) && b.Password.Equals(password));
                return account != null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> AuthenticateUser(string email, string password)
        {
            try
            {
                _admin = new();
                var adminAccount = await _admin.CheckAdminAccount(); 
                return adminAccount.EmailAddress == email && adminAccount.Password == password;
            }
            catch (Exception e)
            {
                throw new Exception("Error authenticating user: " + e.Message);
            }
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            _context = new();
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task AddCustomer(Customer customer)
        {
            _context = new();
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            try
            {
                _context = new();
                var findCustomer = await GetCustomerById(customer.CustomerID);
                if (findCustomer != null)
                {
                    _context.Entry(findCustomer).CurrentValues.SetValues(customer);
                }
                else
                {
                    _context.Customers.Update(customer);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteCustomer(Customer customer)
        {
            try
            {
                _context = new();
                var findCustomer = await GetCustomerById(customer.CustomerID);
                if (findCustomer != null)
                {
                    findCustomer.CustomerStatus = "Deleted"; 
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error deleting customer: " + e.Message);
            }
        }

    }
}
