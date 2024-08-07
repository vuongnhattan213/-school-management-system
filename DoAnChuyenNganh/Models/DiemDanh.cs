using System;
using System.Collections.Generic;

namespace DoAnChuyenNganh.Models;

public partial class DiemDanh
{
    public string? MaSoHocVien { get; set; } = null!;

    public string MaLop { get; set; } = null;

    public string? CaHoc { get; set; }

    public virtual Lop MaLopNavigation { get; set; } = null!;

    public virtual HocVien MaSoHocVienNavigation { get; set; } = null!;
}
