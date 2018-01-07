namespace JixhDb.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using JixhDb.Models.EntityModels;

    public class JixhDbContext : IdentityDbContext<User>
    {
        public JixhDbContext(DbContextOptions<JixhDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieCategory>()
                .HasKey(mc => new { mc.CategoryId, mc.MovieId });

            builder.Entity<MovieCategory>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.Categories)
                .HasForeignKey(mc => mc.MovieId);

            builder.Entity<MovieCategory>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.Movies)
                .HasForeignKey(mc => mc.CategoryId);

            builder.Entity<Comment>()
                .HasOne(c => c.Movie)
                .WithMany(m => m.Comments)
                .HasForeignKey(c => c.MovieId);

            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            builder.Entity<MovieRaiting>()
                .HasOne(mr => mr.User)
                .WithMany(u => u.MoviesRated)
                .HasForeignKey(mr => mr.UserId);

            builder.Entity<MovieRaiting>()
                .HasOne(mr => mr.Movie)
                .WithMany(m => m.Ratings)
                .HasForeignKey(mr => mr.Movieid);

            builder.Entity<Review>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MovieId);

            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<MovieRaiting> MovieRatings { get; set; }
    }
}
