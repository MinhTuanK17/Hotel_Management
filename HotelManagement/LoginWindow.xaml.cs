using BusinessObject;
using HotelManagement.Admins;
using HotelManagement.Customers;
using Microsoft.VisualBasic.ApplicationServices;
using Repositories.CustomerR;
using System.Windows;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ICustomerRepository customerRepository;

        public LoginWindow()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
        }
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if (await customerRepository.AuthenticateUser(email, password))
            {
                MessageBox.Show("Login successfully!");
                AdminWindow adminWindow = new AdminWindow();
                this.Hide();
                adminWindow.Show();
            }
            else
            {
                if (await customerRepository.CheckLogin(email, password))
                {
                    MessageBox.Show("Login successfully!");
                    this.Hide();
                    Customer customer = await customerRepository.GetCustomerByEmail(email);
                    CustomerWindow customerWindow = new CustomerWindow();
                    customerWindow.LoggedInUser = customer;
                    customerWindow.Show();
                }
                else
                {
                    MessageBox.Show("Email or Password is wrong! Please login again!");
                }
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
