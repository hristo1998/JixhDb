using System.ComponentModel.DataAnnotations;

namespace JixhDb.Models.BindingModels.Review
{
    using System;
    using JixhDb.Models.EntittyModels;

    public class NewReviewBindingModel
    {
        [Display(Name = "Review")]
        public string Text { get; set; }

        public int MovieId { get; set; }

    }
}
