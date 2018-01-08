namespace JixhDb.Models.BindingModels.Movies
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static JixhDb.Models.EntityModels.Helpers.DataConstants;

    public class MovieBindingModel
    {
        [MinLength(StringMinLength)]
        [MaxLength(StringMaxLength)]
        public string Title { get; set; }

        public string TrailerLink { get; set; }

        public string CoverUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double Duration { get; set; }

        public string Director { get; set; }

        public string Writers { get; set; }

        public string CategoriesString { get; set; }

        public string Cast { get; set; }

        public string StoryLine { get; set; }

        public double Rating { get; set; } = 0;
    }
}
