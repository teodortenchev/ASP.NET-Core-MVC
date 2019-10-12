using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Services
{
    public interface IUsersService
    {
        IEnumerable<string> ReturnUsernames();
    }
}
