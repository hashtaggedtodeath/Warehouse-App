﻿using System;
using System.Windows;
using Warehouse_App.Data;
using Warehouse_App.Windows;
using Warehouse_App;


namespace Warehouse_App.Windows
{
    public partial class MainWindow : Window
    {
        private readonly DatabaseService _dbService;
        private string _currentTable = "Suppliers"; // По умолчанию показываем поставщиков

        public MainWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            LoadData();
        }

        private void LoadData()
        {
            switch (_currentTable)
            {
                case "Suppliers":
                    MainDataGrid.ItemsSource = _dbService.GetSuppliers();
                    break;
                case "Customers":
                    MainDataGrid.ItemsSource = _dbService.GetCustomers();
                    break;
                case "Products":
                    MainDataGrid.ItemsSource = _dbService.GetProducts();
                    break;
                case "Sales":
                    MainDataGrid.ItemsSource = _dbService.GetSales();
                    break;
            }
        }

        private void SuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTable = "Suppliers";
            LoadData();
        }

        private void CustomersButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTable = "Customers";
            LoadData();
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTable = "Products";
            LoadData();
        }

        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTable = "Sales";
            LoadData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            switch (_currentTable)
            {
            
                case "Suppliers":
                    var newSupplier = new Suppliers();
                    var supplierWindow = new SupplierWindow(newSupplier);
                    if (supplierWindow.ShowDialog() == true)
                    {
                        _dbService.AddSupplier(newSupplier);
                        LoadData();
                    }
                    
                    break;
                case "Customers":
                    var newCustomer = new Customers();
                    var customerWindow = new CustomerWindow(newCustomer);
                    if (customerWindow.ShowDialog() == true)
                    {
                        _dbService.AddCustomer(newCustomer);
                        LoadData();
                    }
                    break;
                case "Products":
                    var newProduct = new Products();
                    var productWindow = new ProductWindow(newProduct, _dbService);
                    if (productWindow.ShowDialog() == true)
                    {
                        _dbService.AddProduct(newProduct);
                        LoadData();
                    }
                    break;
                case "Sales":
                    var newSale = new Sales();
                    var saleWindow = new SaleWindow(newSale, _dbService);
                    if (saleWindow.ShowDialog() == true)
                    {
                        _dbService.AddSale(newSale);
                        LoadData();
                    }
                    break;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainDataGrid.SelectedItem == null) return;

            switch (_currentTable)
            {
                case "Suppliers":
                    var supplier = (Suppliers)MainDataGrid.SelectedItem;
                    var supplierWindow = new SupplierWindow(supplier);
                    if (supplierWindow.ShowDialog() == true)
                    {
                        _dbService.UpdateSupplier(supplier);
                        LoadData();
                    }
                    break;
                case "Customers":
                    var customer = (Customers)MainDataGrid.SelectedItem;
                    var customerWindow = new CustomerWindow(customer);
                    if (customerWindow.ShowDialog() == true)
                    {
                        _dbService.UpdateCustomer(customer);
                        LoadData();
                    }
                    break;
                case "Products":
                    var product = (Products)MainDataGrid.SelectedItem;
                    var productWindow = new ProductWindow(product, _dbService);
                    if (productWindow.ShowDialog() == true)
                    {
                        _dbService.UpdateProduct(product);
                        LoadData();
                    }
                    break;
                case "Sales":
                    var sale = (Sales)MainDataGrid.SelectedItem;
                    var saleWindow = new SaleWindow(sale, _dbService);
                    if (saleWindow.ShowDialog() == true)
                    {
                        _dbService.UpdateSale(sale);
                        LoadData();
                    }
                    break;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainDataGrid.SelectedItem == null) return;

            switch (_currentTable)
            {
                case "Suppliers":
                    var supplier = (Suppliers)MainDataGrid.SelectedItem;
                    _dbService.DeleteSupplier(supplier.SupplierID);
                    break;
                case "Customers":
                    var customer = (Customers)MainDataGrid.SelectedItem;
                    _dbService.DeleteCustomer(customer.CustomerID);
                    break;
                case "Products":
                    var product = (Products)MainDataGrid.SelectedItem;
                    _dbService.DeleteProduct(product.ProductID);
                    break;
                case "Sales":
                    var sale = (Sales)MainDataGrid.SelectedItem;
                    _dbService.DeleteSale(sale.SaleID);
                    break;
            }
            LoadData();
        }
    }
}
