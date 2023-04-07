using FirstTryDDD.Core.AggregateModels.AuthorAggregate;
using FirstTryDDD.Core.AggregateModels.BookAggregate;
using FirstTryDDD.Core.AggregateModels.ReaderAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasIndex(a => a.PhoneNumber).IsUnique();
            modelBuilder.Entity<Author>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Reader>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Reader>().HasIndex(a => a.UserName).IsUnique();

            modelBuilder.Entity<Author>().HasMany(a=>a.Books).WithOne(b=>b.Author).HasForeignKey(b=>b.AuthorId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reader>().HasMany(r=>r.ReaderBookList).WithOne(l=>l.Reader).HasForeignKey(b=>b.ReaderId).OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Book>().HasMany(b=>b.ReaderBookLists).WithOne(l=>l.Book).HasForeignKey(l=>l.BookId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookCategory>().HasMany(b=>b.Books).WithOne(b=>b.Category).HasForeignKey(b=>b.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Author> Author { get; set;}
        public DbSet<Book> Book { get; set;}
        public DbSet<Reader> Reader { get; set;}
        public DbSet<ReaderBookList> ReaderBookList { get; set;}
        public DbSet<BookCategory> Category { get; set;}

    }
}
