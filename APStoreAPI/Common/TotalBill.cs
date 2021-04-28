using APStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStoreAPI.Common
{
    public class TotalBill
    {
        public Bill bill;
        public List<BillDetail> billDetails;
    }
}