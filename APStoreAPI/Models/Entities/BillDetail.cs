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
    
    public partial class BillDetail
    {
        public int BillID { get; set; }
        public int ProductID { get; set; }
        public int Quantities { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
