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
    public class Productos_baño_habController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Productos_baño_hab
        public ActionResult Index()
        {
            var productos_baño_hab = db.Productos_baño_hab.Include(p => p.Habitaciones).Include(p => p.Productos);
            return View(productos_baño_hab.ToList());
        }

        // GET: Productos_baño_hab/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_baño_hab productos_baño_hab = db.Productos_baño_hab.Find(id);
            if (productos_baño_hab == null)
            {
                return HttpNotFound();
            }
            return View(productos_baño_hab);
        }

        // GET: Productos_baño_hab/Create
        public ActionResult Create()
        {
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab");
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre");
            return View();
        }

        // POST: Productos_baño_hab/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cantidad,ID_Producto,ID_Hab")] Productos_baño_hab productos_baño_hab)
        {
            if (ModelState.IsValid)
            {
                db.Productos_baño_hab.Add(productos_baño_hab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", productos_baño_hab.ID_Hab);
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", productos_baño_hab.ID_Producto);
            return View(productos_baño_hab);
        }

        // GET: Productos_baño_hab/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_baño_hab productos_baño_hab = db.Productos_baño_hab.Find(id);
            if (productos_baño_hab == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", productos_baño_hab.ID_Hab);
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", productos_baño_hab.ID_Producto);
            return View(productos_baño_hab);
        }

        // POST: Productos_baño_hab/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cantidad,ID_Producto,ID_Hab")] Productos_baño_hab productos_baño_hab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos_baño_hab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", productos_baño_hab.ID_Hab);
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", productos_baño_hab.ID_Producto);
            return View(productos_baño_hab);
        }

        // GET: Productos_baño_hab/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_baño_hab productos_baño_hab = db.Productos_baño_hab.Find(id);
            if (productos_baño_hab == null)
            {
                return HttpNotFound();
            }
            return View(productos_baño_hab);
        }

        // POST: Productos_baño_hab/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos_baño_hab productos_baño_hab = db.Productos_baño_hab.Find(id);
            db.Productos_baño_hab.Remove(productos_baño_hab);
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
