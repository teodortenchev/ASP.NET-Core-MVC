using Eventures.Models.Validation;
using System;
using System.ComponentModel.DataAnnotations;


namespace Eventures.Domain
{
    public class Event
    {
        public string Id { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Place { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]

        public int TotalTickets { get; set; }

        [Required]
        public decimal TicketPrice { get; set; }
    }
}
