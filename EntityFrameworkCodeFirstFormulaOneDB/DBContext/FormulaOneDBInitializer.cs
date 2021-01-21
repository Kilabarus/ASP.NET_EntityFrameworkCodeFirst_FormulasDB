using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using EntityFrameworkCodeFirstFormulaOneDB.Models;

namespace EntityFrameworkCodeFirstFormulaOneDB.DBContext
{
    public class FormulaOneDBInitializer : DropCreateDatabaseIfModelChanges<FormulaOneDBContext>
    {
        protected override void Seed(FormulaOneDBContext context)
        {
            List<Championship> championships = new List<Championship>
            {
                new Championship { Year = 2020, RacingSeries = Enums.RacingSeries.F1, Title = "Мировой Чемпионат Формулы-1 2020" },
                new Championship { Year = 2018, RacingSeries = Enums.RacingSeries.F1, Title = "Мировой Чемпионат Формулы-1 2018" },
                new Championship { Year = 2014, RacingSeries = Enums.RacingSeries.IndyCar, Title = "Чемпионат Индикар 2014" },
            };

            List<Driver> drivers = new List<Driver>
            {
                new Driver { FirstName = "Шарль", LastName = "Леклер", Country = Enums.Country.Monaco},
                new Driver { FirstName = "Макс", LastName = "Ферстаппен", Country = Enums.Country.Netherlands},                
                new Driver { FirstName = "Джордж", LastName = "Рассел", Country = Enums.Country.UK},
                new Driver { FirstName = "Льюис", LastName = "Хэмилтон", Country = Enums.Country.UK},
                new Driver { FirstName = "Даниил", LastName = "Квят", Country = Enums.Country.Russia}
            };

            championships.ForEach(c => context.Championships.Add(c));
            drivers.ForEach(d => context.Drivers.Add(d));

            context.SaveChanges();
        }
    }
}