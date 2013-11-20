﻿using RavenDbNorthwind.Models.Db;

namespace RavenDbNorthwind.Models.View
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SupplierName { get; set; }
        public Category CategoryName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal PricePerUser { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }
        public int ReorderLevel { get; set; }
    }
}