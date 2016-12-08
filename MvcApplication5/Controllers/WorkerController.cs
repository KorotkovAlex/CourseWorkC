using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication5.Models;

namespace MvcApplication5.Controllers
{
    public class WorkerController : Controller
    {
        private flowofdocumentEntities db = new flowofdocumentEntities();

        //
        // GET: /Worker/

        public ActionResult Index()
        {
            var document = db.Document.Include(d => d.Employee).Include(d => d.Employee1);
            return View(document.ToList());
        }

        //
        // GET: /Worker/Details/5

        public ActionResult Details(int id = 0)
        {
            Document document = db.Document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        //
        // GET: /Worker/Create

        public ActionResult Create()
        {
            ViewBag.author = new SelectList(db.Employee, "idEmployee", "name");
            ViewBag.signer = new SelectList(db.Employee, "idEmployee", "name");
            return View();
        }

        //
        // POST: /Worker/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Document document)
        {
            if (ModelState.IsValid)
            {
                db.Document.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.author = new SelectList(db.Employee, "idEmployee", "name", document.author);
            ViewBag.signer = new SelectList(db.Employee, "idEmployee", "name", document.signer);
            return View(document);
        }

        //
        // GET: /Worker/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Document document = db.Document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.author = new SelectList(db.Employee, "idEmployee", "name", document.author);
            ViewBag.signer = new SelectList(db.Employee, "idEmployee", "name", document.signer);
            return View(document);
        }

        //
        // POST: /Worker/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.author = new SelectList(db.Employee, "idEmployee", "name", document.author);
            ViewBag.signer = new SelectList(db.Employee, "idEmployee", "name", document.signer);
            return View(document);
        }

        //
        // GET: /Worker/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Document document = db.Document.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        //
        // POST: /Worker/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Document.Find(id);
            db.Document.Remove(document);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}