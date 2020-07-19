namespace Bookshop.API.Core.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookshopAPIDB : DbContext
    {
        public BookshopAPIDB()
            : base("name=BookshopAPIDB")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookEvent> BookEvents { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BranchSoldStock> BranchSoldStocks { get; set; }
        public virtual DbSet<BranchStock> BranchStocks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Gift> Gifts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Subtitle)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.BranchName)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.GenreName)
                .IsUnicode(false);

            modelBuilder.Entity<Gift>()
                .Property(e => e.GiftPrice)
                .HasPrecision(18, 0);
        }
    }
}
