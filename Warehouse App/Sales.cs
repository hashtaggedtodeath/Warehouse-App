//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warehouse_App
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sales
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public int CustomerID { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalAmount { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Products Products { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
