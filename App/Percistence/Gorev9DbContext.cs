using App.Percistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace App.Percistence.EntityFrameworkCore
{
    public class Gorev9DbContext:DbContext
    {
        public Gorev9DbContext(DbContextOptions<Gorev9DbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryPost> CategoryPosts { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Post>()
                .HasData(
                new Post() { PostId=1, Url="www.tugcebolat.com", Title="A"},
                
                new Post() { PostId=2, Url="www.bolat.com/blog",Title="B"}
                );
            modelBuilder.Entity<PostImage>()
                .HasData(
                new PostImage() { Id = 1,PostId=1, Url="www.com"},
                new PostImage() { Id = 2,PostId=1, Url="www.comm." },
                new PostImage() { Id = 3,PostId=2, Url="olurmuboyle.com" }
                );
                modelBuilder.Entity<CategoryPost>()
                    .HasKey(pc => new { pc.CategoryId, pc.PostId });

                modelBuilder.Entity<CategoryPost>()
                    .HasOne(pc => pc.Category)
                    .WithMany(p => p.PostCategories)
                    .HasForeignKey(pc => pc.PostId);

                modelBuilder.Entity<CategoryPost>()
                    .HasOne(p => p.Post)
                    .WithMany(c => c.PostCategories)
                    .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1,  CategoryName = "Teknoloji",CategoryDescription="C" },
            new Category { CategoryId = 2, CategoryName= "Seyahat", CategoryDescription="D" });
   
            modelBuilder.Entity<CategoryPost>().HasData(
                new CategoryPost { PostId = 1, CategoryId = 1 },
                new CategoryPost { PostId = 2, CategoryId = 2 });




        }
    }
  


}
