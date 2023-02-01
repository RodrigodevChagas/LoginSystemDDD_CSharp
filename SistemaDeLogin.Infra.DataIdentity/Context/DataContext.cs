using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaDeLogin.Domain.EntitiesIdentity;

namespace SistemaDeLogin.Infra.DataIdentity.Context
{
    public class DataContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        new public DbSet<Usuarios> Users { get; set; }
    }
}
