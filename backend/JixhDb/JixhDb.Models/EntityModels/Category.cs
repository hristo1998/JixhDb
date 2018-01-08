
namespace JixhDb.Models.EntityModels
{   
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using JixhDb.Common.Mapping;
    using JixhDb.Models.BindingModels.Category;

    using static Helpers.DataConstants;

    public class Category : IMapFrom<CategoryBindingModel>
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(StringMinLength)]
        [MaxLength(StringMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<MovieCategory> Movies { get; set; } = new List<MovieCategory>();
    }
}
