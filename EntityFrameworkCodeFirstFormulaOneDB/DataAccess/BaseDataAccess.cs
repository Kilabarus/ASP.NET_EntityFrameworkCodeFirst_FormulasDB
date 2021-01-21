using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntityFrameworkCodeFirstFormulaOneDB.DBContext;

namespace EntityFrameworkCodeFirstFormulaOneDB.DataAccess
{
    public class BaseDataAccess : IDisposable
    {
        protected FormulaOneDBContext db = new FormulaOneDBContext();

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}