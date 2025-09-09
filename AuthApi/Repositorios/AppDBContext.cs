using AuthApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Repositorios
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Rol> Roles { get; set; } = null!;
        public DbSet<Categoriahj> Categorias { get; set; } = null!; // <-- NUEVO (en plural)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Email único
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // 1 Rol -> N Usuarios
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            // Mapear a la tabla EXISTENTE en MySQL (nombre exacto)
            modelBuilder.Entity<Categoriahj>(entity =>
            {
                entity.ToTable("categoriahj");   // <-- tu nombre real
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(100).IsRequired();
            });
        }
    }
}
