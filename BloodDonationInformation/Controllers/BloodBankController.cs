using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloodDonationInformation.Models;
using BloodDonationInformation.DAL;

namespace BloodDonationInformation.Controllers
{
    public class BloodBankController : Controller
    {
        private BloodContext db = new BloodContext();

        // GET: /BloodBank/
        public ViewResult Index()
        {
            return View(db.BloodBanks.ToList());
        }

        // GET: /BloodBank/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodBank bloodbank = db.BloodBanks.Find(id);
            if (bloodbank == null)
            {
                return HttpNotFound();
            }
            return View(bloodbank);
        }

        // GET: /BloodBank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BloodBank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BloodBankID,Name,Address,Contact")] BloodBank bloodbank)
        {
            if (ModelState.IsValid)
            {
                db.BloodBanks.Add(bloodbank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodbank);
        }

        // GET: /BloodBank/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodBank bloodbank = db.BloodBanks.Find(id);
            if (bloodbank == null)
            {
                return HttpNotFound();
            }
            return View(bloodbank);
        }

        // POST: /BloodBank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BloodBankID,Name,Address,Contact")] BloodBank bloodbank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodbank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodbank);
        }

        // GET: /BloodBank/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodBank bloodbank = db.BloodBanks.Find(id);
            if (bloodbank == null)
            {
                return HttpNotFound();
            }
            return View(bloodbank);
        }

        // POST: /BloodBank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodBank bloodbank = db.BloodBanks.Find(id);
            db.BloodBanks.Remove(bloodbank);
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
