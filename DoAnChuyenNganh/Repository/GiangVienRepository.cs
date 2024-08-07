using DoAnChuyenNganh.Models;
namespace DoAnChuyenNganh.Repository
{
    public interface IGiangVienRepository
    {
        public bool create(GiangVien giangVien);
        public bool update(GiangVien giangVien);
        public bool delete(string id);
        public List<GiangVien> GetAll();

        public GiangVien FindByID(string id);
    }
    public class GiangVienRepository : IGiangVienRepository
    {
        private QuanLyTrungTamAnhNguContext _rtx;
        public GiangVienRepository(QuanLyTrungTamAnhNguContext rtx)
        {
            _rtx = rtx;
        }

        public bool create(GiangVien giangVien)
        {
            _rtx.GiangViens.Add(giangVien);
            _rtx.SaveChanges();
            return true;
        }

        public GiangVien FindByID(string id)
        {
            GiangVien h = _rtx.GiangViens.FirstOrDefault(x => x.MaSoGiangVien == id);
            return h;
        }

        public bool update(GiangVien giangVien)
        {
            GiangVien h = _rtx.GiangViens.FirstOrDefault(x => x.MaSoGiangVien == giangVien.MaSoGiangVien);
            if (h != null)
            {
                _rtx.Entry(h).CurrentValues.SetValues(giangVien);
                _rtx.SaveChanges();
            }
            return true;
        }

        public bool delete(string masogiangvienid)
        {
            GiangVien h = _rtx.GiangViens.FirstOrDefault(x => x.MaSoGiangVien == masogiangvienid);
            if (h != null)
            {
                _rtx.GiangViens.Remove(h);
                _rtx.SaveChanges();
                return true;
            }
            return false;
        }

        List<GiangVien> IGiangVienRepository.GetAll()
        {
            return _rtx.GiangViens.ToList();
        }
    }
}