using DoAnChuyenNganh.Models;
using DoAnChuyenNganh.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DoAnChuyenNganh.Controllers
{
    public class QLANController : Controller
    {
        private IHocVienRepository _hocVienRepository;
        private ILopRepository _lopRepository;
        private IGiangVienRepository _giangvienRepository;
        private IDiemRepository _diemRepository;

        public QLANController(IHocVienRepository hocVienRepository, ILopRepository lopRepository, IGiangVienRepository giangVienRepository, IDiemRepository diemRepository) 
        {
            _hocVienRepository = hocVienRepository;       
            _lopRepository = lopRepository;
            _giangvienRepository = giangVienRepository;
            _diemRepository = diemRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrangChu()
        {
            return View();
        }
        public IActionResult DiemDanh()
        {
            return View();
        }

        public IActionResult DangKy()
        {
            List<HocVien> hocViens = _hocVienRepository.GetAll();
            List<Lop> lop = _lopRepository.GetAll();
            ViewBag.HocVien = hocViens;
            ViewBag.Lop = lop;

            return View();
        }

        public class HocVienDiemLop
        {
            public HocVien HocVien { get; set; }
            public Diem Diem { get; set; }
            public Lop Lop { get; set; }
        }

        public IActionResult Diem()
        {
            var lop = _lopRepository.GetAll();
            var hocViens = _hocVienRepository.GetAll();
            var diems = _diemRepository.GetAll();
            var hocVienDiems = hocViens.Join(
                diems,
                hv => hv.MaSoHocVien,
                d => d.MaSoHocVien,
                (hv, d) => new HocVienDiemLop { HocVien = hv, Diem = d })
                .ToList();

            ViewBag.Lop = lop;
            ViewBag.HocVienDiems = hocVienDiems;

            return View();
        }    [HttpPost]
        public IActionResult createDiemCS(Diem diem)
        {
            _diemRepository.create(diem);
            return RedirectToAction("Diem");
        }
        public IActionResult CreateDiem()
        {
            return View("createDiem", new Diem());
        }

        public IActionResult GiangVien()
        {
            List<GiangVien> giangViens = _giangvienRepository.GetAll();

            return View(giangViens);
        }

        [HttpPost]
        public IActionResult createGiangVienCS(GiangVien giangVien)
        {
            _giangvienRepository.create(giangVien);
            return RedirectToAction("GiangVien");
        }
        public IActionResult CreateGiangVien()
        {
            return View("createGiangVien", new GiangVien());
        }

        public IActionResult updateGiangVienCS(GiangVien giangVien)
        {
            _giangvienRepository.update(giangVien);
            return RedirectToAction("GiangVien");
        }
        public IActionResult UpdateGiangVien(string itemId)
        {
            return View("updateGiangVien", _giangvienRepository.FindByID(itemId));
        }

        public IActionResult DeleteGiangVien(string itemId)
        {
            _giangvienRepository.delete(itemId);
            return RedirectToAction("GiangVien");
        }

        public IActionResult HocVien()
        {
            List<HocVien> hocViens = _hocVienRepository.GetAll();

            return View("HocVien", hocViens);
        }

        [HttpPost]
        public IActionResult createHocVienCS(HocVien hocVien)
        {
            _hocVienRepository.create(hocVien);
            return RedirectToAction("HocVien");
        }

        public IActionResult CreateHocVien()
        {
            return View("createHocVien", new HocVien());
        }

        public IActionResult updateHocVienCS(HocVien hocVien)
        {
            _hocVienRepository.update(hocVien);
            return RedirectToAction("HocVien");
        }
        public IActionResult UpdateHocVien(string itemId)
        {
            return View("updateHocVien", _hocVienRepository.FindByID(itemId));
        }

        public IActionResult DeleteHocVien(string itemId) 
        {
            _hocVienRepository.delete(itemId);
            return RedirectToAction("HocVien");
        }

        public IActionResult Lop(string id)
        {
            List<Lop> lops = _lopRepository.GetAll();
            return View("Lop", lops);
        }
        public IActionResult createLopCS(Lop lop)
        {
            _lopRepository.create(lop);
            return RedirectToAction("Lop");
        }
        public IActionResult CreateLop()
        {
            return View("createLop", new Lop());
        }

        [HttpPost]
        public IActionResult updateLopCS(Lop lop)
        {
            _lopRepository.update(lop);
            return RedirectToAction("Lop");
        }
        public IActionResult UpdateLop(string itemId)
        {
            return View("updateLop", _lopRepository.FindByID(itemId));
        }

        public IActionResult DeleteLop(string itemId)
        {
            _lopRepository.delete(itemId);
            return RedirectToAction("Lop");
        }

        public IActionResult BaoCao()
        {
            List<Lop> lops = _lopRepository.GetAll();
            List<HocVien> hocViens = _hocVienRepository.GetAll();
            List<Diem> diems = _diemRepository.GetAll();

            var hocVienDiemLopJoin = from hocVien in hocViens
                                     join diem in diems on hocVien.MaSoHocVien equals diem.MaSoHocVien
                                     join lop in lops on diem.MaLop equals lop.MaLop
                                     select new { hocVien, diem, lop };

            ViewBag.HocVienDiemLop = hocVienDiemLopJoin;

            return View();
        }
        public IActionResult LichGiangDay()
        {
            return View();
        }
    }
}