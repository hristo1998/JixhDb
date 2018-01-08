namespace JixhDb.Models.BindingModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using static JixhDb.Models.EntityModels.Helpers.DataConstants;

    public class CommentBindingModel
    {
        public string movieId { get; set; }

        [MinLength(StringMinLength)]
        [MaxLength(StringMaxLength)]
        public string Title { get; set; }        

        [MinLength(LongStringMinLength)]
        [MaxLength(LongStringMaxLength)]
        public string Text { get; set; }
    }
}
