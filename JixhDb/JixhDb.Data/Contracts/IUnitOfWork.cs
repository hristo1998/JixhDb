using System.Security.Cryptography.X509Certificates;
using JixhDb.Models.EntittyModels;

namespace JixhDb.Data.Contracts
{
    public interface IUnitOfWork
    {

        IRepository<ApplicationUser> Users { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Movie> Movies { get; }

        IRepository<Review> Reviews { get; }

        int SaveChanges();
        
    }
}
