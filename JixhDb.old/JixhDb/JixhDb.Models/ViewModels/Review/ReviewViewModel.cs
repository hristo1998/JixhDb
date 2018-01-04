using System.ComponentModel.DataAnnotations;

namespace JixhDb.Models.ViewModels.Review
{
    using System;
    using JixhDb.Models.EntittyModels;
    public class ReviewViewModel
    {

        public int Id { get; set; }

        public string Text { get; set; }

        public Movie Movie { get; set; }

        public ApplicationUser Reviewer { get; set; }

        [Display(Name ="Posted on")]
        public DateTime DateTime { get; set; }

    }
}
