using ChatInc.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChatInc.Data
{
    public class ChatIncDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public object SingleOrDefault { get; set; }

        public ChatIncDbContext(DbContextOptions options) : base(options)
        {

        }
        
    }
}
