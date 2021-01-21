using EntityFrameworkCodeFirstFormulaOneDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkCodeFirstFormulaOneDB.DataAccess
{
    public class ChampionshipDataAccess : BaseDataAccess
    {
        public IEnumerable<Championship> GetAllChampionships()
        {
            return db.Championships.ToList();            
        }
    }
}