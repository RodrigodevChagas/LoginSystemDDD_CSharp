using Microsoft.EntityFrameworkCore;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.DataIdentity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.Infra.Data.Repository
{
    public class UserRepository
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
            var userInfo = DbSet.FirstOrDefault(x => x.Username == user.Username);
            
            return userInfo != null? userInfo : new Usuarios();
        }
    }
}
