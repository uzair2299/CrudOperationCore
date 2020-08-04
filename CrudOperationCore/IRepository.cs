using CrudOperationCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore
{
   public interface IRepository
    {
        List<User> GetUser(int pageNo);
        User GetUserByID(int UserId);
        bool InsertUser(User user);
        bool DeleteUser(int UserId);
        bool UpdateUser(User user);
        
    }
}
