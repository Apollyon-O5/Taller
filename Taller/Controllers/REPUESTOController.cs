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
    public class REPUESTOController : Controller
    {
        private TallerEntities db = new TallerEntities();

        // GET: REPUESTO
        public ActionResult Index()
        {
            var rEPUESTO = db.REPUESTO.Include(r => r.PROVEEDOR);
            return View(rEPUESTO.ToList());
        }

        // GET: REPUESTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPUESTO rEPUESTO = db.REPUESTO.Find(id);
            if (rEPUESTO == null)
            {
                return HttpNotFound();
            }
            return View(rEPUESTO);
        }

        // GET: REPUESTO/Create
        public ActionResult Create()
        {
            ViewBag.idproveedor = new SelectList(db.PROVEEDOR, "idproveedor", "nombre");
            return View();
        }

        // POST: REPUESTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idrepuesto,nombre,descripcion,marca,precio_u,estado,idproveedor")] REPUESTO rEPUESTO)
        {
            if (ModelState.IsValid)
            {
                db.REPUESTO.Add(rEPUESTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idproveedor = new SelectList(db.PROVEEDOR, "idproveedor", "nombre", rEPUESTO.idproveedor);
            return View(rEPUESTO);
        }

        // GET: REPUESTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPUESTO rEPUESTO = db.REPUESTO.Find(id);
            if (rEPUESTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.idproveedor = new SelectList(db.PROVEEDOR, "idproveedor", "nombre", rEPUESTO.idproveedor);
            return View(rEPUESTO);
        }

        // POST: REPUESTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idrepuesto,nombre,descripcion,marca,precio_u,estado,idproveedor")] REPUESTO rEPUESTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEPUESTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idproveedor = new SelectList(db.PROVEEDOR, "idproveedor", "nombre", rEPUESTO.idproveedor);
            return View(rEPUESTO);
        }

        // GET: REPUESTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPUESTO rEPUESTO = db.REPUESTO.Find(id);
            if (rEPUESTO == null)
            {
                return HttpNotFound();
            }
            return View(rEPUESTO);
        }

        // POST: REPUESTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REPUESTO rEPUESTO = db.REPUESTO.Find(id);
            db.REPUESTO.Remove(rEPUESTO);
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
