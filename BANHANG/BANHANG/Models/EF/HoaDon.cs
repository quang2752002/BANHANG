using System;
using System.Collections.Generic;

namespace BANHANG.Models.EF
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int Id { get; set; }
        public int? Idkh { get; set; }
        public int? Total { get; set; }
        public DateTime? Date { get; set; }
        public string? Name { get; set; }
        public string? Sdt { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }

        public virtual KhachHang? IdkhNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
