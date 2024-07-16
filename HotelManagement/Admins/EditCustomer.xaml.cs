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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        private readonly ICustomerRepository customerRepository;

        public EditCustomer()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
        }
        public void LoadCustomerData(Customer customer)
        {
            txtCustomerID.Text = customer.CustomerID.ToString();
            txtCustomerFullName.Text = customer.CustomerFullName;
            txtTelephone.Text = customer.Telephone;
            txtEmail.Text = customer.EmailAddress;
            txtBirthday.Text = customer.CustomerBirthday.ToString();
            txtStatus.Text = customer.CustomerStatus;
            txtPassword.Text = customer.Password;
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int customerId = int.Parse(txtCustomerID.Text);
                Customer customer = await customerRepository.GetCustomerById(customerId);
                if (customer != null)
                {
                    customer.CustomerFullName = txtCustomerFullName.Text;
                    customer.Telephone = txtTelephone.Text;
                    customer.EmailAddress = txtEmail.Text;
                    customer.CustomerBirthday = DateOnly.Parse(txtBirthday.Text);
                    customer.CustomerStatus = txtStatus.Text;
                    customer.Password = txtPassword.Text;
                    await customerRepository.UpdateCustomer(customer);
                    MessageBox.Show("Edit Customer Successfully!", "Note");
                    this.Close();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Cannot update customer");
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
