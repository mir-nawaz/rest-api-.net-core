using System.Collections.Generic;
using restCore.Models;
using Microsoft.EntityFrameworkCore;

namespace restCore.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DB dbContext;
        public UsersRepository(DB context)
        {
            dbContext = context;
        }
        public IEnumerable<User> GetAll()
        {
            return dbContext.User;
        }

        public User GetById(int UserID)
        {
            var user = dbContext.User.Find(UserID);
            return user;
        }

        public User Insert(User user)
        {
            dbContext.User.Add(user);
            dbContext.SaveChanges();
            User newUser = this.GetById(user.Id);
            return newUser;
        }

        public void Update(User user){
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            dbContext.User.Remove(user);
            dbContext.SaveChanges();
        }
    }
}