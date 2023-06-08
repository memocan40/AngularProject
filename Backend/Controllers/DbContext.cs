using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System;

namespace Backend
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        private static string GetConnectionString()
        {
            var server = Environment.GetEnvironmentVariable("DB_SERVER");
            var database = Environment.GetEnvironmentVariable("DB_DATABASE");
            var username = Environment.GetEnvironmentVariable("DB_USERNAME");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            return $"Server={server};Database={database};Uid={username};Pwd={password};";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

                var server = Environment.GetEnvironmentVariable("DB_SERVER");
                var database = Environment.GetEnvironmentVariable("DB_DATABASE");
                var username = Environment.GetEnvironmentVariable("DB_USERNAME");
                var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

                var connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

                optionsBuilder.UseMySql(connectionString, serverVersion);

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Hier können Sie das Datenbankschema konfigurieren
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired();
        }
    }
}
