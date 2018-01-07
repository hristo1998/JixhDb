namespace JixhDb.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Helpers.DataConstants;

    public class Movie
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(StringMinLength)]
        [MaxLength(StringMaxLength)]
        public string Title { get; set; }

        [Required]
        public string TrailerLink { get; set; }

        [Required]
        public string CoverUrl { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public double Duration { get; set; }

        public virtual ICollection<MovieCategory> Categories { get; set; } = new List<MovieCategory>();

        [Required]
        public string Director { get; set; }

        public string Writers { get; set; }

        public string Cast { get; set; }

        public string StoryLine { get; set; }

        public double Rating { get; set; } = 0;

        public ICollection<MovieRaiting> Ratings { get; set; } = new List<MovieRaiting>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
