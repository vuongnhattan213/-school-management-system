using System;
using System.Collections.Generic;

namespace DoAnChuyenNganh.Models;

public partial class DangNhap
{
    public int IdNguoiDung { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? MaSoGiangVien { get; set; }

    public int MaSoNhanVien { get; set; }

    public virtual GiangVien? MaSoGiangVienNavigation { get; set; }

    public virtual NhanVien MaSoNhanVienNavigation { get; set; } = null!;
}
