using DigitusCase.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitusCase.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CategoryRelationship>()
                .HasKey(e => new { e.CategoryId, e.SubCategoryId });

            modelBuilder.Entity<CategoryRelationship>()
                .HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CategoryRelationship>()
                .HasOne(e => e.SubCategory)
                .WithMany()
                .HasForeignKey(e => e.SubCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CategoryRelationship>()
                .HasCheckConstraint("CHK_NoDuplicatePairs", "\"CategoryId\" <> \"SubCategoryId\"");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryRelationship> CategoryRelationships { get; set; }
    }
}
