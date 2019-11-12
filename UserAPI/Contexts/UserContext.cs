using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserAPI.Domains
{
    public partial class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoUsuarioPermissao01> TipoUsuarioPermissao01 { get; set; }
        public virtual DbSet<TipoUsuarioPermissao02> TipoUsuarioPermissao02 { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress01;Initial Catalog=UserAPI;User ID=sa;Password=info@132");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuarioPermissao01>(entity =>
            {
                entity.ToTable("TIPO_USUARIO_PERMISSAO01");

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__TIPO_USU__B6FCAAA2AC4AA431")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuarioPermissao02>(entity =>
            {
                entity.ToTable("TIPO_USUARIO_PERMISSAO02");

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__TIPO_USU__B6FCAAA2C1AF210C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF724F13B5C82")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuarioPermissao).HasColumnName("TIPO_USUARIO_PERMISSAO");

                entity.Property(e => e.TipoUsuarioPermissaoAcesso).HasColumnName("TIPO_USUARIO_PERMISSAO_ACESSO");

                entity.HasOne(d => d.TipoUsuarioPermissaoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioPermissao)
                    .HasConstraintName("FK__USUARIOS__TIPO_U__5441852A");

                entity.HasOne(d => d.TipoUsuarioPermissaoAcessoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioPermissaoAcesso)
                    .HasConstraintName("FK__USUARIOS__TIPO_U__5535A963");
            });
        }
    }
}
