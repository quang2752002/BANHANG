using System;
using System.Collections.Generic;

namespace BANHANG.Models.EF
{
    public partial class GiamGium
    {
        public int Id { get; set; }
        public int? Idsp { get; set; }
        public int? Promotion { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? Status { get; set; }

        public virtual SanPham? IdspNavigation { get; set; }
    }
}
