using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }
        public virtual DbSet<Produtoras> Produtoras { get; set; }
        public virtual DbSet<TiposTitulo> TiposTitulo { get; set; }
        public virtual DbSet<Titulos> Titulos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'dbo.Favoritos'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=M_OpFlix;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Categoria)
                    .HasName("UQ__Categori__08015F8B77FB8ECD")
                    .IsUnique();

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plataformas>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Plataforma)
                    .HasName("UQ__Platafor__3FCED09269C4EAEE")
                    .IsUnique();

                entity.Property(e => e.Plataforma)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produtoras>(entity =>
            {
                entity.HasKey(e => e.IdProdutora);

                entity.HasIndex(e => e.Produtora)
                    .HasName("UQ__Produtor__9C9D179CC4CDED08")
                    .IsUnique();

                entity.Property(e => e.Produtora)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposTitulo>(entity =>
            {
                entity.HasKey(e => e.IdTipoTitulo);

                entity.HasIndex(e => e.TipoTitulo)
                    .HasName("UQ__TiposTit__36602C3CDD7B0FD7")
                    .IsUnique();

                entity.Property(e => e.TipoTitulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Titulos>(entity =>
            {
                entity.HasKey(e => e.IdTitulo);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Titulos__7D8FE3B252C624CF")
                    .IsUnique();

                entity.Property(e => e.Classificacao)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse).HasColumnType("text");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Titulos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Titulos__IdCateg__59FA5E80");

                entity.HasOne(d => d.IdPlataformaNavigation)
                    .WithMany(p => p.Titulos)
                    .HasForeignKey(d => d.IdPlataforma)
                    .HasConstraintName("FK__Titulos__IdPlata__5AEE82B9");

                entity.HasOne(d => d.IdProdutoraNavigation)
                    .WithMany(p => p.Titulos)
                    .HasForeignKey(d => d.IdProdutora)
                    .HasConstraintName("FK__Titulos__IdProdu__5BE2A6F2");

                entity.HasOne(d => d.IdTipoTituloNavigation)
                    .WithMany(p => p.Titulos)
                    .HasForeignKey(d => d.IdTipoTitulo)
                    .HasConstraintName("FK__Titulos__IdTipoT__59063A47");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105349B50FCD1")
                    .IsUnique();

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Imagens).HasColumnType("text");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
