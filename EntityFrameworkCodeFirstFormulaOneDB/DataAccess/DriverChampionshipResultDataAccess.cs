using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EntityFrameworkCodeFirstFormulaOneDB.Models;
using System.Linq.Expressions;

namespace EntityFrameworkCodeFirstFormulaOneDB.DataAccess
{
    public class DriverChampionshipResultDataAccess : BaseDataAccess
    {
        public IEnumerable<DriverChampionshipResult> GetAllDCRs()
        {
            return db.DriverChampionshipResults.Include(d => d.Championship).Include(d => d.Driver);
        }

        public DriverChampionshipResult GetDCRByPKs(long driverId, long championshipId)
        {
            return db.DriverChampionshipResults.Find(driverId, championshipId);
        }         
        
        public bool Exist(long driverId, long championshipId)
        {
            return db.DriverChampionshipResults.Any(x => x.DriverId == driverId && x.ChampionshipId == championshipId);
        }

        public void Insert(DriverChampionshipResult driverChampionshipResult)
        {
            if (driverChampionshipResult != null)
            {
                db.DriverChampionshipResults.Add(driverChampionshipResult);
                db.SaveChanges();
            }            
        }

        public void Delete(long driverId, long championshipId)
        {
            DriverChampionshipResult dcr = db.DriverChampionshipResults.Find(driverId, championshipId);

            if (dcr != null)
            {
                db.DriverChampionshipResults.Remove(dcr);
                db.SaveChanges();
            }            
        }

        public void Update(DriverChampionshipResult driverChampionshipResult)
        {
            if (driverChampionshipResult != null)
            {
                DriverChampionshipResult dcrToUpdate = db.DriverChampionshipResults
                    .Find(driverChampionshipResult.DriverId, driverChampionshipResult.ChampionshipId);

                if (dcrToUpdate != null)
                {                    
                    dcrToUpdate.Place = driverChampionshipResult.Place;
                    dcrToUpdate.Points = driverChampionshipResult.Points;
                    dcrToUpdate.Wins = driverChampionshipResult.Wins;
                    dcrToUpdate.Team = driverChampionshipResult.Team;

                    db.SaveChanges();
                }
            }
        }
    }
}