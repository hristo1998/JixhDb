namespace JixhDb.Data.Contracts
{
    using System.Security.Cryptography.X509Certificates;
    using JixhDb.Models.EntityModels;

    public interface IUnitOfWork
    {

        //IRepository<ApplicationUser> Users { get; }

        //IRepository<Category> Categories { get; }

        //IRepository<Comment> Comments { get; }

        //IRepository<Movie> Movies { get; }

        //IRepository<Review> Reviews { get; }

        int SaveChanges();

    }
}
