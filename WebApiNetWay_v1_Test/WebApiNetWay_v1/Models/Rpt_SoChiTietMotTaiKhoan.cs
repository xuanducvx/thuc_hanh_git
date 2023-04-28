using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetWay_v1.Models
{
    public class Rpt_SoChiTietMotTaiKhoan
    {
        // Cac Field can tra ra duoi dang Data
        public string Tk { set; get; }
        public string Tk_Du { set; get; }
        public string Stt { set; get; }
        public int Stt0 { set; get; }
        public DateTime Ngay_Ct { set; get; }
        public string So_Ct { set; get; }
        public string Dien_Giai { set; get; }
        public decimal Ps_No { set; get; }
        public decimal Ps_Co { set; get; }
        public string Ma_Dt { set; get; }
        public string Ten_Dt { set; get; }
        public int Bold { set; get; }

    }
}
