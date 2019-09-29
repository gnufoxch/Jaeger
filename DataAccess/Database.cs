using Microsoft.EntityFrameworkCore;
using System;
using Order.Model;

namespace DataAccess
{
    public class Database: DbContext
    {
        private static readonly Database _singleton = new Database();

        public static Database Singleton => _singleton;

        public Database()
        {
            Database.EnsureCreated();
        }

        private readonly String _connectionstring = @"Server=(localdb)\mssqllocaldb;Database=JaegerAutomation;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DbSet<OrderInfo> OrderInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderInfo>().ToTable("ORDERINFO");
            modelBuilder.Entity<OrderInfo>().HasKey(x=>x.Id);
        }
    }
}
