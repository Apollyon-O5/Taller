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
    public class TECNICOController : Controller
    {
        private TallerEntities db = new TallerEntities();

        // GET: TECNICO
        public ActionResult Index()
        {
            return View(db.TECNICO.ToList());
        }

        // GET: TECNICO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TECNICO tECNICO = db.TECNICO.Find(id);
            if (tECNICO == null)
            {
                return HttpNotFound();
            }
            return View(tECNICO);
        }

        // GET: TECNICO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TECNICO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtecnico,apellidos,nombres,dui,tel1,tel2,email")] TECNICO tECNICO)
        {
            if (ModelState.IsValid)
            {
                db.TECNICO.Add(tECNICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tECNICO);
        }

        // GET: TECNICO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TECNICO tECNICO = db.TECNICO.Find(id);
            if (tECNICO == null)
            {
                return HttpNotFound();
            }
            return View(tECNICO);
        }

        // POST: TECNICO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtecnico,apellidos,nombres,dui,tel1,tel2,email")] TECNICO tECNICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tECNICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tECNICO);
        }


        // GET: TECNICO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TECNICO tecnico = db.TECNICO.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: TECNICO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TECNICO tecnico = db.TECNICO.Find(id);

            try
            {
                db.TECNICO.Remove(tecnico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                ViewBag.ErrorMessage = "No se puede eliminar este técnico porque tiene servicios asociados.";
                return View(tecnico);
            }
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
