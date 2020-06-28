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
    public class DanhMucDadsController : Controller
    {
        private WebDuLich db = new WebDuLich();

        // GET: Admin/DanhMucDads
        public ActionResult Index()
        {
            return View(db.DanhMucDads.ToList());
        }

        // GET: Admin/DanhMucDads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucDad danhMucDad = db.DanhMucDads.Find(id);
            if (danhMucDad == null)
            {
                return HttpNotFound();
            }
            return View(danhMucDad);
        }

        // GET: Admin/DanhMucDads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucDads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDanhMucDad,TenDanhMucDad")] DanhMucDad danhMucDad)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucDads.Add(danhMucDad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhMucDad);
        }

        // GET: Admin/DanhMucDads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucDad danhMucDad = db.DanhMucDads.Find(id);
            if (danhMucDad == null)
            {
                return HttpNotFound();
            }
            return View(danhMucDad);
        }

        // POST: Admin/DanhMucDads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDanhMucDad,TenDanhMucDad")] DanhMucDad danhMucDad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMucDad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMucDad);
        }

        // GET: Admin/DanhMucDads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucDad danhMucDad = db.DanhMucDads.Find(id);
            if (danhMucDad == null)
            {
                return HttpNotFound();
            }
            return View(danhMucDad);
        }

        // POST: Admin/DanhMucDads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMucDad danhMucDad = db.DanhMucDads.Find(id);
            db.DanhMucDads.Remove(danhMucDad);
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
