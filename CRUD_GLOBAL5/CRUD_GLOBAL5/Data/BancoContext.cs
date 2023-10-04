using CRUD_GLOBAL5.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_GLOBA5.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { 
        
        }

        public DbSet<ConsultaModel> Marcas { get; set; }
    }
}
