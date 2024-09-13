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
    public class Tipo_llamadaController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Tipo_llamada
        public ActionResult Index()
        {
            return View(db.Tipo_llamada.ToList());
        }

        // GET: Tipo_llamada/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_llamada tipo_llamada = db.Tipo_llamada.Find(id);
            if (tipo_llamada == null)
            {
                return HttpNotFound();
            }
            return View(tipo_llamada);
        }

        // GET: Tipo_llamada/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_llamada/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_tipo_llamada,Tipo_llamada1")] Tipo_llamada tipo_llamada)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_llamada.Add(tipo_llamada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_llamada);
        }

        // GET: Tipo_llamada/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_llamada tipo_llamada = db.Tipo_llamada.Find(id);
            if (tipo_llamada == null)
            {
                return HttpNotFound();
            }
            return View(tipo_llamada);
        }

        // POST: Tipo_llamada/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_tipo_llamada,Tipo_llamada1")] Tipo_llamada tipo_llamada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_llamada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_llamada);
        }

        // GET: Tipo_llamada/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_llamada tipo_llamada = db.Tipo_llamada.Find(id);
            if (tipo_llamada == null)
            {
                return HttpNotFound();
            }
            return View(tipo_llamada);
        }

        // POST: Tipo_llamada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_llamada tipo_llamada = db.Tipo_llamada.Find(id);
            db.Tipo_llamada.Remove(tipo_llamada);
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
