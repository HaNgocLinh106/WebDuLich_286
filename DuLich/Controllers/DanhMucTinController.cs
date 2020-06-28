using DuLich.Models.Fun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_TinTucDuLich.Controllers
{
    public class DanhMucTinController : Controller
    {
        // GET: DanhMucTin
        public ActionResult Index(long id)
        {         
            var model = new DanhMucTinF().DMTin(id);
            ViewBag.Tin = new DanhMucTinF().ChiTietTin(id);
            return View(model);
        }

    }
}