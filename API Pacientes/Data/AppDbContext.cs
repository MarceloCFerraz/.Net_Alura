using API_Pacientes.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Pacientes.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {}
    }
}
