using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using naRatunek.Data;
using naRatunek.Models.Pharmacy;

namespace naRatunek.Controllers
{
    public class PharmaciesController : Controller
    {
        private naRatunekContext db = new naRatunekContext();

        // GET: Pharmacies
        public async Task<ActionResult> Index(string city = "")
        {

            return View(await db.Pharmacies.Where(x => x.City.ToUpper().Contains(city.ToUpper())).ToListAsync());

        }

        // GET: Pharmacies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy pharmacy = await db.Pharmacies.FindAsync(id);
            if (pharmacy == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy);
        }

        // GET: Pharmacies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pharmacies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PharmacyId,PharmacyName,PharmacyType,City,PostalCode,Street,StreetNumber,FlatNumber")] Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                db.Pharmacies.Add(pharmacy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pharmacy);
        }

        // GET: Pharmacies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy pharmacy = await db.Pharmacies.FindAsync(id);
            if (pharmacy == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy);
        }

        // POST: Pharmacies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PharmacyId,PharmacyName,PharmacyType,City,PostalCode,Street,StreetNumber,FlatNumber")] Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pharmacy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pharmacy);
        }

        // GET: Pharmacies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pharmacy pharmacy = await db.Pharmacies.FindAsync(id);
            if (pharmacy == null)
            {
                return HttpNotFound();
            }
            return View(pharmacy);
        }

        // POST: Pharmacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pharmacy pharmacy = await db.Pharmacies.FindAsync(id);
            db.Pharmacies.Remove(pharmacy);
            await db.SaveChangesAsync();
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
