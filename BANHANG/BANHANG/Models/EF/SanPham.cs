using System;
using System.Collections.Generic;

namespace BANHANG.Models.EF
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            GiamGia = new HashSet<GiamGium>();
            HinhAnhs = new HashSet<HinhAnh>();
        }

        public int Id { get; set; }
        public int? Iddanhmuc { get; set; }
        public int? Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Origin { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }

        public virtual DanhMuc? IddanhmucNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual ICollection<GiamGium> GiamGia { get; set; }
        public virtual ICollection<HinhAnh> HinhAnhs { get; set; }
    }
}
