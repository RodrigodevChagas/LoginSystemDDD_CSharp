using FluentResults;
using Microsoft.EntityFrameworkCore;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.Data.Interface;
using SistemaDeLogin.Infra.DataIdentity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly DataContext dataContext;
        protected readonly DbSet<Usuarios> DbSet;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
            DbSet = dataContext.Set<Usuarios>();
        }

        public Usuarios GetUserInfo(Usuarios user)
        {
            var userInfo = DbSet.FirstOrDefault(x => x.Email == user.Email);
            
            // var userInfoTwo = from users in DbSet
            //                   where user.Username == users.Username
            //                   select users;
            
            return userInfo != null? userInfo : new Usuarios();
        }

        public Result UploadProfilePic(Usuarios user, string path) 
        {
            user = GetUserInfo(user);
            user.ProfilePic = path;
            DbSet.Update(user);
            dataContext.SaveChanges();
            
            return Result.Ok();
        }
    }
}
