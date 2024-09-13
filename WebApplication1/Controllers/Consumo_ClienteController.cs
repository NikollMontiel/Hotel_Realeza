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
    public class Consumo_ClienteController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Consumo_Cliente
        public ActionResult Index()
        {
            var consumo_Cliente = db.Consumo_Cliente.Include(c => c.Clientes).Include(c => c.Habitaciones).Include(c => c.Productos).Include(c => c.Refrigeradores);
            return View(consumo_Cliente.ToList());
        }

        // GET: Consumo_Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumo_Cliente consumo_Cliente = db.Consumo_Cliente.Find(id);
            if (consumo_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(consumo_Cliente);
        }

        // GET: Consumo_Cliente/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC");
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab");
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre");
            ViewBag.ID_Refrigerador = new SelectList(db.Refrigeradores, "ID_Refrigerador", "Marca");
            return View();
        }

        // POST: Consumo_Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_consumo,ID_Cliente,ID_Refrigerador,ID_Hab,ID_Producto,Cantidad_Consumida,Total_pago,EstadoCC")] Consumo_Cliente consumo_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Consumo_Cliente.Add(consumo_Cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", consumo_Cliente.ID_Cliente);
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", consumo_Cliente.ID_Hab);
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", consumo_Cliente.ID_Producto);
            ViewBag.ID_Refrigerador = new SelectList(db.Refrigeradores, "ID_Refrigerador", "Marca", consumo_Cliente.ID_Refrigerador);
            return View(consumo_Cliente);
        }

        // GET: Consumo_Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumo_Cliente consumo_Cliente = db.Consumo_Cliente.Find(id);
            if (consumo_Cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", consumo_Cliente.ID_Cliente);
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", consumo_Cliente.ID_Hab);
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", consumo_Cliente.ID_Producto);
            ViewBag.ID_Refrigerador = new SelectList(db.Refrigeradores, "ID_Refrigerador", "Marca", consumo_Cliente.ID_Refrigerador);
            return View(consumo_Cliente);
        }

        // POST: Consumo_Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_consumo,ID_Cliente,ID_Refrigerador,ID_Hab,ID_Producto,Cantidad_Consumida,Total_pago,EstadoCC")] Consumo_Cliente consumo_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumo_Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", consumo_Cliente.ID_Cliente);
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", consumo_Cliente.ID_Hab);
            ViewBag.ID_Producto = new SelectList(db.Productos, "ID_Producto", "Nombre", consumo_Cliente.ID_Producto);
            ViewBag.ID_Refrigerador = new SelectList(db.Refrigeradores, "ID_Refrigerador", "Marca", consumo_Cliente.ID_Refrigerador);
            return View(consumo_Cliente);
        }

        // GET: Consumo_Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumo_Cliente consumo_Cliente = db.Consumo_Cliente.Find(id);
            if (consumo_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(consumo_Cliente);
        }

        // POST: Consumo_Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumo_Cliente consumo_Cliente = db.Consumo_Cliente.Find(id);
            db.Consumo_Cliente.Remove(consumo_Cliente);
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
