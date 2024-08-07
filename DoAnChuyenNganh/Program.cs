using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using DoAnChuyenNganh.Repository;
using DoAnChuyenNganh.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<QuanLyTrungTamAnhNguContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuanLyTrungTamAnhNguDB"));
});

builder.Services.AddTransient<IHocVienRepository, HocVienRepository>();
builder.Services.AddTransient<ILopRepository, LopRepository>();
builder.Services.AddTransient<IGiangVienRepository, GiangVienRepository>();
builder.Services.AddTransient<IDiemRepository, DiemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();