using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using thu_project2_cnt1.Models;

namespace thu_project2_cnt1.Areas.Admin.Controllers
{
    public class DONHANGCTsController : Controller
    {
        private LTHT_K22cnt1Entities db = new LTHT_K22cnt1Entities();

        // GET: Admin/DONHANGCTs
        public ActionResult Index()
        {
            var dONHANGCTs = db.DONHANGCTs.Include(d => d.DONHANG).Include(d => d.HANGHOA);
            return View(dONHANGCTs.ToList());
        }

        // GET: Admin/DONHANGCTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANGCT dONHANGCT = db.DONHANGCTs.Find(id);
            if (dONHANGCT == null)
            {
                return HttpNotFound();
            }
            return View(dONHANGCT);
        }

        // GET: Admin/DONHANGCTs/Create
        public ActionResult Create()
        {
            ViewBag.MaDonHang = new SelectList(db.DONHANGs, "MaDonHang", "TrangThai");
            ViewBag.MaHang = new SelectList(db.HANGHOAs, "MaHang", "TenHang");
            return View();
        }

        // POST: Admin/DONHANGCTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChiTiet,MaDonHang,MaHang,SoLuong,GiaBan")] DONHANGCT dONHANGCT)
        {
            if (ModelState.IsValid)
            {
                db.DONHANGCTs.Add(dONHANGCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDonHang = new SelectList(db.DONHANGs, "MaDonHang", "TrangThai", dONHANGCT.MaDonHang);
            ViewBag.MaHang = new SelectList(db.HANGHOAs, "MaHang", "TenHang", dONHANGCT.MaHang);
            return View(dONHANGCT);
        }

        // GET: Admin/DONHANGCTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANGCT dONHANGCT = db.DONHANGCTs.Find(id);
            if (dONHANGCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDonHang = new SelectList(db.DONHANGs, "MaDonHang", "TrangThai", dONHANGCT.MaDonHang);
            ViewBag.MaHang = new SelectList(db.HANGHOAs, "MaHang", "TenHang", dONHANGCT.MaHang);
            return View(dONHANGCT);
        }

        // POST: Admin/DONHANGCTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChiTiet,MaDonHang,MaHang,SoLuong,GiaBan")] DONHANGCT dONHANGCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONHANGCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDonHang = new SelectList(db.DONHANGs, "MaDonHang", "TrangThai", dONHANGCT.MaDonHang);
            ViewBag.MaHang = new SelectList(db.HANGHOAs, "MaHang", "TenHang", dONHANGCT.MaHang);
            return View(dONHANGCT);
        }

        // GET: Admin/DONHANGCTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANGCT dONHANGCT = db.DONHANGCTs.Find(id);
            if (dONHANGCT == null)
            {
                return HttpNotFound();
            }
            return View(dONHANGCT);
        }

        // POST: Admin/DONHANGCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONHANGCT dONHANGCT = db.DONHANGCTs.Find(id);
            db.DONHANGCTs.Remove(dONHANGCT);
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
