using System.Collections.Generic;
using System.Linq;
using Warehouse_App;

namespace Warehouse_App.Data
{
    public class DatabaseService
    {
        public List<Suppliers> GetSuppliers()
        {
            using (var context = new hueEntities())
            {
                return context.Suppliers.ToList();
            }
        }

        public void AddSupplier(Suppliers supplier)
        {
            using (var context = new hueEntities())
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
            }
        }

        public void UpdateSupplier(Suppliers supplier)
        {
            using (var context = new hueEntities())
            {
                var existing = context.Suppliers.Find(supplier.SupplierID);
                if (existing != null)
                {
                    existing.Name = supplier.Name;
                    existing.Adress = supplier.Adress;
                    existing.Phone = supplier.Phone;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteSupplier(int supplierId)
        {
            using (var context = new hueEntities())
            {
                var supplier = context.Suppliers.Find(supplierId);
                if (supplier != null)
                {
                    context.Suppliers.Remove(supplier);
                    context.SaveChanges();
                }
            }
        }
        //Customers
        public List<Customers> GetCustomers()
        {
            using (var context = new hueEntities())
            {
                return context.Customers.ToList();
            }
        }

        public void AddCustomer(Customers customer)
        {
            using (var context = new hueEntities())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void UpdateCustomer(Customers customer)
        {
            using (var context = new hueEntities())
            {
                var existing = context.Customers.Find(customer.CustomerID);
                if (existing != null)
                {
                    existing.Name = customer.Name;
                    existing.Adress = customer.Adress;
                    existing.Phone = customer.Phone;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var context = new hueEntities())
            {
                var customer = context.Customers.Find(customerId);
                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            }
        }



        //Products
        public List<Products> GetProducts()
        {
            using (var context = new hueEntities())
            {
                return context.Products.ToList();
            }
        }

        public void AddProduct(Products product)
        {
            using (var context = new hueEntities())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Products product)
        {
            using (var context = new hueEntities())
            {
                var existing = context.Products.Find(product.ProductID);
                if (existing != null)
                {
                    existing.Name = product.Name;
                    existing.Unit = product.Unit;
                    existing.Quantity = product.Quantity;
                    existing.PurchasePrice = product.PurchasePrice;
                    existing.SellingPrice = product.SellingPrice;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var context = new hueEntities())
            {
                var product = context.Products.Find(productId);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
        }

    
    //Sales
    public List<Sales> GetSales()
        {
            using (var context = new hueEntities())
            {
                return context.Sales.ToList();
            }
        }

        public void AddSale(Sales sale)
        {
            using (var context = new hueEntities())
            {
                context.Sales.Add(sale);
                context.SaveChanges();
            }
        }

        public void UpdateSale(Sales sale)
        {
            using (var context = new hueEntities())
            {
                var existing = context.Sales.Find(sale.SaleID);
                if (existing != null)
                {
                    existing.ProductID = sale.ProductID;
                    existing.SupplierID = sale.SupplierID;
                    existing.CustomerID = sale.CustomerID;
                    existing.QuantitySold = sale.QuantitySold;
                    existing.TotalAmount = sale.TotalAmount;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteSale(int saleId)
        {
            using (var context = new hueEntities())
            {
                var sale = context.Sales.Find(saleId);
                if (sale != null)
                {
                    context.Sales.Remove(sale);
                    context.SaveChanges();
                }
            }
        }

    }
}