//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APStoreAPI.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public decimal Total { get; set; }
        public int TotalQuantities { get; set; }
        public string CategoryName { get; set; }
    }
}
