using System.Data.Entity;

namespace JixhDb.Data
{
    using JixhDb.Models.EntittyModels;
    using Microsoft.AspNet.Identity.EntityFramework;


    public class JixhDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public JixhDbContext()
            : base("data source=ZERZOLAR-LAPTOP;initial catalog=JixhDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public static JixhDbContext Create()
        {
            return new JixhDbContext();
        }


        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
              .HasMany<Category>(m => m.Categories)
              .WithMany(c => c.Movies)
              .Map(cs =>
              {
                  cs.MapLeftKey("MovieRefId");
                  cs.MapRightKey("CategoryRefId");
                  cs.ToTable("MovieCategory");
              });

            base.OnModelCreating(modelBuilder);
        }

       

      
    }

}