using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Services
{
    public interface IReceiptService
    {
        void GenerateReceipt(string packageId);
    }
}
