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
    public class Devolucion_ProductoController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Devolucion_Producto
        public ActionResult Index()
        {
            var devolucion_Producto = db.Devolucion_Producto.Include(d => d.Productos).Include(d => d.Proveedor);
            return View(devolucion_Producto.ToList());
        }

        // GET: Devolucion_Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devolucion_Producto devolucion_Producto = db.Devolucion_Producto.Find(id);
            if (devolucion_Producto == null)
            {
                return HttpNotFound();
            }
            return View(devolucion_Producto);
        }

        // GET: Devolucion_Producto/Create
        public ActionResult Create()
        {
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre");
            ViewBag.ID_Prov = new SelectList(db.Proveedor, "ID_Prov", "PNP");
            return View();
        }

        // POST: Devolucion_Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Dev,ID_Producto,ID_Prov,Cantidad,Fecha_Dev,Motivo_Dev,Total_Dev")] Devolucion_Producto devolucion_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Devolucion_Producto.Add(devolucion_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", devolucion_Producto.ID_Producto);
            ViewBag.ID_Prov = new SelectList(db.Proveedor, "ID_Prov", "PNP", devolucion_Producto.ID_Prov);
            return View(devolucion_Producto);
        }

        // GET: Devolucion_Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devolucion_Producto devolucion_Producto = db.Devolucion_Producto.Find(id);
            if (devolucion_Producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", devolucion_Producto.ID_Producto);
            ViewBag.ID_Prov = new SelectList(db.Proveedor, "ID_Prov", "PNP", devolucion_Producto.ID_Prov);
            return View(devolucion_Producto);
        }

        // POST: Devolucion_Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Dev,ID_Producto,ID_Prov,Cantidad,Fecha_Dev,Motivo_Dev,Total_Dev")] Devolucion_Producto devolucion_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devolucion_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", devolucion_Producto.ID_Producto);
            ViewBag.ID_Prov = new SelectList(db.Proveedor, "ID_Prov", "PNP", devolucion_Producto.ID_Prov);
            return View(devolucion_Producto);
        }

        // GET: Devolucion_Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devolucion_Producto devolucion_Producto = db.Devolucion_Producto.Find(id);
            if (devolucion_Producto == null)
            {
                return HttpNotFound();
            }
            return View(devolucion_Producto);
        }

        // POST: Devolucion_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Devolucion_Producto devolucion_Producto = db.Devolucion_Producto.Find(id);
            db.Devolucion_Producto.Remove(devolucion_Producto);
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
