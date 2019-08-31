﻿using Panda.App.Models.Package;

namespace Panda.App.Models.Receipt
{
    public class ReceiptViewModel
    {
        public string Id { get; set; }
        public decimal Fee { get; set; }
        public string IssuedOn { get; set; }
        public string Recipient { get; set; } 
        public PackageViewModel Package { get; set; }
    }
}
