using BusinessObject;
using Repositories.CustomerR;
using System.Windows;

namespace HotelManagement.Customers
{
    /// <summary>
    /// Interaction logic for UpdateProfile.xaml
    /// </summary>
    public partial class UpdateProfile : Window
    {
        public Customer LoggedInUser { get; set; }
        private readonly ICustomerRepository customerRepository;

        public UpdateProfile()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            Loaded += UpdateProfile_Loaded;
        }
        private void UpdateProfile_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProfileCustomer();
        }

        public void LoadProfileCustomer()
        {
            if (LoggedInUser != null)
            {
                txtFullName.Text = LoggedInUser.CustomerFullName;
                txtEmail.Text = LoggedInUser.EmailAddress;
                txtTelephone.Text = LoggedInUser.Telephone;
                txtBirthday.Text = LoggedInUser.CustomerBirthday.ToString();
                txtPassword.Text = LoggedInUser.Password;
            }
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LoggedInUser != null)
                {
                    LoggedInUser.EmailAddress = txtEmail.Text;
                    LoggedInUser.CustomerFullName = txtFullName.Text;
                    LoggedInUser.Telephone = txtTelephone.Text;
                    LoggedInUser.CustomerBirthday = DateOnly.Parse(txtBirthday.Text);
                    LoggedInUser.Password = txtPassword.Text;

                    await customerRepository.UpdateCustomer(LoggedInUser);
                    MessageBox.Show("Profile updated successfully!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}");
            }
        }
         private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
