using DotNetTrainingBatch3.ConsoleApp1_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp1_1.EFCoreEg
{
    public class AppdbContext : DbContext              
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "Testdb",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(scb.ConnectionString);
        }

        public DbSet<BlodModel> blods { get; set; }
    }
}
