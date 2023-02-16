using Azure.Core;
using FluentResults;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.ApplicationIdentity.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result UploadProfilePic(Usuarios user, string RootPath) 
        {
            string fileName = Path.GetFileNameWithoutExtension(user.ProfilePicFile.FileName);
            string extension = Path.GetExtension(user.ProfilePicFile.FileName);
            user.ProfilePic = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(RootPath + "/Image", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create)) 
            {
                user.ProfilePicFile.CopyTo(fileStream);
            }

            var result = _userRepository.UploadProfilePic(user, fileName);

            if (!result.IsSuccess)
                return Result.Fail("Nâo foi possivel fazer o upload da foto");
            
            return Result.Ok();
        }

        //public Result UserCheck() 
        //{
        //    if (User.Identity != null && !string.IsNullOrEmpty(User.Identity.Name))
        //    {
        //        Usuarios user = new Usuarios();
        //        user.Username = request.Username != null ? request.Username : User.Identity.Name;
        //        user = userRepository.GetUserInfo(user);
        //    }
        //        return View(user);
        //}
    }
}
