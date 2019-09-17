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
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DateTimeNotBefore(nameof(Start))]
        public DateTime End { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid {0}!")]
        public int TotalTickets { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal TicketPrice { get; set; }
    }
}
