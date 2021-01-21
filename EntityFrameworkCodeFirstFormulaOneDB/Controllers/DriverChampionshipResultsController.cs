using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkCodeFirstFormulaOneDB.DataAccess;
using EntityFrameworkCodeFirstFormulaOneDB.DBContext;
using EntityFrameworkCodeFirstFormulaOneDB.Models;

namespace EntityFrameworkCodeFirstFormulaOneDB.Controllers
{
    public class DriverChampionshipResultsController : Controller
    {
        DriverChampionshipResultDataAccess DCRDataAccess = new DriverChampionshipResultDataAccess();
        DriverDataAccess DDataAccess = new DriverDataAccess();
        ChampionshipDataAccess CDataAccess = new ChampionshipDataAccess();        

        // GET: DriverChampionshipResults
        public ActionResult Index()
        {
            var driverChampionshipResults = DCRDataAccess.GetAllDCRs();
            return View(driverChampionshipResults.ToList());
        }

        // GET: DriverChampionshipResults/Details/5
        public ActionResult Details(long? driverId, long? championshipId)
        {
            if (driverId == null || championshipId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DriverChampionshipResult driverChampionshipResult = DCRDataAccess.GetDCRByPKs(driverId.Value, championshipId.Value);
            
            if (driverChampionshipResult == null)
            {
                return HttpNotFound();
            }
            
            return View(driverChampionshipResult);
        }

        // GET: DriverChampionshipResults/Create
        public ActionResult Create()
        {        
            ViewBag.ChampionshipId = new SelectList(CDataAccess.GetAllChampionships(), "ChampionshipId", "Title");
            ViewBag.DriverId = new SelectList(DDataAccess.GetDriversIdsAndFullNames(), "DriverId", "FullName");  
            
            return View();
        }

        // POST: DriverChampionshipResults/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverId,ChampionshipId,Place,Points,Wins,Team")] DriverChampionshipResult driverChampionshipResult)
        {
            if (ModelState.IsValid)
            {                
                if (DCRDataAccess.Exist(driverChampionshipResult.DriverId, driverChampionshipResult.ChampionshipId))
                {
                    Response.Write("<script>alert('Такая запись уже есть в БД')</script>");                    
                }
                else
                {
                    DCRDataAccess.Insert(driverChampionshipResult);
                    return RedirectToAction("Index");
                }                
            }

            ViewBag.ChampionshipId = new SelectList(CDataAccess.GetAllChampionships(), "ChampionshipId", "Title", driverChampionshipResult.ChampionshipId);
            ViewBag.DriverId = new SelectList(DDataAccess.GetAllDrivers(), "DriverId", "FirstName", driverChampionshipResult.DriverId);
            
            return View(driverChampionshipResult);
        }

        // GET: DriverChampionshipResults/Edit/5
        public ActionResult Edit(long? driverId, long? championshipId)
        {
            if (driverId == null || championshipId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DriverChampionshipResult driverChampionshipResult = DCRDataAccess.GetDCRByPKs(driverId.Value, championshipId.Value);
            
            if (driverChampionshipResult == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.ChampionshipId = new SelectList(CDataAccess.GetAllChampionships(), "ChampionshipId", "Title", driverChampionshipResult.ChampionshipId);
            ViewBag.DriverId = new SelectList(DDataAccess.GetAllDrivers(), "DriverId", "FirstName", driverChampionshipResult.DriverId);
            
            return View(driverChampionshipResult);
        }

        // POST: DriverChampionshipResults/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverId,ChampionshipId,Place,Points,Wins,Team")] DriverChampionshipResult driverChampionshipResult)
        {
            if (ModelState.IsValid)
            {
                DCRDataAccess.Update(driverChampionshipResult);
                return RedirectToAction("Index");
            }
            ViewBag.ChampionshipId = new SelectList(CDataAccess.GetAllChampionships(), "ChampionshipId", "Title", driverChampionshipResult.ChampionshipId);
            ViewBag.DriverId = new SelectList(DDataAccess.GetAllDrivers(), "DriverId", "FirstName", driverChampionshipResult.DriverId);
            return View(driverChampionshipResult);
        }

        // GET: DriverChampionshipResults/Delete/5
        public ActionResult Delete(long? driverId, long? championshipId)
        {
            if (driverId == null || championshipId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            DriverChampionshipResult driverChampionshipResult = DCRDataAccess.GetDCRByPKs(driverId.Value, championshipId.Value);
            
            if (driverChampionshipResult == null)
            {
                return HttpNotFound();
            }
            
            return View(driverChampionshipResult);
        }

        // POST: DriverChampionshipResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long driverId, long championshipId)
        {
            DCRDataAccess.Delete(driverId, championshipId);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {                
                DCRDataAccess.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
