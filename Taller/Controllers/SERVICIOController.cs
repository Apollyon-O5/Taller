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
    public class SERVICIOController : Controller
    {
        private TallerEntities db = new TallerEntities();

        // GET: SERVICIO
        public ActionResult Index()
        {
            var sERVICIO = db.SERVICIO.Include(s => s.TECNICO);
            return View(sERVICIO.ToList());
        }

        // GET: SERVICIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // GET: SERVICIO/Create
        public ActionResult Create()
        {
            ViewBag.idtecnico = new SelectList(db.TECNICO, "idtecnico", "apellidos");
            return View();
        }

        // POST: SERVICIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idservicio,descripcion,precio,idtecnico")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.SERVICIO.Add(sERVICIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idtecnico = new SelectList(db.TECNICO, "idtecnico", "apellidos", sERVICIO.idtecnico);
            return View(sERVICIO);
        }

        // GET: SERVICIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.idtecnico = new SelectList(db.TECNICO, "idtecnico", "apellidos", sERVICIO.idtecnico);
            return View(sERVICIO);
        }

        // POST: SERVICIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idservicio,descripcion,precio,idtecnico")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sERVICIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idtecnico = new SelectList(db.TECNICO, "idtecnico", "apellidos", sERVICIO.idtecnico);
            return View(sERVICIO);
        }

        // GET: SERVICIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // POST: SERVICIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SERVICIO sERVICIO = db.SERVICIO.Find(id);
            db.SERVICIO.Remove(sERVICIO);
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
