using System.Windows;
using Warehouse_App;
using Warehouse_App.Data;

namespace Warehouse_App
{
    public partial class SupplierWindow : Window
    {
        public Suppliers Supplier { get; private set; }

        public SupplierWindow(Suppliers supplier)
        {
            InitializeComponent();
            Supplier = supplier;

            if (Supplier != null)
            {
                NameTextBox.Text = Supplier.Name;
                AddressTextBox.Text = Supplier.Adress;
                PhoneTextBox.Text = Supplier.Phone;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Supplier.Name = NameTextBox.Text;
            Supplier.Adress = AddressTextBox.Text;
            Supplier.Phone = PhoneTextBox.Text;
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
