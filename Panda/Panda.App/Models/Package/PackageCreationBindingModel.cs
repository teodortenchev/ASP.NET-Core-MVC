using System.ComponentModel.DataAnnotations;

namespace Panda.App.Models.Package
{
    public class PackageCreationBindingModel
    {
        [Required]
        public string Description { get; set; }

        public double Weight { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public string Recipient { get; set; }
    }
}
