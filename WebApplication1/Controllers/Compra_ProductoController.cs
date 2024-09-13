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
    public class Compra_ProductoController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Compra_Producto
        public ActionResult Index()
        {
            var compra_Producto = db.Compra_Producto.Include(c => c.Proveedor).Include(c => c.Productos);
            return View(compra_Producto.ToList());
        }

        // GET: Compra_Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra_Producto compra_Producto = db.Compra_Producto.Find(id);
            if (compra_Producto == null)
            {
                return HttpNotFound();
            }
            return View(compra_Producto);
        }

        // GET: Compra_Producto/Create
        public ActionResult Create()
        {
            ViewBag.ID_Prov = new SelectList(db.Proveedor, "ID_Prov", "PNP");
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre");
            return View();
        }

        // POST: Compra_Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Compra,ID_Prov,ID_Producto,Cantidad,Fecha_Compra,Total_pago")] Compra_Producto compra_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Compra_Producto.Add(compra_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Prov = new SelectList(db.Proveedor, "ID_Prov", "PNP", compra_Producto.ID_Prov);
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", compra_Producto.ID_Producto);
            return View(compra_Producto);
        }

        // GET: Compra_Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra_Producto compra_Producto = db.Compra_Producto.Find(id);
            if (compra_Producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Prov = new SelectList(db.Proveedor, "ID_Prov", "PNP", compra_Producto.ID_Prov);
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", compra_Producto.ID_Producto);
            return View(compra_Producto);
        }

        // POST: Compra_Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Compra,ID_Prov,ID_Producto,Cantidad,Fecha_Compra,Total_pago")] Compra_Producto compra_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Prov = new SelectList(db.Proveedor, "ID_Prov", "PNP", compra_Producto.ID_Prov);
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", compra_Producto.ID_Producto);
            return View(compra_Producto);
        }

        // GET: Compra_Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra_Producto compra_Producto = db.Compra_Producto.Find(id);
            if (compra_Producto == null)
            {
                return HttpNotFound();
            }
            return View(compra_Producto);
        }

        // POST: Compra_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra_Producto compra_Producto = db.Compra_Producto.Find(id);
            db.Compra_Producto.Remove(compra_Producto);
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
