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
    public class DonationDetailController : Controller
    {
        private BloodContext db = new BloodContext();

        // GET: /DonationDetail/
        public ViewResult Index()
        {
            var donationdetails = db.DonationDetails.Include(d => d.BloodBank).Include(d => d.Donor);
            return View(donationdetails.ToList());
        }

        // GET: /DonationDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationDetail donationdetail = db.DonationDetails.Find(id);
            if (donationdetail == null)
            {
                return HttpNotFound();
            }
            return View(donationdetail);
        }

        // GET: /DonationDetail/Create
        public ActionResult Create()
        {
            ViewBag.BloodBankID = new SelectList(db.BloodBanks, "BloodBankID", "Name");
            ViewBag.DonorID = new SelectList(db.Donors, "ID", "Name");
            return View();
        }

        // POST: /DonationDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DonationDetailID,DonorID,BloodBankID,Date,Amount")] DonationDetail donationdetail)
        {
            if (ModelState.IsValid)
            {
                db.DonationDetails.Add(donationdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodBankID = new SelectList(db.BloodBanks, "BloodBankID", "Name", donationdetail.BloodBankID);
            ViewBag.DonorID = new SelectList(db.Donors, "ID", "Name", donationdetail.DonorID);
            return View(donationdetail);
        }

        // GET: /DonationDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationDetail donationdetail = db.DonationDetails.Find(id);
            if (donationdetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodBankID = new SelectList(db.BloodBanks, "BloodBankID", "Name", donationdetail.BloodBankID);
            ViewBag.DonorID = new SelectList(db.Donors, "ID", "Name", donationdetail.DonorID);
            return View(donationdetail);
        }

        // POST: /DonationDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DonationDetailID,DonorID,BloodBankID,Date,Amount")] DonationDetail donationdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodBankID = new SelectList(db.BloodBanks, "BloodBankID", "Name", donationdetail.BloodBankID);
            ViewBag.DonorID = new SelectList(db.Donors, "ID", "Name", donationdetail.DonorID);
            return View(donationdetail);
        }

        // GET: /DonationDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationDetail donationdetail = db.DonationDetails.Find(id);
            if (donationdetail == null)
            {
                return HttpNotFound();
            }
            return View(donationdetail);
        }

        // POST: /DonationDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonationDetail donationdetail = db.DonationDetails.Find(id);
            db.DonationDetails.Remove(donationdetail);
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
