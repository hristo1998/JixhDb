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
        
      
    }

}