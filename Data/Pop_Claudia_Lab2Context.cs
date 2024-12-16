using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pop_Claudia_Lab2.Models;

namespace Pop_Claudia_Lab2.Data
{
    public class Pop_Claudia_Lab2Context : DbContext
    {
        public Pop_Claudia_Lab2Context (DbContextOptions<Pop_Claudia_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Pop_Claudia_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Pop_Claudia_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author) 
                .WithMany(a => a.Books) 
                .HasForeignKey(b => b.AuthorID) 
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
