using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Parafarmacie.Data.Models;

public partial class ParafarmacieContext : DbContext
{
    public ParafarmacieContext()
    {
    }

    public ParafarmacieContext(DbContextOptions<ParafarmacieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comune> Comuni { get; set; }

    public virtual DbSet<Parafarmacia> Parafarmacie { get; set; }

    public virtual DbSet<Provincia> Province { get; set; }

    public virtual DbSet<Regione> Regioni { get; set; }

    public virtual DbSet<RipartizioneGeografica> RipartizioniGeografiche { get; set; }

    public virtual DbSet<ZonaAltimetrica> ZoneAltimetriche { get; set; }

    public virtual DbSet<ZonaMontana> ZoneMontane { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Parafarmacie;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comune>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comune__3214EC07918D1B4C");

            entity.ToTable("Comune", "Istat");

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

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Comunes)
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

        modelBuilder.Entity<Parafarmacia>(entity =>
        {
            entity
                .ToTable("Parafarmacie");

            entity.Property(e => e.Cap)
                .HasMaxLength(100)
                .HasColumnName("cap");
            //entity.Property(e => e.CodiceComune)
            //    .HasMaxLength(100)
            //    .HasColumnName("codice_comune");
            entity.Property(e => e.CodiceIdentificativoSito)
                .HasMaxLength(100)
                .HasColumnName("codice_identificativo_sito");
            //entity.Property(e => e.CodiceProvincia)
            //    .HasMaxLength(100)
            //    .HasColumnName("codice_provincia");
            //entity.Property(e => e.CodiceRegione)
            //    .HasMaxLength(100)
            //    .HasColumnName("codice_regione");
            //entity.Property(e => e.Comune)
            //    .HasMaxLength(50)
            //    .HasColumnName("comune");
            entity.Property(e => e.DataFineValidita)
                .HasMaxLength(50)
                .HasColumnName("data_fine_validita");
            entity.Property(e => e.DataInizioValidita)
                .HasMaxLength(50)
                .HasColumnName("data_inizio_validita");
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(100)
                .HasColumnName("indirizzo");
            entity.Property(e => e.Latitudine)
                .HasMaxLength(50)
                .HasColumnName("latitudine");
            entity.Property(e => e.Localizzazione)
                .HasMaxLength(50)
                .HasColumnName("localizzazione");
            entity.Property(e => e.Longitudine)
                .HasMaxLength(50)
                .HasColumnName("longitudine");
            entity.Property(e => e.PartitaIva)
                .HasMaxLength(100)
                .HasColumnName("partita_iva");
            //entity.Property(e => e.Provincia)
            //    .HasMaxLength(50)
            //    .HasColumnName("provincia");
            //entity.Property(e => e.Regione)
            //    .HasMaxLength(100)
            //    .HasColumnName("regione");
            //entity.Property(e => e.SiglaProvincia)
            //    .HasMaxLength(50)
            //    .HasColumnName("sigla_provincia");
            entity.Property(e => e.SitoLogistico)
                .HasMaxLength(100)
                .HasColumnName("sito_logistico");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provinci__3214EC0762EBB50F");

            entity.ToTable("Provincia", "Istat");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sigla)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdRegioneNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdRegione)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Provincia_Regione");
        });

        modelBuilder.Entity<Regione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Regione__3214EC07008E31C5");

            entity.ToTable("Regione", "Istat");

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
            entity.HasKey(e => e.Id).HasName("PK__Ripartiz__3214EC0764996DF2");

            entity.ToTable("RipartizioneGeografica", "Istat");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ZonaAltimetrica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZonaAlti__3214EC079247B4D8");

            entity.ToTable("ZonaAltimetrica", "Istat");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Denominazione)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ZonaMontana>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZonaMont__3214EC07C83A7BB3");

            entity.ToTable("ZonaMontana", "Istat");

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
