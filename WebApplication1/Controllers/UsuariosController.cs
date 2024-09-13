using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsuariosController : Controller
    {
        private Hotel_Peor_Es_NadaEntities1 db = new Hotel_Peor_Es_NadaEntities1();

        // GET: Usuarios
        public ActionResult Index()
        {
            ViewBag.Mensaje = "";
            var usuarios = db.Usuarios.Include(u => u.Roles);
            return View(usuarios.ToList());
        }

        [HttpGet]
        public ActionResult Login()
        {
            //var usuarios = db.Usuarios.Include(u => u.Roles);
            return View();
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.ID_Rol = new SelectList(db.Roles, "ID_Rol", "Rol");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Login(Usuarios usuarios)
        {
            ViewBag.Mensaje = "";
            var result =db.Usuarios.Where(p => p.Nombre_Usuario.Equals(usuarios.Nombre_Usuario) && p.Contraseña.Equals(usuarios.Contraseña));
            if (result.Count() > 0)
            {
                var usr1 = new Usuarios();
                usr1 = result.FirstOrDefault();
                return RedirectToAction("Index","Home", usr1);
            }

            var result0 = db.Usuarios.Where(p => p.Nombre_Usuario.Equals(usuarios.Nombre_Usuario));
            if (result0.Count() == 0) {
                ViewBag.Mensaje = "El usuario no existe";
                return View(); }
            var usr = new Usuarios();
            usr = result0.FirstOrDefault();
            using (var db1 = new Hotel_Peor_Es_NadaEntities1())
            {
                var result1 = db1.Usuarios.FirstOrDefault(b => b.Nombre_Usuario == usr.Nombre_Usuario);
                if (result1 != null)
                {
                    result1.intentos = result1.intentos == null ? result1.intentos = 1 : result1.intentos = result1.intentos + 1;
                    if (result1.intentos >= 3)
                    {
                        result1.Estado = true;
                        ViewBag.Mensaje = "El usuario ha sido bloqueado, contactece con el administrador";
                        ViewBag.Bloqueado = true;
                        //db1.SaveChanges();
                        return View("Login");

                    }
                    else
                    {
                        ViewBag.Bloqueado = false;
                    }
                    db1.SaveChanges();
                }
            }
            
            ViewBag.Mensaje = "El usuario o la contraseña son incorrectos";
            return View("Login");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_U,Nombre_Usuario,Contraseña,ID_Rol")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Rol = new SelectList(db.Roles, "ID_Rol", "Rol", usuarios.ID_Rol);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Rol = new SelectList(db.Roles, "ID_Rol", "Rol", usuarios.ID_Rol);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_U,Nombre_Usuario,Contraseña,ID_Rol")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Rol = new SelectList(db.Roles, "ID_Rol", "Rol", usuarios.ID_Rol);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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
