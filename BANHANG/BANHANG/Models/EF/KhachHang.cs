using System;
using System.Collections.Generic;

namespace BANHANG.Models.EF
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Sdt { get; set; }
        public string? Address { get; set; }
        public string? Img { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
