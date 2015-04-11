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
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<pageEntry> pageEntries { get; set; }
        public virtual DbSet<pagePartEntry> pagePartEntries { get; set; }
        public virtual DbSet<statistic> statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<blogEntry>()
                .Property(e => e.userName)
                .IsFixedLength();

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