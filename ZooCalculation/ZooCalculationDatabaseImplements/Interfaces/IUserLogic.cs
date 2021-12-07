using Data.Implements;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IUserLogic
    {
        IEnumerable<User> Users { get; }

        void AddUser(User user);

        void DeleteUser(int userId);
    }
}
