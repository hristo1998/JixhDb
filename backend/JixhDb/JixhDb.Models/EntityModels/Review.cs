namespace JixhDb.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using JixhDb.Common.Mapping;
    using JixhDb.Models.BindingModels.Review;
    using static Helpers.DataConstants;


    public class Review : IMapFrom<ReviewBindingModel>
    {
        [Key]
        public string Id { get; set; }
            
        [MinLength(StringMinLength)]
        [MaxLength(StringMaxLength)]
        public string Title { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string MovieId { get; set; }

        public Movie Movie { get; set; }

        [MinLength(LongStringMinLength)]
        [MaxLength(LongStringMaxLength)]
        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public int Rating { get; set; }
    }
}
