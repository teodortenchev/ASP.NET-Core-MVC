using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Domain;
using Panda.Services.Tests.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Panda.Services.Tests
{
    public class UsersServiceTests
    {
        private async Task<PandaDbContext> GetDbContext()
        {
            var users = new List<PandaUser>
            {
                new PandaUser { UserName = "user1", Email = "user1@gmail.com"},
                new PandaUser { UserName = "user2", Email = "user2@gmail.com"},
            };

            var optionsBuilder = new DbContextOptionsBuilder<PandaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var dbContext = new PandaDbContext(optionsBuilder.Options);


            foreach (var user in users)
            {
                await dbContext.Users.AddAsync(user);
            }

            await dbContext.SaveChangesAsync();
            return dbContext;
        }

        [Fact]
        public async Task ReturnUsernamesWorksCorrectlyWithUsersInDb()
        {
            var dbContext = await GetDbContext();
            var service = new UsersService(dbContext);

            var actual = service.ReturnUsernames();

            IEnumerable<string> expected = new List<string> { "user1", "user2" };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ReturnNullWithNoUsersWithoutThrowingError()
        {
            var dbContext = await GetDbContext();

            dbContext.Users.RemoveRange(dbContext.Users);

            dbContext.Users.Clear();

            await dbContext.SaveChangesAsync();

            var service = new UsersService(dbContext);

            var actual = service.ReturnUsernames();

            IEnumerable<string> expected = new List<string> { "user1", "user2" };

            Assert.Equal(expected, actual);
        }
    }
}
