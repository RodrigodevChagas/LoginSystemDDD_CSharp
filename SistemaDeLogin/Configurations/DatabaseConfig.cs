using Microsoft.EntityFrameworkCore;
using SistemaDeLogin.Infra.Data.Context;

namespace SistemaDeLogin.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration) {
        
            if(services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<DataContextDashBoard>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionEntities")));
        }
    }
}
