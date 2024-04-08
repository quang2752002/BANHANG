using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BANHANG.Models.EF
{
    public partial class BANHANGContext : DbContext
    {
        public BANHANGContext()
        {
        }

        public BANHANGContext(DbContextOptions<BANHANGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; } = null!;
        public virtual DbSet<DanhMuc> DanhMucs { get; set; } = null!;
        public virtual DbSet<GiamGium> GiamGia { get; set; } = null!;
        public virtual DbSet<HinhAnh> HinhAnhs { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CPTPR8L;Initial Catalog=BANHANG;Persist Security Info=True;User ID=sa;Password=1; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("ADMIN");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.ToTable("CHI_TIET_HOA_DON");

                entity.Property(e => e.Idhd).HasColumnName("idhd");

                entity.Property(e => e.Idsp).HasColumnName("idsp");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdhdNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.Idhd)
                    .HasConstraintName("FK_CHI_TIET_HOA_DON_HOA_DON");

                entity.HasOne(d => d.IdspNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.Idsp)
                    .HasConstraintName("FK_CHI_TIET_HOA_DON_SAN_PHAM");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.ToTable("DANH_MUC");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<GiamGium>(entity =>
            {
                entity.ToTable("GIAM_GIA");

                entity.Property(e => e.End)
                    .HasColumnType("datetime")
                    .HasColumnName("end");

                entity.Property(e => e.Idsp).HasColumnName("idsp");

                entity.Property(e => e.Promotion).HasColumnName("promotion");

                entity.Property(e => e.Start)
                    .HasColumnType("datetime")
                    .HasColumnName("start");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.HasOne(d => d.IdspNavigation)
                    .WithMany(p => p.GiamGia)
                    .HasForeignKey(d => d.Idsp)
                    .HasConstraintName("FK_GIAM_GIA_SAN_PHAM");
            });

            modelBuilder.Entity<HinhAnh>(entity =>
            {
                entity.ToTable("HINH_ANH");

                entity.Property(e => e.Idsp).HasColumnName("idsp");

                entity.Property(e => e.Img)
                    .HasMaxLength(300)
                    .HasColumnName("img");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.HasOne(d => d.IdspNavigation)
                    .WithMany(p => p.HinhAnhs)
                    .HasForeignKey(d => d.Idsp)
                    .HasConstraintName("FK_HINH_ANH_SAN_PHAM");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.ToTable("HOA_DON");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Idkh).HasColumnName("idkh");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .HasColumnName("sdt");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdkhNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Idkh)
                    .HasConstraintName("FK_HOA_DON_KHACH_HANG");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("KHACH_HANG");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Img)
                    .HasMaxLength(300)
                    .HasColumnName("img");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(300)
                    .HasColumnName("password");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(20)
                    .HasColumnName("sdt");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SAN_PHAM");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Iddanhmuc).HasColumnName("iddanhmuc");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Origin)
                    .HasMaxLength(50)
                    .HasColumnName("origin");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.HasOne(d => d.IddanhmucNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.Iddanhmuc)
                    .HasConstraintName("FK_SAN_PHAM_DANH_MUC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
