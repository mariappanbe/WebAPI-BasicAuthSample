using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAuthentication
{
    public interface IUserService
    {
        bool Register(string username, string password);

        bool IsAuthenticate(string username, string password);
    }
}
