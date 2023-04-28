using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetWay_v1.Models
{
    public class OrderDetail
    {
        public int Id_Row { get; set; }
        public int Id { get; set; }
        public int Id_Product { get; set; }
        public string Product_Name { get; set; }
        public decimal Quantity { get; set; }
        public string Note_Detail { get; set; }
        public bool Hoan_Thanh { get; set; }
    }
}
