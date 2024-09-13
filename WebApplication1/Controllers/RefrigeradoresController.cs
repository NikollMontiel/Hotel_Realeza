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
    public class RefrigeradoresController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Refrigeradores
        public ActionResult Index()
        {
            var refrigeradores = db.Refrigeradores.Include(r => r.Habitaciones);
            return View(refrigeradores.ToList());
        }

        // GET: Refrigeradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigeradores refrigeradores = db.Refrigeradores.Find(id);
            if (refrigeradores == null)
            {
                return HttpNotFound();
            }
            return View(refrigeradores);
        }

        // GET: Refrigeradores/Create
        public ActionResult Create()
        {
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab");
            return View();
        }

        // POST: Refrigeradores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Refrigerador,Marca,ID_Hab,EstadoR")] Refrigeradores refrigeradores)
        {
            if (ModelState.IsValid)
            {
                db.Refrigeradores.Add(refrigeradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", refrigeradores.ID_Hab);
            return View(refrigeradores);
        }

        // GET: Refrigeradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigeradores refrigeradores = db.Refrigeradores.Find(id);
            if (refrigeradores == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", refrigeradores.ID_Hab);
            return View(refrigeradores);
        }

        // POST: Refrigeradores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Refrigerador,Marca,ID_Hab,EstadoR")] Refrigeradores refrigeradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refrigeradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", refrigeradores.ID_Hab);
            return View(refrigeradores);
        }

        // GET: Refrigeradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigeradores refrigeradores = db.Refrigeradores.Find(id);
            if (refrigeradores == null)
            {
                return HttpNotFound();
            }
            return View(refrigeradores);
        }

        // POST: Refrigeradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Refrigeradores refrigeradores = db.Refrigeradores.Find(id);
            db.Refrigeradores.Remove(refrigeradores);
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
