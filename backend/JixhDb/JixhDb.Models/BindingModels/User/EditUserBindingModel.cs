namespace JixhDb.Models.BindingModels.User
{
    using System.ComponentModel.DataAnnotations;
    using static EntityModels.Helpers.DataConstants;

    public class EditUserBindingModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
                
        [Range(0, 150)]
        public int Age { get; set; }

        [Range(0, 2)]
        public int Gender { get; set; }

        [Range(StringMinLength, StringMaxLength)]
        public string HomeTown { get; set; }
    }
}
