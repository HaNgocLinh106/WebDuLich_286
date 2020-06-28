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
    public class BinhLuansController : Controller
    {
        private WebDuLich db = new WebDuLich();

        // GET: Admin/BinhLuans
        public ActionResult Index()
        {
            var binhLuans = db.BinhLuans.Include(b => b.BanTin).Include(b => b.NguoiDung);
            return View(binhLuans.ToList());
        }

        // GET: Admin/BinhLuans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuans.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Create
        public ActionResult Create()
        {
            ViewBag.IDBanTin = new SelectList(db.BanTins, "IDBanTin", "TieuDe");
            ViewBag.TenNguoiDung = new SelectList(db.NguoiDungs, "TenNguoiDung", "Email");
            return View();
        }

        // POST: Admin/BinhLuans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBinhLuan,NoiDung,IDBanTin,TenNguoiDung")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                db.BinhLuans.Add(binhLuan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBanTin = new SelectList(db.BanTins, "IDBanTin", "TieuDe", binhLuan.IDBanTin);
            ViewBag.TenNguoiDung = new SelectList(db.NguoiDungs, "TenNguoiDung", "Email", binhLuan.TenNguoiDung);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuans.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBanTin = new SelectList(db.BanTins, "IDBanTin", "TieuDe", binhLuan.IDBanTin);
            ViewBag.TenNguoiDung = new SelectList(db.NguoiDungs, "TenNguoiDung", "Email", binhLuan.TenNguoiDung);
            return View(binhLuan);
        }

        // POST: Admin/BinhLuans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBinhLuan,NoiDung,IDBanTin,TenNguoiDung")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(binhLuan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBanTin = new SelectList(db.BanTins, "IDBanTin", "TieuDe", binhLuan.IDBanTin);
            ViewBag.TenNguoiDung = new SelectList(db.NguoiDungs, "TenNguoiDung", "Email", binhLuan.TenNguoiDung);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuans.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            return View(binhLuan);
        }

        // POST: Admin/BinhLuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BinhLuan binhLuan = db.BinhLuans.Find(id);
            db.BinhLuans.Remove(binhLuan);
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
