namespace JixhDb.Services.Account
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using JixhDb.Models.BindingModels.User;
    using JixhDb.Services.Helpers;
    using JixhDb.Models.EntityModels;

    public interface IUserService
    {
        Task<ServiceResult> UpdateUserAsync(User user, EditUserBindingModel model);

        List<User> GetAllUsers();

        Task<ServiceResult> MarkField(User user, string field);
    }
}
