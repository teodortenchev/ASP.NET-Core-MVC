using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChatInc.Models
{
    public class MessageCreationBindingModel
    {
        [BindRequired]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [StringLength(500, ErrorMessage = "{0} is too long. {1} is the maximum amount of characters")]
        [MinLength(1, ErrorMessage = "Can't send an empty message.")]
        public string Content { get; set; }

        [BindRequired]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [StringLength(30, ErrorMessage = "{0} is too long. {1} is the maximum amount of characters")]
        [MinLength(1, ErrorMessage = "Can't send an empty message.")]
        public string User { get; set; }

    }
}
