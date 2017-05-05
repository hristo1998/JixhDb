using JixhDb.Models.BindingModels.Category;

namespace JixhDb.Web.Services
{
    using System.Collections.Generic;
    using AutoMapper;
    using JixhDb.Models.EntittyModels;
    using JixhDb.Models.ViewModels.Category;
    using JixhDb.Web.Services.Contracts;

    public class CategoriesService : Service, ICategoriesService
    {
        public IEnumerable<CategoryViewModel> Categories()
        {
            return Mapper.Map<IEnumerable<Category>,IEnumerable<CategoryViewModel>>(this.Context.Categories.Entities);
        }

        public void Add(NewCategoryBindingModel category)
        {
            this.Context.Categories.Add(Mapper.Map<NewCategoryBindingModel,Category>(category));
            this.Context.SaveChanges();
        }

        public CategoryViewModel Find(int id)
        {
            return Mapper.Map<Category, CategoryViewModel>(this.Context.Categories.Find(id));
        }

        public void Modify(CategoryViewModel category)
        {
            var old = this.Context.Categories.Find(category.Id);
            old.Name = category.Name;
            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.Context.Categories.Remove(id);
            this.Context.SaveChanges();
        }
    }
}
