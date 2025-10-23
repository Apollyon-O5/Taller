using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Taller;

namespace Taller.Controllers
{
    public class USUARIOSController : Controller
    {
        private TallerEntities db = new TallerEntities();

        // =============================
        // LOGIN / LOGOUT
        // =============================

        // GET: USUARIOS/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: USUARIOS/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string usuario, string clave)
        {
            var user = db.USUARIOS.FirstOrDefault(u => u.Usuario == usuario && u.Clave == clave);
            if (user != null)
            {
                Session["Usuario"] = user.Usuario;
                return RedirectToAction("Index", "USUARIOS");
            }

            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        // GET: USUARIOS/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        // =============================
        // CRUD
        // =============================

        // GET: USUARIOS
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login");

            return View(db.USUARIOS.ToList());
        }

        // GET: USUARIOS/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login");

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
                return HttpNotFound();

            return View(uSUARIOS);
        }

        // GET: USUARIOS/Create
        public ActionResult Create()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login");

            return View();
        }

        // POST: USUARIOS/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,Usuario,Clave")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.USUARIOS.Add(uSUARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login");

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
                return HttpNotFound();

            return View(uSUARIOS);
        }

        // POST: USUARIOS/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,Usuario,Clave")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Login");

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
                return HttpNotFound();

            return View(uSUARIOS);
        }

        // POST: USUARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            db.USUARIOS.Remove(uSUARIOS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // =============================
        // DISPOSE
        // =============================
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
