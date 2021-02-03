using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Profesor> profesores { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignatura>(a => a.HasOne(f => f.Profesor).WithOne(p => p.Asignatura).HasForeignKey<Profesor>(b => b.Asignaturaid));
        }

    }
    
}
