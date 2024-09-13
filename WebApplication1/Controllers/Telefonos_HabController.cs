using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Telefonos_HabController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Telefonos_Hab
        public ActionResult Index()
        {
            var telefonos_Hab = db.Telefonos_Hab.Include(t => t.Habitaciones);
            return View(telefonos_Hab.ToList());
        }

        // GET: Telefonos_Hab/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos_Hab telefonos_Hab = db.Telefonos_Hab.Find(id);
            if (telefonos_Hab == null)
            {
                return HttpNotFound();
            }
            return View(telefonos_Hab);
        }

        // GET: Telefonos_Hab/Create
        public ActionResult Create()
        {
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab");
            return View();
        }

        // POST: Telefonos_Hab/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Tel,ID_Hab")] Telefonos_Hab telefonos_Hab)
        {
            if (ModelState.IsValid)
            {
                db.Telefonos_Hab.Add(telefonos_Hab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", telefonos_Hab.ID_Hab);
            return View(telefonos_Hab);
        }

        // GET: Telefonos_Hab/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos_Hab telefonos_Hab = db.Telefonos_Hab.Find(id);
            if (telefonos_Hab == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", telefonos_Hab.ID_Hab);
            return View(telefonos_Hab);
        }

        // POST: Telefonos_Hab/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Tel,ID_Hab")] Telefonos_Hab telefonos_Hab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefonos_Hab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", telefonos_Hab.ID_Hab);
            return View(telefonos_Hab);
        }

        // GET: Telefonos_Hab/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos_Hab telefonos_Hab = db.Telefonos_Hab.Find(id);
            if (telefonos_Hab == null)
            {
                return HttpNotFound();
            }
            return View(telefonos_Hab);
        }

        // POST: Telefonos_Hab/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefonos_Hab telefonos_Hab = db.Telefonos_Hab.Find(id);
            db.Telefonos_Hab.Remove(telefonos_Hab);
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
