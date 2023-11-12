using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coste_Ionut_Lab2.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Coste_Ionut_Lab2.Data
{
    public class Coste_Ionut_Lab2Context : DbContext
    {
        public Coste_Ionut_Lab2Context(DbContextOptions<Coste_Ionut_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Coste_Ionut_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Coste_Ionut_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Coste_Ionut_Lab2.Models.Author>? Author { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Borrowing)
               .WithOne(e => e.Book)
                .HasForeignKey<Borrowing>("BookID");

        }
        public DbSet<Coste_Ionut_Lab2.Models.Category>? Category { get; set; }
        public DbSet<Coste_Ionut_Lab2.Models.Member>? Member { get; set; }
        public DbSet<Coste_Ionut_Lab2.Models.Borrowing>? Borrowing { get; set; }


    }
}
