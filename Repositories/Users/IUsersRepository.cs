using System.Collections.Generic;
using restCore.Models;

namespace restCore.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int UserID);
        User Insert(User user);
        void Update(User user);
        void Delete(User user);
    }
}