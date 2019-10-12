using Panda.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public class UsersService : IUsersService
    {
        private readonly PandaDbContext context;

        public UsersService(PandaDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<string> ReturnUsernames()
        {
            var usernames = context.Users.Select(x => x.UserName).OrderBy(x => x).ToList();

            return usernames;
    }
}
