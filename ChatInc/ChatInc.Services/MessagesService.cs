using ChatInc.Data;
using ChatInc.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatInc.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly ChatIncDbContext context;

        public MessagesService(ChatIncDbContext context)
        {
            this.context = context;
        }

        public async Task CreateMessageAsync(string content, string user)
        {
            Message message = new Message
            {
                Content = content,
                User = user,
                CreatedOn = DateTime.UtcNow
            };

            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();

        }

        public IEnumerable<Message> GetMessages()
        {
            var messagesByTimeCreatedAsc = context.Messages.OrderBy(x => x.CreatedOn).ToList();

            return messagesByTimeCreatedAsc;             
        }
    }
}
