using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeLogin.Data
{
    public class DataContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
