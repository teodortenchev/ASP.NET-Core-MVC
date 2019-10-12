using Panda.Models.Receipt;
using System.Collections.Generic;

namespace Panda.Services
{
    public interface IReceiptService
    {
        void GenerateReceipt(string packageId);
        IEnumerable<ReceiptViewModel> GetReceiptsForUser(string username);
        ReceiptViewModel GetDetails(string receiptId, string username);


    }
}
