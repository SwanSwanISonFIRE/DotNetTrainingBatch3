using DotNetTrainingBatch3.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DotNetTrainingBatch3.WebApi
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
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(scb.ConnectionString);
        }

        public DbSet<BlodModel> blods { get; set; }
    }
}
