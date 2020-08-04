using CrudOperationCore.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.Models
{
    public class UserRepo : IRepository
    {
        private ApplicationContext context;

        public UserRepo(ApplicationContext applicationContext)
        {
            context = applicationContext;
        }
        public bool DeleteUser(int UserId)
        {
            var user = GetUserByID(UserId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<User> GetUser(int pageNo)
        {
            return context.Users.Skip((pageNo-1)*10).Take(10).ToList();
        }

        public User GetUserByID(int UserId)
        {
            if (UserId > 0)
            {
                return context.Users.FirstOrDefault(x=>x.UserId==UserId);
            }
            return null;
        }

        public bool InsertUser(User user)
        {
            if (user != null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        


        public bool UpdateUser(User user)
        {
            if (user != null)
            {

                context.Update(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
