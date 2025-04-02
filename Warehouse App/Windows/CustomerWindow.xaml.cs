using System.Windows;
using Warehouse_App;
using Warehouse_App.Data;

namespace Warehouse_App
{
    public partial class CustomerWindow : Window
    {
        public Customers Customer { get; private set; }

        public CustomerWindow(Customers customer)
        {
            InitializeComponent();
            Customer = customer;

            if (Customer != null)
            {
                NameTextBox.Text = Customer.Name;
                AddressTextBox.Text = Customer.Adress;
                PhoneTextBox.Text = Customer.Phone;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Customer.Name = NameTextBox.Text;
            Customer.Adress = AddressTextBox.Text;
            Customer.Phone = PhoneTextBox.Text;
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
