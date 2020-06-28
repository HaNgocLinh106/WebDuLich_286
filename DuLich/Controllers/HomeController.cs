using DuLich.Models.Fun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DuLich.Models.EF;
using DuLich.Models.BL;

namespace DuLich.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int page = 1, int pageSize = 6)
        {
            var model = new DanhMucTinF().ListAllPaging(page, pageSize);
            ViewBag.TinMoi = new DanhMucTinF().TinMoi(3);
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult DanhMucDad()
        {
            var model = new DanhMucDadF().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult DanhMuc(long id)
        {
            var model = new DanhMucDadF().ListDanhMuc(id);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult TimKiem(string search)
        {
            var model = new DanhMucTinF().TimKiem(search);
            return View(model);
        }
        public PartialViewResult TinHot()
        {
            var model = new DanhMucTinF().TinHot(10);
            ViewBag.Anh = new DanhMucTinF().VN(12);
            ViewBag.DD = new DanhMucTinF().ListDiaDiemHot(5);
            return PartialView(model);
        }

        [HttpGet]
        public PartialViewResult BinhLuan()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult BinhLuan(BinhLuanModel model)
        {
            var cmt = new BinhLuan();
            cmt.TenNguoiDung = model.TenNguoiDung;
            cmt.NoiDung = model.NoiDung;           
            var result = new DanhMucTinF().ThemBinhLuan(cmt);
            
                ViewBag.Success = "Đã gửi bình luận";
                model = new BinhLuanModel();
            return PartialView(model);
        }        
    }
}
