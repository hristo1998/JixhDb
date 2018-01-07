﻿
namespace JixhDb.Services.Account.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;
    using JixhDb.Data;
    using JixhDb.Services.Helpers;
    using JixhDb.Models.BindingModels.User;
    using AutoMapper;

    public class UserService : IService, IUserService
    {
        private readonly JixhDbContext db;

        public UserService(JixhDbContext db)
        {
            this.db = db;
        }

        public async Task<ServiceResult> UpdateUserAsync(string id, EditUserBindingModel model)
        {
            var result = new ServiceResult();

            var user = this.db.Users.FirstOrDefault(u => u.Id == id);

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.Age = model.Age;
            user.Gender = model.Gender;
            user.HomeTown = model.HomeTown;

            try
            {
                var res = await this.db.SaveChangesAsync();
                result.Succeeded = true;
            }
            catch (System.Exception ex)
            {
                result.Error = ex.Message;              
            }

            return result;
        }

    }
}