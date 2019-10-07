using ChatInc.Domain;
using System.Collections.Generic;

namespace ChatInc.Services
{
    public interface IUserService
    {
        User CreateUser(string username, string password);
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
