using System;
using System.Collections.Generic;

namespace DoAnChuyenNganh.Models;

public partial class GiangVien
{
    public string? TaiKhoanGiangVien { get; set; }

    public string? MatKhauGiangVien { get; set; }

    public string? MaSoGiangVien { get; set; } = null!;

    public string? gvGioiTinh { get; set; }

    public int? gvSoDienThoai { get; set; }

    public string? gvEmail { get; set; }
    public string? TenGiangVien { get; set; }

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();
}