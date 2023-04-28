using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetWay_v1.Models
{
    public class Rpt_BangKeHoaDonBanHang
    {
        // Cac Field can tra ra duoi dang Data
        public string Stt { set; get; }
        public DateTime Ngay_Ct { set; get; }
        public string So_Ct { set; get; }
        public string Ma_Dt { set; get; }
        public string Ten_Dt { set; get; }
        public decimal So_Luong { set; get; }
        public decimal Tien2 { set; get; }
        public decimal Tien3 { set; get; }
        public decimal TTong_Tien { set; get; }      


    }
}
