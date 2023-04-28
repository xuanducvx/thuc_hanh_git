using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetWay_v1.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Ma_User { get; set; }
        public string Ten_User { get; set; }
        public int App_Account_Type { get; set; }

    }
}
