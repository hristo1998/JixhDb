namespace JixhDb.Models.EntittyModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {

        public Movie()
        {
            this.Comments = new HashSet<Comment>();
            this.Reviews = new HashSet<Review>();
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string TrailerLink { get; set; }

        public string CoverUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double Duration { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public string Director { get; set; }

        public string Writers { get; set; }

        public string Cast { get; set; }

        public string Storyline { get; set; }

        [Range(0d,10d)]
        public double Rating { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

    }
}
