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
    public class VEHICULOController : Controller
    {
        private TallerEntities db = new TallerEntities();

        // GET: VEHICULO
        public ActionResult Index()
        {
            var vEHICULO = db.VEHICULO.Include(v => v.CLIENTE);
            return View(vEHICULO.ToList());
        }

        // GET: VEHICULO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = db.VEHICULO.Find(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(vEHICULO);
        }

        // GET: VEHICULO/Create
        public ActionResult Create()
        {
            ViewBag.idcliente = new SelectList(db.CLIENTE, "idcliente", "apellidos");
            return View();
        }

        // POST: VEHICULO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idvehiculo,marca,modelo,año,color,idcliente")] VEHICULO vEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.VEHICULO.Add(vEHICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcliente = new SelectList(db.CLIENTE, "idcliente", "apellidos", vEHICULO.idcliente);
            return View(vEHICULO);
        }

        // GET: VEHICULO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = db.VEHICULO.Find(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcliente = new SelectList(db.CLIENTE, "idcliente", "apellidos", vEHICULO.idcliente);
            return View(vEHICULO);
        }

        // POST: VEHICULO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idvehiculo,marca,modelo,año,color,idcliente")] VEHICULO vEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vEHICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcliente = new SelectList(db.CLIENTE, "idcliente", "apellidos", vEHICULO.idcliente);
            return View(vEHICULO);
        }

        // GET: VEHICULO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = db.VEHICULO.Find(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(vEHICULO);
        }

        // POST: VEHICULO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VEHICULO vEHICULO = db.VEHICULO.Find(id);
            db.VEHICULO.Remove(vEHICULO);
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
