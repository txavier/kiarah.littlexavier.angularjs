namespace Kiarah.LittleXavier.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Kiarah.LittleXavier.Core.Models;

    public partial class littleXavierDbContext : DbContext
    {
        public littleXavierDbContext()
            : base("name=littleXavierDbContext")
        {
        }

        public virtual DbSet<blogEntry> blogEntries { get; set; }
        public virtual DbSet<blogEntryComment> blogEntryComments { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<pageEntry> pageEntries { get; set; }
        public virtual DbSet<pagePartEntry> pagePartEntries { get; set; }
        public virtual DbSet<statistic> statistics { get; set; }
        public virtual DbSet<myCastle> myCastles { get; set; }
        public virtual DbSet<myJourney> myJournies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<myJourney>()
                .Property(e => e.userName)
                .IsFixedLength();

            modelBuilder.Entity<myCastle>()
                .Property(e => e.userName)
                .IsFixedLength();

            modelBuilder.Entity<blogEntry>()
                .Property(e => e.userName)
                .IsFixedLength();

            modelBuilder.Entity<blogEntry>()
                .HasMany(e => e.blogEntryComments)
                .WithRequired(e => e.blogEntry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.blogEntries)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pageEntry>()
                .HasMany(e => e.pagePartEntries)
                .WithRequired(e => e.pageEntry)
                .WillCascadeOnDelete(false);
        }
    }
}
