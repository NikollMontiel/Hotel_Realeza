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
    public class Factura_O_BoletaController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Factura_O_Boleta
        public ActionResult Index()
        {
            var factura_O_Boleta = db.Factura_O_Boleta.Include(f => f.Clientes);
            return View(factura_O_Boleta.ToList());
        }

        // GET: Factura_O_Boleta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura_O_Boleta factura_O_Boleta = db.Factura_O_Boleta.Find(id);
            if (factura_O_Boleta == null)
            {
                return HttpNotFound();
            }
            return View(factura_O_Boleta);
        }

        // GET: Factura_O_Boleta/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC");
            return View();
        }

        // POST: Factura_O_Boleta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Fac,RUT,ID_Cliente,Total_Pago")] Factura_O_Boleta factura_O_Boleta)
        {
            if (ModelState.IsValid)
            {
                db.Factura_O_Boleta.Add(factura_O_Boleta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", factura_O_Boleta.ID_Cliente);
            return View(factura_O_Boleta);
        }

        // GET: Factura_O_Boleta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura_O_Boleta factura_O_Boleta = db.Factura_O_Boleta.Find(id);
            if (factura_O_Boleta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", factura_O_Boleta.ID_Cliente);
            return View(factura_O_Boleta);
        }

        // POST: Factura_O_Boleta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Fac,RUT,ID_Cliente,Total_Pago")] Factura_O_Boleta factura_O_Boleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura_O_Boleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", factura_O_Boleta.ID_Cliente);
            return View(factura_O_Boleta);
        }

        // GET: Factura_O_Boleta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura_O_Boleta factura_O_Boleta = db.Factura_O_Boleta.Find(id);
            if (factura_O_Boleta == null)
            {
                return HttpNotFound();
            }
            return View(factura_O_Boleta);
        }

        // POST: Factura_O_Boleta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura_O_Boleta factura_O_Boleta = db.Factura_O_Boleta.Find(id);
            db.Factura_O_Boleta.Remove(factura_O_Boleta);
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
