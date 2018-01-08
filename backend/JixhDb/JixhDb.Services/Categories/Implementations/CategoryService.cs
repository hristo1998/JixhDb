namespace JixhDb.Services.Categories.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using JixhDb.Data;
    using JixhDb.Models.EntityModels;
    using JixhDb.Models.BindingModels.Category;
    using JixhDb.Services.Helpers;
    using Newtonsoft.Json;
    using AutoMapper;

    public class CategoryService : ICategoryService, IService
    {

        private readonly JixhDbContext db;

        public CategoryService(JixhDbContext db)
        {
            this.db = db;
        }

        public string GetAllCategoriesJson() =>
            JsonConvert.SerializeObject(this.db.Categories.ToList());

        public string GetCategoryByIdJson(string id) =>
            JsonConvert.SerializeObject(this.GetCategoryById(id));

        public Category GetCategoryById(string id) => this.db.Categories.FirstOrDefault(c => c.Id == id);

        public string GetCategoryByNameJson(string name) =>
            JsonConvert.SerializeObject(this.GetCategoryByName(name));

        public Category GetCategoryByName(string name) => this.db.Categories.FirstOrDefault(c => c.Name == name);

        public async Task<ServiceResult> Create(CategoryBindingModel model)
        {
            var result = new ServiceResult();
            var category = new Category();
            Mapper.Map(model, category);

            try
            {
                await this.db.Categories.AddAsync(category);
                await this.db.SaveChangesAsync();
                result.Succeeded = true;
            }
            catch (DbUpdateException ex)
            {
                result.Succeeded = false;
                result.Error = ex.Message;
                throw;
            }

            return result;
        }

        public async Task<ServiceResult> Update(Category category, CategoryBindingModel model)
        {
            var result = new ServiceResult();
            
            try
            {
                Mapper.Map(model, category);
                await this.db.SaveChangesAsync();
                result.Succeeded = true;
            }
            catch (DbUpdateException sx)
            {
                result.Error = sx.Message;
                result.Succeeded = false;
            }

            return result;
        }

        public async Task<ServiceResult> Delete(Category category)
        {
            var result = new ServiceResult();

            try
            {
                this.db.Categories.Remove(category);
                await this.db.SaveChangesAsync();
                result.Succeeded = true;
            }
            catch (DbUpdateException ex)
            {
                result.Succeeded = false;
                result.Error = ex.Message;
            }

            return result;
        }
    }
}
