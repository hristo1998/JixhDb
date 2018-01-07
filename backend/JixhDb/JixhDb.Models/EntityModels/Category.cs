
namespace JixhDb.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Helpers.DataConstants;

    public class Category
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
