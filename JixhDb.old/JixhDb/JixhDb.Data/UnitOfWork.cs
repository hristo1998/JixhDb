using System.Data.Entity;

namespace JixhDb.Data
{
    using JixhDb.Data.Contracts;
    using JixhDb.Data.Repositories;
    using JixhDb.Models.EntittyModels;


    public class UnitOfWork : IUnitOfWork
    {

        private readonly JixhDbContext _context;
        private IRepository<ApplicationUser> _users;
        private IRepository<Category> _categories;
        private IRepository<Comment> _comments;
        private IRepository<Movie> _movie;
        private IRepository<Review> _review;



        public UnitOfWork()
        {
            this._context = Data.Context;
        }

        public IRepository<ApplicationUser> Users
            => this._users ?? (this._users = new Repository<ApplicationUser>(this._context.Set<ApplicationUser>()));

        public IRepository<Category> Categories
            => this._categories ?? (this._categories = new Repository<Category>(this._context.Categories));

        public IRepository<Comment> Comments
            => this._comments ?? (this._comments = new Repository<Comment>(this._context.Comments));

        public IRepository<Movie> Movies
           => this._movie ?? (this._movie = new Repository<Movie>(this._context.Movies));

        public IRepository<Review> Reviews
           => this._review ?? (this._review = new Repository<Review>(this._context.Reviews));

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

    }
}
