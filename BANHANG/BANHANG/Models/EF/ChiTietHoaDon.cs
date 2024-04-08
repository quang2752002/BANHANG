using System;
using System.Collections.Generic;

namespace BANHANG.Models.EF
{
    public partial class ChiTietHoaDon
    {
        public int Id { get; set; }
        public int? Idhd { get; set; }
        public int? Idsp { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual HoaDon? IdhdNavigation { get; set; }
        public virtual SanPham? IdspNavigation { get; set; }
    }
}
