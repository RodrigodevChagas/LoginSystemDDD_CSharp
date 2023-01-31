using Microsoft.EntityFrameworkCore;
using SistemaDeLogin.Domain.EntitiesIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.Infra.Data.Context
{
    public class DataContextDashBoard : DbContext
    {
        public DataContextDashBoard(DbContextOptions<DataContextDashBoard> opts) : base(opts) { }
        
        public DbSet<Usuarios> Users { get; set; }
    }
}
