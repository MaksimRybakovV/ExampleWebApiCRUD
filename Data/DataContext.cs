using ExampleWebApiCRUD.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApiCRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"DataSource={Environment.CurrentDirectory}/Data/DataBase/ExampleDB.db");
        }

        public DbSet<Customer> Customers => Set<Customer>();
    }
}
