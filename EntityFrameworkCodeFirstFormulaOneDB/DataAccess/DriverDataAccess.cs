using EntityFrameworkCodeFirstFormulaOneDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkCodeFirstFormulaOneDB.DataAccess
{
    public class DriverDataAccess : BaseDataAccess
    {
        public IEnumerable<Driver> GetAllDrivers()
        {
            return db.Drivers.ToList();
        }

        public IEnumerable<dynamic> GetDriversIdsAndFullNames()
        {
            return
                db.Drivers
                .Select(x => new {
                    DriverId = x.DriverId,
                    FullName = x.FirstName + " " + x.LastName
                })
                .AsEnumerable().ToList();
        }
    }
}