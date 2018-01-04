using System.Collections.Generic;
using JixhDb.Models.BindingModels.Category;
using JixhDb.Models.ViewModels.Category;

namespace JixhDb.Web.Services.Contracts
{
    interface ICategoriesService
    {
        IEnumerable<CategoryViewModel> Categories();


        void Add(NewCategoryBindingModel category);


        CategoryViewModel Find(int id);


        void Modify(CategoryViewModel category);

        void Delete(int id);
    }
}
