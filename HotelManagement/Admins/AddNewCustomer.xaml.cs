using BusinessObject;
using Repositories.CustomerR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManagement.Admins
{
    /// <summary>
    /// Interaction logic for AddNewCustomer.xaml
    /// </summary>
    public partial class AddNewCustomer : Window
    {
        private readonly ICustomerRepository customerRepository;

        public AddNewCustomer()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    Customer customer = new Customer
                    {
                        CustomerFullName = txtCustomerFullName.Text,
                        Telephone = txtTelephone.Text,
                        EmailAddress = txtEmail.Text,
                        CustomerBirthday = DateOnly.Parse(txtBirthday.Text),
                        CustomerStatus = "Active",
                        Password = txtPassword.Text,
                    };

                await customerRepository.AddCustomer(customer);
                MessageBox.Show("Add Customer Successfully!", "Note");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Can not add customer");
            }
        }

    }
}
