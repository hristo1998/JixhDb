using JixhDb.Models.ViewModels.Review;

namespace JixhDb.Models.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using JixhDb.Models.EntittyModels;

    public class MovieDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name="Cover")]
        public string CoverUrl { get; set; }

        [Display(Name = "Trailer")]
        public string TrailerLink { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public double Duration { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public string Director { get; set; }

        public string Writers { get; set; }

        public string Cast { get; set; }

        public string Storyline { get; set; }

        [Range(0d, 10d)]
        public double Rating { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
