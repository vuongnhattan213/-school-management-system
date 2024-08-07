using DoAnChuyenNganh.Models;
namespace DoAnChuyenNganh.Repository
{
    public interface IHocVienRepository
    {
        public bool create(HocVien hocVien);
        public bool update(HocVien hocVien);
        public bool delete(string id);
        public List<HocVien> GetAll();

        public HocVien FindByID(string id);
    }

    public class HocVienRepository : IHocVienRepository
    {
        private QuanLyTrungTamAnhNguContext _ctx;
        public HocVienRepository(QuanLyTrungTamAnhNguContext ctx)
        {
            _ctx = ctx;
        }

        public bool create(HocVien hocVien)
        {
            _ctx.HocViens.Add(hocVien);
            _ctx.SaveChanges();
            return true;
        }

        public HocVien FindByID(string id)
        {
            HocVien h = _ctx.HocViens.FirstOrDefault(x => x.MaSoHocVien == id);
            return h;
        }

        public bool update(HocVien hocVien)
        {
            HocVien h = _ctx.HocViens.FirstOrDefault(x => x.MaSoHocVien == hocVien.MaSoHocVien);
            if (h != null)
            {
                _ctx.Entry(h).CurrentValues.SetValues(hocVien);
                _ctx.SaveChanges();
            }
            return true;
        }

        public bool delete(string masohocvienid)
        {
            HocVien h = _ctx.HocViens.FirstOrDefault(x => x.MaSoHocVien == masohocvienid);
            if (h != null)
            {
                _ctx.HocViens.Remove(h);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public List<HocVien> GetAll()
        {
            return _ctx.HocViens.ToList();
        }
    }
}