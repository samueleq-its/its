using System;
using System.Collections.Generic;
using GestioneVideotecaScolastica.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioneVideotecaScolastica.Data;

public partial class GestioneVideotecaScolasticaContext : DbContext
{
    public GestioneVideotecaScolasticaContext()
    {
    }

    public GestioneVideotecaScolasticaContext(DbContextOptions<GestioneVideotecaScolasticaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Prestito> Prestiti { get; set; }

    public virtual DbSet<Studente> Studenti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Codice).HasName("PK_TitoliExcel");

            entity.ToTable("Film");

            entity.Property(e => e.Attori).IsUnicode(false);
            entity.Property(e => e.Genere).HasMaxLength(50);
            entity.Property(e => e.Regista).IsUnicode(false);
            entity.Property(e => e.Supporto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titolo).IsUnicode(false);
        });

        modelBuilder.Entity<Prestito>(entity =>
        {
            entity.ToTable("Prestito");

            entity.Property(e => e.DataPrestito).HasColumnType("datetime");
            entity.Property(e => e.DataRestituzione).HasColumnType("datetime");

            entity.HasOne(d => d.IdFilmNavigation).WithMany(p => p.Prestiti)
                .HasForeignKey(d => d.IdFilm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestito_TitoliExcel");

            entity.HasOne(d => d.MatricolaNavigation).WithMany(p => p.Prestiti)
                .HasForeignKey(d => d.Matricola)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prestito_Studente");
        });

        modelBuilder.Entity<Studente>(entity =>
        {
            entity.HasKey(e => e.Matricola);

            entity.ToTable("Studente");

            entity.Property(e => e.Matricola).ValueGeneratedNever();
            entity.Property(e => e.Classe).HasMaxLength(50);
            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
