using DoAnChuyenNganh.Models;
namespace DoAnChuyenNganh.Repository
{
    public interface IDiemRepository
    {
        public bool create(Diem diem);
        public List<Diem> GetAll();
    }
    public class DiemRepository : IDiemRepository
    {
        private QuanLyTrungTamAnhNguContext _dtx;
        public DiemRepository(QuanLyTrungTamAnhNguContext dtx)
        {
            _dtx = dtx;
        }

        public bool create(Diem diem)
        {
            _dtx.Diems.Add(diem);
            _dtx.SaveChanges();
            return true;
        }

        public List<Diem> GetAll()
        {
            return _dtx.Diems.ToList();
        }
    }
}