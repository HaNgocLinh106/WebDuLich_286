using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLich.Controllers;
using DuLich.Models.EF;

namespace DuLich.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        private WebDuLich db = new WebDuLich();
        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","HomeAdmin");
            }
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Pass)
        {
            if (ModelState.IsValid)
            {
                var data = db.TableUsers.Where(s => s.Username.Equals(Username) && s.Pass.Equals(Pass)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["Username"] = data.FirstOrDefault().Username;
                    //Session["Pass"] = data.FirstOrDefault().Pass;
                    //Session["Quyen"] = data.FirstOrDefault().Quyen;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }




    }
}