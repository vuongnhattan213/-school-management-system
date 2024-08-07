using System;
using System.Collections.Generic;

namespace DoAnChuyenNganh.Models;

public partial class Diem
{
    public string? MaSoHocVien { get; set; } = null!;

    public decimal? DiemLan1 { get; set; }

    public decimal? DiemLan2 { get; set; }

    public decimal? DiemLan3 { get; set; }

    public decimal? DiemTrungBinh { get; set; }

    public string MaLop { get; set; } = null!;

    public virtual Lop? MaLopNavigation { get; set; }

    public virtual HocVien? MaSoHocVienNavigation { get; set; }
}