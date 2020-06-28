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
    public class BanTinsController : Controller
    {
        private WebDuLich db = new WebDuLich();

        // GET: Admin/BanTins
        public ActionResult Index()
        {
            var banTins = db.BanTins.Include(b => b.Anh).Include(b => b.DanhMuc).Include(b => b.NoiDung).Include(b => b.TableUser);
            return View(banTins.ToList());
        }

        // GET: Admin/BanTins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanTin banTin = db.BanTins.Find(id);
            if (banTin == null)
            {
                return HttpNotFound();
            }
            return View(banTin);
        }

        // GET: Admin/BanTins/Create
        public ActionResult Create()
        {
            ViewBag.IDAnh = new SelectList(db.Anhs, "IDAnh", "TenAnhDM");
            ViewBag.IDDanhMuc = new SelectList(db.DanhMucs, "IDDanhMuc", "TenDanhMuc");
            ViewBag.IDNoiDung = new SelectList(db.NoiDungs, "IDNoiDung", "TenND_DM");
            ViewBag.Username = new SelectList(db.TableUsers, "Username", "Pass");
            return View();
        }

        // POST: Admin/BanTins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBanTin,TieuDe,BanTinNgan,NgayDang,SoLuotXem,ViTri,IDDanhMuc,Username,IDAnh,IDNoiDung")] BanTin banTin)
        {
            if (ModelState.IsValid)
            {
                db.BanTins.Add(banTin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAnh = new SelectList(db.Anhs, "IDAnh", "TenAnhDM", banTin.IDAnh);
            ViewBag.IDDanhMuc = new SelectList(db.DanhMucs, "IDDanhMuc", "TenDanhMuc", banTin.IDDanhMuc);
            ViewBag.IDNoiDung = new SelectList(db.NoiDungs, "IDNoiDung", "TenND_DM", banTin.IDNoiDung);
            ViewBag.Username = new SelectList(db.TableUsers, "Username", "Pass", banTin.Username);
            return View(banTin);
        }

        // GET: Admin/BanTins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanTin banTin = db.BanTins.Find(id);
            if (banTin == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAnh = new SelectList(db.Anhs, "IDAnh", "TenAnhDM", banTin.IDAnh);
            ViewBag.IDDanhMuc = new SelectList(db.DanhMucs, "IDDanhMuc", "TenDanhMuc", banTin.IDDanhMuc);
            ViewBag.IDNoiDung = new SelectList(db.NoiDungs, "IDNoiDung", "TenND_DM", banTin.IDNoiDung);
            ViewBag.Username = new SelectList(db.TableUsers, "Username", "Pass", banTin.Username);
            return View(banTin);
        }

        // POST: Admin/BanTins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBanTin,TieuDe,BanTinNgan,NgayDang,SoLuotXem,ViTri,IDDanhMuc,Username,IDAnh,IDNoiDung")] BanTin banTin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banTin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAnh = new SelectList(db.Anhs, "IDAnh", "TenAnhDM", banTin.IDAnh);
            ViewBag.IDDanhMuc = new SelectList(db.DanhMucs, "IDDanhMuc", "TenDanhMuc", banTin.IDDanhMuc);
            ViewBag.IDNoiDung = new SelectList(db.NoiDungs, "IDNoiDung", "TenND_DM", banTin.IDNoiDung);
            ViewBag.Username = new SelectList(db.TableUsers, "Username", "Pass", banTin.Username);
            return View(banTin);
        }

        // GET: Admin/BanTins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BanTin banTin = db.BanTins.Find(id);
            if (banTin == null)
            {
                return HttpNotFound();
            }
            return View(banTin);
        }

        // POST: Admin/BanTins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BanTin banTin = db.BanTins.Find(id);
            db.BanTins.Remove(banTin);
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
