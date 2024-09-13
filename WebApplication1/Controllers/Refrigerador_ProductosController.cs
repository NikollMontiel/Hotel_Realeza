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
    public class Refrigerador_ProductosController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Refrigerador_Productos
        public ActionResult Index()
        {
            var refrigerador_Productos = db.Refrigerador_Productos.Include(r => r.Productos).Include(r => r.Refrigeradores);
            return View(refrigerador_Productos.ToList());
        }

        // GET: Refrigerador_Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerador_Productos refrigerador_Productos = db.Refrigerador_Productos.Find(id);
            if (refrigerador_Productos == null)
            {
                return HttpNotFound();
            }
            return View(refrigerador_Productos);
        }

        // GET: Refrigerador_Productos/Create
        public ActionResult Create()
        {
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre");
            ViewBag.ID_Refrigerador = new SelectList(db.Refrigeradores, "ID_Refrigerador", "Marca");
            return View();
        }

        // POST: Refrigerador_Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cantidad,ID_Refrigerador,ID_Producto")] Refrigerador_Productos refrigerador_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Refrigerador_Productos.Add(refrigerador_Productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", refrigerador_Productos.ID_Producto);
            ViewBag.ID_Refrigerador = new SelectList(db.Refrigeradores, "ID_Refrigerador", "Marca", refrigerador_Productos.ID_Refrigerador);
            return View(refrigerador_Productos);
        }

        // GET: Refrigerador_Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerador_Productos refrigerador_Productos = db.Refrigerador_Productos.Find(id);
            if (refrigerador_Productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", refrigerador_Productos.ID_Producto);
            ViewBag.ID_Refrigerador = new SelectList(db.Refrigeradores, "ID_Refrigerador", "Marca", refrigerador_Productos.ID_Refrigerador);
            return View(refrigerador_Productos);
        }

        // POST: Refrigerador_Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cantidad,ID_Refrigerador,ID_Producto")] Refrigerador_Productos refrigerador_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refrigerador_Productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", refrigerador_Productos.ID_Producto);
            ViewBag.ID_Refrigerador = new SelectList(db.Refrigeradores, "ID_Refrigerador", "Marca", refrigerador_Productos.ID_Refrigerador);
            return View(refrigerador_Productos);
        }

        // GET: Refrigerador_Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerador_Productos refrigerador_Productos = db.Refrigerador_Productos.Find(id);
            if (refrigerador_Productos == null)
            {
                return HttpNotFound();
            }
            return View(refrigerador_Productos);
        }

        // POST: Refrigerador_Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Refrigerador_Productos refrigerador_Productos = db.Refrigerador_Productos.Find(id);
            db.Refrigerador_Productos.Remove(refrigerador_Productos);
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
