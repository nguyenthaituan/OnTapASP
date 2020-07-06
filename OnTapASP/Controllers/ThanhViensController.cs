using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnTapASP.Models;

namespace OnTapASP.Controllers
{
    public class ThanhViensController : Controller
    {
        private KIEMTRA_ASPEntities db = new KIEMTRA_ASPEntities();

        // GET: ThanhViens
        public ActionResult Index()
        {
            var thanhVien = db.ThanhVien.Include(t => t.Tinh);
            return View(thanhVien.ToList());
        }

        // GET: ThanhViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhVien.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            return View(thanhVien);
        }

        // GET: ThanhViens/Create
        public ActionResult Create()
        {
            ViewBag.MaTinh = new SelectList(db.Tinh, "MaTinh", "TenTinh");
            return View();
        }

        [HttpGet]
        public ActionResult TimKiem(string MaTV = "", string HoTen = "", string NgaySinh = "",
           string GioiTinh = "", string Email = "", string DiaChi = "", string TenTinh = "")
        {
            if (GioiTinh != "1" && GioiTinh != "0")
                GioiTinh = null;
            ViewBag.MaTV = MaTV;
            ViewBag.HoTen = HoTen;
            ViewBag.NgaySinh = NgaySinh;
            ViewBag.GioiTinh = GioiTinh;
            ViewBag.Email = Email;
            ViewBag.DiaChi = DiaChi;
            ViewBag.MaTinh = new SelectList(db.Tinh, "MaTinh", "TenTinh");
            var thanhviens = db.ThanhVien.SqlQuery("EXEC ThanhVien_TimKiem @MaTV = '" + MaTV + "',@HoTen = N'" + HoTen + "', @NgaySinh = '" + NgaySinh + "', @GioiTinh = '" + GioiTinh + "' ,@Email = N'" + Email + "',@DiaChi = N'" + DiaChi + "',@MaTinh = '" + TenTinh + "' ");

            return View(thanhviens.ToList());
        }


        // POST: ThanhViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTV,HoTV,TenTV,NgaySinh,GioiTinh,Email,DiaChi,AnhTV,MaTinh")] ThanhVien thanhVien)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgNV = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgNV.SaveAs(path); //*************************************************

            if (ModelState.IsValid)
            {
                db.ThanhVien.Add(thanhVien);
                thanhVien.AnhTV = postedFileName;  //****************************************
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTinh = new SelectList(db.Tinh, "MaTinh", "TenTinh", thanhVien.MaTinh);
            return View(thanhVien);
        }

       
        // GET: ThanhViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhVien.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTinh = new SelectList(db.Tinh, "MaTinh", "TenTinh", thanhVien.MaTinh);
            return View(thanhVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTV,HoTV,TenTV,NgaySinh,GioiTinh,Email,DiaChi,AnhTV,MaTinh")] ThanhVien thanhVien)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgNV = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgNV.SaveAs(path);

            //********************************************************************

            if (ModelState.IsValid)
            {
                db.Entry(thanhVien).State = EntityState.Modified;
                thanhVien.AnhTV = postedFileName; //******************************************************888
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.MaTinh = new SelectList(db.Tinh, "MaTinh", "TenTinh", thanhVien.MaTinh);
            return View(thanhVien);
        }

        // GET: ThanhViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhVien.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            return View(thanhVien);
        }

        // POST: ThanhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThanhVien thanhVien = db.ThanhVien.Find(id);
            db.ThanhVien.Remove(thanhVien);
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
