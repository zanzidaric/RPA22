using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VajaMVC.Data
{
    public class StudentNetContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StudentNetContext() : base("name=StudentNetContext")
        {
        }

        public System.Data.Entity.DbSet<VajaMVC.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<VajaMVC.Models.Predmet> Predmets { get; set; }

        public System.Data.Entity.DbSet<VajaMVC.Models.Izpit> Izpits { get; set; }
    }
}
