namespace JixhDb.Models.BindingModels.Category
{
    using System.ComponentModel.DataAnnotations;
    using static JixhDb.Models.EntityModels.Helpers.DataConstants;

    public class CategoryBindingModel
    {
        [Required]
        [MinLength(StringMinLength)]
        [MaxLength(StringMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
