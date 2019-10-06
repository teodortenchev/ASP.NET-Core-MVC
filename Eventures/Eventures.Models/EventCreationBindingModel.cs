using Eventures.Models.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Models
{
    public class EventCreationBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} should be between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} should be between {2} and {1} characters", MinimumLength = 2)]
        public string Place { get; set; }



        [Required(ErrorMessage = "{0} cannot be empty!", AllowEmptyStrings = false)]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!", AllowEmptyStrings = false)]
        [DataType(DataType.DateTime)]
        [DateTimeNotBefore(nameof(Start))]
        public DateTime End { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid {0}!")]
        public int TotalTickets { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "The {0} cannot be a negative number. Max {0} is {2}")]
        public decimal TicketPrice { get; set; }
    }
}
