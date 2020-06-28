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
    public class TableUsersController : Controller
    {
        private WebDuLich db = new WebDuLich();

        // GET: Admin/TableUsers
        public ActionResult Index()
        {
            return View(db.TableUsers.ToList());
        }

        // GET: Admin/TableUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableUser tableUser = db.TableUsers.Find(id);
            if (tableUser == null)
            {
                return HttpNotFound();
            }
            return View(tableUser);
        }

        // GET: Admin/TableUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TableUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Pass,Quyen")] TableUser tableUser)
        {
            if (ModelState.IsValid)
            {
                db.TableUsers.Add(tableUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableUser);
        }

        // GET: Admin/TableUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableUser tableUser = db.TableUsers.Find(id);
            if (tableUser == null)
            {
                return HttpNotFound();
            }
            return View(tableUser);
        }

        // POST: Admin/TableUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Pass,Quyen")] TableUser tableUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableUser);
        }

        // GET: Admin/TableUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableUser tableUser = db.TableUsers.Find(id);
            if (tableUser == null)
            {
                return HttpNotFound();
            }
            return View(tableUser);
        }

        // POST: Admin/TableUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TableUser tableUser = db.TableUsers.Find(id);
            db.TableUsers.Remove(tableUser);
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
