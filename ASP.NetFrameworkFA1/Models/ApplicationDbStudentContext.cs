using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NetFrameworkFA1.Models
{
    public class ApplicationDbStudentContext : DbContext
    {
        public ApplicationDbStudentContext() : base("CaptureSystemDatabase")
        { 

        }

        public DbSet<Student> Students { get; set; }
         public DbSet<FacilitatorTable> FacilitatorTable { get; set; }

    }
}