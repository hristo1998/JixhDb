namespace JixhDb.Models.BindingModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using JixhDb.Models.EntittyModels;

    public class NewMovieBindingModel
    {
        
        public string Title { get; set; }

        public string TrailerLink { get; set; }

        public string CoverUrl { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double Duration { get; set; }
      
        public string Director { get; set; }

        public string Writers { get; set; }

        public string Cast { get; set; }

        public string Storyline { get; set; }

        [Range(0d, 10d)]
        public double Rating { get; set; }
      
    }
}
