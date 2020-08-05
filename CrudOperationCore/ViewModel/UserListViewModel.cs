using CrudOperationCore.Pagination;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationCore.ViewModel
{
    public class UserListViewModel
    {
        public UserListViewModel()
        {
            UserViewModel = new List<UserViewModel>();
        }
        public List<UserViewModel> UserViewModel { get; set; }
        public Pager pager { get; set; }

    }

}
