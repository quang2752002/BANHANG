using System;
using System.Collections.Generic;

namespace BANHANG.Models.EF
{
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
