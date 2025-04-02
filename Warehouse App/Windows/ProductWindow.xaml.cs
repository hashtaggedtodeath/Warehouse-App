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
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
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
