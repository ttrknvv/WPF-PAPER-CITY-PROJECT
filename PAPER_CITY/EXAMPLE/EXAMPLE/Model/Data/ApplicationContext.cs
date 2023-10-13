using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMPLE.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> USERS { get; set; }
        public DbSet<Busket> BUSKET { get; set; }
        public DbSet<BusketBooks> BUSKET_BOOKS { get; set; }
        public DbSet<Books> BOOKS { get; set; }
        public DbSet<Payment> PAYMENT { get; set; }
        public DbSet<Reviews> REVIEWS { get; set; }
        public DbSet<ReviewProblem> REVIEW_PROBLEM { get; set; }
        public ApplicationContext()
        {
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=TARAKANOVNS;Database=PAPERDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>().HasKey(b => b.ID_BOOK);
            modelBuilder.Entity<User>().HasKey(b => b.ID_USER);
            modelBuilder.Entity<Busket>().HasKey(b => b.ID_BUSKET);
            modelBuilder.Entity<BusketBooks>().HasKey(b => b.ID_RECORD);
            modelBuilder.Entity<Payment>().HasKey(b => b.ID_PAY);
        }
    }
}
