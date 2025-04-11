using System;
using System.Windows;
using Warehouse_App.Data;

namespace Warehouse_App.Windows
{
    public partial class ProductWindow : Window
    {
        public Products Product { get; private set; }
        private readonly DatabaseService _dbService;
        

        public ProductWindow(Products product, DatabaseService dbService)
        {
            InitializeComponent();
            Product = product;
            _dbService = dbService;
            DataContext = Product;
            if (Product != null)
            {
                NameTextBox.Text = Product.Name;
                UnitTextBox.Text = Product.Unit;
                QuantityTextBox.Text = Product.Quantity.ToString();
                PurchasePriceTextBox.Text = Product.PurchasePrice.ToString();
                SalesPriceTextBox.Text = Product.SellingPrice.ToString();
            }
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Product.Name = NameTextBox.Text.Trim();
                Product.Unit = UnitTextBox.Text.Trim();
                Product.Quantity = int.Parse(QuantityTextBox.Text);
                Product.PurchasePrice = decimal.Parse(PurchasePriceTextBox.Text);
                Product.SellingPrice = decimal.Parse(SalesPriceTextBox.Text);
                

               
                DialogResult = true;
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте правильность введённых чисел.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
