using System;
using System.Collections.Generic;

namespace DoAnChuyenNganh.Models;

public partial class HocVien
{
    public string TenHocVien { get; set; } = null!;

    public string MaSoHocVien { get; set; } = null!;

    public string? GioiTinh { get; set; }

    public int? SoDienThoai { get; set; }

    public string? Email { get; set; }
}