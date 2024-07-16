using BusinessObject;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccessLayer
{
    public class AdminAccount
    {
        private readonly IConfiguration _configuration;

        public AdminAccount(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AdminAccount()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public async Task<Customer> CheckAdminAccount()
        {
            try
            {
                var adminEmail = await Task.Run(() => _configuration["AdminAccount:Email"]);
                var adminPassword = await Task.Run(() => _configuration["AdminAccount:Password"]);

                var adminCustomer = new Customer
                {
                    EmailAddress = adminEmail,
                    Password = adminPassword
                };

                return adminCustomer;
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading admin account from configuration: " + ex.Message);
            }
        }

    }
}
