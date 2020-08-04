using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrudOperationCore.Models;
using CrudOperationCore.ViewModel;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudOperationCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _user;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICityRepository _cityRepository;

        public HomeController(IRepository userRepo, IWebHostEnvironment webHostEnvironment,ICityRepository cityRepository)
        {
            _user = userRepo;
            _webHostEnvironment = webHostEnvironment;
            _cityRepository = cityRepository;
        }

        public IActionResult Index(int? pageNo)
        {
            int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            List<User> users  = _user.GetUser(PageNo);

            List<UserViewModel> UserVM = new List<UserViewModel>();
            foreach(var item in users)
            {
                UserVM.Add(new UserViewModel()
                {
                    UserId = item.UserId,
                    Name = item.Name,
                    FatherName = item.FatherName,
                    ContactNo = item.ContactNo,
                    Email = item.Email,
                    ProfileImagePath=item.ProfileIamge
                });
            }
            return View(UserVM);
        }

        public IActionResult RegisterUser()
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                ProvincesList = _cityRepository.GetProvinces(),
                CitiesList = _cityRepository.GetCitiesEmpty()
        };
            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult RegisterUser(UserViewModel userViewModel)
        {
            var fileName = UploadedFile(userViewModel.ProfileImage);
            User user = new User()
            {
                
                Name = userViewModel.Name,
                FatherName = userViewModel.FatherName,
                Email = userViewModel.Email,
                ContactNo = userViewModel.ContactNo,
                HomeAddress = userViewModel.HomeAddress,
                ResidentailAddress = userViewModel.ResidentailAddress,
                ProfileIamge = fileName
            };

            bool result = _user.InsertUser(user);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
            
        }

        public IActionResult Edit(int id)
        {
            var user = _user.GetUserByID(id);
            UserViewModel userViewModel = new UserViewModel()
            {UserId=user.UserId,
                Name = user.Name,
                FatherName = user.FatherName,
                Email = user.Email,
                ContactNo = user.ContactNo,
                HomeAddress = user.HomeAddress,
                ResidentailAddress = user.ResidentailAddress,
                ProfileImagePath = user.ProfileIamge
            };
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel)
        {
            if(userViewModel!=null)
            {
                User user = _user.GetUserByID(userViewModel.UserId);
                if (userViewModel.ProfileImage != null)
                {
                    if (user.ProfileIamge != null)
                    {
                        string path = Path.Combine(_webHostEnvironment.WebRootPath, "Images", user.ProfileIamge);
                        System.IO.File.Delete(path);
                    }
                    string uniqueFileName = UploadedFile(userViewModel.ProfileImage);
                    user.ProfileIamge = uniqueFileName;
                }
                user.Name = userViewModel.Name;
                user.FatherName = userViewModel.FatherName;
                user.ContactNo = userViewModel.ContactNo;
                user.HomeAddress = userViewModel.HomeAddress;
                user.ResidentailAddress = userViewModel.ResidentailAddress;
                user.Email = userViewModel.Email;
                bool result = _user.UpdateUser(user);
                if (result)
                {
                    TempData["Msg"] = "User Update Successfully";
                    return RedirectToAction("Index");
                }
                

            }
            return View(userViewModel);
        }
        
        public IActionResult Delete(int id)
        {
            bool result = _user.DeleteUser(id);
            if (result)
            {
                TempData["Msg"] = "Delete Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Msg"] = "Some Thing Went Wrong";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Details(int id)
        {
            var user = _user.GetUserByID(id);
            UserViewModel userViewModel = new UserViewModel()
            {
                UserId = user.UserId,
                Name = user.Name,
                FatherName = user.FatherName,
                Email = user.Email,
                ContactNo = user.ContactNo,
                HomeAddress = user.HomeAddress,
                ResidentailAddress = user.ResidentailAddress,
                ProfileImagePath = user.ProfileIamge
            };
            return View(userViewModel);
        }

        [HttpGet]
        public IActionResult GetCities(string ProvinceId)
        {
            if (!string.IsNullOrWhiteSpace(ProvinceId))
            {
                IEnumerable<SelectListItem> cities = _cityRepository.GetCities(ProvinceId);
                return Json(cities);
            }
            return null;
        }

        private string UploadedFile(IFormFile ProfileImage)
        {
            string uniqueFileName = null;

            if (ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }



    }
}
