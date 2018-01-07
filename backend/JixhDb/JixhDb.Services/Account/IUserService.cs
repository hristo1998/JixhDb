namespace JixhDb.Services.Account
{
    using System.Threading.Tasks;
    using JixhDb.Models.BindingModels.User;
    using JixhDb.Services.Helpers;

    public interface IUserService
    {
        Task<ServiceResult> UpdateUserAsync(string id, EditUserBindingModel model);
    }
}
