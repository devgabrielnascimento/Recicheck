using APIRecicheck.Models;
using Microsoft.EntityFrameworkCore;


namespace APIRecicheck.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<ColetaModel> Coletas { get; set; }

        public virtual DbSet<UserModel> Users { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColetaModel>(entity =>
            {
                entity.ToTable("COLETA");
                entity.HasKey(e => e.coletaId);
                entity.Property(e => e.tipoResiduo).HasColumnType("NVARCHAR2(10)").IsRequired();
                entity.Property(e => e.dataColeta).HasColumnType("date").IsRequired();
                entity.Property(e => e.quantidade).HasColumnType("NVARCHAR2(10)").IsRequired();
        
            });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>()
            .HasKey(u => u.UserId);


        }
    }
}
