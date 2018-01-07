namespace JixhDb.Models.BindingModels.Jwt
{
    using System.ComponentModel.DataAnnotations;

    public class LoginBidingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }      
    }
}
