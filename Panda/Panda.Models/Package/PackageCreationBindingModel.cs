using System.ComponentModel.DataAnnotations;

namespace Panda.Models.Package
{
    public class PackageCreationBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} should be a minimum of {2} characters", MinimumLength = 3)]
        public string Description { get; set; }

        [Range(0, 1000, ErrorMessage = "The {0} cannot be a negative number or exceed {2} kg.")]
        public double Weight { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public string Recipient { get; set; }
    }
}
