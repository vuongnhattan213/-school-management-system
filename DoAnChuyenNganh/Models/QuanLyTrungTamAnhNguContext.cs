using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoAnChuyenNganh.Models;

public partial class QuanLyTrungTamAnhNguContext : DbContext
{
    public QuanLyTrungTamAnhNguContext()
    {
    }

    public QuanLyTrungTamAnhNguContext(DbContextOptions<QuanLyTrungTamAnhNguContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DangNhap> DangNhaps { get; set; }

    public virtual DbSet<Diem> Diems { get; set; }

    public virtual DbSet<DiemDanh> DiemDanhs { get; set; }

    public virtual DbSet<GiangVien> GiangViens { get; set; }

    public virtual DbSet<HocVien> HocViens { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Table1> Table1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ME60LBU\\SQLEXPRESS;uid=sa;password=123;database=QuanLyTrungTamAnhNgu;Encrypt=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DangNhap>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DangNhap");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai).HasMaxLength(50);
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);

            entity.HasOne(d => d.MaSoGiangVienNavigation).WithMany()
                .HasForeignKey(d => d.MaSoGiangVien)
                .HasConstraintName("FK_DangNhap_GiangVien");

            entity.HasOne(d => d.MaSoNhanVienNavigation).WithMany()
                .HasForeignKey(d => d.MaSoNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DangNhap_NhanVien");
        });

        modelBuilder.Entity<Diem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Diem");

            entity.Property(e => e.DiemLan1).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.DiemLan2).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.DiemLan3).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.DiemTrungBinh).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.MaLopNavigation).WithMany()
                .HasForeignKey(d => d.MaLop)
                .HasConstraintName("FK_Diem_Lop");

            entity.HasOne(d => d.MaSoHocVienNavigation).WithMany()
                .HasForeignKey(d => d.MaSoHocVien)
                .HasConstraintName("FK_Diem_HocVien");
        });

        modelBuilder.Entity<DiemDanh>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DiemDanh");

            entity.Property(e => e.CaHoc).HasMaxLength(50);

            entity.HasOne(d => d.MaLopNavigation).WithMany()
                .HasForeignKey(d => d.MaLop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiemDanh_Lop");

            entity.HasOne(d => d.MaSoHocVienNavigation).WithMany()
                .HasForeignKey(d => d.MaSoHocVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiemDanh_HocVien");
        });

        modelBuilder.Entity<GiangVien>(entity =>
        {
            entity.HasKey(e => e.MaSoGiangVien);

            entity.ToTable("GiangVien");

            entity.Property(e => e.MaSoGiangVien).ValueGeneratedNever();
            entity.Property(e => e.MatKhauGiangVien).HasMaxLength(50);
            entity.Property(e => e.TaiKhoanGiangVien).HasMaxLength(50);
        });

        modelBuilder.Entity<HocVien>(entity =>
        {
            entity.HasKey(e => e.MaSoHocVien);

            entity.ToTable("HocVien");

            entity.Property(e => e.MaSoHocVien).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(50);
            entity.Property(e => e.TenHocVien).HasMaxLength(50);
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop);

            entity.ToTable("Lop");

            entity.Property(e => e.MaLop).ValueGeneratedNever();
            entity.Property(e => e.CaHoc).HasMaxLength(50);
            entity.Property(e => e.NgayBatDau).HasMaxLength(50);
            entity.Property(e => e.NgayKetThuc).HasMaxLength(50);
            entity.Property(e => e.SiSo).HasMaxLength(50);
            entity.Property(e => e.TenGiangVien).HasMaxLength(50);
            entity.Property(e => e.TenLop).HasMaxLength(50);
            entity.Property(e => e.ThoiGianHoc).HasMaxLength(50);

            entity.HasOne(d => d.MaSoGiangVienNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.MaSoGiangVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lop_GiangVien");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaSoNhanVien);

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaSoNhanVien).ValueGeneratedNever();
            entity.Property(e => e.MatKhauNhanVien).HasMaxLength(50);
            entity.Property(e => e.TaiKhoanNhanVien).HasMaxLength(50);
        });

        modelBuilder.Entity<Table1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Table1");

            entity.Property(e => e.MaSoHocVien)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.MaSoNhanVien)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}