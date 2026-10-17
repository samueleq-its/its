using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ScuoleItaliane.Models;

public partial class ScuoleItalianeContext : DbContext
{
    public ScuoleItalianeContext()
    {
    }

    public ScuoleItalianeContext(DbContextOptions<ScuoleItalianeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CaratteristicaScuola> CaratteristicaScuole { get; set; }

    public virtual DbSet<Comune> Comuni { get; set; }

    public virtual DbSet<IstitutoRiferimento> IstitutiRiferimento { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Regione> Regioni { get; set; }

    public virtual DbSet<RipartizioneGeografica> RipartizioniGeografiche { get; set; }

    public virtual DbSet<Scuola> Scuole { get; set; }

    public virtual DbSet<TipologiaScuola> TipologieScuola { get; set; }

    public virtual DbSet<ZonaAltimetrica> ZoneAltimetriche { get; set; }

    public virtual DbSet<ZonaMontana> ZonMontane { get; set; }

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
        modelBuilder.Entity<CaratteristicaScuola>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Caratter__3214EC0779DC2C6E");

            entity.ToTable("CaratteristicaScuola");

            entity.Property(e => e.Denominazione)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Comune>(entity =>
        {
            entity.HasKey(e => e.CodiceCatastale);

            entity.ToTable("Comune");

            entity.Property(e => e.CodiceCatastale)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdZonaMontana)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Comuni)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comune_Provincia");

            entity.HasOne(d => d.IdZonaAltimetricaNavigation).WithMany(p => p.Comunes)
                .HasForeignKey(d => d.IdZonaAltimetrica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comune_ZonaAltimetrica");

            entity.HasOne(d => d.IdZonaMontanaNavigation).WithMany(p => p.Comunes)
                .HasForeignKey(d => d.IdZonaMontana)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comune_ZonaMontana");
        });

        modelBuilder.Entity<IstitutoRiferimento>(entity =>
        {
            entity.HasKey(e => e.CodiceIstituto).HasName("PK__Istituto__0B1738681EF9E344");

            entity.ToTable("IstitutoRiferimento");

            entity.Property(e => e.CodiceIstituto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Denominazione)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provinci__3214EC075F296226");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdRegioneNavigation).WithMany(p => p.Provincie)
                .HasForeignKey(d => d.IdRegione)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provincia_Regione");
        });

        modelBuilder.Entity<Regione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Regione__3214EC077A166658");

            entity.ToTable("Regione");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRipartizioneNavigation).WithMany(p => p.Regiones)
                .HasForeignKey(d => d.IdRipartizione)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Regione_RipartizioneGeografica");
        });

        modelBuilder.Entity<RipartizioneGeografica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ripartiz__3214EC07D8C4E2F2");

            entity.ToTable("RipartizioneGeografica");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Scuola>(entity =>
        {
            entity.HasKey(e => e.CodiceScuola).HasName("PK__Scuola__303943F2557974BF");

            entity.ToTable("Scuola");

            entity.Property(e => e.CodiceScuola)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cap)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Denominazione)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdComune)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IdIstitutoRiferimento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IstitutoOmniComprensivo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pec)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SitoWeb)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCaratteristicaScuolaNavigation).WithMany(p => p.Scuolas)
                .HasForeignKey(d => d.IdCaratteristicaScuola)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Scuola__IdCaratt__66603565");

            entity.HasOne(d => d.IdComuneNavigation).WithMany(p => p.Scuole)
                .HasForeignKey(d => d.IdComune)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scuola_Comune");

            entity.HasOne(d => d.IdIstitutoRiferimentoNavigation).WithMany(p => p.Scuolas)
                .HasForeignKey(d => d.IdIstitutoRiferimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Scuola__IdIstitu__6477ECF3");

            entity.HasOne(d => d.IdTipologiaScuolaNavigation).WithMany(p => p.Scuolas)
                .HasForeignKey(d => d.IdTipologiaScuola)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Scuola__IdTipolo__6754599E");
        });

        modelBuilder.Entity<TipologiaScuola>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipologi__3214EC07BD9B7011");

            entity.ToTable("TipologiaScuola");

            entity.Property(e => e.Denominazione)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ZonaAltimetrica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZonaAlti__3214EC0765A2D0C3");

            entity.ToTable("ZonaAltimetrica");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ZonaMontana>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZonaMont__3214EC075E5FF5F2");

            entity.ToTable("ZonaMontana");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
