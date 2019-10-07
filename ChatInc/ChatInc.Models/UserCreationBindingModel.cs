using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ChatInc.Models
{
    public class UserCreationBindingModel
    {
        [BindRequired]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [StringLength(50, ErrorMessage = "{0} is too long. {1} is the maximum amount of characters")]
        [MinLength(4, ErrorMessage = "{0} can't be less than {1} characters.")]
        public string Username { get; set; }

        [BindRequired]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [StringLength(50, ErrorMessage = "{0} is too long. {1} is the maximum amount of characters")]
        [MinLength(6, ErrorMessage = "{0} can't be less than {1} characters.")]
        public string Password { get; set; }
    }
}
