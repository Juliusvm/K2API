using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EvrySmartbike2Service.Models
{
    public class EvrySmartbike2ServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EvrySmartbike2ServiceContext() : base("name=EvrySmartbike2ServiceContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EvrySmartbike2ServiceContext>(null);
        }

        public System.Data.Entity.DbSet<EvrySmartbike2Service.Models.Sensordata> Sensordata { get; set; }

        public System.Data.Entity.DbSet<EvrySmartbike2Service.Models.Beacon> Beacons { get; set; }

        public System.Data.Entity.DbSet<EvrySmartbike2Service.Models.BicycleTour> BicycleTours { get; set; }

        public System.Data.Entity.DbSet<EvrySmartbike2Service.Models.Employee> Employees { get; set; }

    }
}
