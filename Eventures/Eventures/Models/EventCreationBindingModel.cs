using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Models
{
    public class EventCreationBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} should be between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "The {0} should be between {2} and {1} characters", MinimumLength = 2)]
        public string Place { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [Range(0, 100000, ErrorMessage = "The {0} count cannot be a negative number. Max is {2}.")]
        public int TotalTickets { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "The {0} cannot be a negative number. Max {0} is {2}")]
        public decimal TicketPrice { get; set; }
    }
}
