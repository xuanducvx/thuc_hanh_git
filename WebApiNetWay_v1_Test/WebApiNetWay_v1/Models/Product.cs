using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetWay_v1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public decimal? Price { get; set; }
        public int Wait_Time { get; set; }
        public string Image { get; set; }
        public int Id_Category { get; set; }
        public int IsParent { get; set; }

    }
}
