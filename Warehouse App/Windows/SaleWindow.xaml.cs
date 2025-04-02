using System;
using System.Linq;
using System.Windows;
using Warehouse_App.Data;
using Warehouse_App;


namespace Warehouse_App.Windows
{
    public partial class SaleWindow : Window
    {
        private readonly DatabaseService _dbService;
        public Sales Sale { get; private set; }

        public SaleWindow(Sales sale, DatabaseService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Sale = sale ?? new Sales();

            LoadProducts();
            LoadSuppliers();
            LoadCustomers();

            if (Sale.ProductID != 0)
            {
                ProductComboBox.SelectedValue = Sale.ProductID;
                SupplierComboBox.SelectedValue = Sale.SupplierID;
                CustomerComboBox.SelectedValue = Sale.CustomerID;
                QuantityTextBox.Text = Sale.QuantitySold.ToString();
                TotalAmountTextBox.Text = Sale.TotalAmount.ToString("F2");
            }
        }

        private void LoadProducts()
        {
            ProductComboBox.ItemsSource = _dbService.GetProducts();
            ProductComboBox.DisplayMemberPath = "Name";
            ProductComboBox.SelectedValuePath = "ProductID";
        }

        private void LoadSuppliers()
        {
            SupplierComboBox.ItemsSource = _dbService.GetSuppliers();
            SupplierComboBox.DisplayMemberPath = "Name";
            SupplierComboBox.SelectedValuePath = "SupplierID";
        }

        private void LoadCustomers()
        {
            CustomerComboBox.ItemsSource = _dbService.GetCustomers();
            CustomerComboBox.DisplayMemberPath = "Name";
            CustomerComboBox.SelectedValuePath = "CustomerID";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductComboBox.SelectedValue == null || SupplierComboBox.SelectedValue == null ||
                CustomerComboBox.SelectedValue == null || string.IsNullOrWhiteSpace(QuantityTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Sale.ProductID = (int)ProductComboBox.SelectedValue;
            Sale.SupplierID = (int)SupplierComboBox.SelectedValue;
            Sale.CustomerID = (int)CustomerComboBox.SelectedValue;
            Sale.QuantitySold = int.Parse(QuantityTextBox.Text);

            var selectedProduct = _dbService.GetProducts().FirstOrDefault(p => p.ProductID == Sale.ProductID);
            if (selectedProduct != null)
            {
                Sale.TotalAmount = Sale.QuantitySold * selectedProduct.SellingPrice;
                TotalAmountTextBox.Text = Sale.TotalAmount.ToString("F2");
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void QuantityTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (ProductComboBox.SelectedValue == null || string.IsNullOrWhiteSpace(QuantityTextBox.Text))
                return;

            if (int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                var selectedProduct = _dbService.GetProducts().FirstOrDefault(p => p.ProductID == (int)ProductComboBox.SelectedValue);
                if (selectedProduct != null)
                {
                    TotalAmountTextBox.Text = (quantity * selectedProduct.SellingPrice).ToString("F2");
                }
            }
        }
    }
}
