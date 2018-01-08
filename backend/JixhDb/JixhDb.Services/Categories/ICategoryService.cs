namespace JixhDb.Services.Categories
{
    using System.Threading.Tasks;
    using JixhDb.Models.EntityModels;
    using JixhDb.Models.BindingModels.Category;
    using JixhDb.Services.Helpers;

    public interface ICategoryService
    {
        string GetAllCategoriesJson();

        string GetCategoryByIdJson(string id);

        Category GetCategoryById(string id);

        string GetCategoryByNameJson(string name);

        Category GetCategoryByName(string name);

        Task<ServiceResult> Create(CategoryBindingModel model);

        Task<ServiceResult> Update(Category category, CategoryBindingModel model);

        Task<ServiceResult> Delete(Category category);
    }
}
