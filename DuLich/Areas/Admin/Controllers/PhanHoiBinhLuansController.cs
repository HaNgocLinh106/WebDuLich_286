using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DuLich.Models.EF;

namespace DuLich.Areas.Admin.Controllers
{
    public class PhanHoiBinhLuansController : Controller
    {
        private WebDuLich db = new WebDuLich();

        // GET: Admin/PhanHoiBinhLuans
        public ActionResult Index()
        {
            var phanHoiBinhLuans = db.PhanHoiBinhLuans.Include(p => p.BinhLuan).Include(p => p.NguoiDung);
            return View(phanHoiBinhLuans.ToList());
        }

        // GET: Admin/PhanHoiBinhLuans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoiBinhLuan phanHoiBinhLuan = db.PhanHoiBinhLuans.Find(id);
            if (phanHoiBinhLuan == null)
            {
                return HttpNotFound();
            }
            return View(phanHoiBinhLuan);
        }

        // GET: Admin/PhanHoiBinhLuans/Create
        public ActionResult Create()
        {
            ViewBag.IDBinhLuan = new SelectList(db.BinhLuans, "IDBinhLuan", "NoiDung");
            ViewBag.TenNguoiDung = new SelectList(db.NguoiDungs, "TenNguoiDung", "Email");
            return View();
        }

        // POST: Admin/PhanHoiBinhLuans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhanHoi,NoiDung,IDBinhLuan,TenNguoiDung")] PhanHoiBinhLuan phanHoiBinhLuan)
        {
            if (ModelState.IsValid)
            {
                db.PhanHoiBinhLuans.Add(phanHoiBinhLuan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBinhLuan = new SelectList(db.BinhLuans, "IDBinhLuan", "NoiDung", phanHoiBinhLuan.IDBinhLuan);
            ViewBag.TenNguoiDung = new SelectList(db.NguoiDungs, "TenNguoiDung", "Email", phanHoiBinhLuan.TenNguoiDung);
            return View(phanHoiBinhLuan);
        }

        // GET: Admin/PhanHoiBinhLuans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoiBinhLuan phanHoiBinhLuan = db.PhanHoiBinhLuans.Find(id);
            if (phanHoiBinhLuan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBinhLuan = new SelectList(db.BinhLuans, "IDBinhLuan", "NoiDung", phanHoiBinhLuan.IDBinhLuan);
            ViewBag.TenNguoiDung = new SelectList(db.NguoiDungs, "TenNguoiDung", "Email", phanHoiBinhLuan.TenNguoiDung);
            return View(phanHoiBinhLuan);
        }

        // POST: Admin/PhanHoiBinhLuans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhanHoi,NoiDung,IDBinhLuan,TenNguoiDung")] PhanHoiBinhLuan phanHoiBinhLuan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanHoiBinhLuan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBinhLuan = new SelectList(db.BinhLuans, "IDBinhLuan", "NoiDung", phanHoiBinhLuan.IDBinhLuan);
            ViewBag.TenNguoiDung = new SelectList(db.NguoiDungs, "TenNguoiDung", "Email", phanHoiBinhLuan.TenNguoiDung);
            return View(phanHoiBinhLuan);
        }

        // GET: Admin/PhanHoiBinhLuans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanHoiBinhLuan phanHoiBinhLuan = db.PhanHoiBinhLuans.Find(id);
            if (phanHoiBinhLuan == null)
            {
                return HttpNotFound();
            }
            return View(phanHoiBinhLuan);
        }

        // POST: Admin/PhanHoiBinhLuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhanHoiBinhLuan phanHoiBinhLuan = db.PhanHoiBinhLuans.Find(id);
            db.PhanHoiBinhLuans.Remove(phanHoiBinhLuan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
