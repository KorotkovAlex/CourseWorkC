using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication5.Models;
using System.IO;

namespace MvcApplication5.Controllers
{
    public class WorkerController : Controller
    {
        private flowofdocumentEntities1 db = new flowofdocumentEntities1();

        public ViewResult Index(string search)
        {
            var document = db.Document.Include(d => d.Employee).Include(d => d.Employee1);
            if (!String.IsNullOrEmpty(search))
            {
                document = document.Where(s => s.nameDoc.Contains(search));
            }
            
            return View(document.ToList());
        }

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
            ViewBag.author = new SelectList(db.Employee, "login", "name");
            ViewBag.signer = new SelectList(db.Employee, "login", "name");
            return View();
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
            ViewBag.author = new SelectList(db.Employee, "login", "name", document.author);
            ViewBag.signer = new SelectList(db.Employee, "login", "name", document.signer);
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
            ViewBag.author = new SelectList(db.Employee, "login", "name", document.author);
            ViewBag.signer = new SelectList(db.Employee, "login", "name", document.signer);
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

        [Authorize(Roles = "author")]
        public ActionResult MarkingA()
        {
            var document = db.Document.Include(d => d.Employee).Include(d => d.Employee1);
            return View(document.ToList());
        }

        [Authorize(Roles = "signer")]
        public ActionResult Marking()
        {
            var document = db.Document.Include(d => d.Employee).Include(d => d.Employee1);
            return View(document.ToList());
        }

        [HttpPost]
        public FileResult Download(string name)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\Саня\Documents\Visual Studio 2013\Projects\MvcApplication5\MvcApplication5\App_Data\uploads\" + name);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Document document, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
                document.nameDoc = fileName;
                db.Document.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.author = new SelectList(db.Employee, "login", "name", document.author);
            ViewBag.signer = new SelectList(db.Employee, "login", "name", document.signer);
            return View(document);
        }
    }
}