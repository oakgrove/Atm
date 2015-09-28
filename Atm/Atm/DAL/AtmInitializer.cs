using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Atm.DAL
{

    public class AtmInitializer : DropCreateDatabaseIfModelChanges<AtmDbContext>
    {
        //    protected override void Seed(AtmDbContext context)
        //    {
        //        //var students = new List<Student>
        //        //{
        //        //    new Student { FirstMidName = "Carson",   LastName = "Alexander",
        //        //        EnrollmentDate = DateTime.Parse("2010-09-01") },
        //        //    new Student { FirstMidName = "Meredith", LastName = "Alonso",
        //        //        EnrollmentDate = DateTime.Parse("2012-09-01") },
        //        //    new Student { FirstMidName = "Arturo",   LastName = "Anand",
        //        //        EnrollmentDate = DateTime.Parse("2013-09-01") },
        //        //    new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",
        //        //        EnrollmentDate = DateTime.Parse("2012-09-01") },
        //        //    new Student { FirstMidName = "Yan",      LastName = "Li",
        //        //        EnrollmentDate = DateTime.Parse("2012-09-01") },
        //        //    new Student { FirstMidName = "Peggy",    LastName = "Justice",
        //        //        EnrollmentDate = DateTime.Parse("2011-09-01") },
        //        //    new Student { FirstMidName = "Laura",    LastName = "Norman",
        //        //        EnrollmentDate = DateTime.Parse("2013-09-01") },
        //        //    new Student { FirstMidName = "Nino",     LastName = "Olivetto",
        //        //        EnrollmentDate = DateTime.Parse("2005-08-11") }
        //        //};
        //        //students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
        //        //context.SaveChanges();

        //    }
    }

}