﻿using System;
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
    public class TinhsController : Controller
    {
        private KIEMTRA_ASPEntities db = new KIEMTRA_ASPEntities();

        // GET: Tinhs
        public ActionResult Index()
        {
            return View(db.Tinh.ToList());
        }

        // GET: Tinhs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tinh tinh = db.Tinh.Find(id);
            if (tinh == null)
            {
                return HttpNotFound();
            }
            return View(tinh);
        }

        // GET: Tinhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tinhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTinh,TenTinh")] Tinh tinh)
        {
            if (ModelState.IsValid)
            {
                db.Tinh.Add(tinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tinh);
        }

        // GET: Tinhs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tinh tinh = db.Tinh.Find(id);
            if (tinh == null)
            {
                return HttpNotFound();
            }
            return View(tinh);
        }

        // POST: Tinhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTinh,TenTinh")] Tinh tinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tinh);
        }

        // GET: Tinhs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tinh tinh = db.Tinh.Find(id);
            if (tinh == null)
            {
                return HttpNotFound();
            }
            return View(tinh);
        }

        // POST: Tinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tinh tinh = db.Tinh.Find(id);
            db.Tinh.Remove(tinh);
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
