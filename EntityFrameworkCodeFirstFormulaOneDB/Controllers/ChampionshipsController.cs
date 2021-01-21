using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkCodeFirstFormulaOneDB.DBContext;
using EntityFrameworkCodeFirstFormulaOneDB.Models;

namespace EntityFrameworkCodeFirstFormulaOneDB.Controllers
{
    public class ChampionshipsController : Controller
    {
        private FormulaOneDBContext db = new FormulaOneDBContext();

        // GET: Championships
        public ActionResult Index()
        {
            return View(db.Championships.ToList());
        }

        // GET: Championships/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Championship championship = db.Championships.Find(id);
            if (championship == null)
            {
                return HttpNotFound();
            }
            return View(championship);
        }

        // GET: Championships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Championships/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChampionshipId,Year,RacingSeries,Title")] Championship championship)
        {
            if (ModelState.IsValid)
            {
                db.Championships.Add(championship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(championship);
        }

        // GET: Championships/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Championship championship = db.Championships.Find(id);
            if (championship == null)
            {
                return HttpNotFound();
            }
            return View(championship);
        }

        // POST: Championships/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChampionshipId,Year,RacingSeries,Title")] Championship championship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(championship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(championship);
        }

        // GET: Championships/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Championship championship = db.Championships.Find(id);
            if (championship == null)
            {
                return HttpNotFound();
            }
            return View(championship);
        }

        // POST: Championships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Championship championship = db.Championships.Find(id);
            db.Championships.Remove(championship);
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
