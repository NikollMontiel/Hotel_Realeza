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
    public class Cuenta_ClienteController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Cuenta_Cliente
        public ActionResult Index()
        {
            var cuenta_Cliente = db.Cuenta_Cliente.Include(c => c.Clientes).Include(c => c.Habitaciones).Include(c => c.Reservaciones);
            return View(cuenta_Cliente.ToList());
        }

        // GET: Cuenta_Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta_Cliente cuenta_Cliente = db.Cuenta_Cliente.Find(id);
            if (cuenta_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(cuenta_Cliente);
        }

        // GET: Cuenta_Cliente/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC");
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab");
            ViewBag.ID_Reserva = new SelectList(db.Reservaciones, "ID_reserva", "ID_reserva");
            return View();
        }

        // POST: Cuenta_Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cuenta,ID_Cliente,ID_Hab,ID_Reserva,Forma_Pago,Total_llamadas,Total_Refrigerador,Total_estancia,Total_a_pagar")] Cuenta_Cliente cuenta_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cuenta_Cliente.Add(cuenta_Cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", cuenta_Cliente.ID_Cliente);
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", cuenta_Cliente.ID_Hab);
            ViewBag.ID_Reserva = new SelectList(db.Reservaciones, "ID_reserva", "ID_reserva", cuenta_Cliente.ID_Reserva);
            return View(cuenta_Cliente);
        }

        // GET: Cuenta_Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta_Cliente cuenta_Cliente = db.Cuenta_Cliente.Find(id);
            if (cuenta_Cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", cuenta_Cliente.ID_Cliente);
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", cuenta_Cliente.ID_Hab);
            ViewBag.ID_Reserva = new SelectList(db.Reservaciones, "ID_reserva", "ID_reserva", cuenta_Cliente.ID_Reserva);
            return View(cuenta_Cliente);
        }

        // POST: Cuenta_Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cuenta,ID_Cliente,ID_Hab,ID_Reserva,Forma_Pago,Total_llamadas,Total_Refrigerador,Total_estancia,Total_a_pagar")] Cuenta_Cliente cuenta_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuenta_Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", cuenta_Cliente.ID_Cliente);
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", cuenta_Cliente.ID_Hab);
            ViewBag.ID_Reserva = new SelectList(db.Reservaciones, "ID_reserva", "ID_reserva", cuenta_Cliente.ID_Reserva);
            return View(cuenta_Cliente);
        }

        // GET: Cuenta_Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta_Cliente cuenta_Cliente = db.Cuenta_Cliente.Find(id);
            if (cuenta_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(cuenta_Cliente);
        }

        // POST: Cuenta_Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuenta_Cliente cuenta_Cliente = db.Cuenta_Cliente.Find(id);
            db.Cuenta_Cliente.Remove(cuenta_Cliente);
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
