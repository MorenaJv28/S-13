using Microsoft.EntityFrameworkCore;
using S11.Modelo;

namespace S11.Data
{
    public class Contexto : DbContext
    {
        public DbSet<estudiante> Estudiante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=awita28;Database=Programacion2;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }
}
