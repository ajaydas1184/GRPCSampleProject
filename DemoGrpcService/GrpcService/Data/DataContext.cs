using GrpcService.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Data
{
    public class DataContext : DbContext
    {        
        public DataContext(IOptions<DBConnection> dbConnection) : base(dbConnection.Value.DefaultConnection) //base(@"Data Source=DESKTOP-GV90GIC\SQLEXPRESS;Initial Catalog=GrpcTestDB;Integrated Security=True")
        {           
            Database.SetInitializer<DataContext>(new DbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();                      

            modelBuilder.Entity<Employee>()
            .HasRequired(c => c.Department)
            .WithMany(p => p.Employees)
            .HasForeignKey(c => c.DepartmentId)
            .WillCascadeOnDelete(false);            

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
