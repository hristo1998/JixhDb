using System.Data.Entity;

namespace JixhDb.Data
{
    using JixhDb.Models.EntittyModels;
    using Microsoft.AspNet.Identity.EntityFramework;


    public class JixhDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public JixhDbContext()
            : base("name=JixhDb", throwIfV1Schema: false)
        {
        }

        public static JixhDbContext Create()
        {
            return new JixhDbContext();
        }

        public IDbSet<ApplicationUser> Users { get; set; }
      
    }

}