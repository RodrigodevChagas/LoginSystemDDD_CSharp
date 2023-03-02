using FluentResults;
using SistemaDeLogin.ApplicationIdentity.Interfaces;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.Data.Interface;

namespace SistemaDeLogin.ApplicationIdentity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
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
    }
}
