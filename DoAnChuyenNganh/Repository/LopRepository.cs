using DoAnChuyenNganh.Models;
namespace DoAnChuyenNganh.Repository
{
    public interface ILopRepository
    {
        public bool create(Lop lop);
        public bool update(Lop lop);
        public bool delete(string masolopid);
        public List<Lop> GetAll();
        public Lop FindByID(string id);
    }
    public class LopRepository : ILopRepository
    {
        private QuanLyTrungTamAnhNguContext _btx;
        public LopRepository(QuanLyTrungTamAnhNguContext btx) 
        {
            _btx = btx;
        }
        public bool create(Lop lop)
        {
            _btx.Lops.Add(lop);
            _btx.SaveChanges();
            return true;
        }

        public bool delete(string masolopid)
        {
            Lop h = _btx.Lops.FirstOrDefault(x => x.MaLop == masolopid);
            if (h != null)
            {
                _btx.Lops.Remove(h);
                _btx.SaveChanges();
                return true;
            }
            return false;
        }

        public Lop FindByID(string id)
        {
            Lop h = _btx.Lops.FirstOrDefault(x => x.MaLop == id);
            return h;
        }

        public List<Lop> GetAll()
        {
            return _btx.Lops.ToList();
        }

        public bool update(Lop lop)
        {
            Lop h = _btx.Lops.FirstOrDefault(x => x.MaLop == lop.MaLop);
            if (h != null)
            {
                _btx.Entry(h).CurrentValues.SetValues(lop);
                _btx.SaveChanges();
            }
            return true;
        }
    }
}