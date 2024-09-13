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
    public class ReservacionesController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Reservaciones
        
        public ActionResult Index()
        {
            var reservaciones = db.Reservaciones.Include(r => r.Clientes).Include(r => r.Forma_Pago).Include(r => r.Habitaciones);
            return View(reservaciones.ToList());
        }

        // GET: Reservaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            return View(reservaciones);
        }

        // GET: Reservaciones/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC");
            ViewBag.ID_FPago = new SelectList(db.Forma_Pago, "ID_FPago", "Forma_Pago1");
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab");
            return View();
        }

        // POST: Reservaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_reserva,fecha_reserva,ID_Hab,ID_Cliente,tiempo_instancia,Estado_salida,ID_FPago")] Reservaciones reservaciones)
        {
            if (ModelState.IsValid)
            {
                db.Reservaciones.Add(reservaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", reservaciones.ID_Cliente);
            ViewBag.ID_FPago = new SelectList(db.Forma_Pago, "ID_FPago", "Forma_Pago1", reservaciones.ID_FPago);
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", reservaciones.ID_Hab);
            return View(reservaciones);
        }

        // GET: Reservaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", reservaciones.ID_Cliente);
            ViewBag.ID_FPago = new SelectList(db.Forma_Pago, "ID_FPago", "Forma_Pago1", reservaciones.ID_FPago);
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", reservaciones.ID_Hab);
            return View(reservaciones);
        }

        // POST: Reservaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_reserva,fecha_reserva,ID_Hab,ID_Cliente,tiempo_instancia,Estado_salida,ID_FPago")] Reservaciones reservaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Clientes, "ID_Cliente", "PNC", reservaciones.ID_Cliente);
            ViewBag.ID_FPago = new SelectList(db.Forma_Pago, "ID_FPago", "Forma_Pago1", reservaciones.ID_FPago);
            ViewBag.ID_Hab = new SelectList(db.Habitaciones, "ID_Hab", "ID_Hab", reservaciones.ID_Hab);
            return View(reservaciones);
        }

        // GET: Reservaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            return View(reservaciones);
        }

        // POST: Reservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            db.Reservaciones.Remove(reservaciones);
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
