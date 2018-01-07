namespace JixhDb.Models.EntityModels
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using JixhDb.Common.Mapping;
    using JixhDb.Models.BindingModels.User;

    using static Helpers.DataConstants;

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser, IMapFrom<EditUserBindingModel>
    {
        public string ProfilePicUrl { get; set; }
        
        [Range(0, 150)]
        public int Age { get; set; }

        [Range(0,2)]
        public int Gender { get; set; }
        
        [Range(StringMinLength, StringMaxLength)]
        public string HomeTown { get; set; }

        public bool MarkedForChange { get; set; }

        public string FieldForChange { get; set; }

        public ICollection<MovieRaiting> MoviesRated { get; set; } = new List<MovieRaiting>();

        public ICollection<Comment> CommentsRated { get; set; } = new List<Comment>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Review> ReviewsRated { get; set; } = new List<Review>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
