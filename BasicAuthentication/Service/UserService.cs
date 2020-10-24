using BasicAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAuthentication
{
    public class UserService : IUserService
    {
        private readonly List<User> users;
        public UserService()
        {
            users = new List<User>()
            {
                new User(){Username="Admin", Password="Admin"}
            };
        }

        public bool Register(string username, string password)
        {
            this.users.Add(new User()
            {
                Username = username,
                Password = password
            });

            return true;
        }

        public bool IsAuthenticate(string username, string password)
        {
            var user = this.users.FirstOrDefault(item => item.Username == username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
