using ChatInc.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatInc.Services
{
    public interface IMessagesService
    {
        Task CreateMessageAsync(string content, string user);
        IEnumerable<Message> GetMessages();
    }
}
