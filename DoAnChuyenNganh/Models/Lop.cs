using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace DoAnChuyenNganh.Models;

public partial class Lop
{
    public string MaLop { get; set; } = null!;

    public string? TenLop { get; set; }

    public string? NgayBatDau { get; set; }

    public string? NgayKetThuc { get; set; }

    public string? ThoiGianHoc { get; set; }

    public string? CaHoc { get; set; }

    public string? SiSo { get; set; }

    public string? TenGiangVien { get; set; }

    public string? MaSoGiangVien { get; set; } = null!;

    public virtual GiangVien MaSoGiangVienNavigation { get; set; } = null!;
}