using Microsoft.EntityFrameworkCore;
using SistemaDeLogin.Domain.EntitiesIdentity;
using SistemaDeLogin.Infra.DataIdentity.Context;

namespace SistemaDeLogin.Infra.Data.Repository
{
    public class LoginRepository 
    {
        private readonly DataContext context;
        private readonly DbSet<Usuarios> DbSet;
        
        public LoginRepository(DataContext context)
        {
            this.context = context;
            DbSet = context.Set<Usuarios>();
        }
        
        public Usuarios SearchUserInfo(Usuarios users) 
        {
            IQueryable<Usuarios> query = DbSet;

            query = query.Where(x => x.Username == users.Username);
            var aaa = query.ToList();
            var a = aaa[0];
            return a;
        }
    }
}
