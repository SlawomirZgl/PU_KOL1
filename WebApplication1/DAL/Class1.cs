using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace DAL
{
    public class StudentsDb : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grupa> Groups { get; set; }
        public DbSet<History> History { get; set; }
        
        public readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupID)
                .OnDelete(DeleteBehavior.Restrict); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}