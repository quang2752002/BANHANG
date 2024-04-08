using System;
using System.Collections.Generic;

namespace BANHANG.Models.EF
{
    public partial class HinhAnh
    {
        public int Id { get; set; }
        public int? Idsp { get; set; }
        public string? Img { get; set; }
        public string? Status { get; set; }

        public virtual SanPham? IdspNavigation { get; set; }
    }
}
